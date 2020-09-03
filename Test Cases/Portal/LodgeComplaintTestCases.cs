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
    class LodgeComplaintTestCases:LodgeComplaint
    {

        LodgeComplaint complaintlodge;
        static ExcelUtil excelUtil;
        CommonFunctions commFunc;



        /// <summary>
        /// Method to setup pre- condition of test cases.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            complaintlodge = new LodgeComplaint();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "LodgeComplaint");

            // Launch Portal Application
            complaintlodge.SetUpPreCondition("STA_PORTAL");

            // Login to appliation and navigate to respective form

            complaintlodge.LoginAndNavigatToLodgeComplaint(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

        }



        ///// <summary>
        ///// Select Enquiry Type 
        ///// </summary>       
        //[Test, Category("RegressionTest"), Property("AcceptanceCriteria", "1")]



        //public void VerifyEnquireyTypeSelected()
        //{


        //    Start Application
        //    commFunc.StartApplication();

        //    SelectEnquiry
        //    complaintlodge.SelectEnquiryType(excelUtil.GetDataFromExcel("enquiryType"));


        //}
        /// <summary>
        /// Select Complaint Releated 
        /// </summary>       
        //[Test, Category("RegressionTest"), Property("AcceptanceCriteria", "2")]

        ////public void VerifySelectComplaintReleated()
        ////{


        ////    Start Application
        ////    commFunc.StartApplication();

        ////    SelectComplaintReleated
        ////    complaintlodge.SelectCategoryOfComplaints(excelUtil.GetDataFromExcel("categorycomplaint"));


        //}
        ///// <summary>
        ///// Select Complaint Releated 
        ///// </summary>       
        //[Test, Category("RegressionTest"), Property("AcceptanceCriteria", "3")]
        //public void VerifyFurtherDetails()
        //{


        //    // Start Application
        //    commFunc.StartApplication();

        //    // SelectComplaintReleated
        //    complaintlodge.SelectNatureOfComplaints(excelUtil.GetDataFromExcel("message"));


        //}







        ///// <summary>
        ///// Select Name  
        ///// </summary>       
        //[Test, Category("RegressionTest"), Property("AcceptanceCriteria", "3")]

        //public void VerifyName()
        //{


        //    // Start Application
        //    commFunc.StartApplication();

        //    // SelectName
        //    complaintlodge.SelectName(excelUtil.GetDataFromExcel("name"));


        //}


        ///// <summary>
        ///// Select EmailAddress 
        ///// </summary>       
        //[Test, Category("RegressionTest"), Property("AcceptanceCriteria", "4")]


        //public void VerifyEmailAddress()
        //{


        //    // Start Application
        //    commFunc.StartApplication();

        //    // SelectName
        //    complaintlodge.SelectEmailAddress(excelUtil.GetDataFromExcel("emailaddress"));


        //}
        //[Test, Category("RegressionTest"), Property("AcceptanceCriteria", "4")]

        ///// <summary>
        ///// Submit section 
        ///// </summary>    
        //public void VerifySubmit()
        //{


        //    // Submit Application
        //    commFunc.SubmitForm();

        //    // ResponseText
        //    VerifyIsEquals(excelUtil.GetDataFromExcel("FromSubmissionConfirmationMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Application Submission confrmation message");


        //}
        [Test, Category("RegressionTest"), Property("AcceptanceCriteria", "4")]


        public void VerifySelectedEnquiryTypeQuery()
        {

            commFunc.StartApplication();
            complaintlodge.SelectEnquiryType(excelUtil.GetDataFromExcel("enquiryType"));

           seleniumFunc.WaitForElementToBeVisible(lodgeComplaint.NatureOfQuery2);
            complaintlodge.SelectNatureOfQuery(excelUtil.GetDataFromExcel("message"));
            complaintlodge.SelectEmailAddress(excelUtil.GetDataFromExcel("emailaddress"));
            complaintlodge.SelectName(excelUtil.GetDataFromExcel("name"));
            commFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Application Submission confrmation message");



        }
        [Test, Category("RegressionTest"), Property("AcceptanceCriteria", "4")]

        public void VerifySelectedEnquiryTypeComplaint()
        {

            commFunc.StartApplication();
            complaintlodge.SelectEnquiryType(excelUtil.GetDataFromExcel("enquiryType"));
            seleniumFunc.WaitForPageToLoad();
            // seleniumFunc.WaitForElementToBeVisible(lodgeComplaint.NatureOfQuery);
            //seleniumFunc.WaitForElementToBeVisible(lodgeComplaint.ComplaintReleated);
            complaintlodge.SelectCategoryOfComplaints(excelUtil.GetDataFromExcel("categorycomplaint"));
            //  seleniumFunc.WaitForPageToLoad();
            //seleniumFunc.WaitForElementToBeVisible(lodgeComplaint.NatureOfQuery);
            
            seleniumFunc.WaitForEmentToBeClickable(lodgeComplaint.NatureOfQuery);
           // seleniumFunc.WaitForElementToBeVisible(lodgeComplaint.NatureOfQuery);
            complaintlodge.SelectNatureOfComplaints(excelUtil.GetDataFromExcel("message"));
            complaintlodge.SelectEmailAddress(excelUtil.GetDataFromExcel("emailaddress"));
            complaintlodge.SelectName(excelUtil.GetDataFromExcel("name"));
            commFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Application Submission confrmation message");



        }

        [Test, Category("RegressionTest"), Property("AcceptanceCriteria", "4")]

        public void VerifySelectedEnquiryTypeAppeal()
        {

            commFunc.StartApplication();
            //mplaintlodge.SelectEnquiryType(excelUtil.GetDataFromExcel("enquiryType"));
            complaintlodge.SelectEnquiryType(excelUtil.GetDataFromExcel("enquiryType"));
            //complaintlodge.SelectEnquiryType("Appeal");
            seleniumFunc.WaitForPageToLoad();
            //seleniumFunc.WaitForEmentToBeClickable(lodgeComplaint.NaturofAppeal);
            complaintlodge.SelectAppealCategory(excelUtil.GetDataFromExcel("categorycomplaint"));
           // seleniumFunc.WaitForEmentToBeClickable(lodgeComplaint.NaturofAppeal);
            complaintlodge.SelectNatureOfAppeal(excelUtil.GetDataFromExcel("message"));
            complaintlodge.SelectEmailAddress(excelUtil.GetDataFromExcel("emailaddress"));
            complaintlodge.SelectName(excelUtil.GetDataFromExcel("name"));
            commFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Application Submission confrmation message");
        }


    }
}




