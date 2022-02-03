using FinalProject.BaseActions;
using FinalProject.Flows;
using FinalProject.PageObject;
using OpenQA.Selenium;

namespace FinalProject.Utilities
{
    public class ManagePages
    {
        public IWebDriver driver;
        public BaseActions.BasicActions actions;
        public BaseActions.RestApi restSharp;
        public AutomationPanda autoPanda;
        public ParaBank paraBank;
        public ParaBankSite_flow paraBank_flow;
        public ParaBankApi_flow paraBankApi_flow;
        public RestfulBooker restfulBooker;
        public RestfulBookerSite_flow restfulBooker_flow;
        public Demoblaze demoblaze;
        public DemoblazeSite_flow demoblaze_flow;
        public AutomationPanda_flow autopanda_flow;
        public SwagLabs swagLabs;
        public SwagLabs_flow swagLabs_flow;

        public ExtentReportUtil reporter;

        public ManagePages(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void InitClasses()
        {

            actions = new BaseActions.BasicActions(driver);
            restSharp = new RestApi(driver);
            autoPanda = new AutomationPanda(driver);
            autopanda_flow = new AutomationPanda_flow(actions, driver, autoPanda);

            paraBank = new ParaBank(driver);
            paraBank_flow = new ParaBankSite_flow(driver, paraBank, actions);
            paraBankApi_flow = new ParaBankApi_flow(driver, restSharp, actions);

            restfulBooker = new RestfulBooker(driver);
            restfulBooker_flow = new RestfulBookerSite_flow(driver, restfulBooker, actions);

            demoblaze = new Demoblaze(driver);
            demoblaze_flow = new DemoblazeSite_flow(driver, demoblaze, actions);

            swagLabs = new SwagLabs(driver);
            swagLabs_flow = new SwagLabs_flow(driver, swagLabs, actions);

        }
    }
}
