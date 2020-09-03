using NUnit.Framework;
using STA.Utilities.ExcelReader;
using STA__Automation.BussinessLib;
using STA__Automation.CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.TestCases.Forms
{
    class BecomeMarkerTestCases : BecomeMarkerLib
    {
        public static BecomeMarkerLib  becomeMarkerLib;
        public static ExcelUtil excelUtil;
        CommonFunctions comFunc;

        /// <summary>
        ///  Method to set up pre-condition of test case
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            becomeMarkerLib = new BecomeMarkerLib();
            comFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "BeacomeMarker");

            // Launch Portal application
            becomeMarkerLib.SetUpPreCondition(excelUtil.GetDataFromExcel("AppURL"));

            
        }

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "41611 \n 41614")]
        public void VerifyMandetoryFields()
        {
            // Start Application
            comFunc.HandleCookiePopup();

            // Veriyf Mandetory Fields
            becomeMarkerLib.CheckMandetoryFields(excelUtil.GetDataFromExcel("MandetoryFieldsErrorMsg"));
        }

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "41612 \n 41613")]
        public void VerifyBeacomeMarkerFunctionality() {

            // Start Application
            comFunc.HandleCookiePopup();

            // Veriyf Mandetory Fields
            becomeMarkerLib.FillForm(TestContext.CurrentContext.Test.MethodName, excelUtil);
            
            // Submit Form
            comFunc.SubmitForm();

            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmisstionConfMsg"), comFunc.GetFormSubmissionConfirmationMsg(),"Check Beacome Marker form submissiton message.");

        }
    }
}
