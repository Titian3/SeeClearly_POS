using System;
using SeeClearlyPOS_Library;

namespace SeeClearlyPOS_Console
{
    class TerminalConsole
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome To seeClearlyPOS");
            Terminal newTerminalSession = new Terminal();
            Terminal.Cart shoppingCart = new Terminal.Cart();
            Terminal.Catalog priceCatalog = new Terminal.Catalog();

            //Set up Products as per spec.
            priceCatalog.AddDefaultProducts(priceCatalog.newProductCatalog);

            //Check Product list looks good on console.
            Console.WriteLine("Current Products:");
            priceCatalog.ShowCurrentProducts(priceCatalog.newProductCatalog);

            //Make sure to start total at 0 prepare interface.
            bool stillShopping = true;
            double billRunningTotal = 0;

            //Readline to query prices.
            /*
            Arguments:
                -TC1 -- Runs test case 1.
                -TC2 -- Runs test case 2.
                -TC3 -- Runs test case 3.
                -CART -- Displays current cart items.
                -CT -- Completes transaction, totals values.
             */
            do
            {
                Console.WriteLine("Please enter product code:");
                string terminalInput = Console.ReadLine().ToUpper();

                //Menu - Direct Terminal Control.
                if (terminalInput == "TC1")
                {
                    string[] testCase1 = { "A", "B", "C", "D", "A", "B", "A" };
                    newTerminalSession.TestCase(testCase1, 13.25, shoppingCart.CurrentCart, priceCatalog.newProductCatalog, billRunningTotal);
                }
                else if (terminalInput == "TC2")
                {
                    string[] testCase2 = { "C", "C", "C", "C", "C", "C", "C" };
                    newTerminalSession.TestCase(testCase2, 6.00, shoppingCart.CurrentCart, priceCatalog.newProductCatalog, billRunningTotal);
                }
                else if (terminalInput == "TC3")
                {
                    string[] testCase3 = { "A", "B", "C", "D" };
                    newTerminalSession.TestCase(testCase3, 7.25, shoppingCart.CurrentCart, priceCatalog.newProductCatalog, billRunningTotal);
                }
                else if (terminalInput == "CT")
                {
                    newTerminalSession.Calculatetotal(shoppingCart.CurrentCart, priceCatalog.newProductCatalog, billRunningTotal);
                    shoppingCart.ClearCurrentCart();
                }
                else if (terminalInput == "CART")
                {
                    //Show Current Cart contents
                    shoppingCart.ShowCartContents(shoppingCart.CurrentCart);
                }
                else if (terminalInput == "CS")
                {
                    stillShopping = false;
                }
                else
                {
                    //Check if it is a product in the product list
                    newTerminalSession.IsRealProduct(shoppingCart.CurrentCart, priceCatalog.newProductCatalog, terminalInput);
                }
            }
            while (stillShopping);
        }
    }
}
