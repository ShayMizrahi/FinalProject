using FinalProject.BaseActions;
using FinalProject.PageObject;
using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
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
        public Dictionary<string, string> listOfAcount = new Dictionary<string, string>();
        public double CalculateTotal;


        public ParaBankSite_flow(IWebDriver driver, ParaBank paraBank, BasicActions actions)
        {
            this.driver = driver;
            this.paraBank = paraBank;
            this.actions = actions;
        }

        public void LogIn()
        {
            try
            {
                IReportMng.IReporter.CreatNode("Fill-up logIn fields");
                
                // input userName
                actions.UpdateText(paraBank.Username, newUserName, "Username");
                // input password
                actions.UpdateText(paraBank.Password, newPassword, "Password");
                // click on login button
                actions.ClickOnElement(paraBank.LogInButton, "LogInButton");

                ReadAcountsOverview(0, 1);
            }
            catch(Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail, "Failed to log in", e, driver);
            }
            

        }

        public void Register(string InputFirstName, string InputLastName,
            string InputAddress, string InputCity, string InputState, int InputZipCode, int InputPhoneNumber,
            int InputSsn)
        {
            try
            {
                IReportMng.IReporter.CreatNode("Fill-up Register fields");
               
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
            catch(Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail, "Failed to register", e, driver);
            }
        }

        public void CreatNewAcount(int InputTypeIndex, int InputFromAccountIndex, int roundIndex)
        {
            try
            {
                IReportMng.IReporter.CreatNode("Create new acount " + roundIndex);
                
                var OpenNewAcount = actions.SearchElement(paraBank.AcountServicesList, "Open New Account", "acount services");
                actions.ClickOnElement(OpenNewAcount, "OpenNewAcount");
                actions.SelectFromComboBox(paraBank.Type_ComboBox, InputTypeIndex);
                actions.SelectFromComboBox(paraBank.FromAccount_ComboBox, InputFromAccountIndex);

                //     WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                //     wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("fromAccountId']")));

                Thread.Sleep(500);
                actions.ClickOnElement(paraBank.OpenNewAcountButton, "OpenNewAcountButton");

                string TitleOutput = paraBank.TitleAfterCreatNewAcount_OutputResult.Text;
                string ContentOutput1 = paraBank.ContentAfterCreatNewAcount1_OutputResult.Text;

                actions.Validation(TitleOutput, "Account Opened!", "TitleOutput");
                actions.Validation(ContentOutput1, "Congratulations, your account is now open.", "ContentOutput1");

                listOfAcount.Add(paraBank.newAccountId.Text, "");
            }
            catch(Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail, "Failed to creat new acount", e, driver);
            }

        }

        public void ReadAcountsOverview(int InputCell, int InputNumberOfRuns)
        {
            

            for (int i=0; i< InputNumberOfRuns; i++)
            {
                var Cell = paraBank.selectRow[i].FindElement(By.CssSelector("td:nth-child(1)")).Text;
                bool isValueExist = listOfAcount.Equals(Cell);
                if (!isValueExist) 
                {
                    var BalanceCell = paraBank.selectRow[i].FindElement(By.CssSelector("td:nth-child(2)")).Text;
                    listOfAcount.Add(Cell, BalanceCell);
                }
                
            }
            
        }

        public void CheckingAmountOfAcountsAreExist_AcountsOverview()
        {
            IReportMng.IReporter.CreatNode("Checking the amount of acounts that exist");
            
            var AccountsOverview = actions.SearchElement(paraBank.AcountServicesList, "Accounts Overview", "AcountServices");
            actions.ClickOnElement(AccountsOverview, "OpenNewAcount");
            Thread.Sleep(1500);
           

            var HowManyAcountsExsistInTheList = listOfAcount.Count;
            var HowManyAcountsExsistInTheTable = paraBank.selectRow.Count -1;

            actions.Validation(HowManyAcountsExsistInTheList.ToString(), HowManyAcountsExsistInTheTable.ToString(), "Amount Of Acounts");
        }

        public void CalculateAcountsOverview()
        {
            IReportMng.IReporter.CreatNode("Calculate acounts overview");

            var HowManyAcountsExsistInTheTable = paraBank.selectRow.Count - 1;

            for (int i = 0; i < HowManyAcountsExsistInTheTable; i++)
            {
                var Cell = paraBank.selectRow[i].FindElement(By.CssSelector("td:nth-child(2)")).Text;
                string striptCell = Cell.Substring(1);
                double CellAsDouble = double.Parse(striptCell);

                CalculateTotal +=  +CellAsDouble;

            }
            var ActualToTal = paraBank.selectRow[HowManyAcountsExsistInTheTable].FindElement(By.CssSelector("td:nth-child(2)")).Text;
            string striptActualToTal = ActualToTal.Substring(1);
            double ActualToTalAsDouble = double.Parse(striptActualToTal);

            actions.Validation(ActualToTalAsDouble.ToString(), CalculateTotal.ToString(), "Calculate balance");

        }

        public void logOut()
        {
            IReportMng.IReporter.CreatNode("log-out");
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



