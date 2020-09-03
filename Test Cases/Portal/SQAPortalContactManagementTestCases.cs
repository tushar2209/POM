using NUnit.Framework;
using STA.Utilities.ExcelReader;
using STA__Automation.BussinessLib;
using STA__Automation.CommonLib;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.TestCases.Portal
{
    class SQAPortalContactManagementTestCases : SQAPortalContactManagementLib
    {
        static ExcelUtil excelUtil;
        CommonFunctions commFunc;
        SQAPortalContactManagementLib SQAPortalLib;

        [SetUp]
        public void SetUp()
        {
            SQAPortalLib = new SQAPortalContactManagementLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "SQAPortalContact");
            SQAPortalLib.SetUpPreCondition("STA_PORTAL");
            SQAPortalLib.LoginAndNavigatToForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
        }


        [Test, Category("RegressionTest")]
        public void VerifySQAForNewUser()
        {
            comFunc.StartApplication();

            string dyanmicEmailAddress = DateTime.Now.ToString("yyyyMMddhhmmss") + "@capita.co.uk";
            // fill user creation form
            SQAPortalLib.FillUserCreationForm(excelUtil.GetDataFromExcel("Option"), excelUtil.GetDataFromExcel("userType"), dyanmicEmailAddress, excelUtil.GetDataFromExcel("NewContactFirstName"), excelUtil.GetDataFromExcel("NewContactSurname"), excelUtil.GetDataFromExcel("JobTitle"), excelUtil.GetDataFromExcel("TelephoneNo"));

            // Submit form
            //SQAPortalLib.CheckMaximumUserCreationLimitMsg(excelUtil.GetDataFromExcel("MaximumUserCreationLimitMsg"));

        }
    }
    
   
}
