using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TestFramework.Config;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestFramework.Utilities.Helper
{
    public class BrowserSetUp
    {
        public static IWebDriver webDriver;

        /// <summary>
        /// Method to select browser based on Framework settings
        /// </summary>
        public static IWebDriver ConfigureBrowser()
        {

            switch (Settings.BrowserType)
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    //ChromeOptions chromeOptions = new ChromeOptions();
                    //chromeOptions.AddArgument("--headless");
                    webDriver = new ChromeDriver();

                    break;
                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    webDriver = new FirefoxDriver();
                    break;
            }
            return webDriver;
        }
    }
}
