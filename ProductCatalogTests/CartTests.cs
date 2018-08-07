using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductCatalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using ProductCatalog.Tests.Stubs;
using NSubstitute;

namespace ProductCatalog.Tests
{
    [TestClass()]
    public class CartTests
    {

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }



        [TestMethod()]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            "Data\\products-unit-test-data.csv",
            "products-unit-test-data#csv",
            DataAccessMethod.Sequential),
            DeploymentItem(@"Data\products-unit-test-data.csv", "Data")]
        public void AddProductWithActualLogTest()
        {
            // Arrange
            string filePath = "logs.txt";
            var cart = new Cart(new Logger(filePath));
            string name = TestContext.DataRow["Name"].ToString();
            decimal price = Convert.ToDecimal(TestContext.DataRow["Price"]);
            int stock = Convert.ToInt32(TestContext.DataRow["Stock"]);
            int lastIndex = cart.GetProducts().Count - 1;

            Product product = new Product(
                    name,
                    price,
                    stock
                );


            //Act
            var productAdded = cart.AddProduct(product, 1);
            var categoryProducts = cart.GetProducts();
            var expectedProduct = categoryProducts.ElementAt(lastIndex + 1);

            
            //Assert
            Assert.IsTrue(productAdded);
            Assert.AreEqual(expectedProduct.Name, product.Name);
            Assert.AreEqual(expectedProduct.Price, product.Price);
            Assert.AreEqual(expectedProduct.Stock, product.Stock);
        }

        [TestMethod()]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                    "Data\\products-unit-test-data.csv",
                    "products-unit-test-data#csv",
                    DataAccessMethod.Sequential),
                    DeploymentItem(@"Data\products-unit-test-data.csv", "Data")]
        public void AddProductWithStubLogTest()
        {
            // Arrange
            var cart = new Cart(new FakeLogger());
            string name = TestContext.DataRow["Name"].ToString();
            decimal price = Convert.ToDecimal(TestContext.DataRow["Price"]);
            int stock = Convert.ToInt32(TestContext.DataRow["Stock"]);
            int lastIndex = cart.GetProducts().Count - 1;

            Product product = new Product(
                    name,
                    price,
                    stock
                );


            //Act
            var productAdded = cart.AddProduct(product, 1);
            var categoryProducts = cart.GetProducts();
            var expectedProduct = categoryProducts.ElementAt(lastIndex + 1);


            //Assert
            Assert.IsTrue(productAdded);
            Assert.AreEqual(expectedProduct.Name, product.Name);
            Assert.AreEqual(expectedProduct.Price, product.Price);
            Assert.AreEqual(expectedProduct.Stock, product.Stock);
        }
        [TestMethod]
        public void TestN()
        {
            var cart = Substitute.For<Cart>(new FakeLogger());
            cart.AddProductVirtual(Arg.Any<Product>(), Arg.Any<int>()).Returns(true);

            Product product = new Product(
                "Test",
                10,
                11
            );

            Assert.IsTrue(cart.AddProduct(product, 3));
        }
    }
}