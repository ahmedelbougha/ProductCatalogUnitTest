using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog
{
    public class Category
    {
        public string Name { set; get; }
        private List<Product> _products = new List<Product>();

        public Category(string categoryName)
        {
            Name = categoryName;
        }

        public void AddProduct(Product product)
        {
            product.Category = this;
            _products.Add(product);
        }

        public void AddProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                product.Category = this;
            }
            _products.AddRange(products);
        }

        public bool RemoveProduct(int index)
        {
            try
            {
                _products.RemoveAt(index);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<Product> GetProducts()
        {
            return _products;
        }
    }
}
