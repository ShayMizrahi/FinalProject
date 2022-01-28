using OpenQA.Selenium;

namespace FinalProject.Flows
{
    internal class SelectElement
    {
        private IWebElement type_ComboBox;

        public SelectElement(IWebElement type_ComboBox)
        {
            this.type_ComboBox = type_ComboBox;
        }
    }
}