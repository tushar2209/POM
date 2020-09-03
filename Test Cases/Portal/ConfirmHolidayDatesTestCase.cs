using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using STA.Utilities.ExcelReader;
using STA__Automation.BussinessLib;
using STA__Automation.CommonLib;

namespace STA__Automation.TestCases.Portal
{
    class ConfirmHolidayDatesTestCase : ConfirmHolidayDatesLib
    {
        static ConfirmHolidayDatesLib confirmHolidayDatesLib;
        static ExcelUtil excelUtil;
        CommonFunctions commFunc;

        /// <summary>
        /// Methpod to set up pre- condition of test cases
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            confirmHolidayDatesLib = new ConfirmHolidayDatesLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "ConfirmHolidayDates");

            // Launch portal appliation
            confirmHolidayDatesLib.SetUpPreCondition("STA_PORTAL");

            // Login to portal and navigate to respective form
            confirmHolidayDatesLib.LoginAndNavigatConfimHolidayDatesForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
        }



        /// <summary>
        /// Test method to verify mandetoty fields ofConfirm Holidays Dates form
        /// </summary>

        [Test, Category("RegressionTest"), Property("AcceptanceCriteria", "1"), Property("TestCaseIDs", "40813")]
        public void VerifyMandetoryFieldsAndContactDetailsInformation()
        {
            // Start application
            commFunc.StartApplication();

            // Verify contact detail information
            confirmHolidayDatesLib.CheckContactDetailsPrePopulatedFiledsValue(excelUtil.GetDataFromExcel("UserFirstName"), excelUtil.GetDataFromExcel("UserLastName"), excelUtil.GetDataFromExcel("JobTitle"), excelUtil.GetDataFromExcel("UserTeleNumber"), excelUtil.GetDataFromExcel("UserEmailAddress"));

            // Submit forma nd verify mandetory field list
            confirmHolidayDatesLib.SubmitForm();
            confirmHolidayDatesLib.VerifyMandetoryFields(excelUtil);

        }


        /// <summary>
        /// Test method to verify dates validation / warnning messages
        /// </summary>
        [Test, Category("RegressionTest"), Property("AcceptanceCriteria", "3"), Property("TestCaseIDs", "40816\n40816")]
        public void VerifyDateValidations()
        {
            //  Start Application 
            commFunc.StartApplication();

            // Verify Date validation/warning messages
            confirmHolidayDatesLib.VerifyDateValidations(excelUtil, "Warning");

        }


        /// <summary>
        /// Test Case - Verify Confirm Holiday Dates For Current Academic Year
        /// </summary>

        [Test, Category("SmokeTest"), Property("AcceptanceCriteria", "2")]
        public void ConfirmHolidayDatesForCurrentAcademicYear()
        {
            //  Start Application 
            commFunc.StartApplication();

            // Enter dates 
            confirmHolidayDatesLib.SelectSpringHalfTermHoliday(excelUtil.GetDataFromExcel("SpringHalfTermHolidaysStartDate"), excelUtil.GetDataFromExcel("SpringHalfTermHolidaysEndtDate"));
            confirmHolidayDatesLib.SelectEasterHolidaysy(excelUtil.GetDataFromExcel("EasterHolidaysStartDate"), excelUtil.GetDataFromExcel("EasterHolidaysEndDate"));

            confirmHolidayDatesLib.SelectSummerHalfTermHolidays(excelUtil.GetDataFromExcel("SummerHalfTtermHolidaysStartDate"), excelUtil.GetDataFromExcel("SummerHalfTtermHolidaysEndDate"));

            // select on next Academic year No 
            confirmHolidayDatesLib.SelectHolidadyNextAcademicYear(false);

            //Submit form
            commFunc.SubmitForm();

            // Verify Confirmation message
            VerifyIsEquals(excelUtil.GetDataFromExcel("ApplicationSubmitionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Application Submission confrmation message");

        }

        /// <summary>
        /// Test Case - Verify Confirm Holiday Dates For Curren And Nextt Academic Year.
        /// </summary>
        [Test, Category("SanityTest"),  Property("AcceptanceCriteria", "1"), Property("TestCaseIDs", "40817")]
        public void ConfirmHolidayDatesForCurrenAndNexttAcademicYear()
        {

            // Start Application 
            commFunc.StartApplication();

            // Enter dates 
            confirmHolidayDatesLib.SelectSpringHalfTermHoliday(excelUtil.GetDataFromExcel("SpringHalfTermHolidaysStartDate"), excelUtil.GetDataFromExcel("SpringHalfTermHolidaysEndtDate"));
            confirmHolidayDatesLib.SelectEasterHolidaysy(excelUtil.GetDataFromExcel("EasterHolidaysStartDate"), excelUtil.GetDataFromExcel("EasterHolidaysEndDate"));

            confirmHolidayDatesLib.SelectSummerHalfTermHolidays(excelUtil.GetDataFromExcel("SummerHalfTtermHolidaysStartDate"), excelUtil.GetDataFromExcel("SummerHalfTtermHolidaysEndDate"));

            // select on next Academic year Yes 
            confirmHolidayDatesLib.SelectHolidadyNextAcademicYear(true);

            // Enter dates
            confirmHolidayDatesLib.SelectSpringHalfTermHolidayForNextAcademicYear(excelUtil.GetDataFromExcel("NextYearSpringHalfTermHolidaysStartDate"), excelUtil.GetDataFromExcel("NextYearSpringHalfTermHolidaysEndtDate"));
            confirmHolidayDatesLib.SelectEasterHolidaysyForNextAcademicYear(excelUtil.GetDataFromExcel("NextYearEasterHolidaysStartDate"), excelUtil.GetDataFromExcel("NextYearEasterHolidaysEndDate"));
            confirmHolidayDatesLib.SelectSummerHalfTermHolidaysForNextAcaemicYear(excelUtil.GetDataFromExcel("NextYearSummerHalfTtermHolidaysStartDate"), excelUtil.GetDataFromExcel("NextYearSummerHalfTtermHolidaysEndDate"));

            //Submit form
            commFunc.SubmitForm();

            // Verify Confirmation message
            VerifyIsEquals(excelUtil.GetDataFromExcel("ApplicationSubmitionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Application Submission confrmation message");

        }
    }
}
