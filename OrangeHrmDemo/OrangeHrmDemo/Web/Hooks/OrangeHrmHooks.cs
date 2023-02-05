
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

        private static ExtentReports extent;
        private static ExtentTest test;
        private readonly IObjectContainer objectContainer;
        private IWebDriver driver;

        static OrangeHrmHooks()
        {

            extent = ExtentReportsHelper.IntializeExtentReports("Web\\Reports\\htmlReport.html", "Orange Hrm Test Automation Report");

        }
        public OrangeHrmHooks(IObjectContainer objectContainer)
        {

            this.objectContainer = objectContainer;

        }

        [BeforeFeature]
        public static void RunBeforeFeature(FeatureContext featureContext)
        {

            test = extent.CreateTest(featureContext.FeatureInfo.Title);

        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {

            driver = WebBrowserHelper.SetUpBrowser(config.BrowserName);

            objectContainer.RegisterInstanceAs(driver);

            ExtentTest node = test.CreateNode(scenarioContext.ScenarioInfo.Title);

            objectContainer.RegisterInstanceAs(node);

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
