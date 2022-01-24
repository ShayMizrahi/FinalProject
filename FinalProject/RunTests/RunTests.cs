
using FinalProject.Utilities.Reporting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.Threading;
using Test = AventStack.ExtentReports.Model.Test;

namespace FinalProject.Utilities
{

    [TestFixture("Chrome")]
 // [TestFixture("MicrosoftEdge")]
    public class RunTests : ConfigurationDrivers
    {
        public Random rendom = new Random();
        public int selectNumber;
        public int Round;


        public RunTests(string browser) : base(browser)
        {


        }

        [Test, Order(1)]
        public void test1()
        {
            IReportMng.IReporter.CreatTest("ParaBank site, Creat new acount ");
            IWebElement ParaBank = mng.actions.SearchElement(mng.autoPanda.DemoSiteList, "ParaBank");
            mng.actions.ScrollToView(ParaBank, "ParaBank");
            mng.actions.ClickOnElement(ParaBank, "ParaBankButton");

            Thread.Sleep(300);
            mng.paraBank_flow.Register("Shay", "Mizrahi", "Carmel 5 st.",
                "Rehovot", "Israel", 765412, 0548013506, 2432);
            Thread.Sleep(300);
            mng.paraBank_flow.logOut();
            mng.paraBank_flow.LogIn();


        }

        [Test, Order(3)]
        public void test3()
        {

            IReportMng.IReporter.CreatTest("Demoblaze site, Select item and add to cart");

            IWebElement Demoblaze = mng.actions.SearchElement(mng.demoblaze.DemoSiteList, "Demoblaze");
            mng.actions.ScrollToView(Demoblaze, "Demoblaze");
            mng.actions.ClickOnElement(Demoblaze, "DemoblazeButton");

            selectNumber = rendom.Next(1, 7);

            for (int i = 0; i < selectNumber; i++)
            {
                Round++;
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Info, "Round: " + Round);

                // select random category and item
                mng.demoblaze_flow.SelectCategory();
                mng.demoblaze_flow.selectRendomItemFromCategory();
                mng.demoblaze_flow.chackoutAndValidateTheItem(true);
            }

            // go to cart validate the total price and buy the items  
            mng.demoblaze_flow.GoToCartValidateTotalPriceAndBuy();
        }



    }
}
