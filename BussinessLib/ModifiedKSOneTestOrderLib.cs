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
    class ModifiedKSOneTestOrderLib : BaseTestClass
    {
        public static IWebDriver driver;
        public CommonFunctions commFunc;
        public MyActivityPage myActivityPage;
        public ModifiedKSOneTestOrderPage ModifiedKS1Page;
        public SeleniumCommFunctions seleniumFunc;
        public KS2PortalPage ks2PortalPage;

        public void InitialisePageObjects()
        {
            ModifiedKS1Page = new ModifiedKSOneTestOrderPage(driver);
            ks2PortalPage = new KS2PortalPage(driver);
            myActivityPage = new MyActivityPage(driver);
        }

        public void SetUpPreCondition(string appURL)
        {
            driver = GetDriver();

            seleniumFunc = new SeleniumCommFunctions();
            log.Info("Test method setup started");
            InitialisePageObjects();
            commFunc = new CommonFunctions();

            log.Info("launch application");
            commFunc.LaunchApplication(appURL);

        }

        public void LoginAndNavigateToModifiedKS1Form(string userName, string password)
        {

            log.Info("Login to application");
            commFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            NavigateToModifiedKS1Form();

        }

        public void  NavigateToModifiedKS1Form() {

            log.Info("Navigate to From");
            commFunc.NaviagteToFormUnderMyActivity(myActivityPage.ModifyedKS1TestOrderLink);

        }

        public void CheckPrePopulatedFiledsValue(string FullName, string Email)
        {
            VerifyIsEquals(FullName, seleniumFunc.GetAttributeValue(ModifiedKS1Page.YourFullName, "value"), "Check Contact full name");

            VerifyIsEquals(Email, seleniumFunc.GetAttributeValue(ModifiedKS1Page.YourEmail, "value"), "Check Contact email address");

        }

        public void FillEnglishGPS(string MLP, string braille)
        {
            seleniumFunc.WaitAndEnterText(ModifiedKS1Page.EnglishGrammergMLP, MLP);
            seleniumFunc.WaitAndEnterText(ModifiedKS1Page.EnglishGrammergBraille, braille);

        }

        public void FillEnglishReading(string MLP, string braille)
        {
            seleniumFunc.WaitAndEnterText(ModifiedKS1Page.EnglishReadingMLP, MLP);
            seleniumFunc.WaitAndEnterText(ModifiedKS1Page.EnglishReadingBraille, braille+Keys.Tab);

        }

        public void FillMathematics(string MLP, string braille)
        {
            seleniumFunc.WaitAndEnterText(ModifiedKS1Page.MathematicsMLP, MLP);
            seleniumFunc.WaitAndEnterText(ModifiedKS1Page.MathematicsBraille, braille);

        }

        public void FillPupilNumbers(string totalPupilNo, string pupilVisual , string pupilSpcl) {

            seleniumFunc.WaitAndEnterText(ModifiedKS1Page.TotalPupilReqModifiedTest, totalPupilNo);
            seleniumFunc.WaitAndEnterText(ModifiedKS1Page.NoPupilVisualImpairment, pupilVisual);
            seleniumFunc.WaitAndEnterText(ModifiedKS1Page.NoPupilOtherSpecialNeeds, pupilSpcl);

        }

        
        public void CheckLastUpdateOrderPersonDetails(string FullName, string Email) {

            VerifyIsEquals(FullName, seleniumFunc.GetAttributeValue(ModifiedKS1Page.LastPersonFullName, "value"), "Check Last update order person fullname");

            VerifyIsEquals(Email, seleniumFunc.GetAttributeValue(ModifiedKS1Page.LastPersonEmail, "value"), "Check Last update order person emaill");


        }

        public void CheckWarningMsgForPupileVisualImpairment() {


            VerifyIsTrue( seleniumFunc.IsElementDisplayed(ModifiedKS1Page.EnglishGrammergMLPErrorMsg), "Check English Grammerg MLP Error Msg");

            VerifyIsTrue( seleniumFunc.IsElementDisplayed(ModifiedKS1Page.MathematicsMLPErrorMsg), "Check Mathematics MLP Error Msg");

            VerifyIsTrue(seleniumFunc.IsElementDisplayed(ModifiedKS1Page.EnglishReadingMLPErrorMsg), "Check English Reading MLP Error Msg");


        }

        public void CheckWarningMsgForPupileOtherSpecialNeeds()
        {
            VerifyIsTrue(seleniumFunc.IsElementDisplayed(ModifiedKS1Page.EnglishGrammergBrailleErrorMsg), "Check English Grammerg Braille Error Msg");

            VerifyIsTrue(seleniumFunc.IsElementDisplayed(ModifiedKS1Page.MathematicsBrailleErrorMsg), "Check Mathematics Braille Error Msg");

            VerifyIsTrue(seleniumFunc.IsElementDisplayed(ModifiedKS1Page.EnglishReadingBrailleErrorMsg), "Check English Reading Braille Error Msg");


        }

        /// <summary>
        /// Method to CHeck 
        /// </summary>
        /// <param name="isIndependetSchool"></param>
        public void CheckPrivacyNotice(bool isIndependetSchool)
        {
            if (isIndependetSchool)
            {
                seleniumFunc.ScrollElementInView(ModifiedKS1Page.ConfirmedPrivecyNoticeIssuedRadionBtn);
                VerifyIsTrue(seleniumFunc.IsElementDisplayed(ModifiedKS1Page.ConfirmedPrivecyNoticeIssuedRadionBtn), "Check Confirmed - privacy notices issued Radion button should display.");
                VerifyIsTrue(seleniumFunc.IsElementDisplayed(ModifiedKS1Page.PrivecyNoticeNotIssuedRadiobtn), "Check Privacy notices have not been issued Radion button should display.");
                seleniumFunc.WaitAndClickOnElement(ModifiedKS1Page.PrivecyNoticeNotIssuedRadiobtn);
                seleniumFunc.WaitForPageToLoad();
                VerifyIsTrue(seleniumFunc.IsElementDisplayed(ModifiedKS1Page.PrivecyNoticeNotIssuedErrorMsg), "Check error message should dispaly when 'Privacy notices have not been issued' raido button selected.");
            }
            else
            {
                VerifyIsFalse(seleniumFunc.IsElementDisplayed(ModifiedKS1Page.ConfirmedPrivecyNoticeIssuedRadionBtn), "Check Confirmed - privacy notices issued Radion button should not display.");
                VerifyIsFalse(seleniumFunc.IsElementDisplayed(ModifiedKS1Page.PrivecyNoticeNotIssuedRadiobtn), "Check Privacy notices have not been issued Radion button should not display.");

            }

        }

        /// <summary>
        /// Method to select privacy noties confirmation ration button
        /// </summary>
        public void SelectPrivacyNotiesConfirmation() {
            if(seleniumFunc.IsElementDisplayed(ModifiedKS1Page.ConfirmedPrivecyNoticeIssuedRadionBtn))
            seleniumFunc.WaitAndClickOnElement(ModifiedKS1Page.ConfirmedPrivecyNoticeIssuedRadionBtn);
        }



    }
}
