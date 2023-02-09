using OpenQA.Selenium;
using OrangeHrmDemo.Web.PageRepo;
using OrangeHrmDemo.Web.Support;
using OrangeHrmDemo.Web.Utilities;

namespace OrangeHrmDemo.Web.PageObjects
{
    public class AdminPageObjects : ActionHelper
    {

        private readonly IWebDriver driver;
        private readonly AdminPageRepo adminPageRepo;

        public AdminPageObjects(IWebDriver driver)
        {

            this.driver = driver;
            adminPageRepo = new AdminPageRepo(driver);

        }

        public void AddUser(UserDetails userDetails)
        {

            try
            {

                ClickOnObject(driver, adminPageRepo.btnAdd);

                ClickOnObject(driver, adminPageRepo.drpUserRole);
                ClickOnObject(driver, adminPageRepo.GetAdminPageDropdownOptions(userDetails.userRole));

                ClickOnObject(driver, adminPageRepo.drpStatus);
                ClickOnObject(driver, adminPageRepo.GetAdminPageDropdownOptions(userDetails.status));

                EnterData(driver, adminPageRepo.txtPassword, userDetails.password);
                EnterData(driver, adminPageRepo.txtConfirmPassword, userDetails.password);
                EnterData(driver, adminPageRepo.txtUsername, userDetails.userName);
                EnterData(driver, adminPageRepo.txtEmployeeName, userDetails.employeeName);

                do
                {

                    WaitHandler.WaitForElementToBeVisible(driver, adminPageRepo.GetAutoCompleteDropdown, 10, 2);

                } while (!adminPageRepo.drpEmployeeAutoComplete.Text.Equals(userDetails.employeeName));

                PerformKeyBoardActions(driver, "arrow key down");

                ClickOnObject(driver, adminPageRepo.drpEmployeeAutoComplete);

                ClickOnObject(driver, adminPageRepo.btnSave);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

    }
}
