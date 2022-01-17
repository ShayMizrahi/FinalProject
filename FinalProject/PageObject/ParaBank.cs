using FinalProject.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.PageObject
{
    public class ParaBank : Base
    {
        public ParaBank()
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "username")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.ClassName, Using = "button")]
        public IWebElement LogInButton { get; set; }


    }
}
