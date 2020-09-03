using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using STA.Utilities.ExcelReader;
using STA__Automation.BussinessLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;

namespace STA__Automation.Test_Cases.Portal
{
    class ScaningExceptionTestCase : ScaningExceptionLib
    {
        ScaningExceptionLib sacnexception;
        static ExcelUtil excelUtil;
        CommonFunctions commFunc;
        ScaningResolutionLib sacneresolution;

        /// <summary>
        /// Method to setup pre- condition of test cases.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            sacnexception = new ScaningExceptionLib();
            sacneresolution = new ScaningResolutionLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "ScaningException");
            sacnexception.SetUpPreCondition();
            sacneresolution.SetUpPreCondition();
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            //// Launch Portal Application
            //sacnexception.SetUpPreCondition("STA_PORTAL");

            //// Login to appliation and navigate to respective form

            //sacnexception.LoginAndNavigatToScaningException(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

        }


        [Test, Category("RegressionTest"), Property("AcceptanceCriteria", "4")]


        public void VerifyScaningExceptionForm()
        {

            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
            commFunc.CreateNewFrom(excelUtil.GetDataFromExcel("FormName"));
            sacnexception.SelectExceptionCategory(excelUtil.GetDataFromExcel("Exceptioncategory"));
            sacnexception.SelectSite(excelUtil.GetDataFromExcel("Site"));
            sacnexception.Function(excelUtil.GetDataFromExcel("Function"));
            sacnexception.TestPaper(excelUtil.GetDataFromExcel("Testpaper"));
            sacnexception.BatchId(excelUtil.GetDataFromExcel("BatchId"));
            sacnexception.Description(excelUtil.GetDataFromExcel("Description"));
            commFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Application Submission confrmation message");
            comFunc.NavigateBackToCaseManager();
            comFunc.openedInCompetFormCmFromExpandView(excelUtil.GetDataFromExcel("ShortNmae"));
            sacneresolution.CheckResolved();
            sacneresolution.EnterNotes(excelUtil.GetDataFromExcel("Notes"));
            sacneresolution.NotCreateClosure();
            commFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("ResolutionScaningFormConfig"), commFunc.GetFormSubmissionConfirmationMsg(), "Application Submission confrmation message");
        }


        [Test, Category("RegressionTest"), Property("AcceptanceCriteria", "4")]
        public void CreateClosureForm()
        {


            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
            commFunc.CreateNewFrom(excelUtil.GetDataFromExcel("FormName"));
            sacnexception.SelectExceptionCategory(excelUtil.GetDataFromExcel("Exceptioncategory"));
            sacnexception.SelectSite(excelUtil.GetDataFromExcel("Site"));
            sacnexception.Function(excelUtil.GetDataFromExcel("Function"));
            sacnexception.TestPaper(excelUtil.GetDataFromExcel("Testpaper"));
            sacnexception.BatchId(excelUtil.GetDataFromExcel("BatchId"));
            sacnexception.Description(excelUtil.GetDataFromExcel("Description"));
            commFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Application Submission confrmation message");
            comFunc.NavigateBackToCaseManager();
            comFunc.openedInCompetFormCmFromExpandView(excelUtil.GetDataFromExcel("ShortNmae"));
            sacneresolution.CheckResolved();
            sacneresolution.EnterNotes(excelUtil.GetDataFromExcel("Notes"));
            // sacneresolution.NotCreateClosure();
            commFunc.SubmitForm();
            //VerifyIsContains(excelUtil.GetDataFromExcel("ResolutionScaningFormConfig"), commFunc.GetFormSubmissionConfirmationMsg(), "Application Submission confrmation message");

            comFunc.NavigateBackToCaseManager();
            comFunc.openedInCompetFormCmFromExpandView(excelUtil.GetDataFromExcel("CICShortName"));
            sacneresolution.CheckCICClosure();
            comFunc.SubmitForm();


        }

        
    }
}