using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart
{
    [Serializable]
    public class Book
    {
        private string title;
        private string author;
        private string price;
        private string img;
        private string summary;
        private string weight;

        public Book (string title, string author, string price, string weight, string img, string summary)
        {
            this.title = title;
            this.author = author;
            this.price = price;
            this.img = img;
            this.summary = summary;
            this.weight = weight;
        }

        public string Title
        {
            get
            {
                return this.title;
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }
        }

        public string Price
        {
            get
            {
                return this.price;
            }
        }

        public string Weight
        {
            get
            {
                return this.weight;
            }
        }

        public string Img
        {
            get
            {
                return this.img;
            }
        }

        public string Summary
        {
            get
            {
                return this.summary;
            }
        }

        public override string ToString()
        {
            return Title;
        }
    }
}