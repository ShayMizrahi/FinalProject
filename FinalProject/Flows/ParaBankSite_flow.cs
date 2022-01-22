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
    public class ParaBankSite_flow
    {
        public IWebDriver driver;
        public ParaBank paraBank;
        public Actions actions;
 

        public ParaBankSite_flow(IWebDriver driver, ParaBank paraBank, Actions actions)
        {
            this.driver = driver;
            this.paraBank = paraBank;
            this.actions = actions;
        }

        public  void LogIn(string inputUserName, string inputPassword)
        {
            // input userName
            actions.UpdateText(paraBank.Username, inputUserName, "Username");
            // input password
            actions.UpdateText(paraBank.Password, inputPassword, "Password");
            // click on login button
            actions.ClickOnElement(paraBank.LogInButton, "LogInButton");
            // Get output Result
           string TitleOutput = paraBank.Title_OutputResult.Text;
           string ContentOutput = paraBank.Content_OutputResult.Text;
            // write to the log the output result of login
            IReportMng.IReporter.WriteToLog(IReportUtil.Status.Info, "The result after typing username and password Title: '" + TitleOutput + "'  Content: '" + ContentOutput + "'");
        }

        public  void Register(string InputFirstName, string InputLastName, 
            string InputAddress, string InputCity, string InputState, int InputZipCode, int InputPhoneNumber,
            int InputSsn, string InputUserName, string InputPassword, string InputRepeatedPassword)
        {
            // click on Register Button 
            actions.ClickOnElement(paraBank.RegisterButton, "RegisterButton");
            // Fill the fields
            actions.UpdateText(paraBank.FirstNameField, InputFirstName, "FirstNameField");
            actions.UpdateText(paraBank.LastNameField, InputLastName, "LastNameField");
            actions.UpdateText(paraBank.AddressField, InputAddress, "AddressField");
            actions.UpdateText(paraBank.CityField, InputCity, "CityField");
            actions.UpdateText(paraBank.StateField, InputState, "StateField");
            actions.UpdateText(paraBank.ZipCodeField, InputZipCode.ToString(), "ZipCodeField");
            actions.UpdateText(paraBank.PhoneNumberField, InputPhoneNumber.ToString(), "PhoneNumberField");
            actions.UpdateText(paraBank.SsnField, InputPhoneNumber.ToString(), "SsnField");

            actions.UpdateText(paraBank.UsernameField, InputUserName, "UsernameField");
            actions.UpdateText(paraBank.PasswordField, InputPassword, "RepeatedPasswordField");
            actions.UpdateText(paraBank.RepeatedPasswordField, InputRepeatedPassword, "RepeatedPasswordField");
            // Click on Register button
            actions.ClickOnElement(paraBank.ConfirmButton, "ConfirmButton");
        }

    }
}
