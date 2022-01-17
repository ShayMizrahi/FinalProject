using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Utilities.Reporting
{
    public class ExtentReportUtil : IReportUtil
    {
        public static ExtentReports report;
        public static ExtentTest test;
        public static ExtentHtmlReporter htmlReporter;

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
            htmlReporter = new ExtentHtmlReporter(CommonOperations.ReportFolderPath + CommonOperations.ReportFolderName + @"\myReport.html");
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

        public void WriteToLog(IReportUtil.Status status, string Description)
        {
            var convert = ConvertToExtentStatus(status);

            test.Log(convert, Description);

            if (convert != Status.Fail)
            {

            }

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

    }
}
