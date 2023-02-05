
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

            if (GetCurrentUrl(driver).Contains("dashboard"))
            {

                node.Pass("Logged in successfully", ExtentReportsHelper.TakeScreenshot(driver));

            }
            else
            {

                node.Fail("Failed to login", ExtentReportsHelper.TakeScreenshot(driver));

            }

        }

        public void ValidateUnsuccessfulLogin(ExtentTest node,string expectedErrorMessage)
        {

            Thread.Sleep(500);

            IWebElement errorMessageElementOnThePage = landingPageRepo.txtInvalidCredentials;

            if (errorMessageElementOnThePage.Displayed)
            {

                string errorMessage = errorMessageElementOnThePage.Text;

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
            else
            {

                node.Fail("Error message is not displayed. Please check it",ExtentReportsHelper.TakeScreenshot(driver));

            }

        }

    }
}
