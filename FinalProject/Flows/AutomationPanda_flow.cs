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
        public AutomationPanda autoPanda;
        public AutomationPanda_flow(BasicActions actions, IWebDriver driver, AutomationPanda autoPanda)
        {
            this.actions = actions;
            this.driver = driver;
            this.autoPanda = autoPanda;
        }
        public void OpenSite(string websiteName)
        {
            IReportMng.IReporter.CreatNode("Open webSite " + websiteName);
            IWebElement site = actions.SearchElement(autoPanda.DemoSiteList, websiteName, "web sites");
            actions.ScrollToView(site, websiteName);
            actions.ClickOnElement(site, websiteName);
        }
    }
}
