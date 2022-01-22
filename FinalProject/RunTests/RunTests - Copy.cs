using FinalProject.BaseActions;
using FinalProject.Flows;
using FinalProject.PageObject;
using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FinalProject.Utilities
{



    
     
   // [TestFixture("Chrome")]
    [Parallelizable]
    [TestFixture("MicrosoftEdge")]
    public class RunTests2 : ConfigurationDrivers
    {

        public RunTests2(string browser) :base(browser)
        {
            
            
        }

   //     [Test, Order(4)]
        public void test1()
        {

            IReportMng.IReporter.CreatTest("1) ParaBank site, Creat new acount ");
            IWebElement ParaBank = actions.SearchElementByText(autoPanda.DemoSiteList, "ParaBank");
            actions.ScrollToView(ParaBank, "ParaBank");
            actions.ClickOnElement(ParaBank, "ParaBankButton");

            paraBank_flow.LogIn("shayMizrahi", "abcd1234");
            Thread.Sleep(1000);
            paraBank_flow.Register("Shay", "Mizrahi", "Carmel 5 st.",
                "Rehovot", "Israel", 765412, 0548013506, 2432, "Shaymizrahi2",
                "Liat0548013506", "Liat0548013506");
        }

        [Test, Order(2)]
        public void test2()
        {

            IReportMng.IReporter.CreatTest("2) ParaBank site, Creat new acount 2");

            IWebElement RestfulBooker = actions.SearchElementByText(autoPanda.DemoSiteList, "Restful Booker");
            actions.ScrollToView(RestfulBooker, "ParaBank");
            actions.ClickOnElement(RestfulBooker, "ParaBankButton");

            paraBank_flow.LogIn("shay", "1234");

        }

   //     [Test, Order(4)]
        public void test4()
        {

            IReportMng.IReporter.CreatTest("2) ParaBank site, Creat new acount 2");

            IWebElement RestfulBooker = actions.SearchElementByText(autoPanda.DemoSiteList, "Restful Booker");
            actions.ScrollToView(RestfulBooker, "ParaBank");
            actions.ClickOnElement(RestfulBooker, "ParaBankButton");

            paraBank_flow.LogIn("shay", "1234");

        }


    }
}
