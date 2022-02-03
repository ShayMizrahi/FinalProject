using FinalProject.BaseActions;
using FinalProject.PageObject;
using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FinalProject.Flows
{
    public class SwagLabs_flow
    {
        public IWebDriver driver;
        public SwagLabs swagLabs;
        public BasicActions actions;
        public Random rendom = new Random();
        public int amountItemInTheCart;
        public double itemTotal;
        public Dictionary<string, double> itemsPrice = new Dictionary<string, double>();


        public SwagLabs_flow(IWebDriver driver, SwagLabs swagLabs, BasicActions actions)
        {
            this.driver = driver;
            this.swagLabs = swagLabs;
            this.actions = actions;
        }

        public void LogIn(string InputTirleNode, string password)
        {
            try
            {
                IReportMng.IReporter.CreatNode("Log-in to website - " + InputTirleNode);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://www.saucedemo.com/"));

                var randomNumber = rendom.Next(1, 4);
                string selecteduserName = selectUserName(randomNumber);

                // clear and update user name field
                actions.ClearTextOnElement(swagLabs.UserNameField, "user name field");
                actions.UpdateText(swagLabs.UserNameField, selecteduserName, "user name field");
                // clear and update user password field
                actions.ClearTextOnElement(swagLabs.passwordField, "password field");
                actions.UpdateText(swagLabs.passwordField, password, "password field");
                // click on login button
                actions.ClickOnElement(swagLabs.loginBtn, "login btn");

                bool IsLogInPageOpen = actions.IsElementExist(swagLabs.UserNameField);

                if (IsLogInPageOpen)
                {
                    string errorMsg = swagLabs.errorMsg.Text;
                    actions.Validation("Epic sadface: Username and password do not match any user in this service",
                        errorMsg, "errorMsg");
                }
            }

            catch(Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "Failed to log-in", e, driver);
            }
           
            
        }

        public void selectItem(int rounds)
        {
            try
            {
                IReportMng.IReporter.CreatNode("Select/remove item: " + rounds);

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://www.saucedemo.com/inventory.html"));

                int RandomIndexItem = rendom.Next(0, 5);


                var itemName = swagLabs.listOFinventoryitems[RandomIndexItem].FindElement(By.CssSelector(
                    "div.inventory_item_description > div.inventory_item_label > a > div"));

                var itemNameTxt = swagLabs.listOFinventoryitems[RandomIndexItem].FindElement(By.CssSelector(
                    "div.inventory_item_description > div.inventory_item_label > a > div")).Text;

                var itemPriceTxt = swagLabs.listOFinventoryitems[RandomIndexItem].FindElement(By.CssSelector(
                    "div.inventory_item_description > div.pricebar > div")).Text;

                var addToCartBtn = swagLabs.listOFinventoryitems[RandomIndexItem].FindElement(By.CssSelector(
                   "div.inventory_item_description > div.pricebar > button"));

                var itemDescriptionTxt = swagLabs.inventoryItemsDesc[RandomIndexItem].Text;

                var itemImg_produts = swagLabs.inventoryItemsImg[RandomIndexItem].GetAttribute("src");

                // click on the name of the item
                actions.ClickOnElement(itemName, "item Name");

                Thread.Sleep(1000);

                var itemImg_produtsDetails = swagLabs.inventoryItemsImgdetails.GetAttribute("src");
                var itemDescriptionDetails = swagLabs.inventoryItemsDescDetails.Text;

                // validate the name and the price between products and details item page
                actions.Validation(swagLabs.inventoryitemNameLargeSize.Text, itemNameTxt, "item name");
                actions.Validation(swagLabs.inventoryitemPriceLargeSize.Text, itemPriceTxt, "item price");
         //       actions.Validation(itemImg_produtsDetails, itemImg_produts, "item img");
                actions.Validation(itemDescriptionDetails, itemDescriptionTxt, "item img");

                // click on add to cart 
                actions.ClickOnElement(swagLabs.addToCartBtm, "addToCartBtn");

                if (swagLabs.addToCartBtm.Text.Equals("REMOVE"))
                {
                    // checking if  addToCartBtm change to "Remove"  after clicking  
                    actions.Validation("REMOVE", swagLabs.addToCartBtm.Text, "item name");
                    // increase by one
                    amountItemInTheCart++;
                    // the current amount in the cart
                    var amountInTheCart = swagLabs.shoppingCartBadge.Text;
                    // validate  the current amount equal to the  amountItemInTheCart
                    actions.Validation(amountInTheCart, amountItemInTheCart.ToString(), "amountInTheCart");


                    double priceAsInt = convertStringToDouble(swagLabs.inventoryitemPriceLargeSize, 1);

                    itemsPrice.Add(itemNameTxt, priceAsInt);
                }

                else
                {
                    // validate that addToCartBtm changed to "add to cart" after clicking
                    actions.Validation("ADD TO CART", swagLabs.addToCartBtm.Text, "item name");
                    // decrease by one
                    amountItemInTheCart--;

                    itemsPrice.Remove(itemNameTxt);

                    bool isShoppingCartBadgeExist = actions.IsElementExist(swagLabs.shoppingCartBadge);

                    if (isShoppingCartBadgeExist)
                    {
                        // the current amount in the cart
                        var amountInTheCart = swagLabs.shoppingCartBadge.Text;
                        // validate  the current amount equal to the  amountItemInTheCart
                        actions.Validation(amountInTheCart, amountItemInTheCart.ToString(), "amountInTheCart");
                    }

                    else
                    {
                        // the current amount in the cart
                        string amountInTheCart = "0";
                        // validate  the current amount equal to the  amountItemInTheCart
                        actions.Validation(amountInTheCart, amountItemInTheCart.ToString(), "amountInTheCart");
                    }
                   
                }

                // go back to products by clicking on backToProductsBtn
                actions.ClickOnElement(swagLabs.backToProductsBtn, "backToProductsBtn");
            }

            catch(Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "Failed to add items" , e, driver);
            }
            
        }

        public void checkout()
        {
            try
            {
                IReportMng.IReporter.CreatNode("Checkout");

                actions.ClickOnElement(swagLabs.shoppingCartBtn, "shoppingCartBtn");
                Thread.Sleep(1000);
              
                var countOfItems = swagLabs.listOfCartItemLabel.Count;
                actions.Validation(countOfItems.ToString(), amountItemInTheCart.ToString(), "amountInTheCart");
                actions.ClickOnElement(swagLabs.checkoutBtn, "checkoutBtn");
                addYourInformation();
                double totalPrice = calckulatAllThePrices();
                string subtotal = swagLabs.summarySubtotal.Text.Substring(13);
                actions.Validation(subtotal, totalPrice.ToString(), "subtotal");

                //       actions.Validation(totalPrice, )
                var TaxAsDouble =  convertStringToDouble(swagLabs.summaryTax, 6);

                var TotalStr = swagLabs.summaryTotal.Text.Substring(8);
                var Total = TaxAsDouble + totalPrice;
                actions.Validation(Total.ToString(), TotalStr, "Total");

            }

            catch(Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "Failed to finish checkout", e, driver);
            }
           
            
            }

        public void addYourInformation()
        {
            actions.UpdateText(swagLabs.firstNameField, "Shay", "firstNameField");
            actions.UpdateText(swagLabs.lastNameField, "Mizrahi", "lastNameField");
            actions.UpdateText(swagLabs.postalCodeField, "6541235", "postalCodeField");
            actions.ClickOnElement(swagLabs.continueBtn, "continueBtn");
        }

        public double calckulatAllThePrices()
        {
            itemTotal = 0;

            for (int i=0; i< itemsPrice.Count; i++)
            {
                
                var price = itemsPrice.ElementAt(i).Value;

                itemTotal += price;

            }
            return itemTotal;
        }

        public static string selectUserName(int userName)
        {
            string SelectedUserName;
            switch (userName)
            {
                case 1:
                    SelectedUserName = "standard_user";
                    break;
                case 2:
                    SelectedUserName = "locked_out_user";
                    break;
                case 3:
                    SelectedUserName = "problem_user";
                    break;
                case 4:
                    SelectedUserName = "performance_glitch_user";
                    break;
                
                    default:
                    SelectedUserName = "standard_user";
                    break;
            }
            return SelectedUserName;
        }


        public static double convertStringToDouble(IWebElement elem, int substring)
        {
            var value = elem.Text;
            string valueWithDigitOnly = value.Substring(substring);
            double valueAsDouble = double.Parse(valueWithDigitOnly);

            return valueAsDouble;
        }

        
    }
}
