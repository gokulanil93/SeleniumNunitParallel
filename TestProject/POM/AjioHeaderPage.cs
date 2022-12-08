using OpenQA.Selenium;
using TestFramework.Utilities.Extensions;

namespace TestProject.POM
{
    public class AjioHeaderPage : WebDriverHelper
    {
        private readonly IWebDriver driver;
        public AjioHeaderPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        private IWebElement LnkMen => FindElemntByxpath("//a[@title='MEN']");
        private IWebElement LnkClothing => FindElemntByxpath("//li[contains(@data-test,'li-MEN')]//span[contains(text(),'CLOTHING')]");

        /// <summary>
        /// Method to select clothing from under Men section from Header
        /// </summary>
        public void SelectClothing()
        {
            WebElementHelper.Hover(LnkMen, driver);
            LnkClothing.Click();
        }
    }
}
