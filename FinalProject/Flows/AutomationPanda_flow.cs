using FinalProject.BaseActions;
using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using OpenQA.Selenium;


namespace FinalProject.Flows
{
    public class AutomationPanda_flow
    {
        public BasicActions actions;
        public IWebDriver driver;
        public AutomationPanda autoPanda2;
        public AutomationPanda_flow(BasicActions actions, IWebDriver driver, AutomationPanda autoPanda2)
        {
            this.actions = actions;
            this.driver = driver;
            this.autoPanda2 = autoPanda2;
        }
        public void OpenSite(string websiteName)
        {
            IReportMng.IReporter.CreatNode("Open webSite " + websiteName);
            IWebElement site = actions.SearchElement(autoPanda2.DemoSiteList, websiteName, "web sites");
            actions.ScrollToView(site, websiteName);
            actions.ClickOnElement(site, websiteName);
        }
    }
}
