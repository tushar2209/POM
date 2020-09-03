using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using STA.Utilities.ExcelReader;
using STA__Automation.BussinessLib;
using STA__Automation.CommonLib;

namespace STA__Automation.TestCases.Forms
{
    class CM_UploadTestMaterialTestCases: CM_UploadTestMaterialLib
    {
        static ExcelUtil excelUtil;
        CommonFunctions commFunc;
        CM_UploadTestMaterialLib uploadTestMaterialLib;


        [SetUp]
        public void SetUp()
        {
            uploadTestMaterialLib = new CM_UploadTestMaterialLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "CM_UploadTestMaterial");
            uploadTestMaterialLib.SetUpPreCondition();
            
        }

        [Test]
        public void VerifyUploadDocTestFromCM() {
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
            commFunc.CreateNewFrom(excelUtil.GetDataFromExcel("FormName"));
            uploadTestMaterialLib.selectUploadDocumentType(true, false);
            uploadTestMaterialLib.FillUploadTestMaterialSection(excelUtil.GetDataFromExcel("uploadFileName1"), excelUtil.GetDataFromExcel("uploadFileDec1"), excelUtil.GetDataFromExcel("fromDate1"), excelUtil.GetDataFromExcel("Todate1"));
            commFunc.NaviagteToNextPage();
            // Submit form
            comFunc.SubmitForm();
            // verify application submission confirmation message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Upload Test Document confrmation message.");

        }


        [Test]
        public void VerifyUploadZipFileTestFromCM()
        {
            // Login
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
            commFunc.CreateNewFrom(excelUtil.GetDataFromExcel("FormName"));
            uploadTestMaterialLib.selectUploadDocumentType(true,false);
          
            // Fill Form
            uploadTestMaterialLib.FillUploadTestMaterialSection(excelUtil.GetDataFromExcel("uploadFileName1"), excelUtil.GetDataFromExcel("uploadFileDec1"), excelUtil.GetDataFromExcel("fromDate1"), excelUtil.GetDataFromExcel("Todate1"));
            commFunc.NaviagteToNextPage();
            // Submit 
            comFunc.SubmitForm();
           
            // verify application submission confirmation message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Zip upload confirmation message.");


        }

        [Test]
        public void VerifyDocumentUpload() {

            // Login
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
            commFunc.CreateNewFrom(excelUtil.GetDataFromExcel("FormName"));

            // Fill Form
            uploadTestMaterialLib.FillUploadDocForm(excelUtil.GetDataFromExcel("uploadFileName1"), excelUtil.GetDataFromExcel("uploadFileDec1"), excelUtil.GetDataFromExcel("fromDate1"), excelUtil.GetDataFromExcel("Todate1"), excelUtil.GetDataFromExcel("Role"), excelUtil.GetDataFromExcel("Sub_Role"));
     
            // Submit 
            comFunc.SubmitForm();

            // verify application submission confirmation message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check upload document confirmation message.");

        }

    }
}
