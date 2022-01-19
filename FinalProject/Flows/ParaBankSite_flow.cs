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
        public static void LogIn(string inputUserName, string inputPassword)
        {
            // input userName
            Actions.UpdateText(Base.paraBank.Username, inputUserName, "Username");
            // input password
            Actions.UpdateText(Base.paraBank.Password, inputPassword, "Password");
            // click on login button
            Actions.ClickOnElement(Base.paraBank.LogInButton, "LogInButton");
            // Get output Result
            string TitleOutput = Base.paraBank.Title_OutputResult.Text;
            string ContentOutput = Base.paraBank.Content_OutputResult.Text;
            // write to the log the output result of login
            ReportMgr.Reporter.WriteToLog(IReportUtil.Status.Info, "The result after typing username and password Title: '" + TitleOutput + "'  Content: '" + ContentOutput + "'");
        }

        public static void Register(string InputFirstName, string InputLastName, 
            string InputAddress, string InputCity, string InputState, int InputZipCode, int InputPhoneNumber,
            int InputSsn, string InputUserName, string InputPassword, string InputRepeatedPassword)
        {
            // click on Register Button 
            Actions.ClickOnElement(Base.paraBank.RegisterButton, "RegisterButton");
            // Fill the fields
            Actions.UpdateText(Base.paraBank.FirstNameField, InputFirstName, "FirstNameField");
            Actions.UpdateText(Base.paraBank.LastNameField, InputLastName, "LastNameField");
            Actions.UpdateText(Base.paraBank.AddressField, InputAddress, "AddressField");
            Actions.UpdateText(Base.paraBank.CityField, InputCity, "CityField");
            Actions.UpdateText(Base.paraBank.StateField, InputState, "StateField");
            Actions.UpdateText(Base.paraBank.ZipCodeField, InputZipCode.ToString(), "ZipCodeField");
            Actions.UpdateText(Base.paraBank.PhoneNumberField, InputPhoneNumber.ToString(), "PhoneNumberField");
            Actions.UpdateText(Base.paraBank.SsnField, InputPhoneNumber.ToString(), "SsnField");

            Actions.UpdateText(Base.paraBank.UsernameField, InputUserName, "UsernameField");
            Actions.UpdateText(Base.paraBank.PasswordField, InputPassword, "RepeatedPasswordField");
            Actions.UpdateText(Base.paraBank.RepeatedPasswordField, InputRepeatedPassword, "RepeatedPasswordField");
            // Click on Register button
            Actions.ClickOnElement(Base.paraBank.ConfirmButton, "ConfirmButton");
        }

    }
}
