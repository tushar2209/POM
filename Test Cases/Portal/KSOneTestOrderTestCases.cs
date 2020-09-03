using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using STA.Utilities.ExcelReader;
using STA__Automation.BussinessLib;
using STA__Automation.CommonLib;

namespace STA__Automation.TestCases.Portal
{
    class KSOneTestOrderTestCases :KSOneTestOrderLib
    {

        ExcelUtil excelUtil;
        CommonFunctions commFunc;
        KSOneTestOrderLib ksOneLib;

        /// <summary>
        /// Method to set up pre- condition of test case
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            ksOneLib = new KSOneTestOrderLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "KSOneForm");

            // Launch application Portal application
            ksOneLib.SetUpPreCondition("STA_PORTAL");

            
        }

        [Test]
        public void VerifyKeyStage1TestOrder() {
            // Login user and Navigate to respective form
            ksOneLib.LoginAndNavigatKS1Form(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();

            ksOneLib.SelectPrivacyNotiesConfirmation();

            // Fill Form
            ksOneLib.FillForm(true,false, excelUtil.GetDataFromExcel("Paper1"), false, excelUtil.GetDataFromExcel("Paper2"));

            // Submit Form
            commFunc.SubmitForm();

            // Verify Fromsubmission confirmation msg
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application submission confrmation message");

        }


        [Test]
        public void VerifyKeyStage1TestZeroOrder()
        {
            // Login user and Navigate to respective form
            ksOneLib.LoginAndNavigatKS1Form(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();

            ksOneLib.SelectPrivacyNotiesConfirmation();

            // Fill Form
            ksOneLib.FillForm(true,true, excelUtil.GetDataFromExcel("Paper1"), true, excelUtil.GetDataFromExcel("Paper2"));

            // Submit Form
            commFunc.SubmitForm();

            // Verify Fromsubmission confirmation msg
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application submission confrmation message");

        }

        [Test, Property("TestCaseIDs", "37919")]
        public void VerifyPrivacyPolicyForIndependentSchools()
        {
            // Login user and Navigate to respective form
            ksOneLib.LoginAndNavigatKS1Form(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
           
            // Start application
            commFunc.StartApplication();

            // Fill Form
            ksOneLib.CheckPrivacyNotice(true);
         
        }

        [Test, Property("TestCaseIDs", "37921")]
        public void VerifyPrivacyPolicyForAcademySchools()
        {
            // Login user and Navigate to respective form
            ksOneLib.LoginAndNavigatKS1Form(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();

            // Check privecy Form
            ksOneLib.CheckPrivacyNotice(false);

        }

        [Test, Property("TestCaseIDs", "37929")]
        public void VerifyPrivacyPolicyForNormalSchools()
        {
            // Login user and Navigate to respective form
            ksOneLib.LoginAndNavigatKS1Form(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();

            // Fill Form
            ksOneLib.CheckPrivacyNotice(false);

        }
    }
}
