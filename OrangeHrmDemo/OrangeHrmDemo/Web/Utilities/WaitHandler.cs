
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Xml.Linq;

namespace OrangeHrmDemo.Web.Utilities
{
    public class WaitHandler
    {

        public static void WaitForElementToBeClickable(IWebDriver driver,IWebElement element,int maxWaitDuration,int pollingDuration)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(maxWaitDuration))
            {

                PollingInterval = TimeSpan.FromSeconds(pollingDuration)

            };

            try
            {

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

            }

        }

    }
}
