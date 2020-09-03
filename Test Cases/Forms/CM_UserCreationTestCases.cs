using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using STA.Utilities.ExcelReader;
using STA__Automation.BussinessLib;
using STA__Automation.CommonLib;

namespace STA__Automation.TestCases.Forms
{
    class CM_UserCreationTestCases : CM_UserCreationLib
    {

        static ExcelUtil excelUtil;
        CommonFunctions commFunc;
        CM_UserCreationLib CmUserCreationLib;


        [SetUp]
        public void SetUp()
        {
            CmUserCreationLib = new CM_UserCreationLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "CM_UserCreation");
            CmUserCreationLib.SetUpPreCondition();

            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
        }

        [Test, Category("RegressionTest")]
        public void VerifySchoolUsersCreation()
        {
            // search case referance and navigate to respective form
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), excelUtil.GetDataFromExcel("Email"), null);

            commFunc.CreateNewFrom(excelUtil.GetDataFromExcel("FormName"));

            string dyanmicEmailAddress = DateTime.Now.ToString("yyyyMMddhhmmss") + "@capita.co.uk";
            // fill user creation form
            CmUserCreationLib.FillUserCreationForm(excelUtil.GetDataFromExcel("Option"), excelUtil.GetDataFromExcel("userType"), dyanmicEmailAddress, excelUtil.GetDataFromExcel("NewContactFirstName"), excelUtil.GetDataFromExcel("NewContactSurname"), excelUtil.GetDataFromExcel("JobTitle"), excelUtil.GetDataFromExcel("TelephoneNo"));

            // Submit form
            commFunc.SubmitForm();
            string expectedResult =( excelUtil.GetDataFromExcel("FormSubmissionConfMsg") + dyanmicEmailAddress.Trim()).Replace(" : ", "_");
            string actualResult= commFunc.GetFormSubmissionConfirmationMsg().Replace(" : ", "_");
            // verify application submission confirmation message
            VerifyIsEquals(expectedResult, actualResult, "Check School user creation confrmation message.");

        }

        [Test, Category("RegressionTest")]
        public void VerifyLA_UsersCreation()
        {
            // search case referance and navigate to respective form
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
            commFunc.CreateNewFrom(excelUtil.GetDataFromExcel("FormName"));

            string dyanmicEmailAddress = DateTime.Now.ToString("yyyyMMddhhmmss") + "@capita.co.uk";
           
            // fill user creation form
            CmUserCreationLib.FillLACreationForm(excelUtil.GetDataFromExcel("userType"), dyanmicEmailAddress, excelUtil.GetDataFromExcel("NewContactFirstName"), excelUtil.GetDataFromExcel("NewContactSurname"), excelUtil.GetDataFromExcel("JobTitle"), excelUtil.GetDataFromExcel("TelephoneNo"));

            // Submit form
            commFunc.SubmitForm();

            // verify application submission confirmation message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check LA user creation confrmation message.");


        }
    }
}
