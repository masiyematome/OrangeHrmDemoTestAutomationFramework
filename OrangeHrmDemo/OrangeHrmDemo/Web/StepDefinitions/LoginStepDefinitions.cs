using AventStack.ExtentReports;
using BoDi;
using OpenQA.Selenium;
using OrangeHrmDemo.Web.PageObjects;
using OrangeHrmDemo.Web.resources;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace OrangeHrmDemo.Web.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {

        private readonly LandingPageObjects landingPageObjects;
        private readonly IWebDriver driver;
        private ExtentTest node;
    

        public LoginStepDefinitions(IWebDriver driver, ExtentTest node)
        {

            this.node = node;
            this.driver = driver;
            landingPageObjects = new LandingPageObjects(driver);

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

            landingPageObjects.ValidateSuccessfulLogin(node);

        }

        [When(@"the user logs in with invalid login credentials")]
        public void WhenTheUserLogsInWithInvalidLoginCredentials()
        {

            landingPageObjects.Login(config.OrangeHrmUsername, config.OrangeHrmInvalidPassword);

        }

        [Then(@"the user is presented with an error message")]
        public void ThenTheUserIsPresentedWithAnErrorMessage(Table table)
        {

            dynamic tableData = table.CreateDynamicInstance();

            landingPageObjects.ValidateUnsuccessfulLogin(node,tableData.errorMessage);

        }

    }
}
