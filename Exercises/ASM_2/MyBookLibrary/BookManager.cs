using System;
using System.Collections.Generic;
using System.Collections;

namespace MyBookLibrary
{
    public delegate void PrintOutDelegate(string mess);
    public class BookManager
    {

        public event PrintOutDelegate PrintMessEvent;
        private List<Book> listBook = null;

        public List<Book> ListBook
        {
            get { return listBook; }
            set { listBook = value; }
        }

        private int InputInteger(string message)
        {
            int output = 0;
            bool check = false;
            do
            {
                try
                {
                    Console.WriteLine(message + " :");
                    output = Convert.ToInt32(Console.ReadLine());
                    check = true;
                    return output;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong format input");
                }
            } while (check == false);
            return output;
        }

        private float InputFloat(string message)
        {
            float output = 0;
            bool check = false;
            do
            {
                try
                {
                    Console.WriteLine(message + " :");
                    output = Convert.ToSingle(Console.ReadLine());
                    check = true;
                    return output;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong format input");
                }
            } while (check == false);
            return output;
        }

        private int FindById(int id)
        {
            int output = -1;
            if (ListBook == null || ListBook.Count == 0)
            {
                return -1;
            }
            int i = 0;
            foreach (Book b in ListBook)
            {
                if (b.ID == id)
                {
                    output = i;
                    break;
                }
                i++;
            }
            return output;
        }

        private string InputString(string message)
        {
            string output;
            Console.WriteLine(message + " :");
            output = Console.ReadLine();
            return output;
        }

        public void AddNew()
        {
            Console.WriteLine("*** Add a new book ***");
            int id, index;
            do
            {
                id = InputInteger("Enter Book ID");
                index = FindById(id);
                if (index > -1)
                {
                    Console.WriteLine("ID " + id + " has existed, please input another one.");
                }
            } while (index > -1);
            string name = InputString("Enter Book Name");
            string publisher = InputString("Enter Publisher");
            float price = InputFloat("Enter Price");
            Book book = new Book(id, name, publisher, price);
            if (ListBook == null)
            {
                ListBook = new List<Book>();
            }
            ListBook.Add(book);
            PrintMessEvent("Add a book successfully!");
        }

        public void Update()
        {
            Console.WriteLine("*** Update book ***");
            if (ListBook == null || ListBook.Count == 0)
            {
                Console.WriteLine("There is no book.");
                PrintMessEvent("Can not update book!");
                return;
            }
            int id = InputInteger("Enter Book ID");
            int index = FindById(id);
            if (index == -1)
            {
                Console.WriteLine("ID " + id + " doesn't existed!");
                PrintMessEvent("Can not update book!");
                return;
            }
            string name = InputString("Enter Book Name");
            ListBook[index].Name = name;
            string publisher = InputString("Enter Publisher");
            ListBook[index].Publisher = publisher;
            float price = InputFloat("Enter Price");
            ListBook[index].Price = price;
            PrintMessEvent("Update a book successfully!");
        }

        public void Delete()
        {
            Console.WriteLine("*** Delete book ***");
            if (ListBook == null || ListBook.Count == 0)
            {
                Console.WriteLine("There is no book.");
                PrintMessEvent("Can not delete book!");
                return;
            }
            int id = InputInteger("Enter Book ID");
            int index = FindById(id);
            if (index == -1)
            {
                Console.WriteLine("ID " + id + " doesn't existed!");
                PrintMessEvent("Can not delete book!");
                return;
            }
            Console.WriteLine("Do you really wants to delete this book? Please enter (yes/no):");
            string answer = ((Console.ReadLine()).Trim()).ToUpper();
            if (answer.Equals("YES"))
            {
                Book book = ListBook[index];
                ListBook.Remove(book);
                if (ListBook.Count == 0)
                {
                    ListBook = null;
                }
                PrintMessEvent("Delete a book successfully!");
            }
            else
            {
                PrintMessEvent("Delete a book UNsuccessfully!");
            }
        }

        public void ListAllBook()
        {
            Console.WriteLine("*** All books ***");
            if (ListBook == null || ListBook.Count == 0)
            {
                Console.WriteLine("There is no book.");
                return;
            }
            foreach (Book b in ListBook)
            {
                b.PrintInfor();
            }
        }

    }
}
