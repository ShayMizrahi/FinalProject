using FinalProject.BaseActions;
using FinalProject.PageObject;
using FinalProject.Utilities;
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
            Actions.UpdateText(Base.paraBank.Username, inputUserName, "Username");
            Actions.UpdateText(Base.paraBank.Password, inputPassword, "Password");
            Actions.ClickOnElement(Base.paraBank.LogInButton, "LogInButton");
        }
    }
}
