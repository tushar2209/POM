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
    class MakerTrainingConfirmationTestCases :MarkerTrainingConfirmationLib
    {
        public MarkerTrainingConfirmationLib traningConfirmationLib;
        public static ExcelUtil excelUtil;
        CommonFunctions commFunc;


        [SetUp]
        public void SetUp()
        {
            traningConfirmationLib = new MarkerTrainingConfirmationLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "MarkerTraningConfirmation");
            traningConfirmationLib.SetUpPreCondition("STA_PORTAL");
            traningConfirmationLib.LoginAndNavigatToForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

        }

        [Test]
        public void VerifyMarkerTaingConfirmationFunctionality() {

            commFunc.StartApplication();
           
            // Fill Form
            traningConfirmationLib.FillForm(true,true, excelUtil.GetDataFromExcel("RTWDec"), excelUtil.GetDataFromExcel("RTWDocExpDate"), excelUtil.GetDataFromExcel("FileName"));
            
            // Submit Form  and Verify Msg
            comFunc.SubmitForm();
         
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionMsg"), comFunc.GetFormSubmissionConfirmationMsg(), "Check Trtaning Confrimation form submission message.");

        }
    }
}
