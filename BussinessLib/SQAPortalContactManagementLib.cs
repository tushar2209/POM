using OpenQA.Selenium;
using STA.Utilities.ExcelReader;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;
using STA__Automation.Pages.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.BussinessLib
{
    class SQAPortalContactManagementLib : BaseTestClass
    {
        public static SQAPortalContactManagementPage SQAPortal;
        public static SeleniumCommFunctions seleniumFunc;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;
        public static ExcelUtil excelUtil;
        public static CommonFunctions commFunc;

        const string Normal = "Normal";
        const string Super = "Super";
        public void InitialisePageObjects()
        {
            SQAPortal = new SQAPortalContactManagementPage(driver);
            myActivityPage = new MyActivityPage(driver);
            commFunc = new CommonFunctions();
        }

        public void SetUpPreCondition(string appURL)
        {
            driver = GetDriver();
            seleniumFunc = new SeleniumCommFunctions();
            log.Info("Test method setup started");
            InitialisePageObjects();
            comFunc = new CommonFunctions();

            log.Info("launch application");
            comFunc.LaunchApplication(appURL);
        }

        public void LoginAndNavigatToForm(string userName, string password)
        {

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);
            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.SQAPortalContactFormLink);
        }

        public void FillUserCreationForm(string option, string userType, string email, string FirstName, string SurName, string Jobtitle, string TelePhoneNumber)
        {
            if (option == "New")
            {
                seleniumFunc.WaitAndClickOnElement(SQAPortal.CreateNewSQA);
                seleniumFunc.WaitForPageToLoad();
                comFunc.NaviagteToNextPage();

                seleniumFunc.WaitAndEnterText(SQAPortal.SQAFirstName, FirstName);
                seleniumFunc.WaitAndEnterText(SQAPortal.SQALastName, SurName);
                seleniumFunc.WaitAndEnterText(SQAPortal.JobTitle, Jobtitle);
                seleniumFunc.WaitAndEnterText(SQAPortal.SQAEmailAdd, email + Keys.Tab);
                seleniumFunc.WaitForPageToLoad();

                seleniumFunc.WaitAndEnterText(SQAPortal.SQAConfirmEmail, email);
                seleniumFunc.WaitAndEnterText(SQAPortal.SQAContactNo, TelePhoneNumber);
                SelectUserType(userType);
            }
            else if (option == "Update")
            {
                seleniumFunc.WaitAndClickOnElement(SQAPortal.UpdateExistingSQA);
                seleniumFunc.WaitForPageToLoad();
                comFunc.NaviagteToNextPage();
                seleniumFunc.WaitAndClickOnElement(SQAPortal.SQASuperUser);
            }
            comFunc.NaviagteToNextPage();
            comFunc.SubmitForm();
        }

        public void SelectUserType(string userType)
        {
            if (userType == "Normal")
            {
                seleniumFunc.WaitAndClickOnElement(SQAPortal.SQANormalUSer);

            }
            else if (userType == "Super")
            {
                seleniumFunc.WaitAndClickOnElement(SQAPortal.SQASuperUser);

            }
        }
    }
}
