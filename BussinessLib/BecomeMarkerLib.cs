using OpenQA.Selenium;
using STA.Utilities.ExcelReader;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.BussinessLib
{
    class BecomeMarkerLib : BaseTestClass
    {

        public static SeleniumCommFunctions seleniumFunc;
        
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
    
        public static BecomeMarkerPage becomeMarkerPage;

        /// <summary>
        /// Metod to set up pre condition for test case.
        /// </summary>
        /// <param name="appURL"></param>
        public void SetUpPreCondition(string appURL)
        {
            driver = GetDriver();
            seleniumFunc = new SeleniumCommFunctions();
          
            InitialisePageObjects();
            comFunc = new CommonFunctions();
            comFunc.LaunchApplication(appURL);
        }


        public void InitialisePageObjects()
        {
            becomeMarkerPage = new BecomeMarkerPage(driver);
        }

        /// <summary>
        /// Method to check Madetory fields
        /// </summary>
        public void CheckMandetoryFields(string expectedMsg)
        {

            comFunc.SubmitForm();

            VerifyIsEquals(expectedMsg,seleniumFunc.GetText(becomeMarkerPage.FirstNameErrorMsg), "Check FirstName should Madetory filed.");
            VerifyIsEquals(expectedMsg, seleniumFunc.GetText(becomeMarkerPage.LastNameErrorMsg), "Check Last name should Madetory filed.");

            for (int i = 0; i < 3; i++) {
                int count = i + 1;
                VerifyIsEquals(expectedMsg, seleniumFunc.GetText(becomeMarkerPage.AddressLineErrorMsg[i]), "Check Address Line "+ count + " should Madetory fileds.");
            }

            VerifyIsEquals(expectedMsg, seleniumFunc.GetText(becomeMarkerPage.TownErrorMsg), "Check Town/City should Madetory filed.");


            VerifyIsEquals(expectedMsg, seleniumFunc.GetText(becomeMarkerPage.PostcodeErrorMsg), "Check Postcode should Madetory filed.");


            VerifyIsEquals(expectedMsg, seleniumFunc.GetText(becomeMarkerPage.RegionErrorMsg), "Check Region drop dwon should Madetory filed.");


            string[] ContactNumber = { "Home telephone number", "Mobile number", "Work telephone number", "National Insurance number" };
            for (int j = 0; j < 3; j++)
            {
                VerifyIsEquals(expectedMsg, seleniumFunc.GetText(becomeMarkerPage.AddressLineErrorMsg[j]), "Check " + ContactNumber[j] + " should Madetory filed.");
            }

            VerifyIsEquals(expectedMsg, seleniumFunc.GetText(becomeMarkerPage.EmailAddressErrorMsg), "Check Email addressy should Madetory filed.");

        }

        public void FillForm(string testcaseName, ExcelUtil excel) {

            seleniumFunc.SelectValueFromDropDwn(becomeMarkerPage.TitleDropdwon, excel.GetDataFromExcel(testcaseName, "Title"));
            seleniumFunc.WaitAndEnterText(becomeMarkerPage.FirstName, excel.GetDataFromExcel(testcaseName, "FirstName"));
            seleniumFunc.WaitAndEnterText(becomeMarkerPage.LastName, excel.GetDataFromExcel(testcaseName, "LastName"));
            string[] address = excel.GetDataFromExcel(testcaseName, "Address").Split(',');
            for (int i = 0; i < 3; i++) {
                seleniumFunc.WaitAndEnterText(becomeMarkerPage.AddressLines[i], address[i]);
            }
            seleniumFunc.WaitAndEnterText(becomeMarkerPage.TownAndCity, excel.GetDataFromExcel(testcaseName, "City"));
            seleniumFunc.WaitAndEnterText(becomeMarkerPage.Postcode, excel.GetDataFromExcel(testcaseName, "Postcode"));

            seleniumFunc.SelectValueFromDropDwn(becomeMarkerPage.RegionDropDwon, excel.GetDataFromExcel(testcaseName, "Region"));

            for (int j = 0; j < 3; j=j+2)
            {
                seleniumFunc.WaitAndEnterText(becomeMarkerPage.ContactNumber[j], excel.GetDataFromExcel(testcaseName, "ContactNumber"));
            }

            seleniumFunc.WaitAndEnterText(becomeMarkerPage.ContactNumber[1], excel.GetDataFromExcel(testcaseName, "MobileNo"));

            seleniumFunc.WaitAndEnterText(becomeMarkerPage.EmailAddress, excel.GetDataFromExcel(testcaseName, "EmailAddress"));
        

             seleniumFunc.WaitAndEnterText(becomeMarkerPage.ContactNumber[3], excel.GetDataFromExcel(testcaseName, "NationalInsuranceNo"));
        }


    }

    
}
