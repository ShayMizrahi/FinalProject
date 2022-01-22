using FinalProject.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.PageObject
{
    public class Demoblaze
    {
        public IWebDriver driver;
        public Demoblaze(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#contcont > div > div.col-lg-3 > div > a")]
        public IList<IWebElement> Categories { get; set; }



        [FindsBy(How = How.CssSelector, Using = "figure.wp-block-table > table > tbody > tr > td:nth-child(1) > a")]
        public IList<IWebElement> DemoSiteList { get; set; }

        [FindsBy(How = How.ClassName, Using = "hrefch")]
        public IList<IWebElement> ItemsFromCategories { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.card-block > h5")]
        public IList<IWebElement> PriceOfItems { get; set; }


        

    }
}
