using System;
using System.Collections.Generic;
using System.Linq;

namespace SeeClearlyPOS_Library
{
    public class Terminal
    {
        public class ProductList
        {
            public string ProductCode { get; set; }
            public double Price { get; set; }
            public bool HasBulk { get; set; }
            public int BulkTrigger { get; set; }
            public double BulkDiscount { get; set; }

            public override string ToString()
            {
                return "ProductCode: " + ProductCode + "   Price: " + Price;
            }
        }

        public class Catalog
        {
            public List<ProductList> newProductCatalog = new List<ProductList>();

            public void AddDefaultProducts(List<ProductList> newCatalog)
            {
                newCatalog.Add(new ProductList { ProductCode = "A", Price = 1.25, HasBulk = true, BulkTrigger = 3, BulkDiscount = 0.75 });
                newCatalog.Add(new ProductList { ProductCode = "B", Price = 4.25, HasBulk = false });
                newCatalog.Add(new ProductList { ProductCode = "C", Price = 1.00, HasBulk = true, BulkTrigger = 6, BulkDiscount = 1 });
                newCatalog.Add(new ProductList { ProductCode = "D", Price = 0.75, HasBulk = false });
            }
            public void ShowCurrentProducts(List<ProductList> PriceCatalog)
            {
                foreach (ProductList product in PriceCatalog)
                {
                    Console.WriteLine(product);
                }
            }
        }

        public class Cart
        {
            public List<string> CurrentCart = new List<string>();

            public void ShowCartContents(List<string> cartContents)
            {
                Console.WriteLine("Current Cart:");
                foreach (string item in cartContents)
                {
                    Console.WriteLine(item);
                }
            }
            public void ClearCurrentCart()
            {
                CurrentCart.Clear();
            }

        }

        public bool IsRealProduct(List<string> shoppingCart, List<ProductList> priceCatalog, string terminalInput)
        {
            bool inCatalog = priceCatalog.Exists(x => x.ProductCode == terminalInput);
            if (inCatalog == true)
            {
                shoppingCart.Add(terminalInput);
                Console.WriteLine("Current Cart:");
                foreach (string item in shoppingCart)
                {
                    Console.WriteLine(item);
                }
                return true;
            }
            else
            {
                Console.WriteLine("Sorry it looks like your Product is not in the Catalog");
                return false;
            }
        }
        //Check if it is a product

        public double Calculatetotal(List<string> shoppingCart, List<ProductList> priceCatalog, double billRunningTotal)
        {
            //Check for bulk discounts
            var cartCount = shoppingCart.GroupBy(x => x)
            .Select(product => new { ProductCodeName = product.Key, ProductCodeCount = product.Count() })
            .ToList();
            foreach (var key in cartCount)
            {
                Console.WriteLine("Currently in the cart: {0} x {1}", key.ProductCodeCount, key.ProductCodeName);
                var productRef = priceCatalog.Find(x => x.ProductCode.Contains(key.ProductCodeName));
                if (productRef.HasBulk == true)
                {
                    billRunningTotal = billRunningTotal + (productRef.Price * key.ProductCodeCount);
                    double discountsApplied = key.ProductCodeCount / productRef.BulkTrigger;
                    Math.Floor(discountsApplied);
                    if (discountsApplied > 0)
                    {
                        double discountAmount = productRef.BulkDiscount * discountsApplied;
                        Console.WriteLine("Special Discount: -${0}", discountAmount);
                        billRunningTotal = billRunningTotal - discountAmount;
                    }
                }
                else
                {
                    billRunningTotal = billRunningTotal + (productRef.Price * key.ProductCodeCount);
                }
            }
            Console.WriteLine("Total To Pay: ${0}", billRunningTotal);
            return billRunningTotal;
        }
        public void TestCase(string[] caseArray, double targetValue, List<string> shoppingCart, List<ProductList> priceCatalog, double billRunningTotal)
        {
            shoppingCart.InsertRange(0, caseArray);
            double results = Calculatetotal(shoppingCart, priceCatalog, billRunningTotal);
            if (results == targetValue)
            {
                Console.WriteLine("Test Case Passed");
                shoppingCart.Clear();
            }
        }
    }
}

