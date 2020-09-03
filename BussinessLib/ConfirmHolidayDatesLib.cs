using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using STA.Utilities.ExcelReader;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;
using STA__Automation.Pages.Portal;

namespace STA__Automation.BussinessLib
{
    class ConfirmHolidayDatesLib : BaseTestClass
    {
        public static SeleniumCommFunctions seleniumFunc;

        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;
        public static ConfirmHolidayDatesPage confirmHolidayDatesPage;



        /// <summary>
        ///  Method to  set up re condition for test case.
        /// </summary>
        /// <param name="appURL">URL Application U</param>
        public void SetUpPreCondition(string appURL)
        {
            driver = GetDriver();

            seleniumFunc = new SeleniumCommFunctions();
            log.Info("Test method setup started");
            InitialisePageObjects();
            comFunc = new CommonFunctions();

            log.Info("launch application");
            comFunc.LaunchApplication(appURL);

        }

        /// <summary>
        /// Method to initialise  page objects
        /// </summary>
        public void InitialisePageObjects()
        {
            confirmHolidayDatesPage = new ConfirmHolidayDatesPage(driver);
            myActivityPage = new MyActivityPage(driver);


        }

        /// <summary>
        /// Method to login to portal and navigate to MyActivity-> Available Activity -> Titme Table Variation Application
        /// </summary>
        /// <param name="userName"> userName</param>
        /// <param name="password">passWord</param>
        public void LoginAndNavigatConfimHolidayDatesForm(string userName, string password)
        {

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.ConfirmHolidayDatesAppLink);

        }

        public string VerifyMandetoryFields(ExcelUtil excel)
        {
            string TCName = "VerifyMandetoryFieldsAndContactDetailsInformation";
            string[] fieldNames = { "Spring half term holidays", "Easter holidays", "Summer half term holidays", "Next year Accademic Spring half term holidays", " Next year AccademicEaster holidays", " Next year Accademic Summer half term holidays" };
            string[] StartDates = { "SpringHalfTermHolidaysStartDate", "EasterHolidaysStartDate", "SummerHalfTtermHolidaysStartDate", "NextYearSpringHalfTermHolidaysStartDate", "NextYearEasterHolidaysStartDate", "NextYearSummerHalfTtermHolidaysStartDate" };
            string[] EndDates = { "SpringHalfTermHolidaysEndtDate", "EasterHolidaysEndDate", "SummerHalfTtermHolidaysEndDate", "NextYearSpringHalfTermHolidaysEndtDate", "NextYearEasterHolidaysEndDate", "NextYearSummerHalfTtermHolidaysEndDate" };
            string errorList = "";


            if (!seleniumFunc.IsElementDisplayed(confirmHolidayDatesPage.NextAcademicHolidaysYesRadioBtn))
                errorList = "Do you wish to add holidays for the next academic year? is not mandetory field. \n";
            seleniumFunc.WaitAndClickOnElement(confirmHolidayDatesPage.NextAcademicHolidaysYesRadioBtn);

            for (int i = 0; i < 6; i++)
            {

                //  errorList = errorList + CheckStartDateErrorMsg(i, excel.GetDataFromExcel(StartDates[i]), fieldNames[i]);

                CheckStartDateErrorMsg(i, excel.GetDataFromExcel(TCName,StartDates[i]), fieldNames[i]);

                CheckEndDateErrorMsg(i, excel.GetDataFromExcel(TCName,EndDates[i]), fieldNames[i]);

               // errorList = errorList + CheckEndDateErrorMsg(i, excel.GetDataFromExcel(EndDates[i]), fieldNames[i]);
            }

            return errorList;
        }

        public string CheckStartDateErrorMsg(int fieldNo, string date, string dateSectionName)
        {

            string error = "";
            SubmitForm();
           
            var stepDec = "Check "+dateSectionName + "- Start Date mandetory field.";
            VerifyIsTrue(seleniumFunc.IsElementDisplayed(confirmHolidayDatesPage.StartDateMandErrorMsg[fieldNo]), stepDec);
           // if (!seleniumFunc.IsElementDisplayed(confirmHolidayDatesPage.StartDateMandErrorMsg[fieldNo]))
            //    error = dateSectionName + ": Start Date is not mandetory field. \n";
            comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.StartDates[fieldNo], date);
            return error;
        }

        public string CheckEndDateErrorMsg(int fieldNo, string date, string dateSectionName)
        {
            string error = "";
            SubmitForm();
            var stepDec = "Check " + dateSectionName + "- End Date mandetory field.";
            VerifyIsTrue(seleniumFunc.IsElementDisplayed(confirmHolidayDatesPage.EndtDateMandErrorMsg[fieldNo]), stepDec);
         //   if (!seleniumFunc.IsElementDisplayed(confirmHolidayDatesPage.EndtDateMandErrorMsg[fieldNo]))
         //       error = dateSectionName + ": End Date is not mandetory field. \n";
            comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.EndDates[fieldNo], date);
            return error;
        }

        public void SelectSpringHalfTermHoliday(string startDate, string endDate)
        {            
            comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.StartDates[0], startDate);
            comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.EndDates[0], endDate);
        }

        public void SelectEasterHolidaysy(string startDate, string endDate)
        {
            comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.StartDates[1], startDate);
            comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.EndDates[1], endDate);
        }

        public void SelectSummerHalfTermHolidays(string startDate, string endDate)
        {
            comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.StartDates[2], startDate);
            comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.EndDates[2], endDate);
        }

        public void SelectSpringHalfTermHolidayForNextAcademicYear(string startDate, string endDate)
        {
            comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.StartDates[3], startDate);
            comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.EndDates[3], endDate);
        }

        public void SelectEasterHolidaysyForNextAcademicYear(string startDate, string endDate)
        {
            comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.StartDates[4], startDate);
            comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.EndDates[4], endDate);
        }

        public void SelectSummerHalfTermHolidaysForNextAcaemicYear(string startDate, string endDate)
        {
            comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.StartDates[5], startDate);
            comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.EndDates[5], endDate);
        }


        public void SelectHolidadyNextAcademicYear(bool nextYear)
        {
            if (nextYear)
                seleniumFunc.WaitAndClickOnElement(confirmHolidayDatesPage.NextAcademicHolidaysYesRadioBtn);
            else
                seleniumFunc.WaitAndClickOnElement(confirmHolidayDatesPage.NextAcademicHolidaysNoRadioBtn);
        }


        public string CheckContactDetailsPrePopulatedFiledsValue(string firstName, string lastName, string JobeTitle, string TelPhone, string emailAddress)
        {
            string missMatchResult = "";
            seleniumFunc.WaitForPageToLoad();
            seleniumFunc.ScrollElementInView(confirmHolidayDatesPage.ContactFirstName);
            string ActualfirstName = confirmHolidayDatesPage.ContactFirstName.GetAttribute("value");
            string ActualLastName = confirmHolidayDatesPage.ContactLastName.GetAttribute("value");
            string ActualJobTitle = confirmHolidayDatesPage.JobTitle.GetAttribute("value");
            string ActualTeleNum = confirmHolidayDatesPage.TelephoneNumber.GetAttribute("value");
            string ActualEmailAdd = confirmHolidayDatesPage.EmailAddress.GetAttribute("value");

          

            VerifyIsEquals(firstName, ActualfirstName ,"Check Contact FirstName");
            VerifyIsEquals(lastName, ActualLastName, "Check Contact lastName");
            VerifyIsEquals(JobeTitle, ActualJobTitle, "Check Contact JobeTitle");
            VerifyIsEquals(TelPhone, ActualTeleNum, "Check Contact TelPhone");
            VerifyIsEquals(emailAddress, ActualEmailAdd, "Check Contact emailAddress");
/*
            if (!firstName.Equals(ActualfirstName))
                missMatchResult = "Expected Contact first name :" + firstName + " Actual :" + ActualfirstName + "\n";

            if (!lastName.Equals(ActualLastName))
                missMatchResult = "Expected Contact Last name :" + lastName + " Actual :" + ActualLastName + "\n";

            if (!JobeTitle.Equals(ActualJobTitle))
                missMatchResult = "Expected JobeTitle :" + JobeTitle + " Actual :" + ActualJobTitle + "\n";

            if (!TelPhone.Equals(ActualTeleNum))
                missMatchResult = "Expected TelPhone :" + TelPhone + " Actual :" + ActualTeleNum + "\n";

            if (!emailAddress.Equals(ActualEmailAdd))
                missMatchResult = "Expected emailAddress :" + emailAddress + " Actual :" + ActualEmailAdd + "\n";
            */
            return missMatchResult;
        }

        public string VerifyDateValidations(ExcelUtil excel, string validationType)
        {

            string[] fieldNames = { "Spring half term holidays", "Easter holidays", "Summer half term holidays", "Next year Accademic Spring half term holidays", " Next year AccademicEaster holidays", " Next year Accademic Summer half term holidays" };
            string[] StartDates = { "SpringHalfTermHolidaysStartDate", "EasterHolidaysStartDate", "SummerHalfTtermHolidaysStartDate", "NextYearSpringHalfTermHolidaysStartDate", "NextYearEasterHolidaysStartDate", "NextYearSummerHalfTtermHolidaysStartDate" };
            string[] EndDates = { "SpringHalfTermHolidaysEndtDate", "EasterHolidaysEndDate", "SummerHalfTtermHolidaysEndDate", "NextYearSpringHalfTermHolidaysEndtDate", "NextYearEasterHolidaysEndDate", "NextYearSummerHalfTtermHolidaysEndDate" };
            string errorList = "";

            SelectHolidadyNextAcademicYear(true);
            int k = 1;
            for (int i = 0; i < 6; i++)
            {             

                comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.StartDates[i], excel.GetDataFromExcel(StartDates[i]));
                comFunc.SelectDateFromDatePicker(confirmHolidayDatesPage.EndDates[i], excel.GetDataFromExcel(EndDates[i]));

                if (validationType.Equals("Warning"))

                    errorList = errorList + CheckDateWarnings(k, fieldNames[i]);
                else
                    errorList = errorList + CheckDateValidation(k, fieldNames[i]);

                try
                {
                    for (int m = i >= 3 ? m = i + 3 : m = i; m <= k; m++)
                        seleniumFunc.WaitAndClickOnElement(confirmHolidayDatesPage.ClearDates[m]);
                }
                catch (Exception e) {
                    log.Info(e.Message);
                }

               k=i==2?k+4:k+2;

            }

            return errorList;

        }

        public string CheckDateValidation(int SectionNumber, string holidaySectionName)
        {
            string error = "";

            var stepDec = "Check " + holidaySectionName + " start date and  end date Validation.";
            VerifyIsTrue(seleniumFunc.IsElementDisplayed(confirmHolidayDatesPage.DatesValidatetionMsg[SectionNumber]), stepDec);

          //  if (!seleniumFunc.IsElementDisplayed(confirmHolidayDatesPage.DatesValidatetionMsg[SectionNumber]))
           //     error = holidaySectionName + ": Start date and  end date Validation is not proper. \n";

            return error;
        }

        public string CheckDateWarnings(int SectionNumber, string holidaySectionName)
        {
            string error = "";
            Thread.Sleep(2000);

            var stepDec = "Check " + holidaySectionName + " start date and  end date warning Message.";
            VerifyIsTrue(seleniumFunc.IsElementDisplayed(confirmHolidayDatesPage.DatesWarrningMsg[SectionNumber]), stepDec);
            //if (!seleniumFunc.IsElementDisplayed(confirmHolidayDatesPage.DatesWarrningMsg[SectionNumber]))
              //  error = holidaySectionName + ": Warning Message is not displayed. \n";

            return error;
        }

        public void SubmitForm()
        {
            seleniumFunc.WaitAndClickOnElement(confirmHolidayDatesPage.SubmitBtn);
            Thread.Sleep(2000);
        }




    }
}
