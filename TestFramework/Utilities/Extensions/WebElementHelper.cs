using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using TestFramework.Utilities.Helper;

namespace TestFramework.Utilities.Extensions
{
    public static class WebElementHelper
    {
        /// <summary>
        /// Method to select item from dropdown
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SelectDropDownList(this IWebElement element, string value)
        {
            try
            {
                SelectElement el = new SelectElement(element);
                el.SelectByText(value);
            }
            catch (Exception)
            {
                throw new Exception("DropDown Selection Failed");
            }
        }

        /// <summary>
        /// Method to Assert element is present
        /// </summary>
        /// <param name="element"></param>
        public static void AsserElementIsPresent(this IWebElement element)
        {
            if (!IsElementPresent(element))
                throw new Exception(("Element not Present Exeption"));
        }

        private static bool IsElementPresent(IWebElement element)
        {
            try
            {
                bool el=false;
                if (element.Displayed)
                {
                   el=true;
                }
                return el;
            }
            catch (Exception)
            {
                return false;

            }
        }

        /// <summary>
        /// Method to hover over an element
        /// </summary>
        /// <param name="element"></param>
        public static void Hover(this IWebElement element,IWebDriver driver)
        {
            try
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(element).Perform();
                //LogHelpers.WriteToFile("Hover over to ", element.ToString(), "is Successful");
            }
            catch (Exception)
            {
                //LogHelpers.WriteToFile("Hover over to ", element.ToString(), "is not Successful");
                throw new Exception(("Action Cannot be performed"));

            }
        }
    }
}
