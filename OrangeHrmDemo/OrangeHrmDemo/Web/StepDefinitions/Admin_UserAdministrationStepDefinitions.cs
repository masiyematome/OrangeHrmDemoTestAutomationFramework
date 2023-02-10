using OpenQA.Selenium;
using OrangeHrmDemo.Web.PageObjects;
using TechTalk.SpecFlow;
using OrangeHrmDemo.Web.resources;
using TechTalk.SpecFlow.Assist;
using OrangeHrmDemo.Web.Support;

namespace OrangeHrmDemo.Web.StepDefinitions
{
    [Binding]
    public class Admin_UserAdministrationStepDefinitions
    {

        readonly LandingPageObjects landingPageObjects;
        private UserDetails userDetails;
        readonly AdminPageObjects adminPageObjects;
        readonly Common common;
        public Admin_UserAdministrationStepDefinitions(IWebDriver driver)
        {

            landingPageObjects = new LandingPageObjects(driver);
            adminPageObjects = new AdminPageObjects(driver);
            common = new Common(driver);
            userDetails = new UserDetails();

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

            dynamic userData = table.CreateDynamicInstance();

            userDetails = new UserDetails()
            {

                userRole = userData.userRole,
                employeeName = userData.employeeName,
                status = userData.status,
                userName = userData.userName,
                password = userData.password

            };

            adminPageObjects.AddUser(userDetails);

        }

        [When(@"the admin logs out of the application")]
        public void WhenTheAdminLogsOutOfTheApplication()
        {

            common.Logout(); 

        }

        [When(@"the user logs in with the newly created login credentials")]
        public void WhenTheUserLogsInWithTheNewlyCreatedLoginCredentials()
        {

            landingPageObjects.Login(userDetails.userName,userDetails.password);

        }

        [Given(@"there are existing users in the system")]
        [Given(@"there are existing users in the database")]
        public void GivenThereAreExistingUsersInTheSystem()
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
