using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Utilities.Reporting
{
    class IReportMng
    {
        public static IReportUtil IReporter = new ExtentReportUtil();
    }
}
