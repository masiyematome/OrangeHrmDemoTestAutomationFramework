using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OrangeHrmDemo.Web.PageRepo
{
    public class CommonPageRepo
    {
        
        public CommonPageRepo(IWebDriver driver)
        {

            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'user')]")]
        public IWebElement spanUserDropdown;

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Logout']")]
        public IWebElement btnLogout;

        public By GetTabPath(string tabText)
        {

            return By.XPath($"//span[text()[contains(.,'{tabText}')]]");

        }

    }
}
