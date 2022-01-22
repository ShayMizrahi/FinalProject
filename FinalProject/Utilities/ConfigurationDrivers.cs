using System;
using System.Collections;
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

//[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace FinalProject.Utilities
{
    
    public class ConfigurationDrivers
    {
        private string _browser;
        public IWebDriver driver;
        public BaseActions.Actions actions;
        public AutomationPanda autoPanda;
        public ParaBank paraBank;
        public ParaBankSite_flow paraBank_flow;
        public static int WebDriversCounter= 0;
        public ExtentReportUtil reporter;
        public RestfulBooker restfulBooker;
        public RestfulBookerSite_flow restfulBooker_flow;
        public Demoblaze demoblaze;
        public DemoblazeSite_flow demoblaze_flow;


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
                WebDriversCounter++;
                setBrowser(_browser);

            }

            else if (_browser == "MicrosoftEdge")
            {
                driver = new EdgeDriver(CommonOperations.projectDirectory + @"\Resources\Drivers");
                WebDriversCounter++;
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
                InitClasses();
        }


        [TearDown]
        public void AfterEveryTest()
        {
            driver.Close();
            WebDriversCounter--;
        }

        public void InitClasses()
        {
            actions = new BaseActions.Actions(driver);
            autoPanda = new AutomationPanda(driver);

            paraBank = new ParaBank(driver);
            paraBank_flow = new ParaBankSite_flow(driver, paraBank, actions);

            restfulBooker = new RestfulBooker(driver);
            restfulBooker_flow = new RestfulBookerSite_flow(driver, restfulBooker, actions);

            demoblaze = new Demoblaze(driver);
            demoblaze_flow = new DemoblazeSite_flow(driver, demoblaze, actions);
            




        }

        public void closeExtentReport()
        {
            reporter.CloseReport();
        }

       

       
        


        /*
                public void waitUntilEquals(Object obj1, Object obj2)
                {
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10000));
                    wait.Until(ExpectedConditions.Equals(obj1, obj2));
                }
        */
    }
}






