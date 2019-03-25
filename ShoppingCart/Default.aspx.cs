using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ShoppingCart
{
    public partial class Default : System.Web.UI.Page
    {
        private List<Book> books;
        protected void Page_Load(object sender, EventArgs e)
        {
            OleDbConnection cn;
            OleDbCommand cmd;
            OleDbDataReader dr;
            
            books = new List<Book> ();
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
        }

        protected void GetDetails(object sender, EventArgs e)
        {
            HtmlAnchor control = (HtmlAnchor)sender;
            string title = control.Title.Replace(" ", "%20");
            Server.Transfer("Details.aspx?title=" + title, true);
        }

        public List<Book> GetBooks ()
        {
            return this.books;
        }
    }
}