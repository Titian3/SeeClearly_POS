using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeClearlyPOS_Library;
using System;



namespace SeeClearlyPOS_UnitTesting
{
    [TestClass]
    public class SeeClearlyLibraryTest
    {
        Terminal.Cart shoppingCart = new Terminal.Cart();
        Terminal.Catalog priceCatalog = new Terminal.Catalog();
        double billRunningTotal = 0;

        public void UnitTestHelper(string[] testCase, double expectedResult)
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
            UnitTestHelper(testCase1, 13.25);
        }
        [TestMethod]
        public void TestCart2()
        {
            string[] testCase2 = { "C", "C", "C", "C", "C", "C", "C" };
            UnitTestHelper(testCase2, 6.00);
        }
        [TestMethod]
        public void TestCart3()
        {
            string[] testCase3 = { "A", "B", "C", "D" };
            UnitTestHelper(testCase3, 7.25);
        }
    }
}
