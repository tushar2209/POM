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
    class ModifiedKSOneTestOrderTestCases : ModifiedKSOneTestOrderLib
    {
        public ModifiedKSOneTestOrderLib ModifiedKS1Lib;
        public static ExcelUtil excelUtil;
        CommonFunctions commFunc;


        [SetUp]
        public void SetUp()
        {
            ModifiedKS1Lib = new ModifiedKSOneTestOrderLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "ModifiedKS1");

            // Launch portal appliation
            ModifiedKS1Lib.SetUpPreCondition("STA_PORTAL");

          }


        [Test, Category("RegressionTest"), Property("TestCaseIDs", "15739")]
        public void VerifyKS1ModifiedFormPrepopulatedValues()
        {

            // Login to portal and navigate to respective form
            ModifiedKS1Lib.LoginAndNavigateToModifiedKS1Form(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            commFunc.StartApplication();
            ModifiedKS1Lib.CheckPrePopulatedFiledsValue(excelUtil.GetDataFromExcel("FullName"), excelUtil.GetDataFromExcel("YourEmail"));

        }


        [Test, Category("RegressionTest"), Property("TestCaseIDs", "15821")]
        public void VerifyWarningMsgWhenEnterLageQuntityThanNoOfPupileVisualImpairment ()
        {
            // Login to portal and navigate to respective form
            ModifiedKS1Lib.LoginAndNavigateToModifiedKS1Form(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();
            // Fill Pupile numbers section
            ModifiedKS1Lib.FillPupilNumbers(excelUtil.GetDataFromExcel("TotalPupilNo"), excelUtil.GetDataFromExcel("PupilVisual"), excelUtil.GetDataFromExcel("PupilSpcl"));
            // Fill English GPS 
            ModifiedKS1Lib.FillEnglishGPS(excelUtil.GetDataFromExcel("EngGrammarMLP"), excelUtil.GetDataFromExcel("EngGrammarBraille"));
            // Fill Mathematics
            ModifiedKS1Lib.FillMathematics(excelUtil.GetDataFromExcel("MathematicsMLP"), excelUtil.GetDataFromExcel("MathematicsBraille"));
            //Fill English Reading
            ModifiedKS1Lib.FillEnglishReading(excelUtil.GetDataFromExcel("EngReadingMLP"), excelUtil.GetDataFromExcel("EngReadingBraille"));

            commFunc.ClickOnVerifyFormBtn();

            // Verify warning msg
            ModifiedKS1Lib.CheckWarningMsgForPupileVisualImpairment();

        }


        [Test, Category("RegressionTest"), Property("TestCaseIDs", "15826")]
        public void VerifyWarningMsgWhenEnterLageQuntityThanNoOfPupileOtherSpecialNeeds()
        {
            // Login to portal and navigate to respective form
            ModifiedKS1Lib.LoginAndNavigateToModifiedKS1Form(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();
            // Fill Pupile numbers section
            ModifiedKS1Lib.FillPupilNumbers(excelUtil.GetDataFromExcel("TotalPupilNo"), excelUtil.GetDataFromExcel("PupilVisual"), excelUtil.GetDataFromExcel("PupilSpcl"));
            // Fill English GPS 
            ModifiedKS1Lib.FillEnglishGPS(excelUtil.GetDataFromExcel("EngGrammarMLP"), excelUtil.GetDataFromExcel("EngGrammarBraille"));
            // Fill Mathematics
            ModifiedKS1Lib.FillMathematics(excelUtil.GetDataFromExcel("MathematicsMLP"), excelUtil.GetDataFromExcel("MathematicsBraille"));
            //Fill English Reading
            ModifiedKS1Lib.FillEnglishReading(excelUtil.GetDataFromExcel("EngReadingMLP"), excelUtil.GetDataFromExcel("EngReadingBraille"));

            commFunc.ClickOnVerifyFormBtn();
           
            // Verify error msg
            ModifiedKS1Lib.CheckWarningMsgForPupileOtherSpecialNeeds();

        }

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "15735 \n 15732")]
        public void VerifyLastUpdatedDetailsAndSubmitModifyKS1()
        {
            // Login to portal and navigate to respective form
            ModifiedKS1Lib.LoginAndNavigateToModifiedKS1Form(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();
            ModifiedKS1Lib.SelectPrivacyNotiesConfirmation();
            // Fill Pupile numbers section
            ModifiedKS1Lib.FillPupilNumbers(excelUtil.GetDataFromExcel("TotalPupilNo"), excelUtil.GetDataFromExcel("PupilVisual"), excelUtil.GetDataFromExcel("PupilSpcl"));

            // Fill English GPS 
            ModifiedKS1Lib.FillEnglishGPS(excelUtil.GetDataFromExcel("EngGrammarMLP"), excelUtil.GetDataFromExcel("EngGrammarBraille"));
            // Fill Mathematics
            ModifiedKS1Lib.FillMathematics(excelUtil.GetDataFromExcel("MathematicsMLP"), excelUtil.GetDataFromExcel("MathematicsBraille"));
            //Fill English Reading
            ModifiedKS1Lib.FillEnglishReading(excelUtil.GetDataFromExcel("EngReadingMLP"), excelUtil.GetDataFromExcel("EngReadingBraille"));

            commFunc.ClickOnVerifyFormBtn();

            // Submit form and verfiy confirmation message
            commFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Modified KS1 from submission message.");

            commFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
            ModifiedKS1Lib.NavigateToModifiedKS1Form();
            
            // Start application
            commFunc.StartApplication();

            // Check Last person updated
            ModifiedKS1Lib.CheckLastUpdateOrderPersonDetails(excelUtil.GetDataFromExcel("FullName"), excelUtil.GetDataFromExcel("YourEmail"));

        }


        [Test, Property("TestCaseIDs", "49885 \n 49887")]
        public void VerifyPrivacyPolicyForIndependentSchools()
        {
            // Login user and Navigate to respective form
            ModifiedKS1Lib.LoginAndNavigateToModifiedKS1Form(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();

            // Fill Form
            ModifiedKS1Lib.CheckPrivacyNotice(true);

        }

        [Test, Property("TestCaseIDs", "48889")]
        public void VerifyPrivacyPolicyForAcademySchools()
        {
            // Login user and Navigate to respective form
            ModifiedKS1Lib.LoginAndNavigateToModifiedKS1Form(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();

            // Check privecy Form
            ModifiedKS1Lib.CheckPrivacyNotice(false);

        }
               
    }
}
