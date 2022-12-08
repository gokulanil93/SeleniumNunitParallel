using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using TestFramework.Utilities.Helper;
using TestFramework.Utilities.Hooks;

namespace TestFramework.Utilities.Extensions
{
    public class WebDriverHelper : WebDriverBase

    {
        private readonly IWebDriver driver;
        public WebDriverHelper(IWebDriver driver):base(driver)
        {
            this.driver = driver;
        }
        /// <summary>
        /// Method to find element using Xpath
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public IWebElement FindElemntByxpath(string element)
        {
            try
            {
                ExplicitWait("xpath", element, 20);
                var a = driver.FindElement(By.XPath(element));
                //LogHelpers.WriteToFile("Element Identification of", element, "Successful");
                
                return a;
            }
            catch (Exception)
            {
                //LogHelpers.WriteToFile("Element Identification of", element, "Failed");
                throw new ElementNotVisibleException($"Element not found : {element}");
            }

        }

        /// <summary>
        /// Method to take screenshot
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="screenShotName"></param>
        /// <returns></returns>
        public static MediaEntityModelProvider Capture(IWebDriver driver, string screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
        }
    }
}
