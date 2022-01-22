﻿
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using FinalProject.BaseActions;
using FinalProject.Flows;
using FinalProject.PageObject;
using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Test = AventStack.ExtentReports.Model.Test;

namespace FinalProject.Utilities
{



    
     
    [TestFixture("Chrome")]
    [Parallelizable]
    //   [TestFixture("MicrosoftEdge")]
    public class RunTests : ConfigurationDrivers
    {
        

        public RunTests(string browser) :base(browser)
        {
            
            
        }

        [Test, Order(1)]
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

            paraBank_flow.LogIn("Shaymizrahi2", "Liat0548013506");

            actions.Validation("Shaymizrahi2", "Shaymizrahi2", "UserName");
            actions.Validation("Liat0548013506", "Liat0548013506", "Password");
        }

    //    [Test, Order(3)]
        public void test3()
        {

            IReportMng.IReporter.CreatTest("3) ParaBank site, Creat new acount 2");

            IWebElement RestfulBooker = actions.SearchElementByText(autoPanda.DemoSiteList, "Restful Booker");
            actions.ScrollToView(RestfulBooker, "ParaBank");
            actions.ClickOnElement(RestfulBooker, "ParaBankButton");

            paraBank_flow.LogIn("shay", "1234");

        }

        
       
    }
}
