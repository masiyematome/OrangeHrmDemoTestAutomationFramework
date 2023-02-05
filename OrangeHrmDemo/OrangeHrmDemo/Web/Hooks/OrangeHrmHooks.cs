
using AventStack.ExtentReports;
using BoDi;
using OpenQA.Selenium;
using OrangeHrmDemo.Web.resources;
using OrangeHrmDemo.Web.Utilities;
using TechTalk.SpecFlow;

namespace OrangeHrmDemo.Web.Hooks
{

    [Binding]
    public class OrangeHrmHooks
    {

        private static readonly ExtentReports extent;
        private static IObjectContainer globalContainer;
        private IWebDriver driver;

        static OrangeHrmHooks()
        {

            extent = ExtentReportsHelper.IntializeExtentReports("Web\\Reports\\htmlReport.html", "Orange Hrm Test Automation Report");

        }

        [BeforeFeature]
        public static void RunBeforeFeature(IObjectContainer objectContainer, FeatureContext featureContext)
        {

            ExtentTest test = extent.CreateTest(featureContext.FeatureInfo.Title);

            objectContainer.RegisterInstanceAs(test);

            globalContainer = objectContainer;
            
        }

        [BeforeScenario]
        public void BeforeScenario(ExtentTest test,ScenarioContext scenarioContext)
        {

            driver = WebBrowserHelper.SetUpBrowser(config.BrowserName);

            globalContainer.RegisterInstanceAs(driver);

            ExtentTest node = test.CreateNode(scenarioContext.ScenarioInfo.Title);

            globalContainer.RegisterInstanceAs(node);

        }

        [AfterScenario]
        public void AfterScenario()
        {

            driver.Quit();

        }

        [AfterFeature]
        public static void AfterFeature()
        {

            extent.Flush();

        }

    }

}
