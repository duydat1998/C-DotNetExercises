using System;
using System.Collections.Generic;

namespace Lab_Winform
{
    class ProductData
    {
        private List<Product> ProductList = new List<Product>();

        public List<Product> GetProductList
        {
            get
            {
                return ProductList;
            }
        }

        public void AddNew(Product p)
        {
            Product pro = Find(p.ProductID);
            if (pro == null)
            {
                ProductList.Add(p);
            }
            else
            {
                throw new Exception("Product is already existed!");
            }
        }

        public void Remove(int ProductID)
        {
            Product p = Find(ProductID);
            if (p != null)
            {
                ProductList.Remove(p);
            }
            else
            {
                throw new Exception("Product is not already existed!");
            }
        }

        public Product Find(int ProductID)
        {
            foreach(Product p in ProductList)
            {
                if(p.ProductID == ProductID)
                {
                    return p;
                }
            }
            return null;
        }
    }
}
