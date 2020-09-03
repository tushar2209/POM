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
    class OutBoundCustomerContactTestCases : OutBoundCustomerContactLib
    {
        public OutBoundCustomerContactLib outBoundCustomerContactLib;
        static ExcelUtil excelUtil;
        CommonFunctions commFunc;



        /// <summary>
        /// Method to setup pre- condition of test cases.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            outBoundCustomerContactLib = new OutBoundCustomerContactLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "OutBoundCustomerContact");

            outBoundCustomerContactLib.SetUpPreCondition();

            /*Login to CM */
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));

            /*Search Case Rferance*/
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);

            /*Create New form*/
            commFunc.CreateNewFrom(excelUtil.GetDataFromExcel("FormName"));
        }

        [Test]
        public void VerifyOuBoundCustomerContactWithoutCallBack()
        {
            // Fill the Outbound customer form
            outBoundCustomerContactLib.FillOutBoundCustomerContactForm(excelUtil.GetDataFromExcel("DialedNumber"), excelUtil.GetDataFromExcel("ContactName"), excelUtil.GetDataFromExcel("ContactNumber"), excelUtil.GetDataFromExcel("OutBoundCallOutCome"), false, null, null, null, null, excelUtil.GetDataFromExcel("EmailForFollowup"), excelUtil.GetDataFromExcel("AgentNote"));

            // Upload Doucment 
            outBoundCustomerContactLib.AddNewUploadDocument(excelUtil.GetDataFromExcel("UploadFileName"), excelUtil.GetDataFromExcel("FileDescription"));

            // Submit form
            comFunc.SubmitForm();

            // Verify Form Confirmation msg
            VerifyIsContains(excelUtil.GetDataFromExcel("FormSubmissionMsg"), comFunc.GetFormSubmissionConfirmationMsg(), "Check Outbound Customer Contact form submission confirmation msg");

        }

        [Test]
        public void VerifyOuBoundCustomerContactWithCallBack()
        {
            string CallBackdate = commFunc.GetPastOrFutureDate(0, 0, 0, "dd-MMM-yyyy");
            
            // Fill the Outbound customer form
            outBoundCustomerContactLib.FillOutBoundCustomerContactForm(excelUtil.GetDataFromExcel("DialedNumber"), excelUtil.GetDataFromExcel("ContactName"), excelUtil.GetDataFromExcel("ContactNumber"), excelUtil.GetDataFromExcel("OutBoundCallOutCome"), true, excelUtil.GetDataFromExcel("NameOfPersonToCall"), excelUtil.GetDataFromExcel("TelePhNumToCall"), CallBackdate, excelUtil.GetDataFromExcel("TimeOfFollowUpToCall"), excelUtil.GetDataFromExcel("EmailForFollowup"), excelUtil.GetDataFromExcel("AgentNote"));
            
            // Upload Doucment 
            outBoundCustomerContactLib.AddNewUploadDocument(excelUtil.GetDataFromExcel("UploadFileName"), excelUtil.GetDataFromExcel("FileDescription"));

            // Submit and Verify form submission msg
            comFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("FormSubmissionMsg"), comFunc.GetFormSubmissionConfirmationMsg(), "Check Outbound Customer Contact form submission confirmation msg");

            // Navigate back to case Manager
            commFunc.NavigateBackToCaseManager();

            // Open Outbound Customer Contact Call back form
            commFunc.openedInCompetFormCmFromExpandView("OUTCUSCONT");

            // Verify pre populated fileds value in call back from
            outBoundCustomerContactLib.CheckCallBackFormPrepopulatedFields(excelUtil.GetDataFromExcel("NameOfPersonToCall"), excelUtil.GetDataFromExcel("TelePhNumToCall"), CallBackdate, excelUtil.GetDataFromExcel("TimeOfFollowUpToCall"), excelUtil.GetDataFromExcel("EmailForFollowup"));

            // Fill Ountbound Customer conact call back from
            outBoundCustomerContactLib.FillCallBackForm(false, excelUtil.GetDataFromExcel("DateOfFollowUpToCall"), excelUtil.GetDataFromExcel("TimeOfFollowUpToCall"), excelUtil.GetDataFromExcel("AgentNote"));

            // Submit and Verify form submission msg
            comFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("CallBackFormSubmissionMsg"), comFunc.GetFormSubmissionConfirmationMsg(), "Check Outbound Customer Contact form submission confirmation msg");

        }

        [Test]
        public void VerifyOuBoundCustomerContactWithMutipleCallBacks()
        {
            string CallBackdate = commFunc.GetPastOrFutureDate(0, 0, 0, "dd-MMM-yyyy");
            // Fill the Outbound customer form
            outBoundCustomerContactLib.FillOutBoundCustomerContactForm(excelUtil.GetDataFromExcel("DialedNumber"), excelUtil.GetDataFromExcel("ContactName"), excelUtil.GetDataFromExcel("ContactNumber"), excelUtil.GetDataFromExcel("OutBoundCallOutCome"), true, excelUtil.GetDataFromExcel("NameOfPersonToCall"), excelUtil.GetDataFromExcel("TelePhNumToCall"), CallBackdate, excelUtil.GetDataFromExcel("TimeOfFollowUpToCall"), excelUtil.GetDataFromExcel("EmailForFollowup"), excelUtil.GetDataFromExcel("AgentNote"));

            // Upload Doucment 
            outBoundCustomerContactLib.AddNewUploadDocument(excelUtil.GetDataFromExcel("UploadFileName"), excelUtil.GetDataFromExcel("FileDescription"));

            // Submit and Verify form submission msg
            comFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("FormSubmissionMsg"), comFunc.GetFormSubmissionConfirmationMsg(), "Check Outbound Customer Contact form submission confirmation msg");

            // Navigate back to case Manager
            commFunc.NavigateBackToCaseManager();

            // Open Outbound Customer Contact Call back form 
            commFunc.openedInCompetFormCmFromExpandView("OUTCUSCONT");

            // Verify pre populated fileds value in call back from
            outBoundCustomerContactLib.CheckCallBackFormPrepopulatedFields(excelUtil.GetDataFromExcel("NameOfPersonToCall"), excelUtil.GetDataFromExcel("TelePhNumToCall"), CallBackdate, excelUtil.GetDataFromExcel("TimeOfFollowUpToCall"), excelUtil.GetDataFromExcel("EmailForFollowup"));

            // Fill Ountbound Customer conact call back from
            string CallBackdate2 = commFunc.GetPastOrFutureDate(1, 0, 0, "dd-MMM-yyyy");
            outBoundCustomerContactLib.FillCallBackForm(true, CallBackdate2, excelUtil.GetDataFromExcel("TimeOfFollowUpToCall2"), excelUtil.GetDataFromExcel("AgentNote"));

            // Submit and Verify form submission msg
            comFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("CallBackFormSubmissionMsg"), comFunc.GetFormSubmissionConfirmationMsg(), "Check Outbound Customer Contact form submission confirmation msg");

            // Navigate back to case Manager
            commFunc.NavigateBackToCaseManager();

            // Open Outbound Customer Contact Call back form 2
            commFunc.openedInCompetFormCmFromExpandView("OUTCUSCONT");

            // Verify pre populated fileds value in call back from2
            outBoundCustomerContactLib.CheckCallBackFormPrepopulatedFields(excelUtil.GetDataFromExcel("NameOfPersonToCall"), excelUtil.GetDataFromExcel("TelePhNumToCall"), CallBackdate2, excelUtil.GetDataFromExcel("TimeOfFollowUpToCall2"), excelUtil.GetDataFromExcel("EmailForFollowup"));
            
            // Fill Ountbound Customer conact call back from2
            outBoundCustomerContactLib.FillCallBackForm(false, null, null, null);

            // Submit and Verify form submission msg
            comFunc.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("CallBackFormSubmissionMsg"), comFunc.GetFormSubmissionConfirmationMsg(), "Check Outbound Customer Contact form submission confirmation msg");

        }
    }
}
