using System;
using System.Collections.Generic;
using System.Text;

namespace DaveSchrockP4
{
    class Books
    {
        private string isbn, title, author, publisher;
        private double wholesaleCost, markup;
        private static int counter;

        public Books() {counter++; }

        public Books(string i, string t, string a, string p, double w, double m)
        {
            counter++;
            isbn = i;
            title = t;
            author = a;
            publisher = p;
            wholesaleCost = w;
            markup = m;
        }

        public string Isbn
        {
            set
            {
                isbn = value;
            }
            get
            {
                return isbn;
            }
        }

        public string Title
        {
            set { title = value; }
            get { return title; }
        }

        public string Author
        {
            set { author = value; }
            get { return author; }
        }

        public string Publisher
        {
            set { publisher = value; }
            get { return publisher; }
        }

        public double WholesaleCost
        {
            set { wholesaleCost = value; }
            get { return wholesaleCost; }
        }

        public double Markup
        {
            set { markup = value; }
            get { return markup; }
        }

        public static int Counter
        {
            get { return counter; }
        }

        public double CalculateRetail
        {
           get{return (wholesaleCost + (wholesaleCost * markup));}
        }
    }
}
