using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using static STA__Automation.BaseLib.Enums;
using log4net;
using STA__Automation.Pages.Forms;


using System.Windows.Forms;
using OpenQA.Selenium;
using STA__Automation.Pages.Portal;

namespace STA__Automation.BussinessLib
{
    public class ModifiedKS2Lib : BaseTestClass
    {
        public static IWebDriver driver;
        public CommonFunctions comFunc;
        public MyActivityPage myActivityPage;
        public ModifiedKS2Page ModifiedKS2;
        public SeleniumCommFunctions seleniumFunc;
        public KS2PortalPage ks2PortalPage;

        public void InitialisePageObjects() {
            ModifiedKS2 = new ModifiedKS2Page(driver);
            ks2PortalPage = new KS2PortalPage(driver);
            myActivityPage = new MyActivityPage(driver);
        }

        public ModifiedKS2Lib()
        {
            seleniumFunc = new SeleniumCommFunctions();
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

        public void SetUp(String appURL,String userName, String password) {

            log.Info("Test method setup started");
            InitialisePageObjects();
            comFunc = new CommonFunctions();

            log.Info("launch application");
            comFunc.LaunchApplication(appURL); 

            log.Info("Login to application");
           // comFunc.LoginIntoPortal(userName, password);
        }

        public void LoginAndNavigateToModifiedKS2Form(string userName, string password)
        {

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.ModifiedKS2);

        }
        public void CheckPrePopulatedFiledsValue(string FullName, string Email)
        {
           VerifyIsEquals(FullName, seleniumFunc.GetAttributeValue(ModifiedKS2.YourFullName, "value"), "Check Contact full name");
           
            VerifyIsEquals(Email, seleniumFunc.GetAttributeValue(ModifiedKS2.YourEmail, "value"), "Check Contact email address");

        }



        #region Portal Page Methods
        /// <summary>
        /// 
        /// </summary>
        ///
        public void ClickOnStartApplication() {
           // HandleCookiePopup();
            
            seleniumFunc.WaitAndClickOnElement(ModifiedKS2.StartFormBtn);
            seleniumFunc.WaitForPageToLoad();
         
        }

        /// <summary>
        /// 
        /// </summary>
        public void SubmitKs2OrderDetails(String totalPupilNo, String pupilVisual, String pupilSpcl)
        {
                seleniumFunc.EnterText(ModifiedKS2.TotalPupilNo, totalPupilNo);
                seleniumFunc.EnterText(ModifiedKS2.PupilVisual,pupilVisual);
                seleniumFunc.EnterText(ModifiedKS2.PupilSpcl, pupilSpcl);
        }

        public void KS2_EnglishOrder(String EngGramarPunct_EP,String Eng_GP_SPLP, String EngGramarPunct_braille, String EngReading_EP, String EngReading_MLP, String EngReading_Braile)
        {
            seleniumFunc.EnterText(ModifiedKS2.EngGramarPunct_EP, EngGramarPunct_EP);
            seleniumFunc.EnterText(ModifiedKS2.Eng_GP_SPLP, Eng_GP_SPLP);

            seleniumFunc.EnterText(ModifiedKS2.EngGramarPunct_braille, EngGramarPunct_braille);
            seleniumFunc.EnterText(ModifiedKS2.EngReading_EP, EngReading_EP);

            seleniumFunc.EnterText(ModifiedKS2.EngReading_MLP, EngReading_MLP);
            seleniumFunc.EnterText(ModifiedKS2.EngReading_Braile, EngReading_Braile);
            
        }

        public void KS2_Mathematics(String Math_EP, String Math_MLP, String Math_Braille)
        {
                seleniumFunc.EnterText(ModifiedKS2.Math_EP, Math_EP);
                seleniumFunc.EnterText(ModifiedKS2.Math_MLP, Math_MLP);
                seleniumFunc.EnterText(ModifiedKS2.Math_Braille, Math_Braille);
               
         
        }

        public void VerifySubmiteddInfo()
        {
            seleniumFunc.WaitAndClickOnElement(ModifiedKS2.VerifyBtn);
            seleniumFunc.WaitForLoaddingSpinnerDisapper();
            seleniumFunc.WaitForPageToLoad();
          //  seleniumFunc.WaitAndClickOnElement(ModifiedKS2.Confirm_chckbox);
        }

        public void SubmitForm() {
           
            seleniumFunc.WaitAndClickOnElement(ModifiedKS2.SubmitBtn);
            seleniumFunc.WaitForLoaddingSpinnerDisapper();
        }


        /// <summary>
        /// Method to CHeck 
        /// </summary>
        /// <param name="isIndependetSchool"></param>
        public void CheckPrivacyNotice(bool isIndependetSchool)
        {
            if (isIndependetSchool)
            {
                seleniumFunc.ScrollElementInView(ModifiedKS2.ConfirmedPrivecyNoticeIssuedRadionBtn);
                VerifyIsTrue(seleniumFunc.IsElementDisplayed(ModifiedKS2.ConfirmedPrivecyNoticeIssuedRadionBtn), "Check Confirmed - privacy notices issued Radion button should display.");
                VerifyIsTrue(seleniumFunc.IsElementDisplayed(ModifiedKS2.PrivecyNoticeNotIssuedRadiobtn), "Check Privacy notices have not been issued Radion button should display.");
                seleniumFunc.WaitAndClickOnElement(ModifiedKS2.PrivecyNoticeNotIssuedRadiobtn);
                seleniumFunc.WaitForPageToLoad();
                VerifyIsTrue(seleniumFunc.IsElementDisplayed(ModifiedKS2.PrivecyNoticeNotIssuedErrorMsg), "Check error message should dispaly when 'Privacy notices have not been issued' raido button selected.");
            }
            else
            {
                VerifyIsFalse(seleniumFunc.IsElementDisplayed(ModifiedKS2.ConfirmedPrivecyNoticeIssuedRadionBtn), "Check Confirmed - privacy notices issued Radion button should not display.");
                VerifyIsFalse(seleniumFunc.IsElementDisplayed(ModifiedKS2.ConfirmedPrivecyNoticeIssuedRadionBtn), "Check Privacy notices have not been issued Radion button should not display.");

            }

        }






        #endregion





    }
}
