using FinalProject.BaseActions;
using FinalProject.PageObject;
using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using OpenQA.Selenium;

namespace FinalProject.Flows
{
    public class RestfulBookerSite_flow
    {
        public IWebDriver driver;
        public RestfulBooker restfulBooker;
        public BasicActions actions;
 

        public RestfulBookerSite_flow(IWebDriver driver, RestfulBooker restfulBooker, BasicActions actions)
        {
            this.driver = driver;
            this.restfulBooker = restfulBooker;
            this.actions = actions;
        }

        public  void Rooms_Signup(string inputName, string inputEmail, string ImputPhone, string InputSubject, string InputDescription)
        {
            IReportMng.IReporter.CreatNode("Fill-up Rooms_Signup fields");
            
            // input name
            actions.UpdateText(restfulBooker.NameField, inputName, "NameField");
            // input emali
            actions.UpdateText(restfulBooker.EmailField, inputEmail, "EmailField");
            // input phone
            actions.UpdateText(restfulBooker.PhoneField, ImputPhone, "PhoneField");
            // input subject
            actions.UpdateText(restfulBooker.SubjectField, InputSubject, "SubjectField");
            // input description
            actions.UpdateText(restfulBooker.DescriptionField, InputDescription, "DescriptionField");
            // click on submit button
            actions.ClickOnElement(restfulBooker.SubmitButton, "SubmitButton");
  
        }

      
    }
}
