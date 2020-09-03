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
    class EarlyOpeningApplicationTestCases : EarlyOpeningApplicationLib
    {
        ExcelUtil excelUtil;
        CommonFunctions commFunc;
        EarlyOpeningApplicationLib earlyOpeningLib;
        string EarlyOpneingMoreInfromation = "Early opening application more information";

        /// <summary>
        /// Method to set up pre- condition of test case
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            earlyOpeningLib = new EarlyOpeningApplicationLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "EarlyOpeningAppForm");

            // Launch application Portal application
            earlyOpeningLib.SetUpPreCondition("STA_PORTAL");

            // Login user and Navigate to respective form
            earlyOpeningLib.LoginAndNavigatEarlyOpeningAppForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

        }


        /// <summary>
        /// Test Method to verify Contact details
        /// </summary>
        [Test, Category("RegressionTest"), Property("TestCaseIDs", "40029")]
        public void VerifyContactDetails()
        {
            // Start Appliction
            commFunc.StartApplication();
            // Verify contact details 
            earlyOpeningLib.CheckContactDetailsFiledsValue("Main Application", excelUtil.GetDataFromExcel("UserFirstName"), excelUtil.GetDataFromExcel("UserLastName"), excelUtil.GetDataFromExcel("JobTitle"), excelUtil.GetDataFromExcel("UserTeleNumber"), excelUtil.GetDataFromExcel("UserEmailAddress"));

        }

        /// <summary>
        /// Test Method to verify end to end test case of  Application  -> review - > Approved
        /// </summary>
        [Test, Category("RegressionTest"), Category("SanityTest"), Category("SmokeTest"), Property("AcceptanceCriteria", "1")]
        public void VerifyEarlyOpeningAppReqWithDecissionApprovedCase()
        {
            string CaseRefer = excelUtil.GetDataFromExcel("CaseReferanceId");
            // Start application
            commFunc.StartApplication();

            // Fill application from
            earlyOpeningLib.FillEarlyOpeningApplication(excelUtil.GetDataFromExcel("PupilDetailType"), excelUtil.GetDataFromExcel("PupilName"), true, true, false, excelUtil.GetDataFromExcel("ReasonForEarlyOpening"), excelUtil.GetDataFromExcel("NumberOfSchoolDays"), excelUtil.GetDataFromExcel("MoreDetailsEarlyOpening"));

            // Submit form and verify confirmation msg
            commFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("AppSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application submission confrmation message");

            // log out with current user and Login to CM via STA user and naviagte to review from
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            commFunc.SearchCaseReferance(CaseRefer, null, null);
            commFunc.openedInCompetFormCmFromExpandView("EARAPRVIEW");


            // commFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
            //  commFunc.OpenFormFromOutStadingActivity("Application for early opening review ");

            // Verify Review from fileds value
            earlyOpeningLib.CheckReviewFromFieldValues(excelUtil, "Review");

            // select decission and submit form
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission1"), excelUtil.GetDataFromExcel("Decision1Reason"));
            commFunc.SubmitForm();

            // verify application submission confirmation message
            VerifyIsEquals(excelUtil.GetDataFromExcel("ReviewFromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application review submission confrmation message");

        }

        /// <summary>
        /// Test Method to verify end to end test case of  Application  -> review - > Rejected
        /// </summary>

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "40031")]
        public void VerifyEarlyOpeningAppReqWithDecissionRejectedCase()
        {
            string CaseRefer = excelUtil.GetDataFromExcel("CaseReferanceId");
            // Start application
            commFunc.StartApplication();
            // fill form
            earlyOpeningLib.FillEarlyOpeningApplication(excelUtil.GetDataFromExcel("PupilDetailType"), excelUtil.GetDataFromExcel("PupilName"), true, true, false, excelUtil.GetDataFromExcel("ReasonForEarlyOpening"), excelUtil.GetDataFromExcel("NumberOfSchoolDays"), excelUtil.GetDataFromExcel("MoreDetailsEarlyOpening"));

            // Submit fromand verify cofirmation msg
            commFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("AppSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application submission confrmation message");

            // log out with current user and Login to CM via STA user and naviagte to review from
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            commFunc.SearchCaseReferance(CaseRefer, null, null);
            commFunc.openedInCompetFormCmFromExpandView("EARAPRVIEW");

            // Verify review form fiels value
            earlyOpeningLib.CheckReviewFromFieldValues(excelUtil, "Review");

            // Select decisssion and submit form
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission1"), excelUtil.GetDataFromExcel("Decision1Reason"));
            commFunc.SubmitForm();

            // Verify Confirmation msg
            VerifyIsEquals(excelUtil.GetDataFromExcel("ReviewFromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application review submission confrmation message");

        }

        /// <summary>
        /// Test Method to verify end to end test case of  Application  -> review - > More Infromation -> review -> Approved
        /// </summary>
        [Test, Category("RegressionTest"), Category("SanityTest")]
        public void VerifyEarlyOpeningAppReqWithMoreInfoDecissionApprovedCase()
        {
            string CaseRefer = excelUtil.GetDataFromExcel("CaseReferanceId");
            // Start Application
            commFunc.StartApplication();
            // fill form
            earlyOpeningLib.FillEarlyOpeningApplication(excelUtil.GetDataFromExcel("PupilDetailType"), excelUtil.GetDataFromExcel("PupilName"), true, true, false, excelUtil.GetDataFromExcel("ReasonForEarlyOpening"), excelUtil.GetDataFromExcel("NumberOfSchoolDays"), excelUtil.GetDataFromExcel("MoreDetailsEarlyOpening"));

            // Submit form and verify confirmation msg
            comFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("AppSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application submission confrmation message");

            // log out with current user and Login to CM via STA user and naviagte to review from
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            commFunc.SearchCaseReferance(CaseRefer, null, null);
            commFunc.openedInCompetFormCmFromExpandView("EARAPRVIEW");

            // Verify review form fields valus
            earlyOpeningLib.CheckReviewFromFieldValues(excelUtil, "Review");

            // Select Decision and submit form
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission1"), excelUtil.GetDataFromExcel("Decision1Reason"));
            commFunc.SubmitForm();

            // Verify form submission confirmation msg
            VerifyIsEquals(excelUtil.GetDataFromExcel("ReviewFromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application review submission confrmation message");

            // Login to portal - School user and navigate review from
            commFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
            commFunc.OpenFormFromOutStadingActivity(EarlyOpneingMoreInfromation);


            // Add More infromation and upload supportive doc
            commFunc.AddMoreInfromation(excelUtil.GetDataFromExcel("AddtionalInformation"), excelUtil.GetDataFromExcel("UploadDoc1"), excelUtil.GetDataFromExcel("DocumentDecription1"));

            // Verify Review comments
            earlyOpeningLib.CheckReviewFromFieldValues(excelUtil, "MoreInfo");

            // Submit form and verify confrimation msg
            commFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("MoreInfoFromSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application more information submission confrmation message");

            // log out with current user and Login to CM via STA user and naviagte to review from
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            commFunc.SearchCaseReferance(CaseRefer, null, null);
            commFunc.openedInCompetFormCmFromExpandView("EARAPRVIEW");

            // Select Decission and submit form
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission2"), excelUtil.GetDataFromExcel("Decision1Description"));
            commFunc.SubmitForm();

            // verify form submission confirmation msg
            VerifyIsEquals(excelUtil.GetDataFromExcel("Review2FromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application review submission confrmation message");

        }

        /// <summary>
        /// Test Method to verify end to end test case of  Application  -> review - > More Infromation -> review -> Rejected
        /// </summary>

        [Test, Category("RegressionTest")]
        public void VerifyEarlyOpeningAppReqWithMoreInfoDecissionRejectedCase()
        {
            string CaseRefer = excelUtil.GetDataFromExcel("CaseReferanceId");

            // Start Application
            commFunc.StartApplication();

            // Fill form
            earlyOpeningLib.FillEarlyOpeningApplication(excelUtil.GetDataFromExcel("PupilDetailType"), excelUtil.GetDataFromExcel("PupilName"), true, true, false, excelUtil.GetDataFromExcel("ReasonForEarlyOpening"), excelUtil.GetDataFromExcel("NumberOfSchoolDays"), excelUtil.GetDataFromExcel("MoreDetailsEarlyOpening"));

            // Submit form and verify confirmation msg
            comFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("AppSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application submission confrmation message");

            // log out with current user and Login to CM via STA user and naviagte to review from
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            commFunc.SearchCaseReferance(CaseRefer, null, null);
            commFunc.openedInCompetFormCmFromExpandView("EARAPRVIEW");

            // Verify review form fields value
            earlyOpeningLib.CheckReviewFromFieldValues(excelUtil, "Review");

            // Select decission and submit form & verify confirmation msg
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission1"), excelUtil.GetDataFromExcel("Decision1Reason"));
            commFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("ReviewFromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application review submission confrmation message");

            // logout with currnet user & Login to portal - School user and navigate more info form
            commFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
            commFunc.OpenFormFromOutStadingActivity(EarlyOpneingMoreInfromation);


            // Add more infromation & verify review comments
            commFunc.AddMoreInfromation(excelUtil.GetDataFromExcel("AddtionalInformation"), excelUtil.GetDataFromExcel("UploadDoc1"), excelUtil.GetDataFromExcel("DocumentDecription1"));
            earlyOpeningLib.CheckReviewFromFieldValues(excelUtil, "MoreInfo");

            // submit form and verify confirmation msg
            commFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("MoreInfoFromSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application more information submission confrmation message");

            // log out with current user and Login to CM via STA user and naviagte to review from
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            commFunc.SearchCaseReferance(CaseRefer, null, null);
            commFunc.openedInCompetFormCmFromExpandView("EARAPRVIEW");


            // Select decisson and submit form
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission2"), excelUtil.GetDataFromExcel("Decision1Description"));
            commFunc.SubmitForm();

            // Verify Fromsubmission confirmation msg
            VerifyIsEquals(excelUtil.GetDataFromExcel("Review2FromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application review submission confrmation message");

        }
    }

}
