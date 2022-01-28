using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Utilities
{
    public interface IReportUtil
    {

        public enum Status
        {
            Fail,
            Pass,
            Error,
            Info
        }

        public void InitReport();

        public void CloseReport();

        public void WriteToLog(Status status, string Description);

        public void WriteToLog(Status status, string Description, Exception e, IWebDriver driver);

        public void CreatTest(string inputTitle);

        public void CreatNode(string inputTitle);

    }

    }

