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



    [TestFixture("Chrome")]
   // [TestFixture("MicrosoftEdge")]
    public class RunTests : ConfigurationDrivers
    {
        
        public RunTests(string browser) :base(browser)
        {

        }

       

        

        [Test, Order(1)]
        public void test1()
        {

            ReportMgr.Reporter.CreatTest("1) ParaBank site, Creat new acount ");

            IWebElement ParaBank = Actions.SearchElementByText(Base.autoPanda.DemoSiteList, "ParaBank");
            Actions.ScrollToView(ParaBank, "ParaBank");
            Actions.ClickOnElement(ParaBank, "ParaBankButton");

            ParaBankSite_flow.LogIn("shayMizrahi", "abcd1234");
            Thread.Sleep(1000);
            ParaBankSite_flow.Register("Shay", "Mizrahi", "Carmel 5 st.",
                "Rehovot", "Israel", 765412, 0548013506, 2432, "Shaymizrahi2",
                "Liat0548013506", "Liat0548013506");
        }

 //       [Test, Order(2)]
        public void test2()
        {

            ReportMgr.Reporter.CreatTest("2) ParaBank site, Creat new acount 2");

            IWebElement ParaBank = Actions.SearchElementByText(Base.autoPanda.DemoSiteList, "ParaBank");
            Actions.ScrollToView(ParaBank, "ParaBank");
            Actions.ClickOnElement(ParaBank, "ParaBankButton");

            ParaBankSite_flow.LogIn("shay", "1234");

        }

       
    }
}
