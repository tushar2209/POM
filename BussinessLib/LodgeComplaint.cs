using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;
using STA__Automation.Pages.Portal;

namespace STA__Automation.BussinessLib
{
  public   class LodgeComplaint: BaseTestClass
    {


        public static SeleniumCommFunctions seleniumFunc;
        public static LodgeComplaintPage lodgeComplaint;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;


        public void SetUpPreCondition(string appURL)
        {
            driver = GetDriver();
            seleniumFunc = new SeleniumCommFunctions();
            comFunc = new CommonFunctions();

            log.Info("Test method setup started");
            InitialisePageObjects();


            log.Info("launch application");
            comFunc.LaunchApplication(appURL);

        }

        public void InitialisePageObjects()
        {
            lodgeComplaint = new LodgeComplaintPage(driver);
            myActivityPage = new MyActivityPage(driver);


        }


        public void LoginAndNavigatToLodgeComplaint(string userName, string password)
        {
            comFunc.SignOutUser();

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.ComplaintLodgement);

        }


        public void SelectEnquiryType(string enquirytype)
        {
            seleniumFunc.SelectValueFromDropDwnUsingValue(lodgeComplaint.EnquiryTypedrpdown, enquirytype);


        }


        public void SelectCategoryOfComplaints(string complaintcategory)
        {

            seleniumFunc.SelectValueFromDropDwnUsingValue(lodgeComplaint.ComplaintReleated, complaintcategory);


        }
        public void SelectAppealCategory(string appeal)
        {

            seleniumFunc.SelectValueFromDropDwn(lodgeComplaint.SelectAppeal, appeal);


        }

            //public void SelectAppeal()
            //{

            //    seleniumFunc.Click(lodgeComplaint.Selectappeal);


            //}



            public void SelectNatureOfComplaints(string message)
        {

           // seleniumFunc.WaitForEmentToBeClickable(lodgeComplaint.NatureOfQuery);
            seleniumFunc.EnterTextWithoutClear(lodgeComplaint.NatureOfQuery, message);


        }
        public void SelectNatureOfQuery(string message )
        {

            // seleniumFunc.WaitForEmentToBeClickable(lodgeComplaint.NatureOfQuery);
            seleniumFunc.EnterTextWithoutClear(lodgeComplaint.NatureOfQuery2, message);


        }
        public void SelectNatureOfAppeal(string message)
        {

            // seleniumFunc.WaitForEmentToBeClickable(lodgeComplaint.NatureOfQuery);
            seleniumFunc.EnterTextWithoutClear(lodgeComplaint.NaturofAppeal , message);


        }


        public void SelectName(string name)
        {

            seleniumFunc.EnterTextWithoutClear(lodgeComplaint.Name, name);


        }

        public void SelectEmailAddress(string email)
        {

            seleniumFunc.EnterTextWithoutClear(lodgeComplaint.Emailaddress, email);


        }




    }
}
