using OpenQA.Selenium;

namespace OrangeHrmDemo.Web.PageRepo
{
    public class DashboardRepo
    {
        public static By GetDashboardHeading()
        {

            return By.XPath("//h6[text() = 'Dashboard']");

        }

    }
}
