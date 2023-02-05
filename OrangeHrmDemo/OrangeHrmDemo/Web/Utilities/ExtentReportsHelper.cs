using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;

namespace OrangeHrmDemo.Web.Utilities
{
    public class ExtentReportsHelper
    {
        public static ExtentReports IntializeExtentReports(string targetFolderAndFileName,string reporterTitle)
        {

            ExtentReports? extent = null;

            try
            {

                string finalDestinationPath = Environment.CurrentDirectory.Split("bin")[0] + targetFolderAndFileName;

                extent = new ExtentReports();
                ExtentHtmlReporter reporter = new ExtentHtmlReporter(finalDestinationPath);

                extent.AttachReporter(reporter);

                reporter.Config.DocumentTitle = reporterTitle;
                reporter.Config.Theme = Theme.Dark;    

            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

            return extent;

        }

        public static MediaEntityModelProvider TakeScreenshot(IWebDriver driver)
        {

            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            string screenshot = takesScreenshot.GetScreenshot().AsBase64EncodedString;

            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot).Build();

        }

    }

}
