
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
  //  [TestFixture("MicrosoftEdge")]
    public class RunTests : ConfigurationDrivers
    {
        public Random rendom = new Random();
        public int selectNumber;
        public int Round;


        public RunTests(string browser) : base(browser)
        {


        }

    //    [Test, Order(1)]
        public void test1()
        {
            IReportMng.IReporter.CreatTest("ParaBank site, Creat new acount ");
            mng.autopanda_flow.OpenSite("ParaBank");
           
            Thread.Sleep(300);
            mng.paraBank_flow.Register("Shay", "Mizrahi", "Carmel 5 st.",
                "Rehovot", "Israel", 765412, 0548013506, 2432);
            Thread.Sleep(300);
            mng.paraBank_flow.logOut();
            mng.paraBank_flow.LogIn();
            int randomNumber = rendom.Next(1, 4);
            for (int i = 0; i < randomNumber; i++)
            {
                mng.paraBank_flow.CreatNewAcount(1, 0, i+1);
            }
            mng.paraBank_flow.CheckingAmountOfAcountsAreExist_AcountsOverview();
            mng.paraBank_flow.CalculateAcountsOverview();



        }

 //       [Test, Order(3)]
        public void test3()
        {

            IReportMng.IReporter.CreatTest("Demoblaze site, Select item and add to cart");
            mng.autopanda_flow.OpenSite("Demoblaze");
            
            selectNumber = rendom.Next(1, 7);

            for (int i = 0; i < selectNumber; i++)
            {
                Round++;
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Info, "Round: " + Round);

                // select random category and item
                mng.demoblaze_flow.SelectCategory();
                mng.demoblaze_flow.SelectRandomItemFromCategory();
                mng.demoblaze_flow.CheckoutAndValidateTheItem(true);
            }

            // go to cart validate the total price and buy the items  
            mng.demoblaze_flow.GoToCartValidateTotalPriceAndBuy();
        }



    }
}
