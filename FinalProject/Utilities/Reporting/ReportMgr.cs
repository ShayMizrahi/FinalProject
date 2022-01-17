using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Utilities.Reporting
{
    public class ReportMgr
    {
        public static IReportUtil Reporter = new ExtentReportUtil();
    }
}
