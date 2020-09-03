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
    class KSTwoTestOrderTestCases : KSTwoTestOrderLib
    {
        ExcelUtil excelUtil;
        CommonFunctions commFunc;
        KSTwoTestOrderLib ksTwoLib;

        /// <summary>
        /// Method to set up pre- condition of test case
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            ksTwoLib = new KSTwoTestOrderLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "KSTwoTestOrderForm");

            // Launch application Portal application
            ksTwoLib.SetUpPreCondition("STA_PORTAL");

        }


        [Test, Property("TestCaseIDs", "37924")]
        public void VerifyPrivacyPolicyForIndependentSchools()
        {
            // Login user and Navigate to respective form
            ksTwoLib.LoginAndNavigatKS2TestOrderForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();

            // Fill Form
            ksTwoLib.CheckPrivacyNotice(true);

        }

        [Test, Property("TestCaseIDs", "37928")]
        public void VerifyPrivacyPolicyForAcademySchools()
        {
            // Login user and Navigate to respective form
            ksTwoLib.LoginAndNavigatKS2TestOrderForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();

            // Check privecy Form
            ksTwoLib.CheckPrivacyNotice(false);

        }

        [Test]
        public void VerifyKeyStage2TestOrder()
        {
            // Login user and Navigate to respective form
            ksTwoLib.LoginAndNavigatKS2TestOrderForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();

            ksTwoLib.SelectPrivacyNotiesConfirmation();

            // Fill Form
            ksTwoLib.FillForm( false, excelUtil.GetDataFromExcel("Paper1"), false, excelUtil.GetDataFromExcel("Paper2"), false, excelUtil.GetDataFromExcel("Paper3"));

            // Submit Form
            commFunc.SubmitForm();
            // Verify Fromsubmission confirmation msg
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application submission confrmation message");

        }

        [Test]
        public void VerifyKeyStage2TestZeroOrder()
        {
            // Login user and Navigate to respective form
            ksTwoLib.LoginAndNavigatKS2TestOrderForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();

            ksTwoLib.SelectPrivacyNotiesConfirmation();

            // Fill Form
            ksTwoLib.FillForm( true, excelUtil.GetDataFromExcel("Paper1"), true, excelUtil.GetDataFromExcel("Paper2"), true, excelUtil.GetDataFromExcel("Paper3"));

            // Submit Form
            commFunc.SubmitForm();

            // Verify Fromsubmission confirmation msg
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application submission confrmation message");

        }


        [Test]

        public void VerifyKeyStage2TestOrderLastUpdatedPersonDetails()
        {

            // Login user and Navigate to respective form
            ksTwoLib.LoginAndNavigatKS2TestOrderForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();

            ksTwoLib.SelectPrivacyNotiesConfirmation();

            // Fill Form
            ksTwoLib.FillForm( false, excelUtil.GetDataFromExcel("Paper1"), false, excelUtil.GetDataFromExcel("Paper2"), false, excelUtil.GetDataFromExcel("Paper3"));

            // Submit Form
            commFunc.SubmitForm();

            // Verify Fromsubmission confirmation msg
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application submission confrmation message");

            // Launch application Portal application
            ksTwoLib.SetUpPreCondition("STA_PORTAL");

            // Login user and Navigate to respective form
            ksTwoLib.LoginAndNavigatKS2TestOrderForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();

            // verify last updated date
            ksTwoLib.CheckLastUpdateOrderPersonDetails(excelUtil.GetDataFromExcel("FullName"), excelUtil.GetDataFromExcel("YourEmail"));

        }

    }
}
