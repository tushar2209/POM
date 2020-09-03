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

namespace STA__Automation.BussinessLib
{
    class ManagePupilRegistrationLib : BaseTestClass
    {
        public static SeleniumCommFunctions seleniumFunc;

        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public MyActivityPage myActivityPage;
        public ManagePupilRegistrationPage managePupil;

        const string Male = "Male";
        const string Female = "Female";
        public void InitialisePageObjects()
        {
            managePupil = new ManagePupilRegistrationPage(driver);
            myActivityPage = new MyActivityPage(driver);

        }

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

        public void LoginAndNavigatToManagePupilForm(string userName, string password)
        {

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.ManagePupilRegistrationFormLink);

        }

        public void AddPupil(String PupilUPN, String PupilFN, String PupilMN, String PupilLN,String DOB, String pupilGender)
        {
            log.Info("Adding New Pupil");
            seleniumFunc.WaitAndClickOnElement(managePupil.AddPupilBtn);
            seleniumFunc.WaitForPageToLoad();
            seleniumFunc.WaitAndEnterText(managePupil.AddPupilUPN, PupilUPN);
            seleniumFunc.WaitAndEnterText(managePupil.PupilFName,PupilFN);
            seleniumFunc.WaitAndEnterText(managePupil.PupilMName, PupilMN);
            seleniumFunc.WaitAndEnterText(managePupil.PupilLName, PupilLN);
            SelectGender(pupilGender);
            comFunc.SelectDateFromDatePicker(managePupil.PupilDOB, DOB);


        }

        public void VerifyAndSubmit()
        {
            seleniumFunc.WaitAndClickOnElement(managePupil.VerifyBtn);
            seleniumFunc.WaitForPageToLoad();
            seleniumFunc.WaitAndClickOnElement(managePupil.SubmitBtn);
            
        }

        public void SelectGender(String PupilGender)
        {
            log.Info("selecting gender of New Pupil");
            if (PupilGender != null)
                if (PupilGender.Equals(Male))
                {
                    seleniumFunc.WaitAndClickOnElement(managePupil.PupilGenderMale);
                }
                else if (PupilGender.Equals(Female))
                {
                    seleniumFunc.WaitAndClickOnElement(managePupil.PupilGenderFemale);
                    seleniumFunc.WaitForPageToLoad();
                }
            seleniumFunc.WaitForPageToLoad();
        }

    }
}
