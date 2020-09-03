using OpenQA.Selenium;
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
    class CompensatoryMarksLib : BaseTestClass
    {

        public static SeleniumCommFunctions seleniumFunc;

        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public MyActivityPage myActivityPage;
        public CompensatoryMarksPage compensatoryMarksPage;

      

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
        /// Method to initialise  page objects
        /// </summary>
        public void InitialisePageObjects()
        {
            compensatoryMarksPage = new CompensatoryMarksPage(driver);
            myActivityPage = new MyActivityPage(driver);

        }

        /// <summary>
        /// Method to login to portal and navigate to MyActivity-> Available Activity -> Titme Table Variation Application
        /// </summary>
        /// <param name="userName"> userName</param>
        /// <param name="password">passWord</param>
        public void LoginAndNavigatCompensatoryMarksForm(string userName, string password)
        {

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.CompencentoryMarksLink);

        }


        public void CheckContactDetailsFiledsValue(string firstName, string lastName, string JobeTitle, string TelPhone, string emailAddress)
        {
         
            VerifyIsEquals(firstName, seleniumFunc.GetAttributeValue(compensatoryMarksPage.ContactFirstName, "value"), "Check Contact FirstName");
            VerifyIsEquals(lastName, seleniumFunc.GetAttributeValue(compensatoryMarksPage.ContactLastName, "value"), "Check Contact lastName");
            VerifyIsEquals(JobeTitle, seleniumFunc.GetAttributeValue(compensatoryMarksPage.JobTitle, "value"), "Check Contact JobeTitle");
            VerifyIsEquals(TelPhone, seleniumFunc.GetAttributeValue(compensatoryMarksPage.TelephoneNumber, "value"), "Check Contact TelPhone");
            VerifyIsEquals(emailAddress, seleniumFunc.GetAttributeValue(compensatoryMarksPage.EmailAddress, "value"), "Check Contact emailAddress");

        }

        public void FillForm(string pupilName, int ConfirmationCheckBoxes,string ReasonForCompensatoryMarks)
        {

            seleniumFunc.SelectValueFromAutoCompliteDropDown(compensatoryMarksPage.PupilSelectionDropDwns, compensatoryMarksPage.AutoCompletDropDwnOptions, pupilName);

            for (int i = 0; i < ConfirmationCheckBoxes; i++) {
                seleniumFunc.WaitAndClickOnElement(compensatoryMarksPage.ConfirmationCheckBoxes[i]);
            }

            seleniumFunc.WaitAndEnterText(compensatoryMarksPage.ReasonForCompansantoryMarks, ReasonForCompensatoryMarks);

            comFunc.NaviagteToNextPage();

        }

    }
}
