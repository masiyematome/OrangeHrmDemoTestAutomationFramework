
using OpenQA.Selenium;
using OrangeHrmDemo.Web.PageRepo;
using OrangeHrmDemo.Web.Utilities;

namespace OrangeHrmDemo.Web.PageObjects
{
    public class Common : ActionHelper
    {
        public static void NavigateToTab(IWebDriver driver,string tabText)
        {

            IWebElement targetTab = CommonPageRepo.GetTabPath(driver, tabText);

            ClickOnObject(driver, targetTab);
            
        }

    }
}
