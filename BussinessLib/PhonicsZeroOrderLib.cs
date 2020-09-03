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
    class PhonicsZeroOrderLib : BaseTestClass
    {

        public static SeleniumCommFunctions seleniumFunc;

        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public MyActivityPage myActivityPage;
        public PhonicsZeroOrderPage phonicsZeroOrderPage;



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
            phonicsZeroOrderPage = new PhonicsZeroOrderPage(driver);
            myActivityPage = new MyActivityPage(driver);

        }

        /// <summary>
        /// Method to login to portal and navigate to MyActivity-> Available Activity -> Titme Table Variation Application
        /// </summary>
        /// <param name="userName"> userName</param>
        /// <param name="password">passWord</param>
        public void LoginAndNavigatPhonicsZeroOrderForm(string userName, string password)
        {

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.PhonicsZeroOrderFormLink);

        }


        public void CheckContactDetailsFiledsValue(string firstName, string lastName, string JobeTitle, string TelPhone, string emailAddress)
        {

            VerifyIsEquals(firstName, seleniumFunc.GetAttributeValue(phonicsZeroOrderPage.ContactFirstName, "value"), "Check Contact FirstName");
            VerifyIsEquals(lastName, seleniumFunc.GetAttributeValue(phonicsZeroOrderPage.ContactLastName, "value"), "Check Contact lastName");
            VerifyIsEquals(JobeTitle, seleniumFunc.GetAttributeValue(phonicsZeroOrderPage.JobTitle, "value"), "Check Contact JobeTitle");
            VerifyIsEquals(TelPhone, seleniumFunc.GetAttributeValue(phonicsZeroOrderPage.TelephoneNumber, "value"), "Check Contact TelPhone");
            VerifyIsEquals(emailAddress, seleniumFunc.GetAttributeValue(phonicsZeroOrderPage.EmailAddress, "value"), "Check Contact emailAddress");

        }

        public void CheckMandetoryFields(string errorMsg) {

            seleniumFunc.ScrollElementInView(phonicsZeroOrderPage.ConfirmZeroOrderCheckBoxErrorMsg);
            VerifyIsEquals(errorMsg, seleniumFunc.GetText(phonicsZeroOrderPage.ConfirmZeroOrderCheckBoxErrorMsg), "Check Confirm zero orders for phonics mandetory check box");
            
        }

        public void SelectConfirmZeroOrder() {
            seleniumFunc.WaitAndClickOnElement(phonicsZeroOrderPage.ConfirmZeroOrderCheckBox);
        }
    }
}
