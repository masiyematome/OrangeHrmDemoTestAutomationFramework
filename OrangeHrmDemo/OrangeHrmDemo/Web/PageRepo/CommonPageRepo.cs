
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OrangeHrmDemo.Web.PageRepo
{
    public class CommonPageRepo
    {

        private readonly IWebDriver driver;
        
        public CommonPageRepo(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'user')]")]
        public IWebElement spanUserDropdown;

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Logout']")]
        public IWebElement btnLogout;

        public IWebElement GetTabPath(string tabText)
        {

            By elementLocator = By.XPath($"//span[text()[contains(.,'{tabText}')]]");

            return driver.FindElement(elementLocator);

        }

    }
}
