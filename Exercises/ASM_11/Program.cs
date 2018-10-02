using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_11
{
    class Program
    {
        static void PrintProduct(List<Product> l)
        {
            foreach(Product p in l)
            {
                p.PrintInfo();
            }
        }

        //method to show message after removing a product
        static void DissplayMessageAfterRemovingAProduct(string message)
        {
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            Product coffee = new Product { ProductID = 1, ProductName = "Coffee", Quantity = 12, UnitPrice = 3 };
            Product milk = new Product(2, "Milk", 4, 23);
            ManageProduct mp = new ManageProduct();

            //dang ki su kien khi xoa mat hang trong danh sach 
            //-> goi ham DissplayMessageAfterRemovingAProduct
            mp.EventRemoveProduct += new WarningDelegate(DissplayMessageAfterRemovingAProduct);
            mp.AddNew(coffee);
            mp.AddNew(milk);
            Console.WriteLine("********** Danh sach cac mat hang: **********");
            PrintProduct(mp.ListOfProduct);
            Console.WriteLine("Tim mat hang the ProductId");
            int productID = int.Parse(Console.ReadLine());
            Product p = mp.Find(productID);
            if (p != null)
            {
                mp.Remove(p.ProductID);
                Console.WriteLine("Press Enter to review product list.");
                Console.ReadLine();
                PrintProduct(mp.ListOfProduct);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }
}
