using OpenQA.Selenium;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;
using STA__Automation.Pages.Portal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.BussinessLib
{
    class MarkerTrainingConfirmationLib :BaseTestClass
    {
        public static MarkerTrainingConfirmationPage trainingConfirmationPage;
        public static SeleniumCommFunctions seleniumFunc;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;


        public void InitialisePageObjects()
        {
            trainingConfirmationPage = new MarkerTrainingConfirmationPage(driver);
            myActivityPage = new MyActivityPage(driver);

        }

        /**
        * Metod to set up pre condition for test case.
        **/
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

        public void LoginAndNavigatToForm(string userName, string password)
        {

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.MarkerTraningConfirmationFormLink);
        }

        public void FillForm(bool TrainingAttended , bool Visualcheck , string RTWDec , string RTWDocExpDate, string FileName) {

            if (TrainingAttended)
                seleniumFunc.WaitAndClickOnElement(trainingConfirmationPage.ConfirmTrainingAttendCheckBox);
            if(Visualcheck)
                seleniumFunc.WaitAndClickOnElement(trainingConfirmationPage.ConfirmVisualCheckBox);
            seleniumFunc.EnterText(trainingConfirmationPage.RTWDescription, RTWDec);

            comFunc.SelectDateFromDateDropDown(trainingConfirmationPage.RTWDOcExppriryDate, RTWDocExpDate);

            UploadDocuments(FileName, trainingConfirmationPage.fileUploads[0]);
        }



        public void UploadDocuments(string fileName, IWebElement ele)
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string filePath = Path.Combine(projectPath, "Resources\\" + fileName);
            seleniumFunc.EnterTextWithoutClear(ele, filePath);
            seleniumFunc.WaitForPageToLoad();
        }
    }
}
