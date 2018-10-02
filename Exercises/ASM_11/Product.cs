using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_11
{
    class Product
    {
        private int productID;
        private string productName;
        private int quantity;
        private float unitPrice;
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public float UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        public float SubTotal
        {
            get { return unitPrice * quantity; }
        }
        public Product()
        {


        }

        public Product(int productID, string productName, int quantity, float unitPrice)
        {
            this.productID = productID;
            this.productName = productName;
            this.quantity = quantity;
            this.unitPrice = unitPrice;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Product ID: "+ProductID);
            Console.WriteLine("Product Name: "+ProductName);
            Console.WriteLine("Unit Price: "+UnitPrice);
            Console.WriteLine("Quantity: "+Quantity);
            Console.WriteLine("Subtotal: "+SubTotal);
            Console.WriteLine("--- --- --- --- ---");

        }
    }
}
