using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TestFramework.Config;
using TestFramework.Utilities.Helper;

namespace TestFramework.Utilities.Extensions
{
    public class WebDriverBase : BrowserSetUp
    {
        private IWebDriver driver;
        public WebDriverBase(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Method to Initialise browser with the help of framework settings and navigate to URL
        /// </summary>
        public IWebDriver OpenBrowser()
        {
            driver = BrowserSetUp.ConfigureBrowser();
            driver.Navigate().GoToUrl(Settings.URL);
            driver.Manage().Window.Maximize();
            return driver;
        }

        /// <summary>
        /// Method to close browser by quiting the webdriver instance
        /// </summary>
        public void CloseBrowser()
        {
            driver.Quit();
        }

        /// <summary>
        /// generic method to handle implicit wait 
        /// </summary>
        public void ImplicitWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
        }

        /// <summary>
        /// Method to find an element using any given locator after verifying visibility of element using explicit wait
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <param name="timeSpan"></param>
        public void ExplicitWait(string type, string value, int timeSpan)
        {
            if (type == "xpath")
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeSpan));
                wait.Until(ExpectedConditions.ElementIsVisible((By.XPath(value))));
            }
        }
    }
}
