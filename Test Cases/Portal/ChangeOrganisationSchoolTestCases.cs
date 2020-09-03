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
    class ChangeOrganisationSchoolTestCases : ChangeOrganisationSchoolLib
    {
        public ChangeOrganisationSchoolLib ChangeOrgSchoolLib;
        public static ExcelUtil excelUtil;


        [SetUp]
        public void SetUp()
       {
            ChangeOrgSchoolLib = new ChangeOrganisationSchoolLib();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "ChangeOrganisation");
            ChangeOrgSchoolLib.SetUpPreCondition("STA_PORTAL");
            ChangeOrgSchoolLib.LoginAndNavigatToForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

        }


        [Test, Category("RegressionTest")]
        public void VerifyMandetoryfields()
        {
            comFunc.StartApplication();
            

            ChangeOrgSchoolLib.CheckMadetoryFields(excelUtil.GetDataFromExcel("MandetoryFieldMsg"));


        }
           

        [Test, Category("SanityTest"), Property("TestCaseIDs", "28165")]
        public void VerifyPrepopulatedFields()
        {
            log.Info("Start Application");
            comFunc.StartApplication();

            // Verify Contact Details
            ChangeOrgSchoolLib.CheckContactDetailsFiledsValue(excelUtil.GetDataFromExcel("UserFirstName"), excelUtil.GetDataFromExcel("UserLastName"), excelUtil.GetDataFromExcel("JobTitle"), excelUtil.GetDataFromExcel("UserTeleNumber"), excelUtil.GetDataFromExcel("UserEmailAddress"));

            ChangeOrgSchoolLib.CheckOrgDetails(excelUtil.GetDataFromExcel("OrgName"), excelUtil.GetDataFromExcel("OrgAdd"), excelUtil.GetDataFromExcel("OrgPinCode"), excelUtil.GetDataFromExcel("OrgDfeNumber"));

        }
   

        [Test, Property("TestCaseIDs", "28169")]
        public void UpdateOrganisationDetails()
        {
            log.Info("Start Application");
            comFunc.StartApplication();
            ChangeOrgSchoolLib.UpdateSchoolDetails(excelUtil.GetDataFromExcel("OrgTelephone"), excelUtil.GetDataFromExcel("OrgEmail"));

            comFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionMsg"),comFunc.GetFormSubmissionConfirmationMsg(),"Check Org updation message");
            
            
            /* var op = ChangeOrgSchoolLib.ValidateDetailsChange(excelUtil.GetDataFromExcel("OrgTelephone"), excelUtil.GetDataFromExcel("OrgUpdateEmail"));
            if (op)
            {
                Assert.Pass("DB validated");
            }
            else
            {
                Assert.Fail("mismatch");
            }
            */
        }


    }
}
