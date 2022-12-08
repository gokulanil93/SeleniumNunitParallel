using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;
using TestFramework.Config;
using TestFramework.Utilities.Extensions;

namespace TestFramework.Utilities.Hooks
{
    [SetUpFixture]
    public class HooksClass
    {
        public ExtentTest _test;
        public string filePath;
        public static ExtentReports _extent = new ExtentReports();
        public IWebDriver driver;


        [OneTimeSetUp]
        public void Setup()
        {
            ConfigReader.SetFrameworkSettings();

            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + "Reports\\ExtentReport.html";

            //Directory.CreateDirectory(projectPath.ToString() + "Log");
            //filePath = projectPath + "Log\\Logger.log";

            var htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            _extent.AttachReporter(htmlReporter);
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "Gokul");
        }

        [SetUp]
        public void InItWebDriver()
        {
            WebDriverBase webDriverBase = new WebDriverBase(driver);
            driver = webDriverBase.OpenBrowser();
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);

        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _extent.Flush();
        }

        [TearDown]
        public void QuitBrowser()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;
            var message = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                    _test.Fail("Test Failed " + message, WebDriverHelper.Capture(driver, fileName));
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            //foreach (string el in LogHelpers.Log(filePath))
            //{
            //    if (el.EndsWith("Successful"))
            //    {
            //        _test.Pass("Step Details  " + el);
            //    }
            //    else
            //        _test.Fail("Step Details  " + el);

            //}
            _test.Log(logstatus, "Test ended with " + logstatus + message + stacktrace);
            //LogHelpers.WriteToFile(TestContext.CurrentContext.Test.Name.ToString(), logstatus.ToString(), message + stacktrace);
            //File.Create(filePath).Close();
            WebDriverBase webDriverBase = new WebDriverBase(driver);
            webDriverBase.CloseBrowser();
            _extent.Flush();
        }
    }
}
