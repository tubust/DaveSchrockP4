using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace DaveSchrockP4
{
    class Program
    {
        public static readonly DateTime today = DateTime.Now;

        static void Main(string[] args)
        {
            BookInventory totalInventory = new BookInventory();
            ArrayList BookSalesList = new ArrayList(1);
            int bookEntry = 0;
            int userEntry = 0;
            int custId = 0;
            bool getGoing3 = false;
            totalInventory[0] = new Books("0072263121", "A+ Certification", "Mike Meyers", "McGraw-Hill", 50.00, .15);
            totalInventory[1] = new Books("0684857154", "Spin Cycle", "Howard Kurtz", "Simon & Schuster", 10.00, .40);
            totalInventory[2] = new Books("0345463048", "Star Wars The Joiner King", "Troy Denning", "Ballantine Books", 5.00, .25);
            totalInventory[3] = new Books("0130449296", "Objects First With Java", "David J. Barnes", "Prentice Hall", 45.00, .17);
            totalInventory[4] = new Books("8675309001", "Spending Time With Jenny", "Dave Schrock", "Made-up Books", 35.00, .33);
            totalInventory[5] = new Books("4052326439", "Frank's Revenge", "Frank Lee", "Made-up Books", 24.00, .20);
            totalInventory[6] = new Books("2104916544", "Life On The Inside", "Daniel Schrock", "Made-up Books", 20.00, .66);
            totalInventory[7] = new Books("5468834655", "Real Drama", "Jansen Rose", "Made-up Books", 3.50, 1.50);
            Console.WriteLine("Dave Schrock's Bookstore");
            Console.WriteLine("Today is {0:D}", today);
            while (userEntry != 5)
            {
                Console.WriteLine("1 - See all book titles in inventory and their individual retail prices");
                Console.WriteLine("2 - Purchase a book");
                Console.WriteLine("3 - See a list of all books sold");
                Console.WriteLine("4 - See Sales summary");
                Console.WriteLine("5 - Exit");
                Console.WriteLine();
                Console.Write("Please enter your selection: ");
                bool getGoing = false;
                while (getGoing == false)
                {
                    try
                    {
                        userEntry = Int32.Parse(Console.ReadLine());
                        while (userEntry < 1 || userEntry > 5)
                        {
                            Console.Write("Error! Please enter 1 - 5: ");
                            userEntry = Int32.Parse(Console.ReadLine());
                        }
                        getGoing = true;
                    }
                    catch (FormatException)
                    {
                        Console.Write("Error! Please enter 1 - 5: ");
                    }
                }
                switch (userEntry)
                {
                    case 1:
                        {
                            displayAll(totalInventory);
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Please enter your customer number: ");
                            while (getGoing3 == false)
                            {
                                try
                                {
                                    custId = Int32.Parse(Console.ReadLine());
                                    getGoing3 = true;
                                }
                                catch (FormatException)
                                {
                                    Console.Write("Please enter the correct customer number: ");
                                }
                            }
                            getGoing3 = false;
                            bookEntry = purchaseBook(totalInventory);
                            BookSalesList.Add(new BookSales(totalInventory[bookEntry].Isbn,custId));
                            break;
                        }
                    case 3:
                        {
                            listSales(totalInventory,BookSalesList);
                            break;
                        }
                    case 4:
                        {
                            salesSummary(totalInventory, BookSalesList);
                            break;
                        }
                    case 5: break;
                }
            }
            Console.WriteLine("Thank you for shopping at Dave's Bookstore. Please come again soon.");
            Console.ReadLine();
        }

        public static int purchaseBook(BookInventory b)
        {
            bool getGoing = false;
            bool getGoing2 = false;
            int userChoice = 0;
            while (getGoing == false)
            {
                for (int v = 0; v < Books.Counter; v++)
                {
                    Console.WriteLine("{0} - {1,-35} {2,5:C}", (v + 1), b[v].Title, b[v].CalculateRetail);
                }
                Console.Write("Please enter the book you wish to purchase: ");
                try
                {
                    userChoice = Int32.Parse(Console.ReadLine());
                    while (getGoing2 == false)
                    {
                        if (userChoice < 1 || userChoice > Books.Counter + 1)
                        {
                            Console.Write("Error! Please enter a number between 1 - {0}", (Books.Counter + 1));
                            userChoice = Int32.Parse(Console.ReadLine());
                        }
                        else
                        {
                            getGoing2 = true;
                        }
                    }
                    getGoing = true;
                }
                catch (FormatException)
                {
                    Console.Write("Error! Please enter a number between 1 - {0}", (Books.Counter + 1));
                    getGoing2 = false;
                }
            }
            return (userChoice - 1);
        }
        public static void displayAll(BookInventory b)
        {
            Console.WriteLine();
            Console.WriteLine("TITLE                         COST");
            Console.WriteLine("------------------------------------------");
            for (int x = 0; x < Books.Counter; x++)
            {
                Console.WriteLine("{0,-35} {1,5:C}", b[x].Title, b[x].CalculateRetail);
            }
            Console.WriteLine();
        }
        public static void listSales(BookInventory b,ArrayList a)
        {
            Console.WriteLine();
            BookSales[] temp = new BookSales[a.Count];
            for (int num = 0; num < a.Count; num++)
            {
                temp[num] = (BookSales)a[num];
            }
            Console.WriteLine("TITLE                         COST");
            Console.WriteLine("------------------------------------------");
            for (int x = 0; x < temp.Length; x++)
            {
                for (int y = 0; y < Books.Counter; y++)
                {
                    if (temp[x].Isbn == b[y].Isbn)
                    {
                        Console.WriteLine("{0,-35} {1,5:C}",b[y].Title, b[y].CalculateRetail);
                    }
                }
            }
            Console.WriteLine();
        }
        public static void salesSummary(BookInventory b, ArrayList a)
        {
            double retailTotal = 0, wholesaleTotal = 0, profitTotal = 0;
            BookSales[] temp = new BookSales[a.Count];
            Console.WriteLine();
            Console.WriteLine("RETAIL                 WHOLESALE                 PROFIT");
            Console.WriteLine("---------------------------------------------------------------------");
            for (int num = 0; num < a.Count; num++)
            {
                temp[num] = (BookSales)a[num];
            }
            for (int x = 0; x < temp.Length; x++)
            {
                for (int y = 0; y < Books.Counter; y++)
                {
                    if (temp[x].Isbn == b[y].Isbn)
                    {
                        Console.WriteLine("{0,20:C} {1,20:C} {2,20:C}", b[y].CalculateRetail, b[y].WholesaleCost, (b[y].CalculateRetail - b[y].WholesaleCost));
                        profitTotal = profitTotal + (b[y].CalculateRetail - b[y].WholesaleCost);
                        wholesaleTotal = wholesaleTotal + b[y].WholesaleCost;
                        retailTotal = retailTotal + b[y].CalculateRetail;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("TOTAL");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("{0,20:C} {1,20:C} {2,20:C}", retailTotal, wholesaleTotal, profitTotal);
            Console.WriteLine();
         }
    }
}