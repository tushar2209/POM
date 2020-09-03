using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;
namespace STA__Automation.BussinessLib
{
    class CreateMarkerLib : BaseTestClass
    {



        public static SeleniumCommFunctions seleniumFunc;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static CreateMarkerPage markercreate;







        public void SetUpPreCondition()
        {
            driver = GetDriver();
            seleniumFunc = new SeleniumCommFunctions();
            comFunc = new CommonFunctions();

            log.Info("Test method setup started");
            InitialisePageObjects();



        }



        /// <summary>
        /// Method to initialise  page objects
        /// </summary>
        public void InitialisePageObjects()
        {
            markercreate = new CreateMarkerPage(driver);

        }



        public void AddPersonalDetails(string empcode, string gender,string title,string forename,string surname,string addressLine1,string addressLine2,string addressLine3,string addressLine4,string postcode,string country,string materialstatus,string Day,string month,string year)
        {
            seleniumFunc.WaitAndEnterText(markercreate.EmployeeCode, empcode);
            seleniumFunc.WaitAndEnterText(markercreate.Gender, gender);
          //  seleniumFunc.WaitAndEnterText(markercreate.TitlePersonal, title);
           // seleniumFunc.WaitAndEnterText(markercreate.ForeName, forename);
          //  seleniumFunc.WaitAndEnterText(markercreate.SurName, surname);

            seleniumFunc.WaitAndEnterText(markercreate.AdderessLine1, addressLine1);
            seleniumFunc.WaitAndEnterText(markercreate.AdderessLine2, addressLine2);
            seleniumFunc.WaitAndEnterText(markercreate.AdderessLine3, addressLine3);
            seleniumFunc.WaitAndEnterText(markercreate.AdderessLine4, addressLine4);
            seleniumFunc.WaitAndEnterText(markercreate.PostCode, postcode);
            seleniumFunc.WaitAndEnterText(markercreate.Country, country);
            seleniumFunc.WaitAndEnterText(markercreate.MaterialStatus, materialstatus);
            seleniumFunc.SelectValueFromDropDwn(markercreate.DayDatePicker, Day);
            seleniumFunc.SelectValueFromDropDwn(markercreate.MonthDatePicker, month);
            seleniumFunc.SelectValueFromDropDwn(markercreate.YearDatePicker, year);
            comFunc.NaviagteToNextPage();

        }

        public void AddMarkerDetails(string title, string markerfamilyname, string markerothername, string schoolid, string mobilenumber, string landlinenumber,string emailaddress,string prefferdmoode, string contractstate, string contarctstaechangedate,string markerrole,string markersubject,string markerpreviousrole,string capitarole,string capitasubject )
        {
            //comFunc.NaviagteToNextPage();
            seleniumFunc.WaitForEmentToBeClickable(markercreate.Title);
            seleniumFunc.SelectValueFromDropDwnUsingValue(markercreate.Title, title);
            seleniumFunc.WaitAndEnterText(markercreate.Markerfamilyname, markerfamilyname);
            seleniumFunc.WaitAndEnterText(markercreate.Markerothername, markerothername);
            seleniumFunc.WaitAndEnterText(markercreate.SchoolID, schoolid);
            seleniumFunc.WaitAndEnterText(markercreate.Mobilenumber, mobilenumber);
            seleniumFunc.WaitAndEnterText(markercreate.Landlinenumber, landlinenumber);
            seleniumFunc.WaitAndEnterText(markercreate.Emailaddress, emailaddress);
           seleniumFunc.SelectValueFromDropDwnUsingValue(markercreate.preferdmodeofconatct, prefferdmoode);
            seleniumFunc.SelectValueFromDropDwnUsingValue(markercreate.ContarctState, contractstate);
            seleniumFunc.WaitForEmentToBeClickable(markercreate.Contractstatechangedate);
            comFunc.SelectDateFromDatePicker(markercreate.Contractstatechangedate, contarctstaechangedate);
            seleniumFunc.WaitForEmentToBeClickable(markercreate.MarkerRole);
            seleniumFunc.SelectValueFromDropDwn(markercreate.MarkerRole, markerrole);
            seleniumFunc.WaitForEmentToBeClickable(markercreate.MarkerSubject);
            seleniumFunc.SelectValueFromDropDwnUsingValue(markercreate.MarkerSubject, markersubject);
            // seleniumFunc.SelectValueFromDropDwn(markercreate.PreviosRole, markerpreviousrole);
            //  seleniumFunc.SelectValueFromDropDwn(markercreate.Capitarole, capitarole);
            // seleniumFunc.SelectValueFromDropDwn(markercreate.Capitasubject, capitasubject);
            seleniumFunc.ClickOnElementViaJavaScript(markercreate.TPTMarkingNo);
            seleniumFunc.WaitAndClickOnElement(markercreate.NewMarkeryes);





            comFunc.NaviagteToNextPage();

        }



        public void EmploymentDetails(string empstatus, string leaver,string branch)
        {
          //  comFunc.NaviagteToNextPage();
            seleniumFunc.EnterTextWithoutClear(markercreate.Employmentstatus,empstatus);
            seleniumFunc.EnterTextWithoutClear(markercreate.Leaver,leaver);
            seleniumFunc.EnterTextWithoutClear(markercreate.Branch,branch);
           comFunc.NaviagteToNextPage();
        }


        public void PayrollDetails(string Branch, string BankAccountName, string BankAccountNo,string BankName,string SortCode,string PaasportNumber,string NINumber)
        {
            //comFunc.NaviagteToNextPage();
            seleniumFunc.EnterTextWithoutClear(markercreate.Branch, Branch);
            seleniumFunc.EnterTextWithoutClear(markercreate.BankAccountName, BankAccountName);
            seleniumFunc.EnterTextWithoutClear(markercreate.BankAccountNo, BankAccountNo);
            seleniumFunc.EnterTextWithoutClear(markercreate.BankName, BankName);
            seleniumFunc.EnterTextWithoutClear(markercreate.SortCode, SortCode);
            seleniumFunc.EnterTextWithoutClear(markercreate.PaasportNumber, PaasportNumber);
            seleniumFunc.EnterTextWithoutClear(markercreate.NINumber, NINumber);
          


            // comFunc.NaviagteToNextPage();
        }












    }
}