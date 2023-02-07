
using OpenQA.Selenium;

namespace OrangeHrmDemo.Web.PageRepo
{
    public class CommonPageRepo
    {

       public static IWebElement GetTabPath(IWebDriver driver,string tabText)
        {

            By elementLocator = By.XPath($"//span[text()[contains(.,'{tabText}')]]");

            return driver.FindElement(elementLocator);

        }

    }
}
