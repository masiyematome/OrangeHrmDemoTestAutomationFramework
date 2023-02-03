using OpenQA.Selenium;
using OrangeHrmDemo.Web.PageObjects;
using OrangeHrmDemo.Web.resources;
using TechTalk.SpecFlow;

namespace OrangeHrmDemo.Web.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {

        private readonly IWebDriver driver;
        private readonly LandingPageObjects landingPageObjects;

        public LoginStepDefinitions(IWebDriver driver)
        {

            landingPageObjects = new LandingPageObjects(driver);
            this.driver = driver;

        }

        [Given(@"the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {

            landingPageObjects.NavigateToUrl(config.OrangeHrmDemoUrl);

        }

        [When(@"the user logs in with a valid login credentials")]
        public void WhenTheUserLogsInWithAValidLoginCredentials()
        {

            landingPageObjects.Login(config.OrangeHrmUsername, config.OrangeHrmPassword);

        }

        [Then(@"the user is redirected to the dashboard")]
        public void ThenTheUserIsRedirectedToTheDashboard()
        {

            landingPageObjects.ValidateLogin();

        }
    }
}
