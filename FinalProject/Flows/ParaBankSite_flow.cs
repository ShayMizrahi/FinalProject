using FinalProject.BaseActions;
using FinalProject.PageObject;
using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using OpenQA.Selenium;
using System;
using System.Threading;



namespace FinalProject.Flows
{
    public class ParaBankSite_flow
    {
        public IWebDriver driver;
        public ParaBank paraBank;
        public BasicActions actions;
        public static string newPassword;
        public static string newUserName;
        public Random rendom = new Random();




        public ParaBankSite_flow(IWebDriver driver, ParaBank paraBank, BasicActions actions)
        {
            this.driver = driver;
            this.paraBank = paraBank;
            this.actions = actions;
        }

        public void LogIn()
        {
            IReportMng.IReporter.WriteToLog(IReportUtil.Status.Info, "fill-up logIn fields".ToUpper());
            // input userName
            actions.UpdateText(paraBank.Username, newUserName, "Username");
            // input password
            actions.UpdateText(paraBank.Password, newPassword, "Password");
            // click on login button
            actions.ClickOnElement(paraBank.LogInButton, "LogInButton");
            // Get output Result
            string TitleOutput = paraBank.Title_OutputResult.Text;
            string ContentOutput = paraBank.Content_OutputResult.Text;
            // write to the log the output result of login
            IReportMng.IReporter.WriteToLog(IReportUtil.Status.Info, "The result after typing username and password. Title: '" + TitleOutput + "'  Content: '" + ContentOutput + "'");
        }

        public void Register(string InputFirstName, string InputLastName,
            string InputAddress, string InputCity, string InputState, int InputZipCode, int InputPhoneNumber,
            int InputSsn)
        {
            IReportMng.IReporter.WriteToLog(IReportUtil.Status.Info, "fill-up Register fields".ToUpper());
            // click on Register Button 
            actions.ClickOnElement(paraBank.RegisterButton, "RegisterButton");
            newPassword = CreatNewPassword();
            newUserName = CreatNewPassword();
            // Fill the fields
            actions.UpdateText(paraBank.FirstNameField, InputFirstName, "FirstNameField");
            actions.UpdateText(paraBank.LastNameField, InputLastName, "LastNameField");
            actions.UpdateText(paraBank.AddressField, InputAddress, "AddressField");
            actions.UpdateText(paraBank.CityField, InputCity, "CityField");
            actions.UpdateText(paraBank.StateField, InputState, "StateField");
            actions.UpdateText(paraBank.ZipCodeField, InputZipCode.ToString(), "ZipCodeField");
            actions.UpdateText(paraBank.PhoneNumberField, InputPhoneNumber.ToString(), "PhoneNumberField");
            actions.UpdateText(paraBank.SsnField, InputPhoneNumber.ToString(), "SsnField");
            actions.UpdateText(paraBank.UsernameField, newUserName, "UsernameField");
            actions.UpdateText(paraBank.PasswordField, newPassword, "RepeatedPasswordField");
            actions.UpdateText(paraBank.RepeatedPasswordField, newPassword, "RepeatedPasswordField");
            Thread.Sleep(1000);

            // Click on Register button
            actions.ClickOnElement(paraBank.ConfirmButton, "ConfirmButton");

            // Get output Result
            string TitleOutput = paraBank.Title_OutputResult.Text;
            string ContentOutput = paraBank.Content_OutputResult.Text;
            actions.Validation(TitleOutput, "Welcome " + newUserName, "TitleOutput");
            actions.Validation(ContentOutput, "Your account was created successfully. You are now logged in.", "ContentOutput");

        }

        public void logOut()
        {
            actions.ClickOnElement(paraBank.logOut, "logOut");
        }

        public string CreatNewPassword()
        {
            string newPassword = null;
            string Charcters = "abcdefghijklmnopqrstuvwxyz123456789";

            for (int i = 0; i < 8; i++)
            {
                int rendomNumber = rendom.Next(1, 31);
                char selectedChar = Charcters[rendomNumber];
                newPassword += selectedChar.ToString();
            }

            return newPassword;


        }

    }



}



