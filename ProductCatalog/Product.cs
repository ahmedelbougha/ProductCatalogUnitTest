using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCatalog.Interfaces;

namespace ProductCatalog
{
    public class Product
    {
        public string Name { set; get; }
        public decimal Price { set; get; }
        public string Description { set; get; }
        public Category Category { set; get; }
        public int Stock { set; get; }

        public Product(string productName, decimal productPrice = 0, int productStock = 0)
        {
            Name = productName;
            Price = productPrice;
            Stock = productStock;
        }

        public bool TakeOutOfStock(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count cannot be 0 or less");
            }

            if (count > Stock)
            {
                return false;
            }

            Stock -= count;
            return true;
        }

        public bool AddToStock(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count cannot be 0 or less");
            }

            Stock += count;
            return true;
        }
    }
}
