
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace OrangeHrmDemo.Web.Utilities
{
    public class ActionHelper
    {

        public static string GetCurrentUrl(IWebDriver driver)
        {

            string? currentUrl = null;

            try
            {

                currentUrl = driver.Url;

            }catch(Exception e)
            {

                Console.WriteLine($"Couldn't get the current url: {e.Message}");

            }

            return currentUrl;

        }

        public static void ClickOnObject(IWebDriver driver,IWebElement webElement)
        {

            try
            {

                WaitHandler.WaitForElementToBeClickable(driver, webElement, 10, 2);

                webElement.Click();

            }catch(Exception e)
            {

                Console.WriteLine($"Couldn't click on web element: {e.Message}");

            }

        }

        public void EnterData(IWebDriver driver,IWebElement webElement,string data)
        {

            try
            {

                WaitHandler.WaitForElementToBeClickable(driver, webElement, 10, 2);
                webElement.Clear();
                webElement.SendKeys(data);

            }catch(Exception e)
            {

                Console.WriteLine($"Couldn't enter data: {e.Message}");

            }

        }

        public void SelectDropDownItem(IWebDriver driver,IWebElement webElement,string identifier,string itemToSelect)
        {

            try
            {

                SelectElement selectItem = new SelectElement(webElement);

                WaitHandler.WaitForElementToBeClickable(driver, webElement, 10, 2);

                switch (identifier.ToLower())
                {

                    case "text":
                        selectItem.SelectByText(itemToSelect);
                        break;

                    case "index":
                        selectItem.SelectByIndex(int.Parse(itemToSelect));
                        break;

                    case "value":
                        selectItem.SelectByValue(itemToSelect);
                        break;

                }


            }catch(Exception e)
            {

                Console.WriteLine($"Failed to select: {e.Message}");

            }

        }

        public void HandleKeyBoardActions(IWebDriver driver,string targetAction)
        {

            try
            {

                Actions actions = new Actions(driver);

                switch (targetAction.ToLower())
                {

                    case "arrow key down":

                        actions.
                            SendKeys(Keys.ArrowDown)
                            .Build()
                            .Perform();

                        break;

                }

            }
            catch(Exception ex)
            {

                Console.WriteLine("Couldn't perform action: " + ex.Message);

            }
            

        }


    }
}
