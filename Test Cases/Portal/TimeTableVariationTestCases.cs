using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using STA.Utilities.ExcelReader;
using STA__Automation.BaseLib;
using STA__Automation.BussinessLib;
using STA__Automation.CommonLib;


namespace STA__Automation.TestCases.Portal
{
    [TestFixture]
    class TimeTableVariationTestCases : TimeTableVariationLib
    {
        TimeTableVariationLib timeTableVarLib;
        static ExcelUtil excelUtil;
        CommonFunctions commFunc;
        string ttvMoreInfo = "Timetable variation more information";

        /// <summary>
        /// Method to setup pre- condition of test cases.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            timeTableVarLib = new TimeTableVariationLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "TimeTableVariationApp");

            // Launch Portal Application
            timeTableVarLib.SetUpPreCondition("STA_PORTAL");

            // Login to appliation and navigate to respective form
            timeTableVarLib.LoginAndNavigatToTimeTableVariationForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

        }


        /// <summary>
        /// Test method to verify mandetoty fields of Time table variation form and verify prepopulated value of contact details
        /// </summary>       
        [Test, Category("RegressionTest"), Property("AcceptanceCriteria", "1"), Property("TestCaseIDs", "37921")]
        public void VerifyMandetoryFieldsAndContactDetailsInfromation()
        {
            // Start Application
            commFunc.StartApplication();

            // Verify Contact Details
            timeTableVarLib.CheckContactDetailsFiledsValue( "Main Application",excelUtil.GetDataFromExcel("UserFirstName"), excelUtil.GetDataFromExcel("UserLastName"), excelUtil.GetDataFromExcel("JobTitle"), excelUtil.GetDataFromExcel("UserTeleNumber"), excelUtil.GetDataFromExcel("UserEmailAddress"));

            commFunc.NaviagteToNextPage();
            commFunc.NaviagteToNextPage();


            // Assert.True(commFunc.IsCommonFieldErrorMsgDisplayed(), "Common Mandetory fields error msg is not displayed on Review and Submit page.");
            VerifyIsTrue(comFunc.IsCommonFieldErrorMsgDisplayed(), "Check Common Mandetory fields error msg on Review and Submit page displayed");

            // Verify Review page Fileds
            string MandetoryFieldsMsg = commFunc.CheckMandetoryFieldsMsgOnReviewAndSubmitPage(2, excelUtil.GetDataFromExcel("Page2CommonErrorFieldsList"));
            VerifyIsEquals("", MandetoryFieldsMsg, "Check common mandetory filed list on Review and SubmitPage");

            commFunc.NavigateBackToPreiousPages(2);
            timeTableVarLib.SelectPupilAndTestSubjectDetails(excelUtil.GetDataFromExcel("PupilType"), null, null, null, null);
            commFunc.NaviagteToNextPage();

            // Select Reason Section
            timeTableVarLib.SelectReasonSectionA(excelUtil.GetDataFromExcel("SectionAReason"), excelUtil.GetDataFromExcel("Note"));
            timeTableVarLib.SelectSectionBReason(true, true, true, true);
            commFunc.NaviagteToNextPage();

            // Verify Review page Fileds
            string MandetoryFieldsMsg2 = commFunc.CheckMandetoryFieldsMsgOnReviewAndSubmitPage(1, excelUtil.GetDataFromExcel("Page1CommonErrorFieldsList2"));
            VerifyIsEquals("", MandetoryFieldsMsg2, "Check common mandetory filed list on Review and SubmitPage");


            commFunc.NavigateBackToPreiousPages(2);
            timeTableVarLib.SelectPupilAndTestSubjectDetails(excelUtil.GetDataFromExcel("PupilType"), excelUtil.GetDataFromExcel("PupilName1"), excelUtil.GetDataFromExcel("Subject1"), excelUtil.GetDataFromExcel("Date1"), excelUtil.GetDataFromExcel("Time1"));

            commFunc.NaviagteToNextPage();
            commFunc.NaviagteToNextPage();

            // Verify Submit button  & PDF button
            VerifyIsTrue(commFunc.IsSubmitButtonDisplayed() && commFunc.IsApplicationReviewPdfDisplayed(), "Check Submit button  & PDF button is displayed on Review and Submit page.");

        }


        /// <summary>
        /// Test Method to verify Time Table Variation request - auto approved test case
        /// </summary>
        [Test, Category("RegressionTest"), Category("SanityTest"), Category("SmokeTest"), Property("AcceptanceCriteria", "2"), Property("TestCaseIDs", "37714")]
        public void VerifyTimeTableVariationApplicationAutoApprovedCase()
        {

            bool[] sectionBQAns = { false, false, true, true };
            // Start Application
            commFunc.StartApplication();

            // Fill Application page1
            timeTableVarLib.FillApplicationPage1(excelUtil.GetDataFromExcel("PupilType"), excelUtil.GetDataFromExcel("PupilName1"), excelUtil.GetDataFromExcel("Subject1"), excelUtil.GetDataFromExcel("Date1"), excelUtil.GetDataFromExcel("Time1"));

            // Fill Reason section 
            timeTableVarLib.FillReasonSections(excelUtil.GetDataFromExcel("SectionAReason"), excelUtil.GetDataFromExcel("Note"), sectionBQAns);

            // Submit form
            commFunc.SubmitForm();

            // Verify Confrimation Message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Application Submission confrmation message");

        }

        /// <summary>
        /// Test Method to verify Time Table Variation request - auto Reject test case
        /// </summary>
        [Test, Category("RegressionTest"), Category("SanityTest"), Property("AcceptanceCriteria", "2"), Property("TestCaseIDs", "37706")]
        public void VerifyTimeTableVariationApplicationAutoRejectedCase()

        {
            bool[] sectionBQAns = { true, true, false, false };
            // Start Application
            commFunc.StartApplication();

            // Fill Application page1
            timeTableVarLib.FillApplicationPage1(excelUtil.GetDataFromExcel("PupilType"), excelUtil.GetDataFromExcel("PupilName1"), excelUtil.GetDataFromExcel("Subject1"), excelUtil.GetDataFromExcel("Date1"), excelUtil.GetDataFromExcel("Time1"));

            // Fill Reason section 
            timeTableVarLib.FillReasonSections(excelUtil.GetDataFromExcel("SectionAReason"), excelUtil.GetDataFromExcel("Note"), sectionBQAns);

            // Submit form
            commFunc.SubmitForm();

            // Verify Confrimation Message

            VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Application Submission confrmation message");

        }

        /// <summary>
        /// Test Method to verify Time Table Variation request - auto Reject test case
        /// </summary>
        [Test, Category("RegressionTest"), Category("SanityTest"), Property("AcceptanceCriteria", "3"), Property("TestCaseIDs", "37726")]
        public void VerifyTimeTableVariationApplicationWithDecisionApprovedCase()
        {
            bool[] sectionBQAns = { false, false, true, true };

            // Start Application
            commFunc.StartApplication();

            // Fill Application page1
            timeTableVarLib.FillApplicationPage1(excelUtil.GetDataFromExcel("PupilType"), excelUtil.GetDataFromExcel("PupilName1"), excelUtil.GetDataFromExcel("Subject1"), excelUtil.GetDataFromExcel("Date1"), excelUtil.GetDataFromExcel("Time1"));

            // Fill Reason section 
            timeTableVarLib.FillReasonSections(excelUtil.GetDataFromExcel("SectionAReason"), excelUtil.GetDataFromExcel("Note"), sectionBQAns);

            // Submit form and verify Confirmation message
            commFunc.SubmitForm();

            // Verify Confrimation Message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application Submission confrmation message");

            // Logout with current user  and Log with STA user - Navigate to repsective form
            commFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
            commFunc.OpenFormFromOutStadingActivity("Timetable variation review");

            // Verify Review Form
            timeTableVarLib.CheckReviewFromFieldValues(excelUtil, "Review", sectionBQAns);
            timeTableVarLib.SelectDelegatedAuthority();

            // Select Decission 
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission1"), excelUtil.GetDataFromExcel("Decision1Reason"));

            // Submit form and verify result
            commFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("ReviewFromSubmissonConMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application Submission confrmation message of review from");


        }

        /// <summary>
        /// Test Method to verify Time Table Variation request - auto Reject test case
        /// </summary>
        [Test, Category("RegressionTest"), Property("AcceptanceCriteria", "3")]
        public void VerifyTimeTableVariationApplicationWithDecisionRejectedCase()
        {
            bool[] sectionBQAns = { false, false, true, true };
            // Start Application
            commFunc.StartApplication();

            // Fill Application page1
            timeTableVarLib.FillApplicationPage1(excelUtil.GetDataFromExcel("PupilType"), excelUtil.GetDataFromExcel("PupilName1"), excelUtil.GetDataFromExcel("Subject1"), excelUtil.GetDataFromExcel("Date1"), excelUtil.GetDataFromExcel("Time1"));

            // Fill Reason section 
            timeTableVarLib.FillReasonSections(excelUtil.GetDataFromExcel("SectionAReason"), excelUtil.GetDataFromExcel("Note"), sectionBQAns);

            // Submit form
            commFunc.SubmitForm();

            // Verify Confrimation Message
            VerifyIsEquals(commFunc.GetFormSubmissionConfirmationMsg(), excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), "Application submittion confirmation msg is missmated.");

            commFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
            commFunc.OpenFormFromOutStadingActivity("Timetable variation review");

            // verify Review form Fields
            timeTableVarLib.CheckReviewFromFieldValues(excelUtil, "Review", sectionBQAns);
            timeTableVarLib.SelectDelegatedAuthority();

            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission1"), excelUtil.GetDataFromExcel("Decision1Reason"));
            commFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("ReviewFromSubmissonConMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Application Submission confrmation message is missmatched");

        }


        /// Test Method to verify Time Table Variation request -  Review -> More infromation-> Decission Rejected  test case
        /// </summary>
        [Test, Category("RegressionTest"), Category("SanityTest"), Property("TestCaseIDs", "28977")]
        public void VerifyTimeTableVariationAppWithMoreInforDecisionRejectedCase()
        {
            bool[] sectionBQAns = { false, false, true, true };
            string CaseRefer = excelUtil.GetDataFromExcel("CaseReferanceId");
            // Start Application
            commFunc.StartApplication();

            // Fill Application page1
            timeTableVarLib.FillApplicationPage1(excelUtil.GetDataFromExcel("PupilType"), excelUtil.GetDataFromExcel("PupilName1"), excelUtil.GetDataFromExcel("Subject1"), excelUtil.GetDataFromExcel("Date1"), excelUtil.GetDataFromExcel("Time1"));

            // Fill Reason section 
            timeTableVarLib.FillReasonSections(excelUtil.GetDataFromExcel("SectionAReason"), excelUtil.GetDataFromExcel("Note"), sectionBQAns);

            // Submit form and verify Confirmation message
            commFunc.SubmitForm();

            // Verify Confrimation Message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application Submission confrmation message");

            // Logout with current user  and Log with STA user - Navigate to repsective form
            //commFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
           // commFunc.OpenFormFromOutStadingActivity("Timetable variation review");

            // log out with current user and Login to CM and naviagte to review from
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            commFunc.SearchCaseReferance(CaseRefer, null, null);
            commFunc.openedInCompetFormCmFromExpandView("EARAPRVIEW");

            // Verify Review Form
            timeTableVarLib.CheckReviewFromFieldValues(excelUtil, "Review", sectionBQAns);

            timeTableVarLib.SelectDelegatedAuthority();

            // Select Decission 
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission1"), excelUtil.GetDataFromExcel("Decision1Reason"));

            // Submit form and verify result
            commFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("ReviewFromSubmissonConMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application Submission confrmation message of review from");

            // logout with currnet user & Login to portal - School user and navigate more info form
            comFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
            commFunc.OpenFormFromOutStadingActivity(ttvMoreInfo);


            // Add more infromation & verify review comments
            commFunc.AddMoreInfromation(excelUtil.GetDataFromExcel("AddtionalInformation"), excelUtil.GetDataFromExcel("UploadDoc1"), excelUtil.GetDataFromExcel("DocumentDecription1"));
            timeTableVarLib.CheckReviewFromFieldValues(excelUtil, "MoreInfo", sectionBQAns);
            comFunc.NaviagteToNextPage();

            // submit form and verify confirmation msg
            commFunc.SubmitForm(true);
            VerifyIsEquals(excelUtil.GetDataFromExcel("MoreInfoFromSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application more information submission confrmation message");

            // log out with current user and Login to CM and naviagte to review from
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            commFunc.SearchCaseReferance(CaseRefer, null, null);
            commFunc.openedInCompetFormCmFromExpandView("EARAPRVIEW");

            // Logout with currnet user &Login to portal - STA user and navigate review form
           // comFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
           // commFunc.OpenFormFromOutStadingActivity("Timetable variation review");

            // verify re- review form
            timeTableVarLib.CheckReviewFromFieldValues(excelUtil, "Re-Review", sectionBQAns);

            timeTableVarLib.SelectDelegatedAuthority();

            timeTableVarLib.CheckReReviewAddtionalInfromation(excelUtil.GetDataFromExcel("AddtionalInformation"), excelUtil.GetDataFromExcel("UploadDoc1"));
            // Select decisson and submit form
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission2"), excelUtil.GetDataFromExcel("Decision1Description"));
            commFunc.SubmitForm();

            // Verify Fromsubmission confirmation msg
            VerifyIsEquals(excelUtil.GetDataFromExcel("Review2FromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application review submission confrmation message");


        }

        /// Test Method to verify Time Table Variation request - Review -> Moreinfromation-> Decission Approved  test case
        /// </summary>
        [Test, Category("RegressionTest"), Property("TestCaseIDs", "28975")]
        public void VerifyTimeTableVariationAppWithMoreInforDecisionApprovedCase()
        {
            bool[] sectionBQAns = { false, false, true, true };

            // Start Application
            commFunc.StartApplication();

            // Fill Application page1
            timeTableVarLib.FillApplicationPage1(excelUtil.GetDataFromExcel("PupilType"), excelUtil.GetDataFromExcel("PupilName1"), excelUtil.GetDataFromExcel("Subject1"), excelUtil.GetDataFromExcel("Date1"), excelUtil.GetDataFromExcel("Time1"));

            // Fill Reason section 
            timeTableVarLib.FillReasonSections(excelUtil.GetDataFromExcel("SectionAReason"), excelUtil.GetDataFromExcel("Note"), sectionBQAns);

            // Submit form and verify Confirmation message
            commFunc.SubmitForm();

            // Verify Confrimation Message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application Submission confrmation message");


            // Logout with current user  and Log with STA user - Navigate to repsective form
            commFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
            commFunc.OpenFormFromOutStadingActivity("Timetable variation review");

            // Verify Review Form
            timeTableVarLib.CheckReviewFromFieldValues(excelUtil, "Review", sectionBQAns);

            timeTableVarLib.SelectDelegatedAuthority();

            // Select Decission 
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission1"), excelUtil.GetDataFromExcel("Decision1Reason"));

            // Submit form and verify result
            commFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("ReviewFromSubmissonConMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application Submission confrmation message of review from");

            // logout with currnet user & Login to portal - School user and navigate more info form
            comFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
            commFunc.OpenFormFromOutStadingActivity("Timetable variation more information");


            // Add more infromation & verify review comments
            commFunc.AddMoreInfromation(excelUtil.GetDataFromExcel("AddtionalInformation"), excelUtil.GetDataFromExcel("UploadDoc1"), excelUtil.GetDataFromExcel("DocumentDecription1"));
            timeTableVarLib.CheckReviewFromFieldValues(excelUtil, "MoreInfo", sectionBQAns);
            comFunc.NaviagteToNextPage();

            // submit form and verify confirmation msg
            commFunc.SubmitForm(true);
            VerifyIsEquals(excelUtil.GetDataFromExcel("MoreInfoFromSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application more information submission confrmation message");

            // Logout with currnet user &Login to portal - STA user and navigate review form
            comFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("STA_UserName"), excelUtil.GetDataFromExcel("STA_Password"));
            commFunc.OpenFormFromOutStadingActivity("Timetable variation review");

            // verify re- review form
            timeTableVarLib.CheckReviewFromFieldValues(excelUtil, "Re-Review", sectionBQAns);

            timeTableVarLib.SelectDelegatedAuthority();

            timeTableVarLib.CheckReReviewAddtionalInfromation(excelUtil.GetDataFromExcel("AddtionalInformation"), excelUtil.GetDataFromExcel("UploadDoc1"));

            // Select decisson and submit form
            commFunc.SelectDecission(excelUtil.GetDataFromExcel("Decission2"), excelUtil.GetDataFromExcel("Decision1Description"));
            commFunc.SubmitForm();

            // Verify Fromsubmission confirmation msg
            VerifyIsEquals(excelUtil.GetDataFromExcel("Review2FromSubmissonConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check application review submission confrmation message");

        }

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "37719")]

        public void VerifyAdditonalQuestionOnIllnessSelection()
        {
            bool[] sectionBQAns = { false, false, true, true };

            // Start Application
            commFunc.StartApplication();

            // Fill Application page1
            timeTableVarLib.FillApplicationPage1(excelUtil.GetDataFromExcel("PupilType"), excelUtil.GetDataFromExcel("PupilName1"), excelUtil.GetDataFromExcel("Subject1"), excelUtil.GetDataFromExcel("Date1"), excelUtil.GetDataFromExcel("Time1"));

            // Fill Reason section 
            timeTableVarLib.FillReasonSections(excelUtil.GetDataFromExcel("SectionAReason"), excelUtil.GetDataFromExcel("Note"), sectionBQAns);

            // Submit form and verify Confirmation message
            commFunc.SubmitForm();

            // Verify Confrimation Message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Application Submission confrmation message");

        }

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "37806 \n 37813 \n 37816")]
        public void VerifyValidationRulesForSubjectSelection()
        {
            bool[] sectionBQAns = { false, false, true, true };

            // Start Application
            commFunc.StartApplication();

            // select subject date & time
            timeTableVarLib.SelectPupilAndTestSubjectDetails(excelUtil.GetDataFromExcel("PupilType"), excelUtil.GetDataFromExcel("PupilName1"), excelUtil.GetDataFromExcel("Subject1"), excelUtil.GetDataFromExcel("Date1"), excelUtil.GetDataFromExcel("Time1"));
            // Add More Subjects
            timeTableVarLib.AddMoreSubjectPapers(excelUtil.GetDataFromExcel("Subject2"), excelUtil.GetDataFromExcel("Date2"), excelUtil.GetDataFromExcel("Time2"));
            // Check Error Msg
            timeTableVarLib.CheckValidationMsgForSubjectDateAndTime(excelUtil.GetDataFromExcel("SubjectDateTimeErrorMsg"));

            // select subject date & time
            timeTableVarLib.SelectSubjectDateAndTime(excelUtil.GetDataFromExcel("VerifyValidationRulesForSubjectSelection2", "Subject1"), excelUtil.GetDataFromExcel("VerifyValidationRulesForSubjectSelection2", "Date1"), excelUtil.GetDataFromExcel("VerifyValidationRulesForSubjectSelection2", "Time1"));
            // Add More Subjects
            timeTableVarLib.SelectSecondSubjectDateAndTime(excelUtil.GetDataFromExcel("VerifyValidationRulesForSubjectSelection2", "Subject2"), excelUtil.GetDataFromExcel("VerifyValidationRulesForSubjectSelection2", "Date2"), excelUtil.GetDataFromExcel("VerifyValidationRulesForSubjectSelection2", "Time2"));
            // Check Error Msg
            timeTableVarLib.CheckValidationMsgForSubjectDateAndTime(excelUtil.GetDataFromExcel("VerifyValidationRulesForSubjectSelection2", "SubjectDateTimeErrorMsg"));
            

            // select subject date & time
            timeTableVarLib.SelectSubjectDateAndTime(excelUtil.GetDataFromExcel("VerifyValidationRulesForSubjectSelection3", "Subject1"), excelUtil.GetDataFromExcel("VerifyValidationRulesForSubjectSelection3", "Date1"), excelUtil.GetDataFromExcel("VerifyValidationRulesForSubjectSelection3", "Time1"));
            // Add More Subjects
            timeTableVarLib.SelectSecondSubjectDateAndTime(excelUtil.GetDataFromExcel("VerifyValidationRulesForSubjectSelection3", "Subject2"), excelUtil.GetDataFromExcel("VerifyValidationRulesForSubjectSelection3", "Date2"), excelUtil.GetDataFromExcel("VerifyValidationRulesForSubjectSelection3", "Time2"));
            // Check Error Msg
            timeTableVarLib.CheckValidationMsgForSubjectDateAndTime(excelUtil.GetDataFromExcel("VerifyValidationRulesForSubjectSelection3", "SubjectDateTimeErrorMsg"));

        }



        [Test, Category("RegressionTest"), Property("TestCaseIDs", "37735")]
        public void VerifyValidationRulesForDateAndTimeSelection()
        {
            bool[] sectionBQAns = { false, false, true, true };

            // Start Application
            commFunc.StartApplication();

            // Fill Application page1
            timeTableVarLib.SelectPupilAndTestSubjectDetails(excelUtil.GetDataFromExcel("PupilType"), excelUtil.GetDataFromExcel("PupilName1"), excelUtil.GetDataFromExcel("Subject1"), excelUtil.GetDataFromExcel("Date1"), excelUtil.GetDataFromExcel("Time1"));

            // Add More Subjects
            timeTableVarLib.AddMoreSubjectPapers(excelUtil.GetDataFromExcel("Subject2"), excelUtil.GetDataFromExcel("Date2"), excelUtil.GetDataFromExcel("Time2"));

            // Verify Error msg
            timeTableVarLib.CheckValidationMsgForSubjectDateAndTime(excelUtil.GetDataFromExcel("SubjectDateTimeErrorMsg"));

            //Verify Date and time erro msg for Math3 and 1 test parer
            timeTableVarLib.SelectSubjectDateAndTime(excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionMath3&1", "Subject1"), excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionMath3&1", "Date1"), excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionMath3&1", "Time1"));
            timeTableVarLib.SelectSecondSubjectDateAndTime(excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionMath3&1", "Subject2"), excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionMath3&1", "Date2"), excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionMath3&1", "Time2"));
            timeTableVarLib.CheckValidationMsgForSubjectDateAndTime(excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionMath3&1", "SubjectDateTimeErrorMsg"));

            //Verify Date and time error msg for Math3 and 2 test parer
            timeTableVarLib.SelectSubjectDateAndTime(excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionMath3&2", "Subject1"), excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionMath3&2", "Date1"), excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionMath3&2", "Time1"));
            timeTableVarLib.SelectSecondSubjectDateAndTime(excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionMath3&2", "Subject2"), excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionMath3&2", "Date2"), excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionMath3&2", "Time2"));
            timeTableVarLib.CheckValidationMsgForSubjectDateAndTime(excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionMath3&2", "SubjectDateTimeErrorMsg"));

            //Verify Date and time error msg for Eng Reading and Math3 test parer
            timeTableVarLib.SelectSubjectDateAndTime(excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionEngReading&Math", "Subject1"), excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionEngReading&Math", "Date1"), excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionEngReading&Math", "Time1"));
            timeTableVarLib.SelectSecondSubjectDateAndTime(excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionEngReading&Math", "Subject2"), excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionEngReading&Math", "Date2"), excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionEngReading&Math", "Time2"));
            timeTableVarLib.CheckValidationMsgForSubjectDateAndTime(excelUtil.GetDataFromExcel("VerifyValidationRulesForDateAndTimeSelectionEngReading&Math", "SubjectDateTimeErrorMsg"));

        }

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "")]
        public void VerifyValidationMsgForSameSubjectMutipleTimeSelection()
        {
            bool[] sectionBQAns = { false, false, true, true };

            // Start Application
            commFunc.StartApplication();

            // Fill Application page1
            timeTableVarLib.SelectPupilAndTestSubjectDetails(excelUtil.GetDataFromExcel("PupilType"), excelUtil.GetDataFromExcel("PupilName1"), excelUtil.GetDataFromExcel("Subject1"), excelUtil.GetDataFromExcel("Date1"), excelUtil.GetDataFromExcel("Time1"));

            // Add More Subjects
            timeTableVarLib.AddMoreSubjectPapers(excelUtil.GetDataFromExcel("Subject2"), excelUtil.GetDataFromExcel("Date2"), excelUtil.GetDataFromExcel("Time2"));

            // Verify error msg
            timeTableVarLib.CheckValidationMsgForSubjectDateAndTime(excelUtil.GetDataFromExcel("SubjectDateTimeErrorMsg"));

        }
    }
}
