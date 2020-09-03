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
    class CompensatoryMarksTestCases : CompensatoryMarksLib
    {

        ExcelUtil excelUtil;
        CommonFunctions commFunc;
        CompensatoryMarksLib compensatoryMarksLib;

        /// <summary>
        /// Method to set up pre- condition of test case
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            compensatoryMarksLib = new CompensatoryMarksLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "CompensatoryMarks");

            // Launch application Portal application
            compensatoryMarksLib.SetUpPreCondition("STA_PORTAL");

            // Login user and Navigate to respective form
            compensatoryMarksLib.LoginAndNavigatCompensatoryMarksForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
        }



        /// <summary>
        /// Test method to verify mandetoty fields of compensatory Marks
        /// </summary>
   
        [Test, Category("RegressionTest"), Property("AcceptanceCriteria", "3"), Property("TestCaseIDs", "36521\n39021")]
        public void VerifyMandetoryFieldsAndContactDetails()
        {
            // Start Application
            commFunc.StartApplication();

            compensatoryMarksLib.CheckContactDetailsFiledsValue(excelUtil.GetDataFromExcel("UserFirstName"), excelUtil.GetDataFromExcel("UserLastName"), excelUtil.GetDataFromExcel("JobTitle"), excelUtil.GetDataFromExcel("UserTeleNumber"), excelUtil.GetDataFromExcel("UserEmailAddress"));

            // Navigate to Page
            commFunc.NaviagteToNextPage();

            // Verify Review page Fileds
            VerifyIsEquals("", commFunc.CheckMandetoryFieldsMsgOnReviewAndSubmitPage(1, excelUtil.GetDataFromExcel("MandetoryFieldsList")), "Check common mandetory field list on Review Page");

            commFunc.NavigateBackToPreiousPages(1);

            compensatoryMarksLib.FillForm(excelUtil.GetDataFromExcel("PupilName"), 2,  excelUtil.GetDataFromExcel("ReasonForCompensatoryMarks"));

            // Verify Review page Fileds
            VerifyIsTrue(comFunc.IsSubmitButtonDisplayed(), "Check Submit button should display after Mandetory fields fill.");

        }

        /// <summary>
        /// Test case to varify compansantry mark submission functionality
        /// </summary>
        [Test, Property("AcceptanceCriteria", "2"), Property("TestCaseIDs", "")]
        public void VerifyCompanSantryMarksSubmissionScenario() {
           
            // Start Application
            commFunc.StartApplication();

            //fill application form 
            compensatoryMarksLib.FillForm(excelUtil.GetDataFromExcel("PupilName"), 2, excelUtil.GetDataFromExcel("ReasonForCompensatoryMarks"));

            // Submit  form
            comFunc.SubmitForm(true);

            // Verify foirm submission message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionConfirmation"),comFunc.GetFormSubmissionConfirmationMsg(),"Check form submission message.");
        }

    }
}
