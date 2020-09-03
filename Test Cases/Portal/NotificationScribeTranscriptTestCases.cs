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
    class NotificationScribeTranscriptTestCases : NotificationScribeTranscriptLib
    {
        public NotificationScribeTranscriptLib NotificationScribLib;
        public static ExcelUtil excelUtil;
        CommonFunctions comFunc;

        /// <summary>
        ///  Method to set up pre-condition of test case
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            NotificationScribLib = new NotificationScribeTranscriptLib();
            comFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "NotificationScribeTranscriptApp");
            // Launch Portal application
            NotificationScribLib.SetUpPreCondition("STA_PORTAL");

            // Logint ot portal and naviagte to respective form
            NotificationScribLib.LoginAndNavigatToNotificationScribForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

        }


        /// <summary>
        /// Test method to verify mandetory fields of Notification form.
        /// </summary>

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "28168")]
        public void VerifyMandetoryFields()
        {
            // Start Application
            comFunc.StartApplication();

            comFunc.SubmitForm();

            // Verify mandetory fields
            NotificationScribLib.CheckMandetoryFields("", excelUtil.GetDataFromExcel("NameOfTypeOfNotificationErrorMsg"));

   
            NotificationScribLib.CheckMandetoryFields("Scribe", excelUtil.GetDataFromExcel("BriefExplanationErrorMsg"));
            NotificationScribLib.CheckMandetoryFields("Transcript", excelUtil.GetDataFromExcel("BriefExplanationErrorMsg"));
            NotificationScribLib.CheckMandetoryFields("Word processor or other technical or electronic aid", excelUtil.GetDataFromExcel("BriefExplanationErrorMsg"));

         // NotificationScribLib.SelectPapers(excelUtil.GetDataFromExcel("PaperName"), excelUtil.GetDataFromExcel("HowWasTheAidUsed"), excelUtil.GetDataFromExcel("TypeOfNotification"), excelUtil.GetDataFromExcel("NameOfTypeOfNotification"));

            NotificationScribLib.CheckMandetoryFields("BriefExplanation", excelUtil.GetDataFromExcel("BriefExplanationErrorMsg"));
 
        }

        /// <summary>
        /// Test method to verify submit notification application request for Scribe.
        /// </summary>
        [Test, Category("SmokeTest"), Category("SanityTest"), Category("RegressionTest"), Property("AcceptanceCriteria", "2")]
        public void CreateNotificationScribeAppRequest()
        {
            // Start Application
            comFunc.StartApplication();
            // Fill form
            NotificationScribLib.SelectTypeOfNotification(excelUtil.GetDataFromExcel("TypeOfNotification"));
            NotificationScribLib.SelectPupilFromPupilDropDwn(excelUtil.GetDataFromExcel("PupileName"));

            NotificationScribLib.SelectPapers(excelUtil.GetDataFromExcel("PaperName"), excelUtil.GetDataFromExcel("HowWasTheAidUsed"), excelUtil.GetDataFromExcel("TypeOfNotification"), excelUtil.GetDataFromExcel("NameOfTypeOfNotification"));
            NotificationScribLib.AddBrifExplanation(excelUtil.GetDataFromExcel("BriefExplanation"));

            // Submit form and verify Confirmation msg
            comFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), comFunc.GetFormSubmissionConfirmationMsg(), "Check application submission confrmation message");

        }

        /// <summary>
        /// Test method to verify submit notification application request for Transcript.
        /// </summary>

        [Test, Category("SanityTest"), Category("RegressionTest")]
        public void CreateNotificationTranscriptAppRequest()
        {
            // Start application
            comFunc.StartApplication();

            // Fill form
            NotificationScribLib.SelectTypeOfNotification(excelUtil.GetDataFromExcel("TypeOfNotification"));
            NotificationScribLib.SelectPupilFromPupilDropDwn(excelUtil.GetDataFromExcel("PupileName"));

            NotificationScribLib.SelectPapers(excelUtil.GetDataFromExcel("PaperName"), excelUtil.GetDataFromExcel("HowWasTheAidUsed"), excelUtil.GetDataFromExcel("TypeOfNotification"), excelUtil.GetDataFromExcel("NameOfTypeOfNotification"));
            NotificationScribLib.AddBrifExplanation(excelUtil.GetDataFromExcel("BriefExplanation"));

            //Submit form and verify confirmation msg
            comFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), comFunc.GetFormSubmissionConfirmationMsg(), "Check application submission confrmation message");

        }

        /// <summary>
        /// Test method to verify submit notification application request for WordProcess.
        /// </summary>
        [Test, Category("SanityTest"), Category("RegressionTest")]
        public void CreateNotificationWordProcessAppRequest()
        {
            // Start Application
            comFunc.StartApplication();

            // Fill form
            NotificationScribLib.SelectTypeOfNotification(excelUtil.GetDataFromExcel("TypeOfNotification"));
            NotificationScribLib.SelectPupilFromPupilDropDwn(excelUtil.GetDataFromExcel("PupileName"));

            NotificationScribLib.SelectPapers(excelUtil.GetDataFromExcel("PaperName"), excelUtil.GetDataFromExcel("HowWasTheAidUsed"), excelUtil.GetDataFromExcel("TypeOfNotification"), excelUtil.GetDataFromExcel("NameOfTypeOfNotification"));
            NotificationScribLib.AddBrifExplanation(excelUtil.GetDataFromExcel("BriefExplanation"));

            // Submit form and Verify confirmation msg
            comFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), comFunc.GetFormSubmissionConfirmationMsg(), "Check application submission confrmation message");

        }

        /// <summary>
        /// Test method to verify prepopulated values of user contact  details.
        /// </summary>
        [Test, Category("RegressionTest"), Property("TestCaseIDs", "28205")]
        public void VerifyPrepopulatedFileds()
        {
            // Start Application
            comFunc.StartApplication();

            // Check Contact Details
            NotificationScribLib.CheckContactDetails(excelUtil.GetDataFromExcel("UserLastName"), excelUtil.GetDataFromExcel("UserFirstName"), excelUtil.GetDataFromExcel("JobTitle"), excelUtil.GetDataFromExcel("UserTeleNumber"), excelUtil.GetDataFromExcel("UserEmailAddress"));

        }

    }


}