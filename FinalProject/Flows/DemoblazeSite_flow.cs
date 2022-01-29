using FinalProject.BaseActions;
using FinalProject.PageObject;
using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FinalProject.Flows
{
    public class DemoblazeSite_flow
    {
        public IWebDriver driver;
        public List<int> priceOfItems = new List<int>();
        public Demoblaze demoblaze;
        public BasicActions actions;
        public Random random = new Random();
        public string categorySelected;
        public IWebElement selectedItemPrice;
        public IWebElement selectedItem;
        public string selectedItemText;
        public string selectedItemPriceText;
        public int totalPrice;

        public DemoblazeSite_flow(IWebDriver driver, Demoblaze demoblaze, BasicActions actions)
        {
            this.driver = driver;
            this.demoblaze = demoblaze;
            this.actions = actions;
        }


        public void SelectCategory(int itaration)
        {
            IReportMng.IReporter.CreatNode("Select random category " + itaration);

            categorySelected = random.Next(1, 4).ToString();

            switch (categorySelected)
            {
                case "1":
                    categorySelected = "Phones";
                    break;

                case "2":
                    categorySelected = "Laptops";
                    break;

                case "3":
                    categorySelected = "Monitors";
                    break;
            }

            var FindTheSelectedCategory = actions.SearchElement(demoblaze.Categories, categorySelected, "Categories");
            actions.ClickOnElement(FindTheSelectedCategory, categorySelected);


        }

        public void SelectRandomItemFromCategory(int itaration)
        {
            IReportMng.IReporter.CreatNode("Select random item " + itaration);

            Thread.Sleep(1000);
            int countOfItems = demoblaze.ItemsFromCategories.Count;
            IReportMng.IReporter.WriteToLog(IReportUtil.Status.Info, "The amount of the selected category: '" + categorySelected + "' is: '" + countOfItems + "'");

            var rendomNumberOfItem = random.Next(1, countOfItems);
            selectedItem = actions.SearchElement(demoblaze.ItemsFromCategories, rendomNumberOfItem, "items", demoblaze.ItemsFromCategories[rendomNumberOfItem].Text);
            selectedItemText = selectedItem.Text;
            selectedItemPrice = actions.SearchElement(demoblaze.PriceOfItems, rendomNumberOfItem, "price of items", demoblaze.PriceOfItems[rendomNumberOfItem].Text);
            selectedItemPriceText = selectedItemPrice.Text;
            string selectedItemPriceWithoutTheSign = selectedItemPriceText.Substring(1);
            int selectedItemPriceAsInt = Int32.Parse(selectedItemPriceWithoutTheSign);
            priceOfItems.Add(selectedItemPriceAsInt);
            IReportMng.IReporter.WriteToLog(IReportUtil.Status.Info, "The selected item is: '" + selectedItem.Text + "'");
            IReportMng.IReporter.WriteToLog(IReportUtil.Status.Info, "The price of the selected item is: '" + selectedItemPrice.Text + "'");
            actions.ClickOnElement(selectedItem, "selectedItem");
        }

        public void CheckoutAndValidateTheItem(bool GoHomePageAfterFinish, int itaration)
        {
            IReportMng.IReporter.CreatNode("Validate and checkout " + itaration);

            string ItemPrice_ItemDesplayText = demoblaze.ItemPrice_ItemDesplay.Text;
            string shay = ItemPrice_ItemDesplayText.Substring(0, ItemPrice_ItemDesplayText.Length - 13).Trim();
            actions.Validation(demoblaze.ItemName_ItemDesplay.Text, selectedItemText, "ItemName_ItemDesplay");
            actions.Validation(shay, selectedItemPriceText.Trim(), "ItemPrice_ItemDesplay");

            actions.ClickOnElement(demoblaze.AddToCartButton, "AddToCartButton");
            Thread.Sleep(1000);
            var alert_win = driver.SwitchTo().Alert();
            string alertText = alert_win.Text;
            actions.Validation(alertText, "Product added", "alertText");
            alert_win.Accept();

            if (GoHomePageAfterFinish)
            {
                IWebElement homeButton = actions.SearchElement(demoblaze.ListOfTitlePanel, 0, "main buttons", "home button");
                actions.ClickOnElement(homeButton, "homeButton");
            }


        }


        public void GoToCartValidateTotalPriceAndBuy()
        {
            IReportMng.IReporter.CreatNode("Go to cart validate total price and buy");

            IWebElement cartButton = actions.SearchElement(demoblaze.ListOfTitlePanel, 3 , "main buttons", "cart button");
            actions.ClickOnElement(cartButton, "cartButton");
            
            for (int i=0; i< priceOfItems.Count; i ++)
            {   
                int price = priceOfItems[i];
                totalPrice = totalPrice + price;
            }

            Thread.Sleep(1000);

            actions.Validation(demoblaze.totalPrice.Text, totalPrice.ToString(), "Total price");



        }
    }
}
