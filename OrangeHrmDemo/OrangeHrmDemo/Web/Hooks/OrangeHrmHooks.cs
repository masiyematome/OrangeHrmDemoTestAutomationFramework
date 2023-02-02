
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
        private IWebDriver driver;

        public OrangeHrmHooks(IObjectContainer objectContainer)
        {

            this.objectContainer = objectContainer;

        }

        [BeforeScenario]
        public void BeforeScenario()
        {

            driver = WebBrowserHelper.SetUpBrowser(config.BrowserName);

            objectContainer.RegisterInstanceAs(driver);

        }

        [AfterScenario]
        public void AfterScenario()
        {

            driver.Quit();

        }

    }

}
