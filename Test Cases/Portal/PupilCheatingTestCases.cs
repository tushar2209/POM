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
    class PupilCheatingTestCases : PupilCheatingLib
    {
        ExcelUtil excelUtil;
        CommonFunctions commFunc;
        PupilCheatingLib pupilCheatingLib;

        /// <summary>
        /// Method to set up pre- condition of test case
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            pupilCheatingLib = new PupilCheatingLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "NotificationOfPupilCheatingForm");

            // Launch application Portal application
            pupilCheatingLib.SetUpPreCondition("STA_PORTAL");

            // Login user and Navigate to respective form
            pupilCheatingLib.LoginAndNavigatPupilCheatingForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
        }



        /// <summary>
        /// Test method to verify mandetoty fields of Early opening form
        /// </summary>

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "27625")]
        public void VerifyMandetoryFieldsAndContactDetails()
        {
            // Start Application
            commFunc.StartApplication();

            pupilCheatingLib.CheckContactDetailsFiledsValue(excelUtil.GetDataFromExcel("UserFirstName"), excelUtil.GetDataFromExcel("UserLastName"), excelUtil.GetDataFromExcel("JobTitle"), excelUtil.GetDataFromExcel("UserTeleNumber"), excelUtil.GetDataFromExcel("UserEmailAddress"));

            // Navigate to Page
            commFunc.NaviagteToNextPage();

            // Verify Review page Fileds
            VerifyIsEquals("", commFunc.CheckMandetoryFieldsMsgOnReviewAndSubmitPage(1, excelUtil.GetDataFromExcel("MandetoryFieldsErrorList1")), "Check common mandetory filed list1 on Review Page");

            commFunc.NavigateBackToPreiousPages(1);
            string[] NoQMarkedRemoved = { };

            pupilCheatingLib.FillForm(excelUtil.GetDataFromExcel("PupilName"), excelUtil.GetDataFromExcel("TypeOfActionReq"), null, NoQMarkedRemoved);

         
            // Verify Review page Fileds
            VerifyIsEquals("", commFunc.CheckMandetoryFieldsMsgOnReviewAndSubmitPage(1, excelUtil.GetDataFromExcel("MandetoryFieldsErrorList2")), "Check common mandetory filed list2 on Review Page");

        }

        /// <summary>
        /// Test method to verify mandetoty fields of Early opening form
        /// </summary>

        [Test, Category("RegressionTest"), Category("Demo"), Property("AcceptanceCriteria", "2"), Property("TestCaseIDs", "27796 \n 27625")]
        public void VerifyAnnulResultForTestPaper()
        {
            string[] NoQMarkedRemoved = { excelUtil.GetDataFromExcel("NoQuestionMarksRemoved1") };
            // Start Application
            commFunc.StartApplication();

            pupilCheatingLib.FillForm(excelUtil.GetDataFromExcel("PupilName"), excelUtil.GetDataFromExcel("TypeOfActionReq"),excelUtil.GetDataFromExcel("Test"), NoQMarkedRemoved);

            commFunc.SubmitForm(true);

            // verify application submission confirmation message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application submission confrmation message.");

        }

        /// <summary>
        /// Test method to verify mandetoty fields of Early opening form
        /// </summary>

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "27900 \n 28106")]
        public void VerifyRemoveOnlyMarksGainedFromSpecificQuestions()
        {
            string[] NoQMarkedRemoved = { excelUtil.GetDataFromExcel("NoQuestionMarksRemoved1"), excelUtil.GetDataFromExcel("NoQuestionMarksRemoved2") };
           
            // Start Application
            commFunc.StartApplication();

            pupilCheatingLib.FillForm(excelUtil.GetDataFromExcel("PupilName"), excelUtil.GetDataFromExcel("TypeOfActionReq"), excelUtil.GetDataFromExcel("Test"), NoQMarkedRemoved);

            commFunc.SubmitForm(true);

            // verify application submission confirmation message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application submission confrmation message.");

        }

    }
}
