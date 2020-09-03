using NUnit.Framework;
using STA.Utilities.ExcelReader;
using STA__Automation.BussinessLib;
using STA__Automation.CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.TestCases.Portal
{
    class SchoolPortalContactsMangTestCases : CM_UserCreationLib
    {

        static ExcelUtil excelUtil;
        CommonFunctions commFunc;
        CM_UserCreationLib CmUserCreationLib;


        [SetUp]
        public void SetUp()
        {
            CmUserCreationLib = new CM_UserCreationLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "SchoolPortalContactsMang");
         
            CmUserCreationLib.SetUpPreCondition("STA_PORTAL");
            CmUserCreationLib.LoginAndNavigatToForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
        }

        [Test, Category("RegressionTest")]
        public void VerifySchoolUsersCreationLimitValidationForNewUser()
        {
            comFunc.StartApplication();
           
            string dyanmicEmailAddress = DateTime.Now.ToString("yyyyMMddhhmmss") + "@capita.co.uk";
            // fill user creation form
            CmUserCreationLib.FillUserCreationForm(excelUtil.GetDataFromExcel("Option"), excelUtil.GetDataFromExcel("userType"), dyanmicEmailAddress, excelUtil.GetDataFromExcel("NewContactFirstName"), excelUtil.GetDataFromExcel("NewContactSurname"), excelUtil.GetDataFromExcel("JobTitle"), excelUtil.GetDataFromExcel("TelephoneNo"));

            // Submit form
            CmUserCreationLib.CheckMaximumUserCreationLimitMsg(excelUtil.GetDataFromExcel("MaximumUserCreationLimitMsg"));

        }

        [Test, Category("RegressionTest")]
        public void VerifySchoolUsersCreationLimitValidationForUpdateUser()
        {
            comFunc.StartApplication();

            string dyanmicEmailAddress = DateTime.Now.ToString("yyyyMMddhhmmss") + "@capita.co.uk";
            // fill user creation form
            CmUserCreationLib.FillUserCreationForm(excelUtil.GetDataFromExcel("Option"), excelUtil.GetDataFromExcel("userType"), dyanmicEmailAddress, excelUtil.GetDataFromExcel("NewContactFirstName"), excelUtil.GetDataFromExcel("NewContactSurname"), excelUtil.GetDataFromExcel("JobTitle"), excelUtil.GetDataFromExcel("TelephoneNo"));

            // Submit form
            CmUserCreationLib.CheckMaximumUserCreationLimitMsg(excelUtil.GetDataFromExcel("MaximumUserCreationLimitMsg"));

        }


    }
}
