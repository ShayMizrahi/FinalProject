using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using FinalProject.Utilities.Reporting;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace FinalProject.Utilities
{

    public class CommonOperations : Base
    {

        // Path to working directory for the current project
        public static string workingDirectory = Environment.CurrentDirectory;
        // Path to secound 'Finalproject' folder of the current project
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        // Report folder name
        public static string ReportFolderName = "Reporting "
            + DateTime.Now.ToString().Replace("/", ".").Replace(":", ".") + @"\";
        // Path to report folder
        public static string ReportFolderPath = projectDirectory + @"\ExtentReport\";
        // Screenshot folder name
        public static string ScreenshotFolderName = "Screenshot";
        // Path to Screenshot folder
        public static string ScreenshotFolderPath = ReportFolderPath + ReportFolderName;


        [OneTimeSetUp]
        public void BeforTests()
        {
            CreatNewFolder(projectDirectory,  "ExtentReport");
            CreatNewFolder(ReportFolderPath, ReportFolderName);
            CreatNewFolder(ScreenshotFolderPath, ScreenshotFolderName);
            ReportMgr.Reporter.InitReport();
            SetupWebDriver();
        }

        [OneTimeTearDown]
        public void AfterAllTests()
        {
            ReportMgr.Reporter.CloseReport();
            CloseBrowser();
        }

        /// <summary>
        /// 1 Opens chrome browser
        /// 2 Maximizes the web browser window
        /// 3 Set Implicit Wait 
        /// 4 Navigate to the web site
        /// </summary>
        public void SetupWebDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            driver = new ChromeDriver(projectDirectory + @"\Resources\Drivers", options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://automationpanda.com/");
        }

        public void CloseBrowser()
        {
            driver.Close();
        }

        /// <summary>
        /// Creat new folder if not exist
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="FolderName"></param>
        public void CreatNewFolder(string Path, string FolderName)
        {
            if (!Directory.Exists(Path + FolderName))
            {
                Directory.CreateDirectory(Path + FolderName);
            }
        }

       

        [Test]
        public void test1()
        {
 
            ReportMgr.Reporter.CreatTest("Test1");
            ReportMgr.Reporter.WriteToLog(IReportUtil.Status.Fail, "The test is faild");
            ReportMgr.Reporter.WriteToLog(IReportUtil.Status.Pass, "The test wass pass");
            ReportMgr.Reporter.WriteToLog(IReportUtil.Status.Info, "Info about the step");

        }

        [Test]
        public void test2()
        {
            ReportMgr.Reporter.CreatTest("Test2");
            ReportMgr.Reporter.WriteToLog(IReportUtil.Status.Error, "there was error");
            ReportMgr.Reporter.WriteToLog(IReportUtil.Status.Pass, "The test wass pass");
            ReportMgr.Reporter.WriteToLog(IReportUtil.Status.Info, "Info about the step");

        }


    }
}
