
using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OrangeHrmDemo.Web.PageRepo;
using OrangeHrmDemo.Web.Utilities;

namespace OrangeHrmDemo.Web.PageObjects
{
    public class Common : ActionHelper
    {

        private readonly CommonPageRepo commonPageRepo;
        private readonly LandingPageRepo landingPageRepo;
        private readonly IWebDriver driver;

        public Common(IWebDriver driver)
        {

            landingPageRepo = new LandingPageRepo(driver);
            commonPageRepo = new CommonPageRepo(driver);
            this.driver = driver;

        }

        public void NavigateToTab(string tabText)
        {

            IWebElement targetTab = commonPageRepo.GetTabPath(tabText);

            ClickOnObject(driver, targetTab);
            
        }

        public void Logout()
        {

            ClickOnObject(driver, commonPageRepo.spanUserDropdown);

            ClickOnObject(driver, commonPageRepo.btnLogout);

        }

        public void ValidateSuccessfulLogout(ExtentTest node)
        {

            try
            {

                WaitHandler.WaitForElementToBeVisible(driver,landingPageRepo.GetTxtLogin(), 10, 2);

                node.Pass("Logout was successful", ExtentReportsHelper.TakeScreenshot(driver));

            }catch(Exception ex)
            {

                node.Fail("Logout not successful", ExtentReportsHelper.TakeScreenshot(driver));

                Assert.Fail("Logout not successful: " + ex.Message);

            }


        }

    }
}
