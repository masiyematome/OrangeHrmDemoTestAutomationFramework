using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OrangeHrmDemo.Web.PageRepo;
using OrangeHrmDemo.Web.Support;
using OrangeHrmDemo.Web.Utilities;
using System.Text.RegularExpressions;

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

        public bool CheckIfThereAreUsers()
        {

            WaitHandler.WaitForElementToBeVisible(driver, adminPageRepo.GetRecordsFound, 10, 2);

            string recordsFoundText = adminPageRepo.txtRecordsFound.Text;

            if (!recordsFoundText.Contains("No"))
            {

                return true;

            }

            return false;

        }

        public string GrabAUserFromTheRecords()
        {

            Random random = new Random();
            string usernameToSearchFor = string.Empty;
            int randomIndex;

            if (CheckIfThereAreUsers())
            {

                randomIndex = (int) random.NextInt64(adminPageRepo.listOfUsernames.Count);

                usernameToSearchFor = adminPageRepo.listOfUsernames[randomIndex].Text;

            }
            else
            {

                Assert.Fail("No users to select from");

            }

            return usernameToSearchFor;

        }

        public void SearchForUser(string username)
        {

            EnterData(driver, adminPageRepo.txtSearchUsername, username);

            ClickOnObject(driver, adminPageRepo.btnSearch);

        }

        public void ValidateSearchWasSuccessful(ExtentTest node)
        {

            try
            {

                WaitHandler.WaitForElementToBeVisible(driver, adminPageRepo.GetRecordsFound, 10, 2);

                foreach (IWebElement usernameFromRecords in adminPageRepo.listOfUsernames)
                {

                    if (usernameFromRecords.Text.Equals(adminPageRepo.txtSearchUsername.GetAttribute("value")))
                    {

                        node.Pass("Search was successful", ExtentReportsHelper.TakeScreenshot(driver));

                    }
                    else
                    {

                        node.Fail("Search was unsuccessful", ExtentReportsHelper.TakeScreenshot(driver));
                        Assert.Fail("Search was unsuccessful");

                    }

                }

            }
            catch(Exception ex)
            {

                Console.WriteLine(("Search was unsuccessful: " + ex.Message));

                Assert.Fail("Search was unsuccessful");

            }
           
        }

        public void DeleteRecord(string usernameToDelete)
        {

            try
            {
                SearchForUser(usernameToDelete);

                WaitHandler.WaitForElementToBeVisible(driver, adminPageRepo.GetRecordsFound, 10, 2);

                ClickOnObject(driver, adminPageRepo.btnDelete);

                WaitHandler.WaitForElementToBeClickable(driver,adminPageRepo.btnDeleteConfirm,10,2);

                ClickOnObject(driver, adminPageRepo.btnDeleteConfirm);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
 
        }

        public void ValidateDeleteWasSuccessful(ExtentTest node)
        {



            if (!CheckIfThereAreUsers())
            {

                node.Pass("User deleted successfully..", ExtentReportsHelper.TakeScreenshot(driver));

            }
            else
            {

                node.Fail("User not deleted..", ExtentReportsHelper.TakeScreenshot(driver));
                Assert.Fail("User not deleted");

            }

        }
   
    }

}
