using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCatalog.Interfaces;

namespace ProductCatalog
{
    public class Cart
    {
        private List<Product> _products = new List<Product>();
        private ILogger _logger;

        public Cart(ILogger logger)
        {
            _logger = logger;
        }
        public bool AddProduct(Product product, int count)
        {
            try
            {
                product.TakeOutOfStock(count);
               _products.Add(product);
                _logger.Log(DateTime.Now.ToString() + " - product added to cart - " + product.Name);
                _logger.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        virtual public bool AddProductVirtual(Product product, int count)
        {
            try
            {
                product.TakeOutOfStock(count);
                _products.Add(product);
                _logger.Log(DateTime.Now.ToString() + " - product added to cart - " + product.Name);
                _logger.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoveProduct(Product product, int count)
        {
            try
            {
                product.AddToStock(count);
                _products.Remove(product);
                _logger.Log(DateTime.Now.ToString() + " - product removed from cart - " + product.Name);
                _logger.Close();
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
