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
    class EventLogsOfDownloadLib : BaseTestClass
    {
        public static SeleniumCommFunctions seleniumFunc;
        public static EventLogsOfDownloadPage eventLogsOfDownloadPage;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;


        public void InitialisePageObjects()
        {
            eventLogsOfDownloadPage = new EventLogsOfDownloadPage(driver);
            myActivityPage = new MyActivityPage(driver);

        }


        /// <summary>
        /// Metod to set up pre condition for test case.
        /// </summary>
        /// <param name="appURL"></param>
        public void SetUpPreCondition()
        {
            driver = GetDriver();
            seleniumFunc = new SeleniumCommFunctions();
            log.Info("Test method setup started");
            InitialisePageObjects();
            comFunc = new CommonFunctions();
        }

        public void FillEventLogOFDownloadForm( string documentName, string formDate, string toDate) {

            seleniumFunc.SelectValueFromDropDwn(eventLogsOfDownloadPage.DoucmentSDropDwn, documentName);
            comFunc.SelectDateFromDatePicker(eventLogsOfDownloadPage.FromDate,formDate);
            comFunc.SelectDateFromDatePicker(eventLogsOfDownloadPage.ToDate, toDate);
            seleniumFunc.WaitAndClickOnElement(eventLogsOfDownloadPage.SearchBtn);
            seleniumFunc.WaitForPageToLoad();
        }


        public void CheckSearchResult(string schoolName, string Email) {
            VerifyIsTrue(seleniumFunc.IsElementDisplayed(GetDriver().FindElement(By.XPath(eventLogsOfDownloadPage.SearchResult.Replace("$$", schoolName)))), "Check School Name should displayed in event log");
            VerifyIsTrue(seleniumFunc.IsElementDisplayed(GetDriver().FindElement(By.XPath(eventLogsOfDownloadPage.SearchResult.Replace("$$", Email)))), "Check user Email should displayed in event log");

        }

    }
}
