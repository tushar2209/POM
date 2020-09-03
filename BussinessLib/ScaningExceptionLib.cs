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
    class ScaningExceptionLib : BaseTestClass
    {

        public static SeleniumCommFunctions seleniumFunc;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static Scanning_ExceptionPage scanexcept;
        public static Scaning_ResolutionPage resolve;

        //driver = GetDriver();
        //seleniumFunc = new SeleniumCommFunctions();
        //comFunc = new CommonFunctions();

        public void SetUpPreCondition()
        {
            //driver = GetDriver();
            //seleniumFunc = new SeleniumCommFunctions();
            //comFunc = new CommonFunctions();

            //log.Info("Test method setup started");
            //InitialisePageObjects();


            //log.Info("launch application");
            //comFunc.LaunchApplication(appURL);


            driver = GetDriver();
            seleniumFunc = new SeleniumCommFunctions();
            comFunc = new CommonFunctions();

            log.Info("Test method setup started");
            InitialisePageObjects();

        }

        public void InitialisePageObjects()
        {


            scanexcept = new Scanning_ExceptionPage(driver);
            //myActivityPage = new MyActivityPage(driver);
            resolve = new Scaning_ResolutionPage(driver);


        }
        //public void LoginAndNavigatToScaningException(string userName, string password)
        //{

        //    commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
        //    commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
        //    commFunc.CreateNewFrom(excelUtil.GetDataFromExcel("FormName"));
        //    //comFunc.SignOutUser();
        //    //log.Info("Login to application");
        //    //comFunc.LoginIntoPortal(userName, password);

        //    //log.Info("Navigate to From");
        //    //comFunc.NaviagteToFormUnderMyActivity(myActivityPage.Scanningexception);

        //}


        public void SelectExceptionCategory(string exceptioncategory)
        {
            seleniumFunc.SelectValueFromDropDwnUsingValue(scanexcept.ExceptionCategory, exceptioncategory);

        }

        public void SelectSite(string site)
        {
            seleniumFunc.SelectValueFromDropDwnUsingValue(scanexcept.Site, site);

        }

        public void Function(string function)
        {
            seleniumFunc.SelectValueFromDropDwnUsingValue(scanexcept.Function, function);

        }


        public void TestPaper(string testppaer)
        {
            seleniumFunc.SelectValueFromDropDwnUsingValue(scanexcept.TestPaper, testppaer);

        }


        public void BatchId(string batchid)
        {
            seleniumFunc.EnterText(scanexcept.BatchID, batchid);

        }

        public void Description(string desc)
        {
            seleniumFunc.EnterText(scanexcept.Description, desc);

        }
        public void ClickImage()
        {
            seleniumFunc.ClickOnElementViaJavaScript(scanexcept.ClickImageOfCM);

        }

        public void ClickFilter( string caserefernce)
        {

            seleniumFunc.EnterText(scanexcept.ClickFilter, caserefernce);
        }


      

    }

}
