using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using STA.Utilities.ExcelReader;
using STA__Automation.BussinessLib;
using STA__Automation.CommonLib;

namespace STA__Automation.Test_Cases.Portal
{
    class ScaningResolutionTestCase : ScaningResolutionLib
    {
        ScaningResolutionLib sacneresolution;
        static ExcelUtil excelUtil;
        CommonFunctions commFunc;





        /// <summary>
        /// Method to setup pre- condition of test cases.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            sacneresolution = new ScaningResolutionLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "ScaningResolution");

            // Launch Portal Application
         //   sacneresolution.SetUpPreCondition("STA_PORTAL");

            // Login to appliation and navigate to respective form

            sacneresolution.LoginAndNavigatToScaningException(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

        }



        [Test, Category("RegressionTest"), Property("AcceptanceCriteria", "4")]


        public void VerifyScaningResolutionForm()
        {

            commFunc.StartApplication();
            sacneresolution.Start();
            sacneresolution.CheckResolved();
            sacneresolution.EnterNotes(excelUtil.GetDataFromExcel("Notes"));
            sacneresolution.NotCreateClosure();
           commFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Application Submission confrmation message");



        }

    }
}
