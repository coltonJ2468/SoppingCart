using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart
{
    public partial class Cart : System.Web.UI.Page
    {
        private List<Book> books;
        private double total;
        private double totalWeight;
        private Table table;
        protected void Page_Load(object sender, EventArgs e)
        {
            OleDbConnection cn;
            OleDbCommand cmd;
            OleDbDataReader dr;

            books = new List<Book>();
            string connString = WebConfigurationManager.ConnectionStrings["Books"].ToString();
            try
            {
                cn = new OleDbConnection
                {
                    ConnectionString = connString
                };
                cmd = new OleDbCommand("SELECT * FROM books", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Book book = new Book(dr["title"].ToString(),
                                        dr["author"].ToString(),
                                        dr["price"].ToString(),
                                        dr["ship_weight"].ToString(),
                                        dr["image"].ToString(),
                                        dr["summary"].ToString());
                    books.Add(book);
                }
                dr.Close();
                cn.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            txtEmail.Attributes["type"] = "email";
            CreateTable();
        }

        private void CreateTable ()
        {
            total = 0;
            totalWeight = 0;
            submit.Visible = false;
            if (Session.Count > 0)
            {
                table = new Table();
                table.CssClass = "table-bordered";

                TableRow row = new TableRow();
                AddCell(row, "Title");
                AddCell(row, "Quantity");
                AddCell(row, "Price");
                AddCell(row, "Weight(oz)");
                table.Rows.Add(row);
                for (int ix = 0; ix < Session.Count; ix++)
                {
                    foreach (Book book in books)
                    {
                        if (Session.Keys.Get(ix) == book.Title)
                        {
                            int quantity = (int)Session[book.Title];
                            AddRow(book, quantity);
                            string[] price = book.Price.Split('$');
                            total += quantity * double.Parse(price[1]);
                            totalWeight += quantity * double.Parse(book.Weight);
                        }
                    }
                }
                row = new TableRow();

                AddCell(row, "");
                AddCell(row, "Totals:");
                AddCell(row, "$" + total.ToString());
                AddCell(row, totalWeight.ToString());
                table.Rows.Add(row);

                panel.Controls.Add(table);
                panel.Visible = true;
                submit.Visible = true;
            }
            else
            {
                lblStatus.Visible = true;
            }
        }

        private void AddRow (Book book, int quantity)
        {
            TableRow row = new TableRow();

            AddCell(row, book.Title);
            AddCell(row, quantity.ToString());
            string[] price = book.Price.Split('$');
            AddCell(row, "$" + quantity * double.Parse(price[1]));
            AddCell(row, "" + quantity * double.Parse(book.Weight));

            TableCell cell = new TableCell();
            Button btnDelete = new Button();
            btnDelete.Text = "Remove";
            btnDelete.CssClass = "btn btn-secondary";
            btnDelete.Click += RemoveBook;
            btnDelete.ID = book.Title;
            cell.Controls.Add(btnDelete);
            row.Cells.Add(cell);

            table.Rows.Add(row);
        }

        private void AddCell (TableRow row, String data) 
        {
            TableCell cell = new TableCell();
            cell.Text = data;
            row.Cells.Add(cell);
        }

        protected void RemoveBook (object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            foreach (Book book in books)
            {
                if (btnDelete.ID == book.Title)
                {
                    string[] price = book.Price.Split('$');
                    total -= double.Parse(price[1]);
                    total -= double.Parse(book.Weight);
                }
            }
            if ((int)Session[btnDelete.ID] > 1)
            {
                Session[btnDelete.ID] = (int)Session[btnDelete.ID] - 1;
            }
            else
            {
                Session.Remove(btnDelete.ID);
            }
            panel.Controls.Clear();
            CreateTable();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            lblPrice.Text = "$" + total;
            lblShip.Text = "$" + totalWeight * .48;
            lblTotal.Text = "$" + (total + (totalWeight * .48));
            formCheck.Visible = true;
        }

        protected void Order_Click(object sender, EventArgs e)
        {
            int OrderNum = GetOrderID();
            SendReciept(OrderNum);
            Server.Transfer("Result.aspx?order=" + OrderNum);
        }

        private void SendReciept (int OrderNum)
        {
            

            using (var email = new MailMessage("caj2468@gmail.com", txtEmail.Value)
            {
                IsBodyHtml = true,
                Subject = "Book Store Reciept Order #" + OrderNum,
                Body = "<h1>Order #" + OrderNum + "<h1><br/>" +
                "Price: " + lblPrice.Text + "<br/>" +
                "Shipping: " + lblShip.Text + "<br/>" +
                "Total: " + lblTotal.Text + "<br/><br/>" +
                "Name: " + txtName.Value + "<br/>" +
                "Street: " + txtStreet.Value + "<br/>" +
                "City: " + txtCity.Value + "<br/>" +
                "State: " + txtState.Value + "<br/>" +
                "Zip: " + txtZip.Value + "<br/><br/>" + 
                "Books Orderd:<br/>"
            })
            {
                for (int ix = 0; ix < Session.Count; ix++)
                {
                    foreach (Book book in books)
                    {
                        if (Session.Keys.Get(ix) == book.Title)
                        {
                            email.Body += "(" + Session[book.Title] + ") " + book.Title + " by " + book.Author + "<br/>";
                        }
                    }
                }
                using (var client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential("caj2468@gmail.com", "@ShadowWeaverSucks")
                })
                    client.Send(email);
            }
                
        }

        private int GetOrderID ()
        {
            OleDbConnection cn;
            OleDbCommand cmd;
            OleDbDataReader dr;

            int orderNumber = 0;
            string connString = WebConfigurationManager.ConnectionStrings["Orders"].ToString();
            try
            {
                cn = new OleDbConnection
                {
                    ConnectionString = connString
                };
                cmd = new OleDbCommand("SELECT * FROM OrderNumber", cn);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    orderNumber = int.Parse(dr["NextOrderNumber"].ToString());
                }
                dr.Close();
                orderNumber++;
                cmd = new OleDbCommand("UPDATE OrderNumber SET NextOrderNumber = " + orderNumber + "WHERE CompanyName = 'Book Store'", cn);
                cmd.ExecuteNonQuery();
                dr.Close();
                cn.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            return orderNumber;
        }
    }
}