
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OrangeHrmDemo.Web.Utilities
{
    public class ActionHelper
    {

        public string GetCurrentUrl(IWebDriver driver)
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

        public void ClickOnObject(IWebDriver driver,IWebElement webElement)
        {

            try
            {

                webElement.Click();

            }catch(Exception e)
            {

                Console.WriteLine($"Couldn't click on web element {e.Message}");

            }

        }

        public void EnterData(IWebDriver driver,IWebElement webElement,string data)
        {

            try
            {

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


    }
}
