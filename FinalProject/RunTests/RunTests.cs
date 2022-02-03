
using FinalProject.Utilities.Reporting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using Test = AventStack.ExtentReports.Model.Test;

namespace FinalProject.Utilities
{
    [TestFixture("Chrome")]
 //   [TestFixture("Firefox")]
  //  [TestFixture("MicrosoftEdge")]
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
            IReportMng.IReporter.CreatTest("ParaBank site, Creat new acount  / Run with: " + ConfigurationDrivers._browser);
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
                mng.paraBank_flow.CreatNewAcount(1, 0, i + 1);
            }
            mng.paraBank_flow.CheckingAmountOfAcountsAreExist_AcountsOverview();
            mng.paraBank_flow.CalculateAcountsOverview();



        }

       [Test, Order(3)]
        public void test3()
        {

            IReportMng.IReporter.CreatTest("Demoblaze site, Select item and add to cart / Run with: " + ConfigurationDrivers._browser);
            mng.autopanda_flow.OpenSite("Demoblaze");

            selectNumber = rendom.Next(1, 7);

            for (int i = 0; i < selectNumber; i++)
            {
                Round++;

                // select random category and item
                mng.demoblaze_flow.SelectCategory(Round);
                mng.demoblaze_flow.SelectRandomItemFromCategory(Round);
                mng.demoblaze_flow.CheckoutAndValidateTheItem(true, Round);
            }

            // go to cart validate the total price and buy the items  
            mng.demoblaze_flow.GoToCartValidateTotalPriceAndBuy();
        }

        [Test, Order(5)]
        public void test4()
        {
            IReportMng.IReporter.CreatTest("Swag Labs site, Select item and add to cart / Run with: " + ConfigurationDrivers._browser);
            mng.autopanda_flow.OpenSite("Swag Labs");
            //checking wrong user name and password
            mng.swagLabs_flow.LogIn("Wrong username and password", "123456");
            //checking valid user name and password
            mng.swagLabs_flow.LogIn("valid username and password", "secret_sauce");
            //select item
            selectNumber = rendom.Next(1, 7);

            for (int i = 0; i < selectNumber; i++)
            {
                mng.swagLabs_flow.selectItem(i + 1);
            }

            mng.swagLabs_flow.checkout();


         }
        }
    }
