using OpenQA.Selenium;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;
using STA__Automation.Pages.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STA.Utilities.ExcelReader;

namespace STA__Automation.BussinessLib
{
    class OperationalIncResolutionLib : BaseTestClass
    {

        public static SeleniumCommFunctions seleniumFunc;
        static ExcelUtil excelUtil;
        public static OperationalIncResolutionPage operincidentpage;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;
        public static CM_ContactDetailsPage cM_ContactDetails;

        /// <summary>
        ///  Method to  set up pre condition for test case.
        /// </summary>
        /// <param name="appURL">URL Application U</param>
        public void SetUpPreCondition()
        {
            driver = GetDriver();
            seleniumFunc = new SeleniumCommFunctions();
            comFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "OperationalResolution");
            log.Info("Test method setup started");
            InitialisePageObjects();
        }

        /// <summary>
        /// Method to initialise  page objects
        /// </summary>
        public void InitialisePageObjects()
        {
            operincidentpage = new OperationalIncResolutionPage(driver);
            myActivityPage = new MyActivityPage(driver);
            cM_ContactDetails = new CM_ContactDetailsPage(driver);
        }

        public void FillInboundCustomerContactinfoSec(string contactName,string contactEmail,string contactNumber,string contactdisposition,string AreaforKS1,string contactype,string MarkerdropDown,string contactreason,string typeofissue)
        {
            
            seleniumFunc.WaitAndEnterText(operincidentpage.ContactName, contactName);
            seleniumFunc.WaitAndEnterText(operincidentpage.Contactemail, contactEmail);
            seleniumFunc.WaitAndEnterText(operincidentpage.ContactNumber, contactNumber);
            seleniumFunc.SelectValueFromDropDwn(operincidentpage.ContactDisposition, contactdisposition);
            seleniumFunc.WaitAndClickOnElement(operincidentpage.ContactArea);
            seleniumFunc.SelectValueFromDropDwn(operincidentpage.AreaforKS1, AreaforKS1);
            seleniumFunc.SelectValueFromDropDwn(operincidentpage.ContactType, contactype);
            seleniumFunc.SelectValueFromDropDwn(operincidentpage.MarkerDropDown, MarkerdropDown);
            seleniumFunc.WaitAndClickOnElement(operincidentpage.CommunicationType);
            seleniumFunc.SelectValueFromDropDwn(operincidentpage.ContactReason, contactreason);
            seleniumFunc.WaitAndClickOnElement(operincidentpage.IssuePriority);
            comFunc.NaviagteToNextPage();

        }

        public void FillInboundCustomerOperationalIssueSec(string typeofissue,string issuecategory,string site,string function,string date,string time,string detailsofissue)
        {
            seleniumFunc.SelectValueFromDropDwn(operincidentpage.TypeofIssue, typeofissue);
            seleniumFunc.SelectValueFromDropDwn(operincidentpage.IssueCategory, issuecategory);
            seleniumFunc.SelectValueFromDropDwn(operincidentpage.Site, site);
            seleniumFunc.SelectValueFromDropDwn(operincidentpage.Function, function);
            comFunc.SelectDateFromDatePicker(operincidentpage.DateofIssueOccurence, date);
            seleniumFunc.WaitAndEnterText(operincidentpage.TimeofIssueOccurence, time);
            seleniumFunc.WaitAndEnterText(operincidentpage.DetailsofIssue, detailsofissue);
            comFunc.NaviagteToNextPage();

        }
        public void FillInboundCustomerNotesSec(string agentnotes,string NotesAttachment)
        {
           seleniumFunc.WaitAndEnterText(operincidentpage.AgentNotes, agentnotes);
            comFunc.UploadDocuments(NotesAttachment,operincidentpage.Attachments[0]);
            comFunc.SubmitForm();
 
        }
        public void VerifyICCForm(string TypeofIssue,string IssueCategory,string site,string Function,string timeofissue,string detailsofissue,string agentnotes)
        {
            VerifyIsEquals(TypeofIssue, seleniumFunc.GetAttributeValue(operincidentpage.TypeofIssue, "value"), "Value not matching");
            VerifyIsEquals(IssueCategory, seleniumFunc.GetAttributeValue(operincidentpage.IssueCategory, "value"), "Value not matching");
            VerifyIsEquals(site, seleniumFunc.GetAttributeValue(operincidentpage.Site, "value"), "Value not matching");
            VerifyIsEquals(Function, seleniumFunc.GetAttributeValue(operincidentpage.Function, "value"), "Value not matching");
           // VerifyIsEquals(excelUtil.GetDataFromExcel("DateofIssue"), seleniumFunc.GetAttributeValue(operincidentpage.DateofIssueOccurence, "value"), "Value not matching");
           // VerifyIsEquals(comFunc.GetReqFromatDate(excelUtil.GetDataFromExcel("DateofIssue"), "dd/MM/yyyy"), seleniumFunc.GetAttributeValue(operincidentpage.DateofIssueOccurence, "value"), "Value not matching");
            VerifyIsEquals(timeofissue, seleniumFunc.GetAttributeValue(operincidentpage.TimeofIssueOccurence, "value"), "Value not matching");
            VerifyIsEquals(detailsofissue, seleniumFunc.GetAttributeValue(operincidentpage.DetailsofIssue, "value"), "Value not matching");
          //  VerifyIsEquals(agentnotes, seleniumFunc.GetAttributeValue(operincidentpage.AgentNotes, "value"), "Value not matching");
            comFunc.NaviagteToNextPage();

        }
        public void SubmitICCForm(string Activity,string InformationNotes,string Attachment)
        {
           seleniumFunc.SelectValueFromDropDwn(operincidentpage.Activity, Activity);
           seleniumFunc.WaitAndEnterText(operincidentpage.InformationNotes, InformationNotes);
           comFunc.UploadDocuments(Attachment, operincidentpage.Attachments[0]);
           comFunc.SubmitForm();

        }


    }
}
