using System;
using System.Collections;
using FinalProject.PageObject;
using FinalProject.Utilities.Reporting;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

[assembly:Parallelizable(ParallelScope.Fixtures)]
namespace FinalProject.Utilities
{
   
    public class ConfigurationDrivers 
    {
        private string _browser;
        

        public ConfigurationDrivers(string browser)
        {
            _browser = browser;
 
        }
        
        [SetUp]
        public void SetUp()
        {
            dynamic capability = GetBrowserOptions(_browser);

            if (_browser == "Chrome")
            {
               
                Base.driver = new ChromeDriver(CommonOperations.projectDirectory + @"\Resources\Drivers");
                setBrowser(_browser);
            }

            else if (_browser == "MicrosoftEdge")
            {
                Base.driver = new EdgeDriver(CommonOperations.projectDirectory + @"\Resources\Drivers");
                setBrowser(_browser);
            }

        }

        private dynamic GetBrowserOptions(string browserName)
        {
            if(browserName == "Chrome")
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

        public static void  setBrowser(string BrowserName)
        {
            try
            {
                InitPages.Init();
                Base.driver.Manage().Window.Maximize();
                Base.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Base.driver.Navigate().GoToUrl("https://automationpanda.com/");
                
            //    ReportMgr.Reporter.WriteToLog(IReportUtil.Status.Pass, "The browser: " + BrowserName + " was open successfuly");
            }

            catch(Exception e)
            {
                ReportMgr.Reporter.WriteToLog(IReportUtil.Status.Fail, "Faild to open The browser: " + BrowserName , e);
            }
           
        }
        

        [TearDown]
        public void AfterEvery()
        {
            CommonOperations.AfterEveryTest();
        }

        

       















        /*
            public static IEnumerable LatestConfigurations
            {
                get
                {
   
                    //chrome on Windows(#1 platform as of 2019)
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest-1", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest-2", "Windows 10");

                    //chrome on Windows 7(#3 platform as of 2019)
                    yield return new TestFixtureData("Chrome", "latest", "Windows 7");
                    yield return new TestFixtureData("Chrome", "latest-1", "Windows 7");
                    yield return new TestFixtureData("Chrome", "latest-2", "Windows 7");

                    //firefox
                    yield return new TestFixtureData("Firefox", "latest", "macOS 10.13");
                    yield return new TestFixtureData("Firefox", "latest-1", "macOS 10.13");
                    yield return new TestFixtureData("Firefox", "latest-2", "macOS 10.13");

                    //edge
                    yield return new TestFixtureData("MicrosoftEdge", "latest", "Windows 10");
                    yield return new TestFixtureData("MicrosoftEdge", "latest-1", "Windows 10");
                    yield return new TestFixtureData("MicrosoftEdge", "latest-2", "Windows 10");

                    //IE
                    yield return new TestFixtureData("Internet Explorer", "latest", "Windows 10");
                    yield return new TestFixtureData("Internet Explorer", "latest", "Windows 7");

                    //Doesn't work
                    //yield return new TestFixtureData("Internet Explorer", "latest", "Windows 8");       
                    //yield return new TestFixtureData("Internet Explorer", "10.0", "Windows 7");
                }
            }

            public static IEnumerable SimpleConfiguration
            {
                get
                {
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");
                    yield return new TestFixtureData("Chrome", "latest", "Windows 10");

                }
            }
        */
    }
      
    }

    

