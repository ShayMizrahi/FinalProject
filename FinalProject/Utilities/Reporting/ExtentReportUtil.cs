using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using FinalProject.Utilities.Reporting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FinalProject.Utilities
{
    public class ExtentReportUtil : IReportUtil
    {
        public static ExtentReports report;
        public static ExtentTest test;
        public static ExtentHtmlReporter htmlReporter;
        public IWebDriver driver;
        public ConfigurationDrivers config;

        public void CloseReport()
        {
            report.Flush(); 
        }
       
        /// <summary>
        /// 1 Initialize htmlReporter
        /// 2 Set document title
        /// 3 Set report name
        /// 4 Set dark theme to the extent report
        /// 5 Initialize ExtentReports
        /// 6 Attach 
        /// </summary>
        public void InitReport()
        {
            htmlReporter = new ExtentHtmlReporter(CommonOperations.ReportFolderPath 
                + CommonOperations.ReportFolderName + @"\myReport.html");
            htmlReporter.Config.DocumentTitle = "Automation Panda";
            htmlReporter.Config.ReportName = "Report";
            htmlReporter.Config.Theme = Theme.Dark;

            report = new ExtentReports();
            report.AttachReporter(htmlReporter);
            report.AddSystemInfo("HostName", "LocalHost");
            report.AddSystemInfo("OS", "Windows10");
            report.AddSystemInfo("TesterName", "Shay Mizrahi");
            report.AddSystemInfo("Browser", "Chrome");
        }

        
        /// <summary>
        /// First method - Write to extent report status and description.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="Description"></param>
        public void WriteToLog(IReportUtil.Status status, string Description)
        {
            var convert = ConvertToExtentStatus(status);

            test.Log(convert, Description);
        }
       
        /// <summary>
        /// Second method - Write to extent report status, description and exception.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="Description"></param>
        /// <param name="e"></param>
        public void WriteToLog(IReportUtil.Status status, string Description, Exception e, IWebDriver driver)
        {
            var convert = ConvertToExtentStatus(status);
           
            test.Log(convert, Description);
            test.Log(Status.Info, "See exception " + e); 
            test.Log(Status.Info, "See exception ", 
                MediaEntityBuilder.CreateScreenCaptureFromPath(CopyScreenshot(driver)).Build());
               
      
        }

        public void CreatTest(string inputTitle)
        {
            test = report.CreateTest(inputTitle);
        }

        public Status ConvertToExtentStatus(IReportUtil.Status status)
        {
            switch (status)
            {
                case IReportUtil.Status.Fail:
                    return Status.Fail;
                case IReportUtil.Status.Pass:
                    return Status.Pass;
                case IReportUtil.Status.Error:
                    return Status.Error;
                case IReportUtil.Status.Info:
                    return Status.Info;
                default:
                    return Status.Fail;
            }

        }

        public string CopyScreenshot(IWebDriver driver)
        {
            string sSpath = CommonOperations.ScreenshotFolderPath + CommonOperations.ScreenshotFolderName;
            string imageName = "Screenshot" + DateTime.Now.ToString().Replace("/", ".").Replace(":", ".") + @".png";
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(sSpath + imageName, ScreenshotImageFormat.Png);

            return sSpath + imageName;
        }

       
    }

}
