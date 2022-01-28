using FinalProject.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.PageObject
{
    public class ParaBank
    {
        public IWebDriver driver;
        public ParaBank(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        // LogIn 

        [FindsBy(How = How.Name, Using = "username")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='button' and @value='Log In' and @type='submit' ]")]
        public IWebElement LogInButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "title")]
        public IWebElement Title_OutputResult { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='rightPanel']/p")]
        public IWebElement Content_OutputResult { get; set; }


        // Register

        [FindsBy(How = How.XPath, Using = "//*[@id='loginPanel']/p[2]/a")]
        public IWebElement RegisterButton { get; set; }

        [FindsBy(How = How.Id, Using = "customer.firstName")]
        public IWebElement FirstNameField { get; set; }

        [FindsBy(How = How.Id, Using = "customer.lastName")]
        public IWebElement LastNameField { get; set; }

        [FindsBy(How = How.Id, Using = "customer.address.street")]
        public IWebElement AddressField { get; set; }

        [FindsBy(How = How.Id, Using = "customer.address.city")]
        public IWebElement CityField { get; set; }

        [FindsBy(How = How.Id, Using = "customer.address.state")]
        public IWebElement StateField { get; set; }

        [FindsBy(How = How.Id, Using = "customer.address.zipCode")]
        public IWebElement ZipCodeField { get; set; }

        [FindsBy(How = How.Id, Using = "customer.phoneNumber")]
        public IWebElement PhoneNumberField { get; set; }

        [FindsBy(How = How.Id, Using = "customer.ssn")]
        public IWebElement SsnField { get; set; }

        [FindsBy(How = How.Id, Using = "customer.username")]
        public IWebElement UsernameField { get; set; }

        [FindsBy(How = How.Id, Using = "customer.password")]
        public IWebElement PasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "repeatedPassword")]
        public IWebElement RepeatedPasswordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='button' and @value='Register' and @type='submit' ]")]
        public IWebElement ConfirmButton { get; set; }

        // Log out

        [FindsBy(How = How.XPath, Using = "//*[@id='leftPanel']/ul/li[8]/a")]
        public IWebElement logOut { get; set; }

        // Acount services

        [FindsBy(How = How.CssSelector, Using = "#leftPanel > ul > li")]
        public IList<IWebElement> AcountServicesList { get; set; }

        // Open new acount

        [FindsBy(How = How.Id, Using = "type")]
        public IWebElement Type_ComboBox { get; set; }

        [FindsBy(How = How.Id, Using = "fromAccountId")]
        public IWebElement FromAccount_ComboBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Open New Account']")]
        public IWebElement OpenNewAcountButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@ng-if='showResult']/h1")]
        public IWebElement TitleAfterCreatNewAcount_OutputResult { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@ng-if='showResult']/p[1]")]
        public IWebElement ContentAfterCreatNewAcount1_OutputResult { get; set; }

        [FindsBy(How = How.Id, Using = "newAccountId")]
        public IWebElement newAccountId { get; set; }

        // Acounts overview

        [FindsBy(How = How.CssSelector, Using = "#accountTable > tbody > tr")]
        public IList<IWebElement> selectRow { get; set; }

        [FindsBy(How = How.ClassName, Using = "ng-binding")]
        public IList<IWebElement> selectCell { get; set; }




    }
}
