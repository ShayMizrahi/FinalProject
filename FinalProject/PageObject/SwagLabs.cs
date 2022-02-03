using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.PageObject
{
    public class SwagLabs
    {
        public IWebDriver driver;
        public SwagLabs(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }


        // login page

        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement UserNameField { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement passwordField { get; set; }

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement loginBtn { get; set; }

        [FindsBy(How = How.XPath, Using = " //div[@class='error-message-container error']/h3")]
        public IWebElement errorMsg { get; set; }


        // products page

        [FindsBy(How = How.CssSelector, Using = "div.inventory_list > div")]
        public IList<IWebElement> listOFinventoryitems { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.inventory_item_description > div.inventory_item_label > a > div")]
        public IWebElement listOFinventoryitemsNames { get; set; }

        [FindsBy(How = How.ClassName, Using = "shopping_cart_badge")]
        public IWebElement shoppingCartBadge { get; set; }

        [FindsBy(How = How.ClassName, Using = "inventory_item_img")]
        public IList<IWebElement> inventoryItemsImg { get; set; }

        [FindsBy(How = How.ClassName, Using = "inventory_item_desc")]
        public IList<IWebElement> inventoryItemsDesc { get; set; }



        // details page

        [FindsBy(How = How.XPath, Using = "//*[@id='inventory_item_container']/div/div/div[2]/div[1]")]
        public IWebElement inventoryitemNameLargeSize { get; set; }

        [FindsBy(How = How.ClassName, Using = "inventory_details_price")]
        public IWebElement inventoryitemPriceLargeSize { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='inventory_item_container']/div/div/div[2]/button")]
        public IWebElement addToCartBtm { get; set; }

        [FindsBy(How = How.Id, Using = "back-to-products")]
        public IWebElement backToProductsBtn{ get; set; }

        [FindsBy(How = How.ClassName, Using = "inventory_details_img")]
        public IWebElement inventoryItemsImgdetails { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='inventory_details_desc_container']/div[2]")]
        public IWebElement inventoryItemsDescDetails { get; set; }

       
        // cart page

        [FindsBy(How = How.ClassName, Using = "cart_item_label")]
        public IList<IWebElement> listOfCartItemLabel { get; set; }

        [FindsBy(How = How.ClassName, Using = "shopping_cart_link")]
        public IWebElement shoppingCartBtn { get; set; }

        [FindsBy(How = How.Id, Using = "checkout")]
        public IWebElement checkoutBtn { get; set; }


        // cart page - your information

        [FindsBy(How = How.Name, Using = "firstName")]
        public IWebElement firstNameField { get; set; }

        [FindsBy(How = How.Name, Using = "lastName")]
        public IWebElement lastNameField { get; set; }

        [FindsBy(How = How.Name, Using = "postalCode")]
        public IWebElement postalCodeField { get; set; }

        [FindsBy(How = How.Id, Using = "continue")]
        public IWebElement continueBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "summary_tax_label")]
        public IWebElement summaryTax { get; set; }

        [FindsBy(How = How.ClassName, Using = "summary_total_label")]
        public IWebElement summaryTotal { get; set; }

        [FindsBy(How = How.ClassName, Using = "summary_subtotal_label")]
        public IWebElement summarySubtotal { get; set; }



    }
}
