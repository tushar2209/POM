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
    class PhonicsZeroOrderTestCases :PhonicsZeroOrderLib
    {
        ExcelUtil excelUtil;
        CommonFunctions commFunc;
        PhonicsZeroOrderLib phonicsZeroOrderLib;

        /// <summary>
        /// Method to set up pre- condition of test case
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            phonicsZeroOrderLib = new PhonicsZeroOrderLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "PhonicsZeroOrder");

            // Launch application Portal application
            phonicsZeroOrderLib.SetUpPreCondition("STA_PORTAL");

            // Login user and Navigate to respective form
            phonicsZeroOrderLib.LoginAndNavigatPhonicsZeroOrderForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
        }



        /// <summary>
        /// Test method to verify mandetoty fields of compensatory Marks
        /// </summary>

        [Test, Category("RegressionTest"), Property("AcceptanceCriteria", "3"), Property("TestCaseIDs", "41092")]
        public void VerifyMandetoryFieldsAndContactDetails()
        {
            // Start Application
            commFunc.StartApplication();

            phonicsZeroOrderLib.CheckContactDetailsFiledsValue(excelUtil.GetDataFromExcel("UserFirstName"), excelUtil.GetDataFromExcel("UserLastName"), excelUtil.GetDataFromExcel("JobTitle"), excelUtil.GetDataFromExcel("UserTeleNumber"), excelUtil.GetDataFromExcel("UserEmailAddress"));

            // Navigate to Page
            commFunc.SubmitForm();

            // Verify Review page Fileds
            phonicsZeroOrderLib.CheckMandetoryFields(excelUtil.GetDataFromExcel("MandFieldErrorMsg"));

        }

        /// <summary>
        /// Test method to verify mandetoty fields of compensatory Marks
        /// </summary>

        [Test, Category("RegressionTest"), Property("AcceptanceCriteria", "3"), Property("TestCaseIDs", "41093")]
        public void VerifyPhonicZeroOrderFormSubmission()
        {
            // Start Application
            commFunc.StartApplication();

            phonicsZeroOrderLib.SelectConfirmZeroOrder();

            // Navigate to Page
            commFunc.SubmitForm();

            // Verify Review page Fileds
            VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissonConMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Phonic Zero Order application Submission confrmation message.");


        }

    }
}
