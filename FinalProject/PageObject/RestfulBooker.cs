using FinalProject.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.PageObject
{
    public class RestfulBooker
    {
        public IWebDriver driver;
        public RestfulBooker(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "name")]
        public IWebElement NameField { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement EmailField { get; set; }

        [FindsBy(How = How.Id, Using = "phone")]
        public IWebElement PhoneField { get; set; }

        [FindsBy(How = How.Id, Using = "subject")]
        public IWebElement SubjectField { get; set; }

        [FindsBy(How = How.Id, Using = "description")]
        public IWebElement DescriptionField { get; set; }

        [FindsBy(How = How.Id, Using = "submitContact")]
        public IWebElement SubmitButton { get; set; }

    }
}
