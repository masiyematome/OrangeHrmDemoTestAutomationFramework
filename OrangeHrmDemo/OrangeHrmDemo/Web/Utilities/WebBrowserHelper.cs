

using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;

namespace OrangeHrmDemo.Web.Utilities
{
    public class WebBrowserHelper
    {

        public static IWebDriver SetUpBrowser(string browserName)
        {

            IWebDriver driver = null;

            switch (browserName.ToLower())
            {
                
                case "chrome":

                    new DriverManager().SetUpDriver(new ChromeConfig());

                    ChromeOptions chromeOptions = new ChromeOptions();

                    chromeOptions.AcceptInsecureCertificates = true;

                    driver = new ChromeDriver(chromeOptions);

                    break;

                case "firefox":

                    new DriverManager().SetUpDriver(new FirefoxConfig());

                    FirefoxOptions firefoxOptions = new FirefoxOptions();

                    firefoxOptions.AcceptInsecureCertificates = true;

                    driver = new FirefoxDriver(firefoxOptions);

                    break;

                case "ie":

                    new DriverManager().SetUpDriver(new InternetExplorerConfig());

                    InternetExplorerOptions internetExplorerOptions = new InternetExplorerOptions();

                    internetExplorerOptions.AcceptInsecureCertificates = true;

                    driver = new InternetExplorerDriver(internetExplorerOptions);


                    break;

                case "edge":

                    new DriverManager().SetUpDriver(new EdgeConfig());

                    EdgeOptions edgeOptions = new EdgeOptions();

                    edgeOptions.AcceptInsecureCertificates = true;

                    driver = new EdgeDriver(edgeOptions);

                    break;

            }

            driver.Manage().Window.Maximize();

            return driver;

        }

    }
}
