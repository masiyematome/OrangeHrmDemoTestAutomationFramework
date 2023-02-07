
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OrangeHrmDemo.Web.PageRepo;
using OrangeHrmDemo.Web.Utilities;

namespace OrangeHrmDemo.Web.PageObjects
{
    public class LandingPageObjects : ActionHelper
    {

        private readonly IWebDriver driver;
        private readonly LandingPageRepo landingPageRepo;

        public LandingPageObjects(IWebDriver driver)
        {

            this.driver = driver;
            landingPageRepo = new LandingPageRepo(driver);

        }

        public void NavigateToUrl(string url)
        {

            try
            {

                driver.Url = url;

            }

            catch(Exception ex)
            {

                Console.WriteLine($"Couldn't navigate to url: {ex.Message}");

            }

        }

        public void Login(string username,string password)
        {

            EnterData(driver, landingPageRepo.txtUsername, username);
            EnterData(driver, landingPageRepo.txtPassword, password);
            ClickOnObject(driver, landingPageRepo.btnLogin);

        }

        public void ValidateSuccessfulLogin(ExtentTest node)
        {

            try
            {

                By dashboardTextLocator = DashboardRepo.GetDashboardHeading();

                WaitHandler.WaitForElementToBeVisible(driver, dashboardTextLocator, 10, 2);

                node.Pass("Login passed", ExtentReportsHelper.TakeScreenshot(driver));

            }
            catch(Exception ex)
            {

                node.Fail("Login failed", ExtentReportsHelper.TakeScreenshot(driver));

                Assert.Fail("Login failed: " + ex.Message);

            }
            

        }

        public void ValidateUnsuccessfulLogin(ExtentTest node,string expectedErrorMessage)
        {


            By errorMessageLocator = landingPageRepo.GetTxtInvalidCredentials();

            try
            {

                WaitHandler.WaitForElementToBeVisible(driver, errorMessageLocator , 10, 2);

                string errorMessage = driver.FindElement(errorMessageLocator).Text;

                if (string.Equals(errorMessage, expectedErrorMessage, StringComparison.OrdinalIgnoreCase))
                {

                    node.Pass("Failed to login..Negative test passed!", ExtentReportsHelper.TakeScreenshot(driver));

                }
                else
                {

                    node.Fail("Error message on the page does not match the expected error message.Please check it",
                        ExtentReportsHelper.TakeScreenshot(driver));

                    Assert.Fail("Error message on the page does not match the expected error message.Please check it");

                }

            }
            catch(Exception ex)
            {

                node.Fail("Error message is not displayed. Please check it", ExtentReportsHelper.TakeScreenshot(driver));

                Assert.Fail($"Error message not on the page {ex.Message}");

            }


        }

    }
}
