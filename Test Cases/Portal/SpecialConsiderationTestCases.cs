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
    class SpecialConsiderationTestCases : SpecialConsiderationLib
    {
        ExcelUtil excelUtil;
        CommonFunctions commFunc;
        SpecialConsiderationLib specialConsiderationLib;

        /// <summary>
        /// Method to set up pre- condition of test case
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            specialConsiderationLib = new SpecialConsiderationLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "SpecialConsiderationForm");

            // Launch application Portal application
            specialConsiderationLib.SetUpPreCondition("STA_PORTAL");

            // Login user and Navigate to respective form
            specialConsiderationLib.LoginAndNavigatEarlyOpeningAppForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
        }


        /// <summary>
        /// Test method to verify mandetoty fields of Early opening form
        /// </summary>

        [Test, Category("RegressionTest")]
        public void VerifyMandetoryFieldsAndContactDetails()
        {
            // Start Application
            commFunc.StartApplication();

            specialConsiderationLib.CheckContactDetailsFiledsValue(excelUtil.GetDataFromExcel("UserFirstName"), excelUtil.GetDataFromExcel("UserLastName"), excelUtil.GetDataFromExcel("JobTitle"), excelUtil.GetDataFromExcel("UserTeleNumber"), excelUtil.GetDataFromExcel("UserEmailAddress"));

            // Navigate to Page
            commFunc.NaviagteToNextPage();

            // Verify Review page Fileds
            string MandetoryFieldsMsg = commFunc.CheckMandetoryFieldsMsgOnReviewAndSubmitPage(1, excelUtil.GetDataFromExcel("MandetoryFieldsErrorList"));

            VerifyIsEquals("", MandetoryFieldsMsg, "Check common mandetory filed list on Review Page");

        }

        [Test, Category("RegressionTest"), Category("Demo"), Property("AcceptanceCriteria", "2"), Property("TestCaseIDs", "36521\n39021")]
        public void VerifySpecialConsiderationAutoApproved1Case()
        {
            // Start Application
            commFunc.StartApplication();

            bool[] Subjects = { true, false, true, false };
            bool[] QuestionsAns = { true, true, true, true };

            // Fill Application from and navigate to next page
            specialConsiderationLib.fillApplication(excelUtil.GetDataFromExcel("PupilDetailType"), excelUtil.GetDataFromExcel("PupilName"), Subjects, QuestionsAns, excelUtil.GetDataFromExcel("ReasonForSpecialConsideration"), excelUtil.GetDataFromExcel("DateOfincident"), excelUtil.GetDataFromExcel("RelationshipToPupil"), excelUtil.GetDataFromExcel("BrieflyExplain"));

            // Submit form and verify submission message
            commFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application Submission Auto Approved confrmation message.");

        }

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "40854")]
        public void VerifySpecialConsiderationAutoApproved2Case()
        {
            // Start Application
            commFunc.StartApplication();

            bool[] Subjects = { true, false, true, false };
            bool[] QuestionsAns = { true, true, true, true };

            // Fill Application from and navigate to next page
            specialConsiderationLib.fillApplication(excelUtil.GetDataFromExcel("PupilDetailType"), excelUtil.GetDataFromExcel("PupilName"), Subjects, QuestionsAns, excelUtil.GetDataFromExcel("ReasonForSpecialConsideration"), excelUtil.GetDataFromExcel("DateOfincident"), excelUtil.GetDataFromExcel("RelationshipToPupil"), excelUtil.GetDataFromExcel("BrieflyExplain"));

            // Submit form and verify submission message
            commFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application Submission Auto Approved confrmation message.");

        }


        [Test, Category("RegressionTest"), Category("Demo"), Property("AcceptanceCriteria", "3")]
        public void VerifySpecialConsiderationWithDecissionApprovedCase()
        {
            bool[] Subjects = { true, false, true, false };
            bool[] QuestionsAns = { true, true, true, true };

            // Start Application
            commFunc.StartApplication();

            // Fill Application from and navigate to next page
            specialConsiderationLib.fillApplication(excelUtil.GetDataFromExcel("PupilDetailType"), excelUtil.GetDataFromExcel("PupilName"), Subjects, QuestionsAns, excelUtil.GetDataFromExcel("ReasonForSpecialConsideration"), excelUtil.GetDataFromExcel("DateOfincident"), excelUtil.GetDataFromExcel("RelationshipToPupil"), excelUtil.GetDataFromExcel("BrieflyExplain"));

            // Submit form and verify submission message
            commFunc.SubmitForm();

            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("UserCMName"), excelUtil.GetDataFromExcel("UserCmPassword"));
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
            comFunc.openedInCompetFormCmFromExpandView(excelUtil.GetDataFromExcel("ShortNmae"));

            //erifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application Submission Auto Approved confrmation message.");


            // Logout with current user and Log with STA user -Navigate to repsective form
            //commFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
            //commFunc.OpenFormFromOutStadingActivity("Special consideration review");

            // Verify Review Form
            specialConsiderationLib.CheckReviewFromFieldValues(excelUtil, "Review", Subjects, QuestionsAns);

            // Select Decission 
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission1"), excelUtil.GetDataFromExcel("Decision1Reason"));

            // Submit form and verify result
            commFunc.SubmitForm();
            //VerifyIsTrue(commFunc.GetFormSubmissionConfirmationMsg().Contains("submitted successfully"), "Check Application form Submission confirmation msg.");
            VerifyIsEquals(excelUtil.GetDataFromExcel("ReviewFromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application form Submission confirmation msg.");
        }

        [Test, Category("RegressionTest")]
        public void VerifySpecialConsiderationWithDecissionRejectedCase()
        {
            // Start Application
            commFunc.StartApplication();

            bool[] Subjects = { true, false, true, false };
            bool[] QuestionsAns = { true, true, true, true };

            // Fill Application from and navigate to next page
            specialConsiderationLib.fillApplication(excelUtil.GetDataFromExcel("PupilDetailType"), excelUtil.GetDataFromExcel("PupilName"), Subjects, QuestionsAns, excelUtil.GetDataFromExcel("ReasonForSpecialConsideration"), excelUtil.GetDataFromExcel("DateOfincident"), excelUtil.GetDataFromExcel("RelationshipToPupil"), excelUtil.GetDataFromExcel("BrieflyExplain"));

            // Submit form and verify submission message
            commFunc.SubmitForm();
            //erifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application Submission Auto Approved confrmation message.");
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("UserCMName"), excelUtil.GetDataFromExcel("UserCmPassword"));
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
            comFunc.openedInCompetFormCmFromExpandView(excelUtil.GetDataFromExcel("ShortNmae"));

            //Logout with current user and Log with STA user - Navigate to repsective form
            //commFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
            //commFunc.OpenFormFromOutStadingActivity("Special consideration review");

            // Verify Review Form
            specialConsiderationLib.CheckReviewFromFieldValues(excelUtil, "Review", Subjects, QuestionsAns);

            // Select Decission 
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission1"), excelUtil.GetDataFromExcel("Decision1Reason"));

            // Submit form and verify result
            commFunc.SubmitForm();
            // VerifyIsTrue(commFunc.GetFormSubmissionConfirmationMsg().Contains("submitted successfully"), "Check Application form Submission confirmation msg.");
            VerifyIsEquals(excelUtil.GetDataFromExcel("ReviewFromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application form Submission confirmation msg.");

        }


        [Test, Category("RegressionTest"), Property("TestCaseIDs", "40770")]
        public void VerifySpecialConsiderationWithMoreInfoAndDecissionApprovedCase()
        {
            bool[] Subjects = { true, false, true, false };
            bool[] QuestionsAns = { true, true, true, true };


            // Start Application
            commFunc.StartApplication();

            // Fill Application from and navigate to next page
            specialConsiderationLib.fillApplication(excelUtil.GetDataFromExcel("PupilDetailType"), excelUtil.GetDataFromExcel("PupilName"), Subjects, QuestionsAns, excelUtil.GetDataFromExcel("ReasonForSpecialConsideration"), excelUtil.GetDataFromExcel("DateOfincident"), excelUtil.GetDataFromExcel("RelationshipToPupil"), excelUtil.GetDataFromExcel("BrieflyExplain"));

            // Submit form and verify submission message
            commFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application Submission confrmation message.");
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("UserCMName"), excelUtil.GetDataFromExcel("UserCmPassword"));
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
            comFunc.openedInCompetFormCmFromExpandView(excelUtil.GetDataFromExcel("ShortNmae"));

            // Logout with current user and Log with STA user -Navigate to repsective form
            ////commFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
            ////commFunc.OpenFormFromOutStadingActivity("Special consideration review");

            //// Verify Review Form
            //specialConsiderationLib.CheckReviewFromFieldValues(excelUtil, "Review", Subjects, QuestionsAns);

            //// Select Decission 
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission1"), excelUtil.GetDataFromExcel("Decision1Reason"));

            //// Submit form and verify result
            commFunc.SubmitForm();
            //// VerifyIsTrue(commFunc.GetFormSubmissionConfirmationMsg().Contains("submitted successfully"), "Check Review form Submission confirmation msg.");
            //VerifyIsEquals(excelUtil.GetDataFromExcel("ReviewFromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Review form Submission confirmation msg.");
            //omFunc.NavigateBackToCaseManager();
            //pecialConsiderationLib.LogOffCm();
            //comFunc.openedInCompetFormCmFromExpandView(excelUtil.GetDataFromExcel("ShortNmae"));
            specialConsiderationLib.SetUpPreCondition("STA_PORTAL");
            //// Login to portal - School user and navigate review from
            comFunc.LoginIntoPortal(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
            commFunc.OpenFormFromOutStadingActivity("Special consideration additional information");

            //// Add More infromation and upload supportive doc
            commFunc.AddMoreInfromation(excelUtil.GetDataFromExcel("AddtionalInformation"), excelUtil.GetDataFromExcel("UploadDoc1"), excelUtil.GetDataFromExcel("DocumentDecription1"));

            //// Verify Review comments
         //   specialConsiderationLib.CheckReviewFromFieldValues(excelUtil, "MoreInfo", Subjects, QuestionsAns);

          //  Submit form and verify confrimation msg
            commFunc.SubmitForm();
            //VerifyIsTrue(commFunc.GetFormSubmissionConfirmationMsg().Contains("submitted successfully"), "Check application more information submission confrmation message");
            //VerifyIsEquals(excelUtil.GetDataFromExcel("MoreInfoFromSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Addtional Information form Submission confirmation msg.");

            //Login to portal - STA user and navigate review form
            //comFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
            //commFunc.OpenFormFromOutStadingActivity("Special consideration review");
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("UserCMName"), excelUtil.GetDataFromExcel("UserCmPassword"));
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
            comFunc.openedInCompetFormCmFromExpandView(excelUtil.GetDataFromExcel("ShortNmae"));

            //   Verify Review Form
           // specialConsiderationLib.CheckReviewFromFieldValues(excelUtil, "ReReview", Subjects, QuestionsAns);
           // specialConsiderationLib.CheckReReviewAddtionalInfromation(excelUtil.GetDataFromExcel("AddtionalInformation"), excelUtil.GetDataFromExcel("UploadDoc1"));

           // Select Decission and submit form
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission2"), excelUtil.GetDataFromExcel("Decision2Reason"));
            commFunc.SubmitForm();

            //verify form submission confirmation msg
             VerifyIsTrue(commFunc.GetFormSubmissionConfirmationMsg().Contains("submitted successfully"), "Check application Re-Review form submission confrmation message");
            VerifyIsEquals(excelUtil.GetDataFromExcel("Review2FromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application form Submission confirmation msg.");

        }


        [Test, Category("RegressionTest"), Property("TestCaseIDs", "40856")]
        public void VerifySpecialConsiderationWithMoreInfoAndDecissionRejectedCase()
        {
            bool[] Subjects = { true, false, true, false };
            bool[] QuestionsAns = { true, true, true, true };




            // Start Application
            commFunc.StartApplication();

            // Fill Application from and navigate to next page
            specialConsiderationLib.fillApplication(excelUtil.GetDataFromExcel("PupilDetailType"), excelUtil.GetDataFromExcel("PupilName"), Subjects, QuestionsAns, excelUtil.GetDataFromExcel("ReasonForSpecialConsideration"), excelUtil.GetDataFromExcel("DateOfincident"), excelUtil.GetDataFromExcel("RelationshipToPupil"), excelUtil.GetDataFromExcel("BrieflyExplain"));

            // Submit form and verify submission message
            commFunc.SubmitForm();
            // VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application Submission Auto Approved confrmation message.");
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("UserCMName"), excelUtil.GetDataFromExcel("UserCmPassword"));
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
            comFunc.openedInCompetFormCmFromExpandView(excelUtil.GetDataFromExcel("ShortNmae"));

            // Logout with current user and Log with STA user -Navigate to repsective form
            //commFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
            //commFunc.OpenFormFromOutStadingActivity("Special consideration review");

            // Verify Review Form
            specialConsiderationLib.CheckReviewFromFieldValues(excelUtil, "Review", Subjects, QuestionsAns);

            // Select Decission 
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission1"), excelUtil.GetDataFromExcel("Decision1Reason"));

            // Submit form and verify result
            commFunc.SubmitForm();

            specialConsiderationLib.SetUpPreCondition("STA_PORTAL");
            //// Login to portal - School user and navigate review from
            comFunc.LoginIntoPortal(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
            ////// VerifyIsTrue(commFunc.GetFormSubmissionConfirmationMsg().Contains("submitted successfully"), "Check Review form Submission confirmation msg.");
            ////VerifyIsEquals(excelUtil.GetDataFromExcel("ReviewFromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Review form Submission confirmation msg.");

            ////// Login to portal - School user and navigate review from
            ////comFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
            ////commFunc.OpenFormFromOutStadingActivity("Special consideration additional information");
            commFunc.OpenFormFromOutStadingActivity("Special consideration additional information");


            ////// Add More infromation and upload supportive doc
            commFunc.AddMoreInfromation(excelUtil.GetDataFromExcel("AddtionalInformation"), excelUtil.GetDataFromExcel("UploadDoc1"), excelUtil.GetDataFromExcel("DocumentDecription1"));
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("UserCMName"), excelUtil.GetDataFromExcel("UserCmPassword"));
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
            comFunc.openedInCompetFormCmFromExpandView(excelUtil.GetDataFromExcel("ShortNmae"));

            ////// Verify Review comments
            ////specialConsiderationLib.CheckReviewFromFieldValues(excelUtil, "MoreInfo", Subjects, QuestionsAns);

            ////// Submit form and verify confrimation msg
            commFunc.SubmitForm();
            //////VerifyIsTrue(commFunc.GetFormSubmissionConfirmationMsg().Contains("submitted successfully"), "Check Addtional Information form Submission confirmation msg.");
            ////VerifyIsEquals(excelUtil.GetDataFromExcel("MoreInfoFromSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Addtional Information form Submission confirmation msg.");

            ////// Login to portal - STA user and navigate review form
            ////comFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
            ////commFunc.OpenFormFromOutStadingActivity("Special consideration review");

            ////// Verify Review Form
            ////specialConsiderationLib.CheckReviewFromFieldValues(excelUtil, "ReReview", Subjects, QuestionsAns);

            ////specialConsiderationLib.CheckReReviewAddtionalInfromation(excelUtil.GetDataFromExcel("AddtionalInformation"), excelUtil.GetDataFromExcel("UploadDoc1"));

            ////// Select Decission and submit form
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission2"), excelUtil.GetDataFromExcel("Decision2Reason"));
            commFunc.SubmitForm();

            ////// verify form submission confirmation msg
            ////// VerifyIsTrue(commFunc.GetFormSubmissionConfirmationMsg().Contains("submitted successfully"), "Check application Re-Review form submission confrmation message");
            ////VerifyIsEquals(excelUtil.GetDataFromExcel("Review2FromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application form Submission confirmation msg.");

        }

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "37723")]
        public void VarifyMaintainedHistoryWhenMultipelTimeMoreInfoRequested()
        {

            bool[] Subjects = { true, false, true, false };
            bool[] QuestionsAns = { true, true, true, true };
            string[] histroyDateAndTime = new string[2];
            string[] histroyReasonForDecision = { excelUtil.GetDataFromExcel("Decision1Reason"), excelUtil.GetDataFromExcel("Decision2Reason") };
            string[] histroyAddionalInfo = { excelUtil.GetDataFromExcel("AddtionalInformation"), excelUtil.GetDataFromExcel("AddtionalInformation2") };


            // Start Application
            commFunc.StartApplication();

            // Fill Application from and navigate to next page
            specialConsiderationLib.fillApplication(excelUtil.GetDataFromExcel("PupilDetailType"), excelUtil.GetDataFromExcel("PupilName"), Subjects, QuestionsAns, excelUtil.GetDataFromExcel("ReasonForSpecialConsideration"), excelUtil.GetDataFromExcel("DateOfincident"), excelUtil.GetDataFromExcel("RelationshipToPupil"), excelUtil.GetDataFromExcel("BrieflyExplain"));

            // Submit form and verify submission message
            commFunc.SubmitForm();
            //VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application Submission Auto Approved confrmation message.");
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("UserCMName"), excelUtil.GetDataFromExcel("UserCmPassword"));
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
            comFunc.openedInCompetFormCmFromExpandView(excelUtil.GetDataFromExcel("ShortNmae"));

            // Logout with current user and Log with STA user -Navigate to repsective form
            //commFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
            //commFunc.OpenFormFromOutStadingActivity("Special consideration review");

            // Select Decission 
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission1"), excelUtil.GetDataFromExcel(""));

            // Submit form and verify result
            commFunc.SubmitForm();
            //  VerifyIsEquals(excelUtil.GetDataFromExcel("ReviewFromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Review form Submission confirmation msg.");

            // Login to portal - School user and navigate review from
            //comFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
            //commFunc.OpenFormFromOutStadingActivity("Special consideration additional information");
            specialConsiderationLib.SetUpPreCondition("STA_PORTAL");
            //// Login to portal - School user and navigate review from
            comFunc.LoginIntoPortal(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
            commFunc.OpenFormFromOutStadingActivity("Special consideration additional information");

            // Store revoew commnet date and Time
            histroyDateAndTime[0] = specialConsiderationLib.GetReviewCommentDateAndTime(0);

            //Verify History
            specialConsiderationLib.CheckMaintainedHistory(1, "Additional information", histroyDateAndTime, histroyReasonForDecision, histroyAddionalInfo);

            // Submit form and verify confrimation msg
            commFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("MoreInfoFromSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Addtional Information form Submission confirmation msg.");

            //// Login to portal - STA user and navigate review form
            //comFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
            //commFunc.OpenFormFromOutStadingActivity("Special consideration review");

            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("UserCMName"), excelUtil.GetDataFromExcel("UserCmPassword"));
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
            comFunc.openedInCompetFormCmFromExpandView(excelUtil.GetDataFromExcel("ShortNmae"));

            // Select Decission and submit form
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission2"), excelUtil.GetDataFromExcel("Decision2Reason"));

            //Verify History
            specialConsiderationLib.CheckMaintainedHistory(1, "Special consideration review", histroyDateAndTime, histroyReasonForDecision, histroyAddionalInfo);

            commFunc.SubmitForm();

            // verify form submission confirmation msg
            // VerifyIsEquals(excelUtil.GetDataFromExcel("Review2FromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application form Submission confirmation msg.");

            // Login to portal - School user and navigate review from
            //comFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            specialConsiderationLib.SetUpPreCondition("STA_PORTAL");
            //// Login to portal - School user and navigate review from
            comFunc.LoginIntoPortal(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
            commFunc.OpenFormFromOutStadingActivity("Special consideration additional information");


            histroyDateAndTime[1] = specialConsiderationLib.GetReviewCommentDateAndTime(1);

            //Verify History
            specialConsiderationLib.CheckMaintainedHistory(2, "Additional information", histroyDateAndTime, histroyReasonForDecision, histroyAddionalInfo);


            // Submit form and verify confrimation msg
            commFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("MoreInfoFromSubmissionConfMsg2"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Addtional Information form Submission confirmation msg.");
            specialConsiderationLib.SetUpPreCondition("STA_PORTAL");
            //// Login to portal - School user and navigate review from
            // comFunc.LoginIntoPortal(excelUtil.GetDataFromExcel("UserName"), excelUtil
            // Login to portal - STA user and navigate review form
            //comFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
            comFunc.LoginIntoPortal(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));


            commFunc.OpenFormFromOutStadingActivity("Special consideration review");


            //Verify Maintain History
            specialConsiderationLib.CheckMaintainedHistory(2, "Special consideration review", histroyDateAndTime, histroyReasonForDecision, histroyAddionalInfo);

            // Select Decission and submit form
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission3"), excelUtil.GetDataFromExcel("Decision3Reason"));

            commFunc.SubmitForm();

            // verify form submission confirmation msg
            VerifyIsEquals(excelUtil.GetDataFromExcel("Review3FromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application form Submission confirmation msg.");


        }



    }
}
