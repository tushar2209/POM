using NUnit.Framework;
using OpenQA.Selenium;
using STA.Utilities.ExcelReader;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;
using STA__Automation.Pages.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.BussinessLib
{
    class MaintainingLALib : BaseTestClass
    {
        public static MaintainingLAPage maintainingLA;
        public static SeleniumCommFunctions seleniumFunc;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;
        public static ExcelUtil excelUtil;

        public void InitialisePageObjects()
        {
            maintainingLA = new MaintainingLAPage(driver);
            myActivityPage = new MyActivityPage(driver);

        }

        /**
        * Metod to set up pre condition for test case.
        **/
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

        public void LoginAndNavigatToForm(string userName, string password)
        {

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.MantainLASelection);
        }


        public void OpenMantainLASelection() {

            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.MantainLASelection);
        }


        public void SelectLA(String LAName)
        {
            seleniumFunc.WaitAndEnterText(maintainingLA.LADropdown, "");
            seleniumFunc.SelectValueFromAutoCompliteDropDown(maintainingLA.LADropdown, maintainingLA.LADrpdownOptions,LAName);

        }

        public string GetSelectedLAName() {
           return seleniumFunc.GetAttributeValue(maintainingLA.LADropdown,"value");
        }



        public String DatabaseValidation()
        {
            var AppRef = comFunc.GetReferanceCode();

            String household = DatabaseUtil.GetResultsFromDB("select households.organisationname from households where householdid in" +
            "(select householdid from applications where applicationtype = 'LAS' and applicationid in" +
                "(select applicationid from applicationreferences where referencename = 'LASID' and ReferenceValue in" +
                "(select value from applicationattributes where attributename = 'MODERATING LA' and casereference = '" + AppRef + "'" + ")" +
                ")" +
            ")");
            Console.WriteLine("output " + household);
            return household;
        }


        public void CheckContactDetailsFiledsValue(string firstName, string lastName, string JobeTitle, string TelPhone, string emailAddress)
        {

            string ActualfirstName = maintainingLA.ContactFirstName.GetAttribute("value");
            string ActualLastName = maintainingLA.ContactLastName.GetAttribute("value");
            string ActualJobTitle = maintainingLA.JobTitle.GetAttribute("value");
            string ActualTeleNum = maintainingLA.TelephoneNumber.GetAttribute("value");
            string ActualEmailAdd = maintainingLA.EmailAddress.GetAttribute("value");

            seleniumFunc.ScrollElementInView(maintainingLA.TelephoneNumber);
            VerifyIsEquals(firstName, ActualfirstName, "Check Contact FirstName");
            VerifyIsEquals(lastName, ActualLastName, "Check Contact lastName");
            VerifyIsEquals(JobeTitle, ActualJobTitle, "Check Contact JobeTitle");
            VerifyIsEquals(TelPhone, ActualTeleNum, "Check Contact TelPhone");
            VerifyIsEquals(emailAddress, ActualEmailAdd, "Check Contact emailAddress");

        }


        public void CheckMadetoryFields(string ManDetoryFields) {

            seleniumFunc.WaitAndEnterText(maintainingLA.LADropdown,"");
            comFunc.NaviagteToNextPage();

            // Verify Review page Fileds
               VerifyIsEquals("", comFunc.CheckMandetoryFieldsMsgOnReviewAndSubmitPage(1, ManDetoryFields), "Check mandetory filed list on Review and SubmitPage");
        }

    }
    
}
