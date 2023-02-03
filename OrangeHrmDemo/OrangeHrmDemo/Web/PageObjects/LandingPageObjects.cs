
using OpenQA.Selenium;
using OrangeHrmDemo.Web.PageRepo;
using OrangeHrmDemo.Web.Utilities;

namespace OrangeHrmDemo.Web.PageObjects
{
    public class LandingPageObjects : ActionHelper
    {

        private readonly LandingPageRepo landingPageRepo;
        private readonly IWebDriver driver;

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

            }catch(Exception ex)
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

        public void ValidateLogin()
        {

            if (GetCurrentUrl(driver).Contains("dashboard"))
            {

                Console.WriteLine("Logged in successfully");

            }
            else
            {

                Console.WriteLine("Failed to login");

            }

        }

    }
}
