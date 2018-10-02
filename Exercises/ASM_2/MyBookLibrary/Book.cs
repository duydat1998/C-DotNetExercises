using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookLibrary
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public float Price { get; set; }

        public Book()
        {

        }

        public Book(int iD, string name, string publisher, float price)
        {
            ID = iD;
            Name = name;
            Publisher = publisher;
            Price = price;
        }

        public void PrintInfor()
        {
            Console.WriteLine("Book Id: "+ID);
            Console.WriteLine("Book name: "+Name);
            Console.WriteLine("Publisher: "+Publisher);
            Console.WriteLine("Price: "+Price);
            Console.WriteLine("--- --- --- ---");
        }
    }
}
