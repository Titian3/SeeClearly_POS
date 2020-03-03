using System;
using SeeClearlyPOS_Library;

namespace SeeClearlyPOS_Console
{
    class TerminalConsole
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To SeeClearlyPOS");

            Terminal.Cart shoppingCart = new Terminal.Cart();
            Terminal.Catalog priceCatalog = new Terminal.Catalog();
            Terminal.ConsoleHelpers consoleHelpers = new Terminal.ConsoleHelpers();

            Console.WriteLine("Current Products:");
            priceCatalog.ShowCurrentProducts(priceCatalog.ProductCatalog);

            //Make sure to start total at 0 prepare interface.
            bool stillShopping = true;
            double billRunningTotal = 0;
            string commands = @"
            Arguments:
                -TC1 -- Runs test case 1.
                -TC2 -- Runs test case 2.
                -TC3 -- Runs test case 3.
                -CART -- Displays current cart items.
                -CT -- Completes transaction, totals values.
                -CS -- Complete the Shopping experience.
                -ADD -- Addes a new item to the catalog.
                -ITEMS -- Shows products in catalog.";
            Console.WriteLine(commands);

            do
            {
                Console.WriteLine("[TERMINAL:] Please enter product or argument:");
                string terminalInput = Console.ReadLine().ToUpper();

                //Menu - Takes arguments as above
                if (terminalInput == "TC1")
                {
                    string[] testCase1 = { "A", "B", "C", "D", "A", "B", "A" };
                    consoleHelpers.TestCase(testCase1, 13.25, shoppingCart.CurrentCart, priceCatalog.ProductCatalog, billRunningTotal);
                }
                else if (terminalInput == "TC2")
                {
                    string[] testCase2 = { "C", "C", "C", "C", "C", "C", "C" };
                    consoleHelpers.TestCase(testCase2, 6.00, shoppingCart.CurrentCart, priceCatalog.ProductCatalog, billRunningTotal);
                }
                else if (terminalInput == "TC3")
                {
                    string[] testCase3 = { "A", "B", "C", "D" };
                    consoleHelpers.TestCase(testCase3, 7.25, shoppingCart.CurrentCart, priceCatalog.ProductCatalog, billRunningTotal);
                }
                //Complete Transaction, calculate totals
                else if (terminalInput == "CT")
                {
                    shoppingCart.CalculateCartTotal(shoppingCart.CurrentCart, priceCatalog.ProductCatalog, billRunningTotal);
                    shoppingCart.ClearCurrentCart();
                }
                else if (terminalInput == "CART")
                {
                    shoppingCart.ShowCartContents(shoppingCart.CurrentCart);
                }
                //Adds a new product to the catalog
                else if (terminalInput == "ADD")
                {
                    Console.WriteLine("Adding a new Product:");
                    try
                    {
                        Console.WriteLine("Please Enter a single Letter");
                        string newProductCode = Console.ReadLine().ToUpper();
                        Console.WriteLine("Please Enter a Price:");
                        double newPrice = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Does it get a Bulk Discount? Y|N");
                        string newHasBulk = Console.ReadLine().ToUpper();
                        if (newHasBulk == "Y")
                        {
                            Console.WriteLine("How many to buy in bulk?");
                            int newBulkTrigger = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please Enter a discount Price:");
                            double newBulkDiscount = Convert.ToDouble(Console.ReadLine());
                            priceCatalog.AddNewProduct(priceCatalog.ProductCatalog, newProductCode, newPrice, false, newBulkTrigger, newBulkDiscount);
                            Console.WriteLine("Thanks I've added the new product with discount called: {0}", newProductCode);
                        }
                        else
                        {
                            int newBulkTrigger = 0;
                            double newBulkDiscount = 0;
                            priceCatalog.AddNewProduct(priceCatalog.ProductCatalog, newProductCode, newPrice, false, newBulkTrigger, newBulkDiscount);
                            Console.WriteLine("Thanks I've added the new product called: {0}", newProductCode);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Computer says no.... {0}", e);
                    }
                    
                    
                }
                //Shows the Items avalible to be scanned, for if a new item is added.
                else if (terminalInput == "ITEMS")
                {
                    priceCatalog.ShowCurrentProducts(priceCatalog.ProductCatalog);
                }
                else if (terminalInput == "CS")
                {
                    stillShopping = false;
                }
                else
                {
                    //Check if it is a product in the product list
                    shoppingCart.AddProductToCart(shoppingCart.CurrentCart, priceCatalog.ProductCatalog, terminalInput);
                }
            }
            while (stillShopping);
        }
    }
}
