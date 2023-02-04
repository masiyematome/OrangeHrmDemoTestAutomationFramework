
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

        private readonly IObjectContainer objectContainer;

        private ExtentReports extent;
        private ScenarioContext scenarioContext;
        private IWebDriver driver;

        public OrangeHrmHooks(IObjectContainer objectContainer,ScenarioContext scenarioContext)
        {

            this.objectContainer = objectContainer;
            this.scenarioContext = scenarioContext;
            extent = ExtentReportsHelper.IntializeExtentReports("Web\\Reports\\htmlReport.html", "Orange Hrm Test Automation Report");

        }

        [BeforeScenario]
        public void BeforeScenario()
        {

            driver = WebBrowserHelper.SetUpBrowser(config.BrowserName);

            objectContainer.RegisterInstanceAs(driver);

            ExtentTest test = extent.CreateTest(scenarioContext.ScenarioInfo.Title);

            objectContainer.RegisterInstanceAs(test);

        }

        [AfterScenario]
        public void AfterScenario()
        {

            driver.Quit();
            extent.Flush();

        }

    }

}
