using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBookLibrary;
using static Menu.Menu;
using System.Collections.Generic;

namespace ASM_2
{
    class Program
    {
        static void Print(string mess)
        {
            Console.WriteLine(mess);
        }
        static void Main(string[] args)
        {
            List<string> options = new List<string>();
            
            options.Add("Add new book");
            options.Add("Update a book");
            options.Add("Delete a book");
            options.Add("List all book");
            options.Add("Quit");

            BookManager manager = new BookManager();
            manager.PrintMessEvent += Print;
            int accChoice;
            while(true)
            {
                PrintOption(options);
                accChoice = GetChoice(1, options.Count);
                switch (accChoice)
                {
                    case 1:
                        manager.AddNew();
                        break;
                    case 2:
                        manager.Update();
                        break;
                    case 3:
                        manager.Delete();
                        break;
                    case 4:
                        manager.ListAllBook();
                        break;
                    case 5:
                        return;

                }
            } 

        }
    }
}
