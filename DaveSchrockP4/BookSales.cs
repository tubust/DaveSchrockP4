using System;
using System.Collections.Generic;
using System.Text;

namespace DaveSchrockP4
{
    class BookSales
    {
        private string isbn;
        private int customerId;
        private static int salesCounter;

        public BookSales() {}

        public BookSales(string i, int c)
        {
            salesCounter++;
            isbn = i;
            customerId = c;
        }

        public string Isbn
        {
            set { isbn = value; }
            get { return isbn; }
        }

        public int CustomerId
        {
            set { customerId = value; }
            get { return customerId; }
        }

        public int SalesCounter
        {
            get { return salesCounter; }
        }
    }
}
