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
    class OperationalIncResolutionTestCase : OperationalIncResolutionLib
    {

        OperationalIncResolutionLib operresolutionlib;
        static ExcelUtil excelUtil;
        CommonFunctions commFunc;

        /// <summary>
        /// Method to setup pre- condition of test cases.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            operresolutionlib = new OperationalIncResolutionLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "OperationalResolution");
            operresolutionlib .SetUpPreCondition();
        }

        [Test]
        public void VerifyOperationalncidentResolutionForm()
        {
            /*Login to CM */
            commFunc.LoginIntoCM("STA_CM", excelUtil.GetDataFromExcel("CM_UserName"), excelUtil.GetDataFromExcel("CM_Password"));
            /*Search Case Rferance*/
            commFunc.SearchCaseReferance(excelUtil.GetDataFromExcel("CaseRefeNo"), null, null);
            /*Create New form */
            commFunc.CreateNewFrom(excelUtil.GetDataFromExcel("FormName"));
            //Fill Forms for all 3 sections
            operresolutionlib.FillInboundCustomerContactinfoSec(excelUtil.GetDataFromExcel("ContactName"), excelUtil.GetDataFromExcel("ContactEmail"), excelUtil.GetDataFromExcel("ContactNumber"), excelUtil.GetDataFromExcel("Contactdisposition"), excelUtil.GetDataFromExcel("AreaForKS1"), excelUtil.GetDataFromExcel("ContactType"),excelUtil.GetDataFromExcel("Markerdropdown"), excelUtil.GetDataFromExcel("ContactReason"), excelUtil.GetDataFromExcel("TypeofIssue"));
            operresolutionlib.FillInboundCustomerOperationalIssueSec(excelUtil.GetDataFromExcel("TypeofIssue"), excelUtil.GetDataFromExcel("IssueCategory"), excelUtil.GetDataFromExcel("Site"), excelUtil.GetDataFromExcel("Function"), excelUtil.GetDataFromExcel("DateofIssue"), excelUtil.GetDataFromExcel("TimeofIssue"), excelUtil.GetDataFromExcel("DetailsofIssue"));
            operresolutionlib.FillInboundCustomerNotesSec(excelUtil.GetDataFromExcel("Agent Notes"), excelUtil.GetDataFromExcel("NotesAttachment"));
            //Verify submission message
            VerifyIsContains(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check Operational Incident Resolution confrmation message.");
            //Navigate back to Contact detail page
            comFunc.NavigateBackToCaseManager();
            //Open Review Form
            commFunc.openedInCompetFormCmFromExpandView("OPINRESFRM");
            //Validate Form values
            operresolutionlib.VerifyICCForm(excelUtil.GetDataFromExcel("TypeofIssue"), excelUtil.GetDataFromExcel("IssueCategory"),excelUtil.GetDataFromExcel("Site"), excelUtil.GetDataFromExcel("Function"), excelUtil.GetDataFromExcel("TimeofIssue"), excelUtil.GetDataFromExcel("DetailsofIssue"), excelUtil.GetDataFromExcel("Agent Notes"));
            //Submit the reviewed form
            operresolutionlib.SubmitICCForm(excelUtil.GetDataFromExcel("Activity"), excelUtil.GetDataFromExcel("Information"), excelUtil.GetDataFromExcel("NotesAttachment"));
            //Verify Submission Message
            VerifyIsContains(excelUtil.GetDataFromExcel("FormSumbissionReviewMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Please check the review form");

        }
    }
}
