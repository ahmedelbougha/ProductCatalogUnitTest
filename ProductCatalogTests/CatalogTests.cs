using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCatalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProductCatalog.Tests
{
    [TestClass()]
    public class CatalogTests
    {
        private static Catalog catalog;

        [ClassInitialize]
        public static void CatalogInitialize(TestContext context)
        {
            Debug.WriteLine("Start of Catalog Tests");
            catalog = new Catalog("Default");
        }

        [TestMethod()]
        public void CatalogTest()
        {
            // Assert
            Assert.AreEqual(catalog.Name, "Default");
            Assert.IsInstanceOfType(catalog.GetCategories(), typeof(List<Category>));
        }

        [TestMethod()]
        public void AddCategoryTest()
        {
            // Arrange
            Category category = new Category("category1");
            catalog.AddCategory(category);

            // Act
            var categories = catalog.GetCategories();
            var expectedCategory = categories.ElementAt(0);

            // Assert
            Assert.AreEqual(expectedCategory, category);
        }

        [TestMethod()]
        public void AddCategoriesTest()
        {
            Assert.Inconclusive("Incompleted test");
        }

        [TestMethod()]
        public void RemoveCategoryTest()
        {
            Assert.Inconclusive("Incompleted test");
        }

        [TestMethod()]
        public void GetCategoriesTest()
        {
            Assert.Inconclusive("Incompleted test");
        }

        [ClassCleanup]
        public static void CatalogCleanup()
        {
            Debug.WriteLine("End of Catalog Tests");
        }
    }
}