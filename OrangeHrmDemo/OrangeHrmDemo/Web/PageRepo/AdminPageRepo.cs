
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OrangeHrmDemo.Web.PageRepo
{

    public class AdminPageRepo
    {

        private readonly IWebDriver driver;

        public AdminPageRepo(IWebDriver driver)
        {

            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//button[text()[contains(.,'Add')]]")]
        public IWebElement btnAdd;

        [FindsBy(How = How.XPath, Using = "//*[text()[contains(.,'Role')]]//ancestor::*[contains(@class,'gutter')]//*[contains(@class,'text-input')]")]
        public IWebElement drpUserRole;

        [FindsBy(How = How.XPath, Using = "//*[text() = 'Status']//ancestor::*[contains(@class,'gutter')]//*[contains(@class,'text-input')]")]
        public IWebElement drpStatus;

        [FindsBy(How = How.XPath, Using = "//input[contains(@placeholder,'Type')]")]
        public IWebElement txtEmployeeName;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'autocomplete-dropdown')]")]
        public IWebElement drpEmployeeAutoComplete;

        [FindsBy(How = How.XPath, Using = "//*[text() = 'Username']//ancestor::Div[contains(@class,'gutters')]//input")]
        public IWebElement txtUsername;

        [FindsBy(How = How.XPath, Using = "//*[text() = 'Password']//ancestor::Div[contains(@class,'gutters')]//input")]
        public IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = "//*[text()[contains(.,'Confirm')]]//ancestor::Div[contains(@class,'gutters')]//input")]
        public IWebElement txtConfirmPassword;

        [FindsBy(How = How.XPath, Using = "//button[normalize-space() = 'Save']")]
        public IWebElement btnSave;

        [FindsBy(How = How.CssSelector, Using = "input:not([placeholder])")]
        public IWebElement txtSearchUsername;

        [FindsBy(How = How.XPath, Using = "//button[text() = ' Search ']")]
        public IWebElement btnSearch;

        [FindsBy(How = How.XPath, Using = "//span[text()[contains(.,'Found')]]")]
        public IWebElement txtRecordsFound;

        [FindsBy(How = How.XPath, Using = "//div[@role='cell'][2]")]
        public IList<IWebElement> listOfUsernames;
        public By GetAutoCompleteDropdown => By.XPath("//div[contains(@class,'autocomplete-dropdown')]");
        public By GetRecordsFound => By.XPath("//span[text()[contains(.,'Found')]]");


        public IWebElement GetAdminPageDropdownOptions(string option)
        {

            return driver.FindElement(By.XPath($"//div[@role='option']//span[contains(text(),'{option}')]"));

        }

        

    }

}
