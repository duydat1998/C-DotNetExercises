using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_11
{
    public delegate void WarningDelegate(string message);
    class ManageProduct
    {
        //an event to show message when remove a product
        public event WarningDelegate EventRemoveProduct;

        public List<Product> ListOfProduct { get; }

        public ManageProduct()
        {
            ListOfProduct = new List<Product>();
        }
        public void AddNew(Product p)
        {
            ListOfProduct.Add(p);

        }

        public void Remove(int productID)
        {
            Product p = Find(productID);
            if (p != null)
            {
                ListOfProduct.Remove(p);
                EventRemoveProduct("Product with ID: " + productID + " is removed.");
            }
        }

        public Product Find(int productID)
        {
            if(ListOfProduct.Count == 0)
            {
                return null;
            }
            Product output = null;
            foreach(Product p in ListOfProduct)
            {
                if(p.ProductID == productID)
                {
                    output = p;
                }
            }
            return output;
        }
    }
}
