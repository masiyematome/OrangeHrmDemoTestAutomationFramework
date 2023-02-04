using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OrangeHrmDemo.Web.PageRepo
{
    public class LandingPageRepo
    {

        private readonly IWebDriver driver;

        public LandingPageRepo(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//input[@name='username']")]
        public IWebElement txtUsername;

        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        public IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = "//button[contains(@class,'login')]")]
        public IWebElement btnLogin;

        [FindsBy(How = How.XPath, Using = "//h5[text() = 'Login']")]
        public IWebElement txtLogin;

    }
}
