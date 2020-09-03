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
    public class KsTwo : BaseTestClass
    {

        public KS2FromPage ks2FromPage;
        public SeleniumCommFunctions seleniumFunc;
        public KS2PortalPage ks2PortalPage;
        public MyActivityPage myActivityPage;


        public CommonFunctions comFunc;
        // public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void InitialisePageObjects() {
            ks2FromPage = new KS2FromPage(driver);
            ks2PortalPage = new KS2PortalPage(driver);
            myActivityPage = new MyActivityPage(driver);
        }

        public KsTwo() {

            seleniumFunc = new SeleniumCommFunctions();
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

        public void NaviagteToKs2From() {
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.ModifiedKS2);
        }


        #region Portal Page Methods
        /// <summary>
        /// 
        /// </summary>
        ///
        public void ClickOnStartApplication() {
           // HandleCookiePopup();
            
            seleniumFunc.WaitAndClickOnElement(ks2FromPage.StartFormBtn);
            seleniumFunc.WaitForPageToLoad();
         
        }


        public void FillFormModifiedKS2(String userName, String emailAddress)
        {
           
                seleniumFunc.WaitAndClickOnElement(ks2FromPage.PrivacyCheckbox);
                seleniumFunc.WaitForPageToLoad();
               
                seleniumFunc.EnterText(ks2FromPage.FullName, "Tushar");
                seleniumFunc.EnterText(ks2FromPage.EmailAdd, "tmehan@capita.co.uk");
           
        }

        /// <summary>
        /// 
        /// </summary>
        public void SubmitKs2OrderDetails(String totalPupilNo, String pupilVisual, String pupilSpcl)
        {
                seleniumFunc.EnterText(ks2FromPage.TotalPupilNo,"10");
                seleniumFunc.EnterText(ks2FromPage.PupilVisual,"4");
                seleniumFunc.EnterText(ks2FromPage.PupilSpcl,"3");
        }

        public void KS2_EnglishOrder(String EngGramarPunct_EP,String Eng_GP_SPLP, String EngGramarPunct_braille, String EngReading_EP, String EngReading_MLP, String EngReading_Braile)
        {
            seleniumFunc.EnterText(ks2FromPage.EngGramarPunct_EP,"3");
            seleniumFunc.EnterText(ks2FromPage.Eng_GP_SPLP,"2");

            seleniumFunc.EnterText(ks2FromPage.EngGramarPunct_braille,"1");
            seleniumFunc.EnterText(ks2FromPage.EngReading_EP,"2");

            seleniumFunc.EnterText(ks2FromPage.EngReading_MLP,"1");
            seleniumFunc.EnterText(ks2FromPage.EngReading_Braile,"3");
            
        }

        public void KS2_Mathematics(String Math_EP, String Math_MLP, String Math_Braille)
        {
                seleniumFunc.EnterText(ks2FromPage.Math_EP,"2");
                seleniumFunc.EnterText(ks2FromPage.Math_MLP,"1");
                seleniumFunc.EnterText(ks2FromPage.Math_Braille,"3");
               
         
        }

        public void VerifySubmiteddInfo()
        {
            seleniumFunc.WaitAndClickOnElement(ks2FromPage.VerifyBtn);
            seleniumFunc.WaitForLoaddingSpinnerDisapper();
            seleniumFunc.WaitForPageToLoad();
          //  seleniumFunc.WaitAndClickOnElement(ks2FromPage.Confirm_chckbox);
        }

        public void SubmitForm() {
           
            seleniumFunc.WaitAndClickOnElement(ks2FromPage.SubmitBtn);
            seleniumFunc.WaitForLoaddingSpinnerDisapper();
        }

        public String GetFromSubmisstionConfMsg() {
            String msg = "";
            msg = seleniumFunc.GetText(ks2FromPage.FormSubmitConfMsg);
            return msg;
        }

        #endregion

        #region Portal Page Methods
        /// <summary>
        /// 
        /// </summary>
        public void ClickCookieContinueBtn()
        {
            try
            {
                IWebElement continueBtn = ks2PortalPage.CookiePopUp.FindElement(By.Id("epdsubmit"));
                seleniumFunc.WaitAndClickOnElement(continueBtn);
                SendKeys.SendWait("{TAB}");
                SendKeys.SendWait("{ENTER}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public void HandleCookiePopup()
        {
            try
            {
                seleniumFunc.WaitForPageToLoad();
                seleniumFunc.WaitAndClickOnElement(ks2PortalPage.CookiesCheckbox);
                ClickCookieContinueBtn();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public void FillFormKS2()
        {
           seleniumFunc.WaitAndClickOnElement(ks2PortalPage.PrivacyCheckbox);
           seleniumFunc.ClickOnElement(ks2PortalPage.RadioNoBelowGPS);
                
           seleniumFunc.EnterText(ks2PortalPage.TxtBoxGPS, "2");
           seleniumFunc.WaitAndClickOnElement(ks2PortalPage.RadioNoBelowEng);
                
           seleniumFunc.EnterText(ks2PortalPage.TxtBoxEng, "2");
           seleniumFunc.ClickOnElement(ks2PortalPage.RadioYesBelowMath);
              
                // ConfirmCheckbox.Click();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String CaptureRefCode()
        {
            seleniumFunc.WaitForElementToBeVisible(ks2PortalPage.ReferenceCode);
            var refno = seleniumFunc.GetText(ks2PortalPage.ReferenceCode);
            log.Info("The refernce code of form is :" + refno);
            return refno;

        }
        #endregion 




        public void CloseApplication() {
            seleniumFunc.ClosedAllBrowser();
            log.Info("Closed Browser");

        }


    }
}
