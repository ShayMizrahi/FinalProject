using FinalProject.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;


namespace FinalProject.PageObject
{
    public class AutomationPanda 
    {

        public AutomationPanda()
        {
            PageFactory.InitElements(CommonOperations.driver, this);
        }



        [FindsBy(How = How.CssSelector, Using = "figure.wp-block-table > table > tbody > tr > td:nth-child(1) > a")]
        public IList<IWebElement> DemoSiteList { get; set; }


    }
}
