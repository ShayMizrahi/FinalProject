using FinalProject.Utilities;
using FinalProject.Utilities.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace FinalProject.BaseActions
{
    public class BasicActions
    {
        public IWebDriver driver;
        public IJavaScriptExecutor js;
        public SelectElement SelectAnEducation;
        public BasicActions(IWebDriver driver)
        {
            this.driver = driver;
        }

        #region Click methods
        /// <summary>
        /// Click on element 
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="elemName"></param>
        public void ClickOnElement(IWebElement elem, string elemName)
        {
            try
            {
                elem.Click();
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                    "Element: " + elemName + " was clicked successfuly");
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "Failed to clicked on element: " + elemName, e, driver);
            }
        }
        #endregion

        #region Update text methods
        /// <summary>
        /// Input text to element 
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="inputText"></param>
        /// <param name="elemName"></param>
        public void UpdateText(IWebElement elem, string inputText, string elemName)
        {
            try
            {
                elem.SendKeys(inputText);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                    "Text: " + inputText + " on element: " + elemName + " was updated successfuly");
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "Failed to update text: " + inputText + " on element: " + elemName, e, driver);
            }

        }
        #endregion

        #region Validation methods
        /// <summary>
        /// Validate that Expected value is equal to Actual value
        /// </summary>
        /// <param name="ActualValue"></param>
        /// <param name="ExpectedValue"></param>
        /// <param name="Element"></param>
        public void Validation(string ActualValue, string ExpectedValue, string Element)
        {
            try
            {
                Assert.AreEqual(ActualValue, ExpectedValue);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                    "The expected value: " + ExpectedValue + " and actual value: " + ActualValue +
                    " are equal for element: " + Element);
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Error,
                    "The expected value: " + ExpectedValue + " and actual value: " + ActualValue +
                    " are NOT equal for element: " + Element, e, driver);
            }

        }
        #endregion

        #region Search methods
        /// <summary>
        /// Search element from list of elements
        /// Two way to search:
        /// 1 find element by text
        /// 2 find element by index
        /// </summary>
        /// <param name="listElem"></param>
        /// <param name="inputText"></param>
        /// <returns></returns>
        public IWebElement SearchElement(IList<IWebElement> listElem, string inputText)
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
                        IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                            "Selected element: " + elemText + " from list of elements was found successfuly");
                        return elem;
                    }
                }
            }

            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "Selected element: " + elemText + " from list of elements was not found", e, driver);
            }

            return elem;
        }

        public IWebElement SearchElement(IList<IWebElement> listElem, int inputIndex)
        {
            IWebElement selectedElement = null;
            try
            {
                selectedElement = listElem[inputIndex];

                if (selectedElement != null)
                {
                    IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                        "Selected element by index: " + inputIndex + " from list of elements was found successfuly");
                    return selectedElement;
                }
            }


            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "Selected element by index: " + inputIndex + " from list of elements was not found", e, driver);
            }

            return selectedElement;
        }

        #endregion

        #region Select methods
        /// <summary>
        /// Select from combobox with index or text
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="selectByIndex"></param>
        public void SelectFromComboBox(IWebElement elem, int selectByIndex)
        {
            try
            {
                SelectAnEducation = new SelectElement(elem);
                SelectAnEducation.SelectByIndex(selectByIndex);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                    "Element by index: " + selectByIndex + " from element" + elem.Text + " was selected successfuly");
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "Element by index: " + selectByIndex + " from element" + elem.Text + " was NOT selected", e, driver);
            }

        }

        public void SelectFromComboBox(IWebElement elem, string selectByText)
        {
            try
            {
                SelectAnEducation = new SelectElement(elem);
                SelectAnEducation.SelectByText(selectByText);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                    "Element with text: " + selectByText + " from element" + elem + " was selected successfuly");
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "Element by text: " + selectByText + " from element" + elem + " was NOT selected", e, driver);
            }

        }

        #endregion

        #region Scroll methods
        /// <summary>
        /// Scroll web page with two ways:
        /// 1 Scroll to element
        /// 2 Scroll by X position and Y position
        /// </summary>
        /// <param name="xPosition"></param>
        /// <param name="yPosition"></param>
        public void ScrollTo(int xPosition = 0, int yPosition = 0)
        {
            try
            {
                js = (IJavaScriptExecutor)driver;
                var scrollTo = String.Format("window.scrollTo({0}, {1})", xPosition, yPosition);
                js.ExecuteScript(scrollTo);
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                    "Web page was scrolled successfuly,  X position: " + xPosition + " and Y position: " + yPosition);
            }
            catch (Exception e)
            {
                IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                    "Web page failed to scroll, X position: " + xPosition + " and Y position: " + yPosition, e, driver);
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
                    IReportMng.IReporter.WriteToLog(IReportUtil.Status.Pass,
                        "Web page scrolled to element: " + elemName + " successfuly");
                }

                catch (Exception e)
                {
                    IReportMng.IReporter.WriteToLog(IReportUtil.Status.Fail,
                        "Web page failed to scroll to element: " + elemName, e, driver);
                }


            }
        }

        #endregion
    }
}
