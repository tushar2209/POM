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
    class KSOneTestOrderLib : BaseTestClass
    {

        public static SeleniumCommFunctions seleniumFunc;

        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public MyActivityPage myActivityPage;
        public KSOneTestOrderPage ksOnePage;


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
            ksOnePage = new KSOneTestOrderPage(driver);
            myActivityPage = new MyActivityPage(driver);

        }

        /// <summary>
        /// Method to login to portal and navigate to MyActivity-> Available Activity -> KEY STAGE 1 
        /// </summary>
        /// <param name="userName"> userName</param>
        /// <param name="password">passWord</param>
        public void LoginAndNavigatKS1Form(string userName, string password)
        {

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.KS1TestOrderLink);

        }

        public void FillForm(bool privecyNoties, bool value1, string paper1No, bool value2, string paper2No)
        {
            if (privecyNoties)
                seleniumFunc.WaitAndClickOnElement(ksOnePage.ConfirmedPrivecyNoticeIssuedRadionBtn);
            else
                seleniumFunc.WaitAndClickOnElement(ksOnePage.PrivecyNoticeNotIssuedRadiobtn);

            if (value1)
                seleniumFunc.WaitAndClickOnElement(ksOnePage.YesRadioButtons[0]);
            else
            {
                seleniumFunc.WaitAndClickOnElement(ksOnePage.NoRadioButtons[0]);
                seleniumFunc.WaitAndEnterText(ksOnePage.PaperTextBoxes[0], paper1No);
            }

            if (value2)
                seleniumFunc.WaitAndClickOnElement(ksOnePage.YesRadioButtons[1]);
            else
            {
                seleniumFunc.WaitAndClickOnElement(ksOnePage.NoRadioButtons[1]);
                seleniumFunc.WaitAndEnterText(ksOnePage.PaperTextBoxes[1], paper2No);
            }
        }

        public void CheckPrivacyNotice(bool isIndependetSchool) {
            if (isIndependetSchool)
            {
                seleniumFunc.ScrollElementInView(ksOnePage.ConfirmedPrivecyNoticeIssuedRadionBtn);
                VerifyIsTrue(seleniumFunc.IsElementDisplayed(ksOnePage.ConfirmedPrivecyNoticeIssuedRadionBtn), "Check Confirmed - privacy notices issued Radion button should display.");
                VerifyIsTrue(seleniumFunc.IsElementDisplayed(ksOnePage.PrivecyNoticeNotIssuedRadiobtn), "Check Privacy notices have not been issued Radion button should display.");
            }
            else {
                seleniumFunc.ScrollElementInView(ksOnePage.YourEmailAddressTextBox);
                VerifyIsFalse(seleniumFunc.IsElementDisplayed(ksOnePage.ConfirmedPrivecyNoticeIssuedRadionBtn), "Check Confirmed - privacy notices issued Radion button should not display.");
                VerifyIsFalse(seleniumFunc.IsElementDisplayed(ksOnePage.PrivecyNoticeNotIssuedRadiobtn), "Check Privacy notices have not been issued Radion button should not display.");

            }

        }

        /// <summary>
        /// Method to select privacy noties confirmation ration button
        /// </summary>
        public void SelectPrivacyNotiesConfirmation()
        {
            if (seleniumFunc.IsElementDisplayed(ksOnePage.ConfirmedPrivecyNoticeIssuedRadionBtn))
                seleniumFunc.WaitAndClickOnElement(ksOnePage.ConfirmedPrivecyNoticeIssuedRadionBtn);
        }

    }
}
