using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;
using STA__Automation.Pages.Portal;

namespace STA__Automation.BussinessLib
{
    class PupilCheatingLib:BaseTestClass
    {

        public static SeleniumCommFunctions seleniumFunc;

        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public MyActivityPage myActivityPage;
        public PupilCheatingPage pupilCheatingPage;
    
        const string WholeCohort = "Whole cohort";
        const string PartialCohort = "Partial cohort";
        const string IndividualPupile = "Individual pupil";

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
            pupilCheatingPage = new PupilCheatingPage(driver);
            myActivityPage = new MyActivityPage(driver);
        
        }

        /// <summary>
        /// Method to login to portal and navigate to MyActivity-> Available Activity -> Titme Table Variation Application
        /// </summary>
        /// <param name="userName"> userName</param>
        /// <param name="password">passWord</param>
        public void LoginAndNavigatPupilCheatingForm(string userName, string password)
        {

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.NotificationOfPupilCheatingLink);

        }


        public void CheckContactDetailsFiledsValue(string firstName, string lastName, string JobeTitle, string TelPhone, string emailAddress)
        {
            string ActualfirstName = pupilCheatingPage.ContactFirstName.GetAttribute("value");
            string ActualLastName = pupilCheatingPage.ContactLastName.GetAttribute("value");
            string ActualJobTitle = pupilCheatingPage.JobTitle.GetAttribute("value");
            string ActualTeleNum = pupilCheatingPage.TelephoneNumber.GetAttribute("value");
            string ActualEmailAdd = pupilCheatingPage.EmailAddress.GetAttribute("value");

            seleniumFunc.ScrollElementInView(pupilCheatingPage.JobTitle);
            VerifyIsEquals(firstName, ActualfirstName, "Check Contact FirstName");
            VerifyIsEquals(lastName, ActualLastName, "Check Contact lastName");
            VerifyIsEquals(JobeTitle, ActualJobTitle, "Check Contact JobeTitle");
            VerifyIsEquals(TelPhone, ActualTeleNum, "Check Contact TelPhone");
            VerifyIsEquals(emailAddress, ActualEmailAdd, "Check Contact emailAddress");

        }

        public void FillForm(string pupilName, string typeOfActionReq,string testPaper, string[] NoQMarkedRemoved) {

            seleniumFunc.SelectValueFromAutoCompliteDropDown(pupilCheatingPage.PupilSelectionDropDwns, pupilCheatingPage.AutoCompletDropDwnOptions, pupilName);

            if (typeOfActionReq.Equals("Annul the result for the test paper"))
            {
                seleniumFunc.WaitAndClickOnElement(pupilCheatingPage.TypeOfActionReqRadioBtns[0]);
            }
            else if (typeOfActionReq.Equals("Remove only the marks gained from specific questions")) {
                seleniumFunc.WaitAndClickOnElement(pupilCheatingPage.TypeOfActionReqRadioBtns[1]);

                for (int i = 0; i < NoQMarkedRemoved.Length; i++)
                {
                    seleniumFunc.WaitAndEnterText(pupilCheatingPage.NoQMarkedRemoveTextBoxes[i], NoQMarkedRemoved[i]);
                    if(i < NoQMarkedRemoved.Length-1)
                    seleniumFunc.WaitAndClickOnElement(pupilCheatingPage.AddQuestionBtn);
                }
            }
            if(testPaper!=null)
            seleniumFunc.SelectValueFromAutoCompliteDropDown(pupilCheatingPage.TestDropDwn, pupilCheatingPage.AutoCompletDropDwnOptions, testPaper);

            comFunc.NaviagteToNextPage();

        }

    }
}
