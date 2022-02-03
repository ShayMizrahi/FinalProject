using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;


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
            switch (browserName)
            {
                case "Chrome":
                    return new ChromeOptions();

                case "Firefox":
                    return new FirefoxOptions();

                case "MicrosoftEdge":
                    return new FirefoxOptions();
                default:
                    return new ChromeOptions();

            }

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






