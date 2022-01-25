
using FinalProject.Utilities.Reporting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;


namespace FinalProject.Utilities
{

    [TestFixture("Chrome")]
    //[TestFixture("MicrosoftEdge")]
    public class RunTests2 : ConfigurationDrivers
    {

        public RunTests2(string browser) : base(browser)
        {

        }

        [Test, Order(2)]
        public void test2()
        {
            IReportMng.IReporter.CreatTest("Rest fulBooker site, send messege");

            IWebElement RestfulBooker = mng.actions.SearchElement(mng.autoPanda.DemoSiteList, "Restful Booker");
            mng.actions.ScrollToView(RestfulBooker, "RestfulBooker");
            mng.actions.ClickOnElement(RestfulBooker, "ParaBankButton");
            mng.actions.ScrollToView(mng.restfulBooker.NameField, "NameField");
            mng.restfulBooker_flow.Rooms_Signup("Shay Mizrahi", "shaymizrahi@gmail.com", "0548013506",
                "book room", "What is the price for night?");
        }

        [Test, Order(4)]
        public void test4()
        {
            IReportMng.IReporter.CreatTest("ParaBank site, Api testing");
            IWebElement ParaBank = mng.actions.SearchElement(mng.autoPanda.DemoSiteList, "ParaBank");
            mng.actions.ScrollToView(ParaBank, "ParaBank");
            mng.actions.ClickOnElement(ParaBank, "ParaBankButton");
            mng.paraBank_flow.Register("Shay", "Mizrahi", "Carmel 5",
                "Rehovot", "Israel", 765412, 0548013506, 2432);
            mng.paraBankApi_flow.api();
        }

    }
}
