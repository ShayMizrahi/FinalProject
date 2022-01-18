using AventStack.ExtentReports;
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

        public void WriteToLog(Status status, string Description, Exception e);

        public void CreatTest(string inputTitle);

        }

    }

