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
    class ScaningResolutionLib: BaseTestClass
    {
        public static SeleniumCommFunctions seleniumFunc;
        public static Scaning_ResolutionPage scanresolve;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;

        public void SetUpPreCondition()        {
            driver = GetDriver();
            seleniumFunc = new SeleniumCommFunctions();
            comFunc = new CommonFunctions();

            log.Info("Test method setup started");
            InitialisePageObjects();


            log.Info("launch application");
           // comFunc.LaunchApplication();

        }


        public void InitialisePageObjects()
        {


            scanresolve = new Scaning_ResolutionPage(driver);
            myActivityPage = new MyActivityPage(driver);



        }


        public void LoginAndNavigatToScaningException(string userName, string password)
        {
            comFunc.SignOutUser();
            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.ScanningResolution);

        }

        public void Start()
        {
            seleniumFunc.Click(scanresolve.Start);

        }


        public void CheckResolved()
        {
            seleniumFunc.ClickOnElement(scanresolve.Resolved);

        }

        public void CheckCICClosure()
        {
            seleniumFunc.ClickOnElement(scanresolve.CICClosure);

        }

        public void EnterNotes( string notes )
        {
            seleniumFunc.EnterText(scanresolve.Notes, notes);

        }

        public void NotCreateClosure()
        {
            seleniumFunc.ClickOnElement(scanresolve.NotCreateClosure);

        }




    }
}
