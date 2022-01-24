using System;
using System.Collections;
using FinalProject.BaseActions;
using FinalProject.Flows;
using FinalProject.PageObject;
using FinalProject.Utilities.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace FinalProject.Utilities
{

    public class ConfigurationDrivers
    {
        private string _browser;
        public IWebDriver driver;
        public ExtentReportUtil reporter;
        public ManagePages mng;

        public ConfigurationDrivers(string browser)
        {
            _browser = browser;
        }


        [SetUp]
        public void SetUpWebDriver()
        {
            dynamic capability = GetBrowserOptions(_browser);

            if (_browser == "Chrome")
            {

                driver = new ChromeDriver(CommonOperations.projectDirectory + @"\Resources\Drivers");
                setBrowser(_browser);

            }

            else if (_browser == "MicrosoftEdge")
            {
                driver = new EdgeDriver(CommonOperations.projectDirectory + @"\Resources\Drivers");
                setBrowser(_browser);
            }

        }

        private dynamic GetBrowserOptions(string browserName)
        {
            if (browserName == "Chrome")
            {
                return new ChromeOptions();
            }

            if (browserName == "Firefox")
            {
                return new FirefoxOptions();
            }

            if (browserName == "MicrosoftEdge")
            {
                return new FirefoxOptions();
            }

            return new ChromeOptions();
        }

        public void setBrowser(string BrowserName)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://automationpanda.com/");
            InitPages();
        }


        [TearDown]
        public void AfterEveryTest()
        {
            driver.Close();
        }

        public void InitPages()
        {
            mng = new ManagePages(driver);
            mng.InitClasses();
        }

    }
}






