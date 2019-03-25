using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingCart
{
    public partial class Details : System.Web.UI.Page
    {
        private List<Book> books;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.PreviousPage != null)
            {
                Default prevPage = (Default)PreviousPage;
                this.books = prevPage.GetBooks();
                foreach (Book book in books)
                {
                    if (Request.QueryString[0] == book.Title)
                    {
                        ImgBook.ImageUrl = book.Img;
                        Name.Text = book.Title;
                        Author.Text = book.Author;
                        Price.Text = book.Price;
                        Summary.Text = book.Summary;
                    }
                }
            }
        }

        public List<Book> GetBooks ()
        {
            return this.books;
        }

        protected void AddCart_Click (object sender, EventArgs e)
        {
            if (Session[Name.Text] == null)
            {
                Session[Name.Text] = 1;
            }
            else
            {
                Session[Name.Text] = (int)Session[Name.Text] + 1;
            }
        }
    }
}