using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCatalog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Tests
{
    [TestClass()]
    public class CategoryTests
    {
        private TestContext testContextInstance;
        private static Category _category;

      
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [ClassInitialize]
        public static void CategoryClassInitializer(TestContext context)
        {
            _category = new Category("Test Category");            
        }

        [TestMethod()]
        [TestProperty("Kind", "DataDriven")]
        [TestCategory("Fixtures")]
        [DeploymentItem(@"Data\products-unit-test-data.csv", "Data")]
        public void ReadLinesTest()
        {
            string fileName = @"Data\products-unit-test-data.csv";
            Debug.WriteLine(Path.GetFullPath(fileName));
            var lines = File.ReadAllLines(fileName);
            
            Assert.AreEqual(5, lines.Length);
        }

        [TestMethod()]
        [Owner("Ahmed Rashad")]
        [TestProperty("Kind", "DataDriven")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "Data\\products-unit-test-data.csv",
            "products-unit-test-data#csv",
            DataAccessMethod.Sequential),
            DeploymentItem(@"Data\products-unit-test-data.csv", "Data")]
        [Description("DataDriven Test")]
        public void AddProductTest()
        {
            // Arrange
            string name = TestContext.DataRow["Name"].ToString();
            decimal price = Convert.ToDecimal(TestContext.DataRow["Price"]);
            int stock = Convert.ToInt32(TestContext.DataRow["Stock"]);
            int lastIndex = _category.GetProducts().Count - 1;

            Product product = new Product(
                    name,
                    price,
                    stock
                );
            _category.AddProduct(product);

            //Act
            var categoryProducts = _category.GetProducts();
            var expectedProduct = categoryProducts.ElementAt(lastIndex + 1);

            //Assert
            Assert.AreEqual(expectedProduct.Name, product.Name);
            Assert.AreEqual(expectedProduct.Price, product.Price);
            Assert.AreEqual(expectedProduct.Stock, product.Stock);
        }

        [TestMethod()]
        public void ProductsAre4Test()
        {
            // Assert
            Assert.AreEqual(4, _category.GetProducts().Count);
        }

        [TestMethod()]
        public void SuccessfulRemoveProductTest()
        {
            bool status = _category.RemoveProduct(0);
            Assert.IsTrue(status);
        }

        [TestMethod()]
        public void FailRemoveProductTest()
        {
            bool status = _category.RemoveProduct(10);
            Assert.IsFalse(status);
        }

        //[TestMethod()]
        //public void GetProductsTest()
        //{
        //    Assert.Inconclusive("Incompleted test");
        //}

        //[TestMethod()]
        //public void CategoryTest1()
        //{
        //    Assert.Inconclusive("Incompleted test");
        //}

        //[TestMethod()]
        //public void AddProductTest1()
        //{
        //    Assert.Inconclusive("Incompleted test");
        //}

        //[TestMethod()]
        //public void AddProductsTest1()
        //{
        //    Assert.Inconclusive("Incompleted test");
        //}

        //[TestMethod()]
        //public void RemoveProductTest1()
        //{
        //    Assert.Inconclusive("Incompleted test");
        //}

        //[TestMethod()]
        //public void GetProductsTest1()
        //{
        //    Assert.Inconclusive("Incompleted test");
        //}
    }
}