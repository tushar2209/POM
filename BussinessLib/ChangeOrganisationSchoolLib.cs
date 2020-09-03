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
    class ChangeOrganisationSchoolLib : BaseTestClass
    {
        public static ChangeOrganisationSchoolPage chOrgSch;
        public static SeleniumCommFunctions seleniumFunc;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;
        public static ExcelUtil excelUtil;


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
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.ChangeOrgDetailsLink);
        }
        public void InitialisePageObjects()
        {
            chOrgSch = new ChangeOrganisationSchoolPage(driver);
            myActivityPage = new MyActivityPage(driver);

        }

        public void StartApplication()
        {
            seleniumFunc.SwitchToFrame("repair-frame");
            seleniumFunc.WaitForPageToLoad();
        }

        public String Validate_Form_Title()
        {
            try
            {
                seleniumFunc.WaitForElementToBeVisible(chOrgSch.FormTitle);
                String pageTitle = chOrgSch.FormTitle.Text;
                Console.WriteLine("uiTitle : " + pageTitle);
                return pageTitle;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Assert.Fail("Test Case Failed in method: Validate_Form_Title");
                return null;
            }
        }

        public string GetOrganisationName()
        {
            return chOrgSch.SchoolNameTextbox.GetAttribute("value");
        }

        public string GetOrganisationAddress()
        {
            return chOrgSch.SchoolAddress.GetAttribute("value");
        }

        public string GetOrganisationEmail()
        {
            return chOrgSch.EmailAddress.GetAttribute("value");
        }
        
        public void UpdateSchoolDetails(String Telephone, String EmailAdd)
        {
            seleniumFunc.EnterText(chOrgSch.TelephoneNumber, Telephone);
            seleniumFunc.EnterText(chOrgSch.EmailAddress, EmailAdd);
                   
        }
        public void CheckContactDetailsFiledsValue(string firstName, string lastName, string JobeTitle, string TelPhone, string emailAddress)
        {

            string ActualfirstName = chOrgSch.ContactFirstName.GetAttribute("value");
            string ActualLastName = chOrgSch.ContactLastName.GetAttribute("value");
            string ActualJobTitle = chOrgSch.JobTitle.GetAttribute("value");
            string ActualTeleNum = chOrgSch.UserTelephoneNumber.GetAttribute("value");
            string ActualEmailAdd = chOrgSch.UserEmailAddress.GetAttribute("value");

            seleniumFunc.ScrollElementInView(chOrgSch.TelephoneNumber);
            VerifyIsEquals(firstName, ActualfirstName, "Check Contact FirstName");
            VerifyIsEquals(lastName, ActualLastName, "Check Contact lastName");
            VerifyIsEquals(JobeTitle, ActualJobTitle, "Check Contact JobeTitle");
            VerifyIsEquals(TelPhone, ActualTeleNum, "Check Contact TelPhone");
            VerifyIsEquals(emailAddress, ActualEmailAdd, "Check Contact emailAddress");

        }


        public void CheckOrgDetails(string orgName, string orgAddress, string orgPincode, string orgDFENumber) {

        
            VerifyIsEquals(orgName, seleniumFunc.GetAttributeValue( chOrgSch.SchoolNameTextbox,"value"), "Check School Name");
            VerifyIsEquals(orgAddress, seleniumFunc.GetAttributeValue(chOrgSch.SchoolAddress, "value"), "Check School address");
            VerifyIsEquals(orgPincode, seleniumFunc.GetAttributeValue(chOrgSch.SchoolPostcode, "value"), "Check School pincode");
            VerifyIsContains(orgDFENumber, seleniumFunc.GetText(chOrgSch.SchoolDFENumber), "Check School DFE number");
            
        }


        public void CheckMadetoryFields(string errorMsg) {

            seleniumFunc.WaitAndEnterText(chOrgSch.TelephoneNumber,"" );
            seleniumFunc.WaitAndEnterText(chOrgSch.EmailAddress, "");
            comFunc.SubmitForm();
            VerifyIsEquals(errorMsg, seleniumFunc.GetText(chOrgSch.TelephoneNumberErrorMsg),"Check org telephone number should mandetory");

            VerifyIsEquals(errorMsg, seleniumFunc.GetText(chOrgSch.EmailAddressErrorMsg), "Check org email address should mandetory");


        }

        public Dictionary<String, String> FetchDetailsFromDB(String AppRef)
        {
            String HouseHoldID = DatabaseUtil.GetResultsFromDB("select householdid from [dbo].[Applications] where ApplicationReference like'" + AppRef + "'");
            String OrgPhone = DatabaseUtil.GetResultsFromDB("select OrganisationPhone from[dbo].[Households] where householdid in (select householdid from [dbo].[Applications] where ApplicationReference like'" + AppRef + "')");

            // String OrgPhone = GetDBConnection("select OrganisationPhone from [dbo].[Households] where householdid='" + HouseHoldID + "'");
            Console.WriteLine("Organisation phone no =" + OrgPhone);

            String OrgEmail = DatabaseUtil.GetResultsFromDB("select OrganisationEmail from [dbo].[Households] where householdid='" + HouseHoldID + "'");
            Console.WriteLine("Organisation EmailAdd =" + OrgEmail);
            var dic1 = new Dictionary<String, String>
            {
                { "Organsiation Phone", OrgPhone },
                { "Org Email ", OrgEmail }
            };

            return dic1;
        }

        public bool ValidateDetailsChange(String Telephone, String EmailAdd)
        {
            var reference = comFunc.GetReferanceCode();
            var dict = FetchDetailsFromDB(reference);
            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + "-" + item.Value);
            }
            Console.WriteLine(dict.Any(x => x.Value == excelUtil.GetDataFromExcel("OrgTelephone")));
            Console.WriteLine(dict.Any(x => x.Value == excelUtil.GetDataFromExcel("OrgEmail")));
            //excelobj.GetColumnValueUsingTestCaseName(tcName, "OrgEmail");
            List<String> inputDetail = new List<string>();
            inputDetail.Add(excelUtil.GetDataFromExcel("OrgTelephone"));
            inputDetail.Add(excelUtil.GetDataFromExcel("OrgEmail"));

            var res = inputDetail.All(i => dict.Any(d => d.Value.Contains(i)));
            return res;
            //Console.WriteLine("list op" + res);
            //return dict.Any(x => x.Value == excelobj.GetColumnValueUsingTestCaseName(tcName, "OrgTelephone"))
            //    && dict.Any(x => x.Value == excelobj.GetColumnValueUsingTestCaseName(tcName, "OrgEmail"));
        }
    }
}
