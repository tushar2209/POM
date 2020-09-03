using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;
using STA__Automation.Pages.Portal;

namespace STA__Automation.BussinessLib
{
    class CM_UserCreationLib : BaseTestClass
    {
        public static SeleniumCommFunctions seleniumFunc;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static CM_UserCreationPage cmUserCreationPage;
        public static MyActivityPage myActivityPage;


        /// <summary>
        ///  Method to  set up re condition for test case.
        /// </summary>
        /// <param name="appURL">URL Application U</param>
        public void SetUpPreCondition()
        {
            driver = GetDriver();

            seleniumFunc = new SeleniumCommFunctions();
            log.Info("Test method setup started");
            InitialisePageObjects();
            comFunc = new CommonFunctions();


        }

        /// <summary>
        /// Method to initialise  page objects
        /// </summary>
        public void InitialisePageObjects()
        {
            cmUserCreationPage = new CM_UserCreationPage(driver);
            myActivityPage = new MyActivityPage(driver);

        }


        /// <summary>
        ///  Method to  set up re condition for test case.
        /// </summary>
        /// <param name="appURL">URL Application U</param>
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


        /// <summary>
        /// Method to login to portal and navigate to MyActivity-> Available Activity -> Titme Table Variation Application
        /// </summary>
        /// <param name="userName"> userName</param>
        /// <param name="password">passWord</param>
        public void LoginAndNavigatToForm(string userName, string password)
        {

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.SchoolPortlContactMangFromLink);


        }


        public void FillUserCreationForm(string option, string userType, string email, string FirstName, string SurName, string Jobtitle, string TelePhoneNumber)
        {
            if (option == "New")
            {
                seleniumFunc.WaitAndClickOnElement(cmUserCreationPage.CreateNewContactRadio);
                seleniumFunc.WaitForPageToLoad();
                comFunc.NaviagteToNextPage();

                seleniumFunc.WaitAndEnterText(cmUserCreationPage.NewContactFirstName[0], FirstName);
                seleniumFunc.WaitAndEnterText(cmUserCreationPage.NewContactSurname[0], SurName);
                seleniumFunc.WaitAndEnterText(cmUserCreationPage.JobTitle[0], Jobtitle);
                seleniumFunc.WaitAndEnterText(cmUserCreationPage.EmailAdd[0], email + Keys.Tab);
                seleniumFunc.WaitForPageToLoad();

                seleniumFunc.WaitAndEnterText(cmUserCreationPage.ConfirmEmailAdd[0], email);
                seleniumFunc.WaitAndEnterText(cmUserCreationPage.TelephoneNo[0], TelePhoneNumber);
                selectUserType(userType);
            }
            else if (option == "Update")
            {
                seleniumFunc.WaitAndClickOnElement(cmUserCreationPage.UpdateContactRadio);
                seleniumFunc.WaitForPageToLoad();
                comFunc.NaviagteToNextPage();
                seleniumFunc.WaitAndClickOnElement(cmUserCreationPage.SuperUserCheckbox[1]);
            }
            comFunc.NaviagteToNextPage();
        }

        public void UpdateUserDetails()
        {


        }

        public void selectUserType(string userType)
        {
            if (userType == "Normal")
            {
                seleniumFunc.WaitAndClickOnElement(cmUserCreationPage.NormalUserCheckbox[0]);

            }
            else if (userType == "Super")
            {
                seleniumFunc.WaitAndClickOnElement(cmUserCreationPage.SuperUserCheckbox[0]);

            }
            else if (userType == "headteacher")
            {
                seleniumFunc.WaitAndClickOnElement(cmUserCreationPage.HeadTeacherCheckbox[0]);

            }

        }

        /// <summary>
        /// Method to fill LA creartion form
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="email"></param>
        /// <param name="FirstName"></param>
        /// <param name="SurName"></param>
        /// <param name="Jobtitle"></param>
        /// <param name="TelePhoneNumber"></param>
        public void FillLACreationForm(string userType, string email, string FirstName, string SurName, string Jobtitle, string TelePhoneNumber)
        {

            seleniumFunc.WaitAndEnterText(cmUserCreationPage.LACreationTextboxes[0], FirstName);
            seleniumFunc.WaitAndEnterText(cmUserCreationPage.LACreationTextboxes[1], SurName);
            seleniumFunc.WaitAndEnterText(cmUserCreationPage.LACreationTextboxes[2], Jobtitle);
            seleniumFunc.WaitAndEnterText(cmUserCreationPage.LACreationTextboxes[3], email + Keys.Tab);

            seleniumFunc.WaitForPageToLoad();
            seleniumFunc.WaitAndEnterText(cmUserCreationPage.LACreationTextboxes[4], email);
            seleniumFunc.WaitAndEnterText(cmUserCreationPage.LACreationTextboxes[5], TelePhoneNumber);

            seleniumFunc.SelectValueFromDropDwn(cmUserCreationPage.LACreationRole, userType);

        }

        public void CheckMaximumUserCreationLimitMsg(string LimitMsg)
        {
            VerifyIsEquals(LimitMsg, seleniumFunc.GetText(cmUserCreationPage.UserCreationLimitMsg), "Check maximum user creation limt validatipon message");
        }
    }

}
