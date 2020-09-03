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
    class ViewKS1KS2TestMaterailTestCases : ViewKS1KS2TestMaterialLib
    {

        ViewKS1KS2TestMaterialLib viewKS1KS2TestMaterialLib;
        static ExcelUtil excelUtil;
        CommonFunctions commFunc;
        CM_UploadTestMaterialLib uploadTestMaterialLib;
        EventLogsOfDownloadLib eventLogsOfDownloadLib;
        string eventLogOfDownload = "Event logs of download";


        /// <summary>
        /// Method to setup pre- condition of test cases.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            viewKS1KS2TestMaterialLib = new ViewKS1KS2TestMaterialLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "ViewKS1KS2TestMaterial");
            uploadTestMaterialLib = new CM_UploadTestMaterialLib();
            eventLogsOfDownloadLib = new EventLogsOfDownloadLib();

        }

        [Test]
        public void VerifyKS1NewUploadedTestMaterial() {

            string[] categoryList = { excelUtil.GetDataFromExcel("Category"), excelUtil.GetDataFromExcel("Category2"), excelUtil.GetDataFromExcel("Category3") };
            string[] subCategoryList = { excelUtil.GetDataFromExcel("SubCategory"), excelUtil.GetDataFromExcel("SubCategory2"), excelUtil.GetDataFromExcel("SubCategory3") };
            string[] subjectList = { excelUtil.GetDataFromExcel("Subject"), excelUtil.GetDataFromExcel("Subject2"), excelUtil.GetDataFromExcel("Subject3") };
            string[] uploadFileDecList = { excelUtil.GetDataFromExcel("uploadFileDec1"), excelUtil.GetDataFromExcel("uploadFileDec2"), excelUtil.GetDataFromExcel("uploadFileDec3") };

            uploadTestMaterialLib.SetUpPreCondition();

            //Login to CM 
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            //Search Case Rferance
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
           
            //Create New form
            commFunc.CreateNewFrom(excelUtil.GetDataFromExcel("FormName"));
            uploadTestMaterialLib.selectUploadDocumentType(true, true);

            //Fill Forms
            uploadTestMaterialLib.FillUploadtestMaterilForm(categoryList, subCategoryList, subjectList, excelUtil.GetDataFromExcel("uploadFileName1"), uploadFileDecList, commFunc.GetCurrentDate("dd-MMM-yyyy"), commFunc.GetPastOrFutureDate(0, 1, 0, "dd-MMM-yyyy"));

            commFunc.NaviagteToNextPage();

            uploadTestMaterialLib.DeletePreviouslyUploadTestMaterial();

            // Submit form
            commFunc.SubmitForm();
          
            // verify application submission confirmation message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Upload Test Document confrmation message.");
   
            // Launch Portal application
            viewKS1KS2TestMaterialLib.SetUpPreCondition("STA_PORTAL");

            // Logint ot portal and naviagte to respective form
            viewKS1KS2TestMaterialLib.LoginAndNavigatToViewTestMaterialForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"),"KS11");

            comFunc.StartApplication();


            VerifyIsContains(excelUtil.GetDataFromExcel("SubCategory"), viewKS1KS2TestMaterialLib.getSubCategoryOfViewMaterial(), "Check Sub category section");
            int count = 1;
            for (int i = 0; i < uploadFileDecList.Length; i++)
            {
                VerifyIsTrue(viewKS1KS2TestMaterialLib.IsUploadedDocDisplayed(uploadFileDecList[i]), "Check Uploaded Doucment" + count + " should displayed.");
                VerifyIsContains(subjectList[i], viewKS1KS2TestMaterialLib.GetNameofViewScection(i), "Check Sorting order of subject at " + count);
                count++;
            }
            

            viewKS1KS2TestMaterialLib.DownloadDocument(uploadFileDecList[2]);

            VerifyIsTrue(commFunc.IsDoucmentDownloaded(excelUtil.GetDataFromExcel("uploadFileName1")),"Check Doucment should able to download");

            //Verify Event log in cm */
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            /*Search Case Rferance*/
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);

            /*Create New form*/
            commFunc.CreateNewFrom(eventLogOfDownload);
            eventLogsOfDownloadLib.SetUpPreCondition();

            // Fill Event log of download form
            eventLogsOfDownloadLib.FillEventLogOFDownloadForm(uploadFileDecList[2], commFunc.GetCurrentDate("dd-MMM-yyyy"), commFunc.GetCurrentDate("dd-MMM-yyyy"));

            // Verify log for dwonlowed doucment
            eventLogsOfDownloadLib.CheckSearchResult( excelUtil.GetDataFromExcel("SchoolName"), excelUtil.GetDataFromExcel("UserName"));
        }

        [Test]
        public void VerifyKS2NewUploadedTestMaterial()
        {
            string[] categoryList = { excelUtil.GetDataFromExcel("Category"), excelUtil.GetDataFromExcel("Category2"), excelUtil.GetDataFromExcel("Category3") };
            string[] subCategoryList = { excelUtil.GetDataFromExcel("SubCategory"), excelUtil.GetDataFromExcel("SubCategory2"), excelUtil.GetDataFromExcel("SubCategory3") };
            string[] subjectList = { excelUtil.GetDataFromExcel("Subject"), excelUtil.GetDataFromExcel("Subject2"), excelUtil.GetDataFromExcel("Subject3") };
            string[] uploadFileDecList = { excelUtil.GetDataFromExcel("uploadFileDec1"), excelUtil.GetDataFromExcel("uploadFileDec2"), excelUtil.GetDataFromExcel("uploadFileDec3") };


            uploadTestMaterialLib.SetUpPreCondition();

            /*Login to CM */
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            /*Search Case Rferance*/
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);

            /*Create New form*/
            commFunc.CreateNewFrom(excelUtil.GetDataFromExcel("FormName"));
            uploadTestMaterialLib.selectUploadDocumentType(true, true);
            
            uploadTestMaterialLib.FillUploadtestMaterilForm(categoryList, subCategoryList, subjectList, excelUtil.GetDataFromExcel("uploadFileName1"), uploadFileDecList, commFunc.GetCurrentDate("dd-MMM-yyyy"), commFunc.GetPastOrFutureDate(0, 1, 0, "dd-MMM-yyyy"));

            commFunc.NaviagteToNextPage();

            uploadTestMaterialLib.DeletePreviouslyUploadTestMaterial();

            // Submit form
            commFunc.SubmitForm();

            // verify application submission confirmation message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Upload Test Document confrmation message.");

            // Launch Portal application
            viewKS1KS2TestMaterialLib.SetUpPreCondition("STA_PORTAL");

            // Logint ot portal and naviagte to respective form
            viewKS1KS2TestMaterialLib.LoginAndNavigatToViewTestMaterialForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"), "KS2");

            comFunc.StartApplication();

            VerifyIsContains(excelUtil.GetDataFromExcel("SubCategory"), viewKS1KS2TestMaterialLib.getSubCategoryOfViewMaterial(),"Check Sub category section");
            int count = 1;
            for (int i = 0; i < uploadFileDecList.Length; i++)
            {
                VerifyIsTrue(viewKS1KS2TestMaterialLib.IsUploadedDocDisplayed(uploadFileDecList[i]), "Check Uploaded Doucment"+ count + " should displayed.");
                VerifyIsContains(subjectList[i], viewKS1KS2TestMaterialLib.GetNameofViewScection(i), "Check Sorting order of subject at " + count );
                count++;
            }

            viewKS1KS2TestMaterialLib.DownloadDocument(uploadFileDecList[0]);

            VerifyIsTrue(commFunc.IsDoucmentDownloaded(excelUtil.GetDataFromExcel("uploadFileName1")), "Check Doucment should able to download");

            //Verify Event log in cm */
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            /*Search Case Rferance*/
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);

            /*Create New form*/
            commFunc.CreateNewFrom(eventLogOfDownload);
            eventLogsOfDownloadLib.SetUpPreCondition();

            // Fill Event log of download form
            eventLogsOfDownloadLib.FillEventLogOFDownloadForm(uploadFileDecList[0], comFunc.GetCurrentDate("dd-MMM-yyyy"), comFunc.GetCurrentDate("dd-MMM-yyyy"));

            // Verify log for dwonlowed doucment
            eventLogsOfDownloadLib.CheckSearchResult(excelUtil.GetDataFromExcel("SchoolName"), excelUtil.GetDataFromExcel("UserName"));

        }

        [Test]
        public void VerifyPhonicsNewUploadedTestMaterial()
        {

            uploadTestMaterialLib.SetUpPreCondition();

            /*Login to CM */
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            /*Search Case Rferance*/
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);

            /*Create New form*/
            commFunc.CreateNewFrom(excelUtil.GetDataFromExcel("FormName"));
            uploadTestMaterialLib.selectUploadDocumentType(true, true);

             /*Fill Forms*/
            uploadTestMaterialLib.SelectCategoriesAndSubject(excelUtil.GetDataFromExcel("Category"), excelUtil.GetDataFromExcel("SubCategory"), null);

            uploadTestMaterialLib.FillUploadTestMaterialSection(excelUtil.GetDataFromExcel("uploadFileName1"), excelUtil.GetDataFromExcel("uploadFileDec1"), commFunc.GetCurrentDate("dd-MMM-yyyy"), commFunc.GetPastOrFutureDate(0, 1, 0, "dd-MMM-yyyy"));

            commFunc.NaviagteToNextPage();

            uploadTestMaterialLib.DeletePreviouslyUploadTestMaterial();

            // Submit form
            commFunc.SubmitForm();

            // verify application submission confirmation message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Upload Test Document confrmation message.");

            // Launch Portal application
            viewKS1KS2TestMaterialLib.SetUpPreCondition("STA_PORTAL");

            // Logint ot portal and naviagte to respective form
            viewKS1KS2TestMaterialLib.LoginAndNavigatToViewTestMaterialForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"), "Phonics");

            comFunc.StartApplication();

            VerifyIsTrue(viewKS1KS2TestMaterialLib.IsUploadedDocDisplayed(excelUtil.GetDataFromExcel("uploadFileDec1")), "Check Uploaded Doucment should displayed view KS1 test Material");

            viewKS1KS2TestMaterialLib.DownloadDocument(excelUtil.GetDataFromExcel("uploadFileDec1"));

            VerifyIsTrue(commFunc.IsDoucmentDownloaded(excelUtil.GetDataFromExcel("uploadFileName1")), "Check Doucment should able to download");


            //Verify Event log in cm */
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            /*Search Case Rferance*/
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);

            /*Create New form*/
            commFunc.CreateNewFrom(eventLogOfDownload);
            eventLogsOfDownloadLib.SetUpPreCondition();

            // Fill Event log of download form
            eventLogsOfDownloadLib.FillEventLogOFDownloadForm(excelUtil.GetDataFromExcel("uploadFileDec1"), comFunc.GetCurrentDate("dd-MMM-yyyy"), comFunc.GetCurrentDate("dd-MMM-yyyy"));

            // Verify log for dwonlowed doucment
            eventLogsOfDownloadLib.CheckSearchResult(excelUtil.GetDataFromExcel("SchoolName"), excelUtil.GetDataFromExcel("UserName"));

        }

        [Test]
        public void VerifyTeacherAssismentNewUploadedTestMaterial() {

            uploadTestMaterialLib.SetUpPreCondition();

            /*Login to CM */
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            /*Search Case Rferance*/
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);

            /*Create New form*/
            commFunc.CreateNewFrom(excelUtil.GetDataFromExcel("FormName"));
            uploadTestMaterialLib.selectUploadDocumentType(true, true);

            /*Fill Forms*/
            uploadTestMaterialLib.SelectCategoriesAndSubject(excelUtil.GetDataFromExcel("Category"), null, null);

            //upload dpoucment
            uploadTestMaterialLib.FillUploadTestMaterialSection(excelUtil.GetDataFromExcel("uploadFileName1"), excelUtil.GetDataFromExcel("uploadFileDec1"), commFunc.GetCurrentDate("dd-MMM-yyyy"), commFunc.GetPastOrFutureDate(0, 1, 0, "dd-MMM-yyyy"));

            commFunc.NaviagteToNextPage();

            uploadTestMaterialLib.DeletePreviouslyUploadTestMaterial();

            // Submit form
            commFunc.SubmitForm();

            // verify application submission confirmation message
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Upload Test Document confrmation message.");

            // Launch Portal application
            viewKS1KS2TestMaterialLib.SetUpPreCondition("STA_PORTAL");

            // Logint ot portal and naviagte to respective form
            viewKS1KS2TestMaterialLib.LoginAndNavigatToViewTestMaterialForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"), "TeacherAssistment");
            comFunc.StartApplication();

            //verify download 
            VerifyIsTrue(viewKS1KS2TestMaterialLib.IsUploadedDocDisplayed(excelUtil.GetDataFromExcel("uploadFileDec1")), "Check Uploaded Doucment should displayed view KS1 test Material");

            // verify donwload uploaded doucment
            viewKS1KS2TestMaterialLib.DownloadDocument(excelUtil.GetDataFromExcel("uploadFileDec1"));

            VerifyIsTrue(commFunc.IsDoucmentDownloaded(excelUtil.GetDataFromExcel("uploadFileName1")), "Check Doucment should able to download");

            //Verify Event log in cm */
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            /*Search Case Rferance*/
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);

            /*Create New form*/
            commFunc.CreateNewFrom(eventLogOfDownload);
            eventLogsOfDownloadLib.SetUpPreCondition();

            // Fill Event log of download form
            eventLogsOfDownloadLib.FillEventLogOFDownloadForm(excelUtil.GetDataFromExcel("uploadFileDec1"), comFunc.GetCurrentDate("dd-MMM-yyyy"), comFunc.GetCurrentDate("dd-MMM-yyyy"));

            // Verify log for dwonlowed doucment
            eventLogsOfDownloadLib.CheckSearchResult(excelUtil.GetDataFromExcel("SchoolName"), excelUtil.GetDataFromExcel("UserName"));

        }

    }
}
