using System;
using System.Collections.Generic;
using System.Linq;

namespace SeeClearlyPOS_Library
{
    public class Terminal
    {
        //Pricing Data Model - Uses 2 addition properties to identify when bulk should be applied and how much of a discount should be applied to the cart.
        public class ProductList
        {
            public string ProductCode { get; set; }
            public double Price { get; set; }
            public bool HasBulk { get; set; }
            public int BulkTrigger { get; set; }
            public double BulkDiscount { get; set; }

            //Used in Console Display
            public override string ToString()
            {
                return "ProductCode: " + ProductCode + "   Price: " + Price;
            }
        }

        //Create the Product Catalog based on Pricing data model above.
        public class Catalog
        {
            public List<ProductList> newProductCatalog = new List<ProductList>
            {
                new ProductList { ProductCode = "A", Price = 1.25, HasBulk = true, BulkTrigger = 3, BulkDiscount = 0.75 },
                new ProductList { ProductCode = "B", Price = 4.25, HasBulk = false },
                new ProductList { ProductCode = "C", Price = 1.00, HasBulk = true, BulkTrigger = 6, BulkDiscount = 1 },
                new ProductList { ProductCode = "D", Price = 0.75, HasBulk = false }
            };

            //Price Catalog as per brief.
            public void AddNewProduct(List<ProductList> newCatalog, string newProductCode, double newPrice, bool newHasBulk, int newBulkTrigger, double newBulkDiscount)
            {
                newCatalog.Add(new ProductList { ProductCode = newProductCode, Price = newPrice, HasBulk = newHasBulk, BulkTrigger = newBulkTrigger, BulkDiscount = newBulkDiscount });
            }
            //Used in Console Display shows current Catalog
            public void ShowCurrentProducts(List<ProductList> PriceCatalog)
            {
                foreach (ProductList product in PriceCatalog)
                {
                    Console.WriteLine(product);
                }
            }
        }

        //Sets up Shopping cart, Displays and clears cart If multiple transactions are done on Console.
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

        //On the Console A check is done to ensure non-Product code values are not put on the cart
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
        
        //
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

