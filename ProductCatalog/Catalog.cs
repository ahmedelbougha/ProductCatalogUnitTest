using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog
{
    public class Catalog
    {
        public string Name { set; get; }
        private List<Category> _categories;
        public const double Tax = 0.05;

        public Catalog(string storeName)
        {
            Name = storeName;
            _categories = new List<Category>();
        }

        public void AddCategory(Category category)
        {
            _categories.Add(category);
        }

        public void AddCategories(List<Category> categories)
        {
            _categories.AddRange(categories);
        }

        public bool RemoveCategory(Category category)
        {
            try
            {
                _categories.Remove(category);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public List<Category>GetCategories()
        {
            return _categories;
        }
    }
}
