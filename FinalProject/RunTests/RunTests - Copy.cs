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
    [Parallelizable]
 //   [TestFixture("MicrosoftEdge")]
    public class RunTests2 : ConfigurationDrivers
    {

        public RunTests2(string browser) :base(browser)
        {
         
        }


        [Test, Order(2)]
        public void test2()
        {
            IReportMng.IReporter.CreatTest("Rest fulBooker site, send massege");

            IWebElement RestfulBooker = actions.SearchElementByText(autoPanda.DemoSiteList, "Restful Booker");
            actions.ScrollToView(RestfulBooker, "RestfulBooker");
            actions.ClickOnElement(RestfulBooker, "ParaBankButton");
            actions.ScrollToView(restfulBooker.NameField, "NameField");
            restfulBooker_flow.Rooms_Signup("Shay Mizrahi", "shaymizrahi@gmail.com", "0548013506",
                "book room", "What is the price for night?");
        }

        [Test, Order(4)]
        public void test4()
        {

            IReportMng.IReporter.CreatTest("ParaBank site, Creat new acount 2");

            IWebElement RestfulBooker = actions.SearchElementByText(autoPanda.DemoSiteList, "Restful Booker");
            actions.ScrollToView(RestfulBooker, "ParaBank");
            actions.ClickOnElement(RestfulBooker, "ParaBankButton");

            paraBank_flow.LogIn("shay", "1234");
        }


    }
}
