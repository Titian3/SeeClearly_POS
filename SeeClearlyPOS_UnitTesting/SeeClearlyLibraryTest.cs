using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeClearlyPOS_Library;
using System;
using System.Collections.Generic;



namespace SeeClearlyPOS_UnitTesting
{
    [TestClass]
    public class SeeClearlyLibraryTest
    {
        Terminal.Cart shoppingCart = new Terminal.Cart();
        Terminal.Catalog priceCatalog = new Terminal.Catalog();
        public List<Terminal.ProductList> SpecProductCatalog = new List<Terminal.ProductList>
        {
            new Terminal.ProductList { ProductCode = "A", Price = 1.25, HasBulk = true, BulkTrigger = 3, BulkDiscount = 0.75 },
            new Terminal.ProductList { ProductCode = "B", Price = 4.25, HasBulk = false },
            new Terminal.ProductList { ProductCode = "C", Price = 1.00, HasBulk = true, BulkTrigger = 6, BulkDiscount = 1 },
            new Terminal.ProductList { ProductCode = "D", Price = 0.75, HasBulk = false }
        };
        double billRunningTotal = 0;

        public void UnitTestHelper_TotalCost(string[] testCase, double expectedResult)
        {
            shoppingCart.CurrentCart.InsertRange(0, testCase);
            double results = shoppingCart.CalculateCartTotal(shoppingCart.CurrentCart, priceCatalog.ProductCatalog, billRunningTotal);
            Console.WriteLine("Unit Test Expected for {0} ", results);
            Assert.AreEqual(results, expectedResult);
        }
        [TestMethod]
        public void TestCart1()
        {
            string[] testCase1 = { "A", "B", "C", "D", "A", "B", "A" };
            UnitTestHelper_TotalCost(testCase1, 13.25);
        }
        [TestMethod]
        public void TestCart2()
        {
            string[] testCase2 = { "C", "C", "C", "C", "C", "C", "C" };
            UnitTestHelper_TotalCost(testCase2, 6.00);
        }
        [TestMethod]
        public void TestCart3()
        {
            string[] testCase3 = { "A", "B", "C", "D" };
            UnitTestHelper_TotalCost(testCase3, 7.25);
        }
        [TestMethod]
        public void TestProductInCatalog()
        {
            string testScan1 = "A";
            bool result = shoppingCart.AddProductToCart(shoppingCart.CurrentCart, priceCatalog.ProductCatalog, testScan1);
            Assert.IsTrue(result, "Product {0} Is in the Catalog", testScan1);
        }
        [TestMethod]
        public void TestProductNotInCatalog()
        {
            string testScan2 = "$";
            bool result = shoppingCart.AddProductToCart(shoppingCart.CurrentCart, priceCatalog.ProductCatalog, testScan2);
            Assert.IsFalse(result, "Product '{0}' is Not in the Catalog", testScan2);
        }
        [TestMethod]
        public void TestCatalog()
        {
            for (int i = 0; i < SpecProductCatalog.Count; i++)
            {
                Assert.AreSame(SpecProductCatalog[i].ProductCode, priceCatalog.ProductCatalog[i].ProductCode, "Error on Row: {2}\nCatalog Did not have {0} in correct Place, it has {1} product code at Row {2}", SpecProductCatalog[i].ProductCode, priceCatalog.ProductCatalog[i].ProductCode, (i+1));
            }
        }
    }
}
