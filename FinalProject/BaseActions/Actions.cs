using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.BaseActions
{
    public class Actions
    {
        public IWebDriver driver;
        public IJavaScriptExecutor js;
        public Actions(IWebDriver driver )
        {
            this.driver = driver;
        }
        public void ScrollTo(int xPosition = 0, int yPosition = 0)
        {
            try
            {
                js = (IJavaScriptExecutor)driver;
                var scrollTo = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
                js.ExecuteScript(scrollTo);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass, "Wab page was scrolled  successfuly,  X position: " + xPosition + " and Y position: " + yPosition);
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail, "Wab page faild to scroll, X position: " + xPosition + " and Y position: " + yPosition, e, driver);
            }

        }

        public void ScrollToView(IWebElement element, string elemName)
        {
            if (element.Location.Y > 200)
            {
                try
                {
                    js = (IJavaScriptExecutor)driver;
                    var scrollTo = String.Format("window.scrollTo({0}, {1})", 0, element.Location.Y - 100);
                    js.ExecuteScript(scrollTo);
                    IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass, "Wab page scrolled to element: " + elemName + " successfuly");
                }

                catch (Exception e)
                {
                    IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail, "Wab page faild to scroll to element: " + elemName, e, driver);
                }


            }
        }

        public  void ClickOnElement(IWebElement elem, string elemName)
        {
            try
            {
                elem.Click();
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass, "Element: " + elemName + " was clicked successfuly");
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail, "Faild to clicked on element: " + elemName, e, driver);
            }
        }

        public IWebElement SearchElementByText(IList<IWebElement> listElem, string inputText)
        {

            string elemText = null;
            IWebElement elem = null;

            try
            {


                for (int i = 0; i < listElem.Count; i++)
                {
                    elem = listElem[i];

                    elemText = elem.Text;

                    if (elemText.Equals(inputText))
                    {
                        IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass, "Selected element: " + elemText + " from list of elements was  found successfuly");
                        return elem;
                    }
                }
            }

            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail, "Selected element: " + elemText + " from list of elements was not found");
            }

           return elem;
        }

        public  void UpdateText(IWebElement elem,string inputText, string elemName)
        {
            try
            {
                elem.SendKeys(inputText);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass, "Text: " + inputText + " on element: " + elemName  + " was update successfuly");
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail, "Faild to update text: " + inputText + " on element: " + elemName, e, driver);
            }

           
        }

        public  void Validation(string ActualValue, string ExpectedValue, string Element)
        {
            try
            {
                Assert.AreEqual(ActualValue, ExpectedValue);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass, "The expected value: " + ExpectedValue + " and actual value: " + ActualValue + " are equal on element: " + Element);
            }
            catch(Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail, "The expected value: " + ExpectedValue + " and actual value: " + ActualValue + " are NOT equal" + " are equal on element: " + Element, e, driver);
            }
           
        }

    }
}
