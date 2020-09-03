using OpenQA.Selenium;
using STA.Utilities.ExcelReader;
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
    class CreateSchoolUserLib : BaseTestClass
    {
        public static CreateSchoolUserPage CreateSchool;
        public static SeleniumCommFunctions seleniumFunc;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;
        public static ExcelUtil excelUtil;
        public static CommonFunctions commFunc;

        const string Normal = "Normal";
        const string Super = "Super";
        const string headteacher = "headteacher";
        public void InitialisePageObjects()
        {
            CreateSchool = new CreateSchoolUserPage(driver);
            myActivityPage = new MyActivityPage(driver);
            commFunc = new CommonFunctions();
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

        public void LoginAndSearchForForm()
        {
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CaseManagUser"), excelUtil.GetDataFromExcel("CaseManagPwd"));
            commFunc.searchAndOpenCaseReferance(excelUtil.GetDataFromExcel("CaseRef"), null,null);
            commFunc.NaviagteToNextPage();
            commFunc.NaviagteToNextPage();

            commFunc.CreateNewFrom(excelUtil.GetDataFromExcel("FormName"));

        }

        public void SelectUserRole(string UserRole)
        {
            seleniumFunc.ScrollElementInView(CreateSchool.NormalUserCheckbox);
            if (UserRole != null)
                if (UserRole.Equals(Normal))
                {
                    seleniumFunc.WaitAndClickOnElement(CreateSchool.NormalUserCheckbox);
                }
                else if (UserRole.Equals(Super))
                {
                    seleniumFunc.WaitAndClickOnElement(CreateSchool.SuperUserCheckbox);
                }
                else if (UserRole.Equals(headteacher))
                {
                    seleniumFunc.WaitAndClickOnElement(CreateSchool.HeadTeacherCheckbox);
                }

        }


       public void FillApplication(string UserFirstName, string UserSurname, string JobTitle, string EmailAdd, string ConfrimEmail, string Telephone)
       {

       }



    }


}
