
using AventStack.ExtentReports;
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

                WaitHandler.WaitForElementToBeVisible(driver, DashboardRepo.GetDashboardHeading(), 10, 2);

                node.Pass("Logged in successfully", ExtentReportsHelper.TakeScreenshot(driver));

            }
            catch (Exception ex)
            {

                if (GetCurrentUrl(driver).Contains("dashboard"))
                {

                    node.Pass("Logged in successfully", ExtentReportsHelper.TakeScreenshot(driver));

                }
                else
                {

                    node.Fail("Failed to login", ExtentReportsHelper.TakeScreenshot(driver));

                }

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

                    node.Pass("Failed to login", ExtentReportsHelper.TakeScreenshot(driver));

                }
                else
                {

                    node.Fail("Error message on the page does not match the expected error message.Please check it",
                        ExtentReportsHelper.TakeScreenshot(driver));

                }


            }
            catch(Exception ex)
            {

                Console.WriteLine($"Error message not on the page {ex.Message}");

                node.Fail("Error message is not displayed. Please check it", ExtentReportsHelper.TakeScreenshot(driver));

            }


        }

    }
}
