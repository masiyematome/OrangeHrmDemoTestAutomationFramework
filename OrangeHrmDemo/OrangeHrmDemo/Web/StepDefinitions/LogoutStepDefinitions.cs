using AventStack.ExtentReports;
using OpenQA.Selenium;
using OrangeHrmDemo.Web.PageObjects;
using TechTalk.SpecFlow;
using OrangeHrmDemo.Web.resources;

namespace OrangeHrmDemo.Web.StepDefinitions
{
    [Binding]
    public class LogoutStepDefinitions
    {

        private readonly Common common;
        private readonly ExtentTest node;
        private readonly LandingPageObjects landingPageObjects;

        public LogoutStepDefinitions(IWebDriver driver, ExtentTest node)
        {

            this.node = node;
            common = new Common(driver);
            landingPageObjects = new LandingPageObjects(driver);

        }

        [Given(@"the user is logged in")]
        public void GivenTheUserIsLoggedIn()
        {

            landingPageObjects.NavigateToUrl(config.OrangeHrmDemoUrl);
            landingPageObjects.Login(config.OrangeHrmUsername, config.OrangeHrmPassword);

        }

        [When(@"the user logouts")]
        public void WhenTheUserLogouts()
        {

            common.Logout();

        }

        [Then(@"the user is redirected to the login page")]
        public void ThenTheUserIsRedirectedToTheLoginPage()
        {

            common.ValidateSuccessfulLogout(node);

        }
    }
}
