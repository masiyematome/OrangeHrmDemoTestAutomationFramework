using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OrangeHrmDemo.Web.Utilities
{
    public class WaitHandler
    {

        public static void WaitForElementToBeVisible(IWebDriver driver, By elementBy, int maxWaitDuration, int pollingDuration)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWaitDuration))
            {

                PollingInterval = TimeSpan.FromSeconds(pollingDuration)
                
            };

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(elementBy));

        }
        public static void WaitForElementToBeClickable(IWebDriver driver,IWebElement element,int maxWaitDuration,int pollingDuration)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWaitDuration))
            {

                PollingInterval = TimeSpan.FromSeconds(pollingDuration)

            };

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));

        }

    }
}
