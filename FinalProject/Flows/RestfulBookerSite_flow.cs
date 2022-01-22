using FinalProject.BaseActions;
using FinalProject.PageObject;
using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.Flows
{
    public class RestfulBookerSite_flow
    {
        public IWebDriver driver;
        public RestfulBooker restfulBooker;
        public Actions actions;
 

        public RestfulBookerSite_flow(IWebDriver driver, RestfulBooker restfulBooker, Actions actions)
        {
            this.driver = driver;
            this.restfulBooker = restfulBooker;
            this.actions = actions;
        }

        public  void Rooms_Signup(string inputName, string inputEmail, string ImputPhone, string InputSubject, string InputDescription)
        {
            IReportMng.IReporter.WriteToLog(IReportUtil.Status.Info, "fill-up Rooms_Signup fields".ToUpper());
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
