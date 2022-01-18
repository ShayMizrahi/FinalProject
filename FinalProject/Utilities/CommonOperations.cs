using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using FinalProject.BaseActions;
using FinalProject.PageObject;
using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace FinalProject.Utilities
{
   [SetUpFixture]
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
        public static string ScreenshotFolderName = @"Screenshot\";
        // Path to Screenshot folder
        public static string ScreenshotFolderPath = ReportFolderPath + ReportFolderName;


       [OneTimeSetUp]
        public void BeforTests()
        {
            CreatNewFolder(projectDirectory, "ExtentReport");
            CreatNewFolder(ReportFolderPath, ReportFolderName);
            CreatNewFolder(ScreenshotFolderPath, ScreenshotFolderName);
            ReportMgr.Reporter.InitReport();
        }


        [OneTimeTearDown]
        public void AfterAllTests()
        {
            ReportMgr.Reporter.CloseReport();
        }

       
        public static void BeforEvryTest()
        {
            CommonOperations.SetupWebDriver();
            InitPages.Init();
        }

        
        public static  void AfterEveryTest()
        {
            CommonOperations.CloseBrowser();
        }



        /// <summary>
        /// 1 Opens chrome browser
        /// 2 Maximizes the web browser window
        /// 3 Set Implicit Wait 
        /// 4 Navigate to the web site
        /// </summary>
        public static void SetupWebDriver()
        {
           
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://automationpanda.com/");
            


        }

        public static void CloseBrowser()
        {
            driver.Close();
        }

        /// <summary>
        /// Creat new folder if not exist
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="FolderName"></param>
        public static void CreatNewFolder(string Path, string FolderName)
        {
            if (!Directory.Exists(Path + FolderName))
            {
                Directory.CreateDirectory(Path + FolderName);
            }
        }

        public static string copyScreenshot()
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(ScreenshotFolderPath + ScreenshotFolderName
                    + "Screenshot" + DateTime.Now.ToString().Replace("/", ".").Replace(":", ".") + @".png",
            ScreenshotImageFormat.Png);

            string path = ScreenshotFolderPath + ScreenshotFolderName
                    + "Screenshot" + DateTime.Now.ToString().Replace("/", ".").Replace(":", ".") + @".png";


            return path;
        }



    }


}

