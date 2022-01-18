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

namespace FinalProject.Utilities
{



    [TestFixture("Chrome")]
   // [TestFixture("MicrosoftEdge")]
    public class RunTests : ConfigurationDrivers
    {
        
        public RunTests(string browser) :base(browser)
        {

        }

        public void BeforEvry()
        {
          //  CommonOperations.BeforEvryTest();
          



        }

        

        [Test, Order(1)]
        public void test1()
        {

            ReportMgr.Reporter.CreatTest("1) ParaBank site, Creat new acount ");

            IWebElement ParaBank = Actions.SearchElementByText(Base.autoPanda.DemoSiteList, "ParaBank");
            Actions.ScrollToView(ParaBank, "ParaBank");
            Actions.ClickOnElement(ParaBank, "ParaBankButton");

            ParaBankSite_flow.LogIn("shayMizrahi", "abcd1234");
        }

        [Test, Order(2)]
        public void test2()
        {

            ReportMgr.Reporter.CreatTest("2) ParaBank site, Creat new acount 2");

            IWebElement ParaBank = Actions.SearchElementByText(Base.autoPanda.DemoSiteList, "ParaBank");
            Actions.ScrollToView(ParaBank, "ParaBank");
            Actions.ClickOnElement(ParaBank, "ParaBankButton");

            ParaBankSite_flow.LogIn("shayMizrahi", "abcd1234");
        }

        [Test, Order(3)]
        public void test3()
        {

            ReportMgr.Reporter.CreatTest("3) ParaBank site, Creat new acount 3");

            IWebElement ParaBank = Actions.SearchElementByText(Base.autoPanda.DemoSiteList, "ParaBank");
            Actions.ScrollToView(ParaBank, "ParaBank");
            Actions.ClickOnElement(ParaBank, "ParaBankButton");

            ParaBankSite_flow.LogIn("shayMizrahi", "abcd1234");
        }

        [Test, Order(4)]
        public void test4()
        {

            ReportMgr.Reporter.CreatTest("4) ParaBank site, Creat new acount 4");

            IWebElement ParaBank = Actions.SearchElementByText(Base.autoPanda.DemoSiteList, "ParaBank");
            Actions.ScrollToView(ParaBank, "ParaBank");
            Actions.ClickOnElement(ParaBank, "ParaBankButton");

            ParaBankSite_flow.LogIn("shayMizrahi", "abcd1234");
        }
    }
}
