using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeeClearlyPOS_Library;
using System;
using System.Collections.Generic;
using System.Linq;



namespace SeeClearlyPOS_UnitTesting
{
    [TestClass]
    public class SeeClearlyLibraryTest
    {

        [TestMethod]
        public void TestCart1()
        {
            Terminal newTerminalSession = new Terminal();
            Terminal.Cart shoppingCart = new Terminal.Cart();
            Terminal.Catalog priceCatalog = new Terminal.Catalog();
            double billRunningTotal = 0;
            priceCatalog.AddDefaultProducts(priceCatalog.newProductCatalog);
            string[] testCase1 = { "A", "B", "C", "D", "A", "B", "A" };
            shoppingCart.CurrentCart.InsertRange(0, testCase1);
            double results = newTerminalSession.Calculatetotal(shoppingCart.CurrentCart, priceCatalog.newProductCatalog, billRunningTotal);
            Console.WriteLine("Unit Test Expected for {0} ", results);
            Assert.AreEqual(results, 13.25);
        }
        [TestMethod]
        public void TestCart2()
        {
            Terminal newTerminalSession = new Terminal();
            Terminal.Cart shoppingCart = new Terminal.Cart();
            Terminal.Catalog priceCatalog = new Terminal.Catalog();
            double billRunningTotal = 0;
            priceCatalog.AddDefaultProducts(priceCatalog.newProductCatalog);
            string[] testCase2 = { "C", "C", "C", "C", "C", "C", "C" };
            shoppingCart.CurrentCart.InsertRange(0, testCase2);
            double results = newTerminalSession.Calculatetotal(shoppingCart.CurrentCart, priceCatalog.newProductCatalog, billRunningTotal);
            Console.WriteLine("Unit Test Expected for {0} ", results);
            Assert.AreEqual(results, 6.00);
        }
        [TestMethod]
        public void TestCart3()
        {
            Terminal newTerminalSession = new Terminal();
            Terminal.Cart shoppingCart = new Terminal.Cart();
            Terminal.Catalog priceCatalog = new Terminal.Catalog();
            double billRunningTotal = 0;
            priceCatalog.AddDefaultProducts(priceCatalog.newProductCatalog);
            string[] testCase3 = { "A", "B", "C", "D" };
            shoppingCart.CurrentCart.InsertRange(0, testCase3);
            double results = newTerminalSession.Calculatetotal(shoppingCart.CurrentCart, priceCatalog.newProductCatalog, billRunningTotal);
            Console.WriteLine("Unit Test Expected for {0} ", results);
            Assert.AreEqual(results, 7.25);
        }
    }
}
