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
    class KSTwoTestOrderLib : BaseTestClass
    {

        public static SeleniumCommFunctions seleniumFunc;

        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public MyActivityPage myActivityPage;
        public KSTwoTestOrderPage kSTwoTestOrderPage;


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
            kSTwoTestOrderPage = new KSTwoTestOrderPage(driver);
            myActivityPage = new MyActivityPage(driver);

        }

        /// <summary>
        /// Method to login to portal and navigate to MyActivity-> Available Activity -> KEY STAGE 1 
        /// </summary>
        /// <param name="userName"> userName</param>
        /// <param name="password">passWord</param>
        public void LoginAndNavigatKS2TestOrderForm(string userName, string password)
        {

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.KS2TestPaperOrderLink);

        }

   

        public void CheckPrivacyNotice(bool isIndependetSchool)
        {
            if (isIndependetSchool)
            {
                seleniumFunc.ScrollElementInView(kSTwoTestOrderPage.ConfirmedPrivecyNoticeIssuedRadionBtn);
                VerifyIsTrue(seleniumFunc.IsElementDisplayed(kSTwoTestOrderPage.ConfirmedPrivecyNoticeIssuedRadionBtn), "Check Confirmed - privacy notices issued Radion button should display.");
                VerifyIsTrue(seleniumFunc.IsElementDisplayed(kSTwoTestOrderPage.PrivecyNoticeNotIssuedRadiobtn), "Check Privacy notices have not been issued Radion button should display.");
            }
            else
            {
                seleniumFunc.ScrollElementInView(kSTwoTestOrderPage.YourEmailAddressTextBox);
                VerifyIsFalse(seleniumFunc.IsElementDisplayed(kSTwoTestOrderPage.ConfirmedPrivecyNoticeIssuedRadionBtn), "Check Confirmed - privacy notices issued Radion button should not display.");
                VerifyIsFalse(seleniumFunc.IsElementDisplayed(kSTwoTestOrderPage.PrivecyNoticeNotIssuedRadiobtn), "Check Privacy notices have not been issued Radion button should not display.");

            }

        }

        public void FillFormWithPrivecyNoties(bool privecyNoties, bool value1, string paper1No, bool value2, string paper2No, bool value3, string paper3No)
        {
            if (privecyNoties)
                seleniumFunc.WaitAndClickOnElement(kSTwoTestOrderPage.ConfirmedPrivecyNoticeIssuedRadionBtn);
            else
                seleniumFunc.WaitAndClickOnElement(kSTwoTestOrderPage.PrivecyNoticeNotIssuedRadiobtn);

            FillForm( value1,  paper1No,  value2,  paper2No,  value3,  paper3No);


        }


        public void FillForm( bool value1, string paper1No, bool value2, string paper2No, bool value3, string paper3No)
        {
         
            if (value1)
                seleniumFunc.WaitAndClickOnElement(kSTwoTestOrderPage.YesRadioButtons[0]);
            else
            {
                seleniumFunc.WaitAndClickOnElement(kSTwoTestOrderPage.NoRadioButtons[0]);
                seleniumFunc.WaitAndEnterText(kSTwoTestOrderPage.PaperTextBoxes[0], paper1No);
            }

            if (value2)
                seleniumFunc.WaitAndClickOnElement(kSTwoTestOrderPage.YesRadioButtons[1]);
            else
            {
                seleniumFunc.WaitAndClickOnElement(kSTwoTestOrderPage.NoRadioButtons[1]);
                seleniumFunc.WaitAndEnterText(kSTwoTestOrderPage.PaperTextBoxes[1], paper2No);
            }

            if (value3)
                seleniumFunc.WaitAndClickOnElement(kSTwoTestOrderPage.YesRadioButtons[2]);
            else
            {
                seleniumFunc.WaitAndClickOnElement(kSTwoTestOrderPage.NoRadioButtons[2]);
                seleniumFunc.WaitAndEnterText(kSTwoTestOrderPage.PaperTextBoxes[2], paper3No);
            }
        }

        public void CheckLastUpdateOrderPersonDetails(string FullName, string Email)
        {

            VerifyIsEquals(FullName, seleniumFunc.GetAttributeValue(kSTwoTestOrderPage.LastPersonToUpdateOrder, "value"), "Check Last update order person fullname");

            VerifyIsEquals(Email, seleniumFunc.GetAttributeValue(kSTwoTestOrderPage.EmailAddress, "value"), "Check Last update order person emaill");


        }

        /// <summary>
        /// Method to select privacy noties confirmation ration button
        /// </summary>
        public void SelectPrivacyNotiesConfirmation()
        {
            if (seleniumFunc.IsElementDisplayed(kSTwoTestOrderPage.ConfirmedPrivecyNoticeIssuedRadionBtn))
                seleniumFunc.WaitAndClickOnElement(kSTwoTestOrderPage.ConfirmedPrivecyNoticeIssuedRadionBtn);
        }

    }
}
