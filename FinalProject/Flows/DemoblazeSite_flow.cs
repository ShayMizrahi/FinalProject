using FinalProject.BaseActions;
using FinalProject.PageObject;
using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Flows
{
    public class DemoblazeSite_flow
    {
        public IWebDriver driver;
        public Demoblaze demoblaze;
        public Actions actions;
        public IWebElement selectItem;

        public DemoblazeSite_flow(IWebDriver driver, Demoblaze demoblaze, Actions actions)
        {
            this.driver = driver;
            this.demoblaze = demoblaze;
            this.actions = actions;
        }

        
        public void SelectCategory()
        {
            IReportMng.IReporter.WriteToLog(IReportUtil.Status.Info, "Select from categories".ToUpper());
            Random random = new Random();
            
            string categorySelected = random.Next(1, 4).ToString();

            switch (categorySelected)
            {
                case "1":
                    categorySelected= "Phones";
                    break;

                case "2":
                    categorySelected = "Laptops";
                    break;

                case "3":
                    categorySelected = "Monitors";
                    break;
            }

           var FindTheSelectedCategory =  actions.SearchElementByText(demoblaze.Categories, categorySelected);
            actions.ClickOnElement(FindTheSelectedCategory, "FindTheSelectedCategory");
            int countOfItems = demoblaze.ItemsFromCategories.Count;
            IReportMng.IReporter.WriteToLog(IReportUtil.Status.Info, "The amount of the selected category: '" + categorySelected + "' is: '" + countOfItems + "'");

            if (categorySelected == "Phones")
            {
                selectItem = actions.SearchElementByText(demoblaze.ItemsFromCategories, "Samsung galaxy s6");
            }

            else if (categorySelected == "Laptops")
            {
                 selectItem = actions.SearchElementByText(demoblaze.ItemsFromCategories, "Sony vaio i7");
            }

            else if (categorySelected == "Monitors")
            {
                 selectItem = actions.SearchElementByText(demoblaze.ItemsFromCategories, "ASUS Full HD");
            }

            IReportMng.IReporter.WriteToLog(IReportUtil.Status.Info, "The selected item is: '" + selectItem.Text + "'");



        }

     
    }
}
