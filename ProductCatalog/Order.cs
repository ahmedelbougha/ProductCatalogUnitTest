using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog
{
    public class Order
    {
        public DateTime OrderDate { get; }
        public int ReferenceNumber { get; }
        private List<Product> _products;

        public Order()
        {
            OrderDate = DateTime.Now;
            ReferenceNumber = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }

        public bool SetProducts(List<Product> products)
        {
            _products = products;
            return true;
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public decimal GetTotal()
        {
            decimal total = 0;
            foreach (var product in _products)
            {
                total += product.Price;
            }

            return total;
        }

        public decimal GetTotalAfterTax()
        {
            decimal total = GetTotal();
            decimal taxAmount = total * (decimal)Catalog.Tax;

            return total + taxAmount;
        }
    }
}
