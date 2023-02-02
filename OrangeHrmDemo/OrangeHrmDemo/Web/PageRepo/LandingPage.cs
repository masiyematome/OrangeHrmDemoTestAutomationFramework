using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OrangeHrmDemo.Web.PageRepo
{
    public class LandingPage
    {

        private readonly IWebDriver driver;

        public LandingPage(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.Id, Using = "//input[@name='username']")]
        public IWebElement txtUsername;

        [FindsBy(How = How.Id, Using = "//input[@name='password']")]
        public IWebElement txtPassword;

        [FindsBy(How = How.Id, Using = "//button[contains(@class,'login')]")]
        public IWebElement btnLogin;

    }
}
