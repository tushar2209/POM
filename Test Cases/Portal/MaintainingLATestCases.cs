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
    class MaintainingLATestCases : MaintainingLALib
    {
        public MaintainingLALib LALib;
        public static ExcelUtil excelUtil;


        [SetUp]
        public void SetUp()
        {

            LALib = new MaintainingLALib();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "LASelection");
            LALib.SetUpPreCondition("STA_PORTAL");
            LALib.LoginAndNavigatToForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

        }

        [Test, Category("RegressionTest")]
        public void VerifyMandetoryFields()
        {
            log.Info("Start Application");
            comFunc.StartApplication();

            LALib.CheckMadetoryFields(excelUtil.GetDataFromExcel("MandetoryFieldList"));
          
             }

        [Test, Category("SanityTest"), Property("TestCaseIDs", "28179")]
        public void VerifyPrepopulatedFileds()
        {
            log.Info("Start Application");
            comFunc.StartApplication();
           
             LALib.CheckContactDetailsFiledsValue(excelUtil.GetDataFromExcel("UserFirstName"), excelUtil.GetDataFromExcel("UserLastName"), excelUtil.GetDataFromExcel("JobTitle"), excelUtil.GetDataFromExcel("UserTeleNumber"), excelUtil.GetDataFromExcel("UserEmailAddress"));

        }

        [Test, Category("SanityTest"), Property("TestCaseIDs", "28345")]
        public void VerifyLASelection()
        {
            log.Info("Start Application");
            comFunc.StartApplication();

            // Select LA
            LALib.SelectLA(excelUtil.GetDataFromExcel("LAName"));
            comFunc.NaviagteToNextPage();

            // Submit Form  and Verify Msg
            comFunc.SubmitForm();            
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionMsg"), comFunc.GetFormSubmissionConfirmationMsg(),"Check LA Selection form submission message.");


            log.Info("Navigate to From");

            comFunc.LogoutCurrentUserAndLoginAnotherUserToPortal("STA_PORTAL", excelUtil.GetDataFromExcel("SetUp","UserName"), excelUtil.GetDataFromExcel("SetUp", "Password"));
            LALib.OpenMantainLASelection();

            // start application
            comFunc.StartApplication();

            VerifyIsEquals(excelUtil.GetDataFromExcel("LAName"), LALib.GetSelectedLAName(), "Check selected LA value should displayed.");


        }


    }
}
