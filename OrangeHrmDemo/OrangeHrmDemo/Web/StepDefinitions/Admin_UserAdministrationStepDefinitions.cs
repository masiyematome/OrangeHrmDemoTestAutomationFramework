using OpenQA.Selenium;
using OrangeHrmDemo.Web.PageObjects;
using TechTalk.SpecFlow;
using OrangeHrmDemo.Web.resources;
using TechTalk.SpecFlow.Assist;

namespace OrangeHrmDemo.Web.StepDefinitions
{
    [Binding]
    public class Admin_UserAdministrationStepDefinitions
    {

        private readonly LandingPageObjects landingPageObjects;
        private readonly Common common;
        public Admin_UserAdministrationStepDefinitions(IWebDriver driver)
        {

            landingPageObjects = new LandingPageObjects(driver);
            common = new Common(driver);

        }

        [Given(@"the admin is on the Admin page")]
        public void GivenTheAdminIsOnTheAdminPage()
        {

            landingPageObjects.NavigateToUrl(config.OrangeHrmDemoUrl);
            landingPageObjects.Login(config.OrangeHrmUsername, config.OrangeHrmPassword);
            common.NavigateToTab("Admin");

        }

        [When(@"the admin adds a new user")]
        public void WhenTheAdminAddsANewUser(Table table)
        {


            

        }

        [When(@"the admin logs out of the application")]
        public void WhenTheAdminLogsOutOfTheApplication()
        {
            throw new PendingStepException();
        }

        [When(@"the user logs in with the newly created login credentials")]
        public void WhenTheUserLogsInWithTheNewlyCreatedLoginCredentials()
        {
            throw new PendingStepException();
        }

        [When(@"the admin searches for a user")]
        public void WhenTheAdminSearchesForAUser()
        {
            throw new PendingStepException();
        }

        [Then(@"the admin is presented with the details of the searched user")]
        public void ThenTheAdminIsPresentedWithTheDetailsOfTheSearchedUser()
        {
            throw new PendingStepException();
        }

        [When(@"the admin deletes a user")]
        public void WhenTheAdminDeletesAUser()
        {
            throw new PendingStepException();
        }

        [Then(@"the admin is presented with no user details upon searching for the deleted user")]
        public void ThenTheAdminIsPresentedWithNoUserDetailsUponSearchingForTheDeletedUser()
        {
            throw new PendingStepException();
        }
    }
}
