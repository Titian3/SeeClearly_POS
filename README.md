# SeeClearly_POS

Small Point of sales system with console, Practice your scanning before you hit the self Checkout.

Accepts arbitrary ordering of products from a product list then returns a total cart value, Applies discount if necessary.
Includes some unit tests for some particular test case carts. 

## Installation / Usage:
- Open Visual Studio 2019, Currently using community version With C# and .NET packages installed.
- Click on 'Clone or Check Out Code' Button on quick start panel.

![Image of 'Clone or Check Out Code'](http://pubdocs.garbage.geek.nz/CloneButton.PNG)
  
- On The Github Repository click the 'clone or download button'.
- Copy the Git link or click the copy button.
- Paste this link on the 'Repository Location' on Visual Studio Then click Clone.
- Once Files have loaded in, Click on the switch View icon in the solution explorer, Change it to SeeClearlyPOS.sln.
- ![Image of 'Switch Button'](http://pubdocs.garbage.geek.nz/SwitchViewButton.PNG)
- Push F6 to build the solution.
- At the Top toolbar, Click the startup project dropdown, select 'SeeClearlyPOS_Console'.
- ![Image of 'Console start'](http://pubdocs.garbage.geek.nz/ConsoleExecutionButton.PNG)
- Click start to Bring up the console, there will be a list of arguments available.
- Unit tests can be started from the test context menu at top or with Ctrl + R, A by default.
- ![Image of 'Tests menu'](http://pubdocs.garbage.geek.nz/RunTests.PNG)

## Tech used:
- C#
- Visual Studio unit testing

## Exercise requirements
1. Submit a C# Class Library For a point of sale scanning System.

   It Must have the following:
   
    - Accepts Arbitrary input of products on a given product list.
    - Returns correct total Price for an entire cart.
    - Apply Bulk Discount if applicable.

2. Have automated tests to prove it works, 3 test cases have been given.

3. (Optional) Have a User interface.

## How I implemented these:
1. I have created a [class library](SeeClearlyPOS%20Library/Terminal.cs), it is split in to 3 classes to manage the terminal.

    - **ProductList:** 
      - The Pricing Data Model used for the Catalog.
    - **Catalog:** 
      - The Product list with the details provided from the requirements.
    - **Cart:** 
      - The Cart List to hold input of products. 
      - A Method to check the input is a valid product.
      - A Method to calculate cart total and apply bulk discount.

2. I have used Visual Studio [Unit testing](SeeClearlyPOS_UnitTesting/SeeClearlyLibraryTest.cs) to automate testing the required test carts and also some of the library Methods and data.

3. A [console](SeeClearly_POS/SeeClearlyPOS_Console/TerminalConsole.cs) has been created to emulate how the library might interact on a basic interface and to help with testing my code. It can also do the 3 test cases.
