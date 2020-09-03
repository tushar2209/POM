using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using STA.Utilities.ExcelReader;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;
using STA__Automation.Pages.Portal;

namespace STA__Automation.BussinessLib
{
    class EarlyOpeningApplicationLib : BaseTestClass
    {

        public static SeleniumCommFunctions seleniumFunc;

        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public MyActivityPage myActivityPage;
        public EarlyOpeningApplicationPage earlyOpeningAppPage;
        public MoreInfromationCommPage moreInforPage;


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
            earlyOpeningAppPage = new EarlyOpeningApplicationPage(driver);
            myActivityPage = new MyActivityPage(driver);
            moreInforPage = new MoreInfromationCommPage(driver);


        }

        /// <summary>
        /// Method to login to portal and navigate to MyActivity-> Available Activity -> Titme Table Variation Application
        /// </summary>
        /// <param name="userName"> userName</param>
        /// <param name="password">passWord</param>
        public void LoginAndNavigatEarlyOpeningAppForm(string userName, string password)
        {

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.EarlyOpeningAppLink);

        }


        public void SelectPupilDetails(string pupilType, string pupilName)
        {
            seleniumFunc.ScrollElementInView(earlyOpeningAppPage.IndividualPupilRadioBtn);
            if (pupilType != null)
                if (pupilType.Equals(WholeCohort))
                {
                    seleniumFunc.WaitAndClickOnElement(earlyOpeningAppPage.WholeCohortRadioBtn);
                }
                else if (pupilType.Equals(PartialCohort))
                {
                    seleniumFunc.WaitAndClickOnElement(earlyOpeningAppPage.PartialCohortRadioBtn);
                    seleniumFunc.WaitForPageToLoad();
                }
                else if (pupilType.Equals(IndividualPupile))
                {
                    seleniumFunc.WaitAndClickOnElement(earlyOpeningAppPage.IndividualPupilRadioBtn);
                }

            seleniumFunc.WaitForPageToLoad();

            if (pupilName != null)
            {
                seleniumFunc.ScrollElementInView(earlyOpeningAppPage.SubjectEngGrammmerCheckBox);

                if (pupilType.Equals(IndividualPupile))
                {
                    seleniumFunc.WaitForElementToBeVisible(earlyOpeningAppPage.PupilSelectionDropDwns[0]);
                    seleniumFunc.SelectValueFromAutoCompliteDropDown(earlyOpeningAppPage.PupilSelectionDropDwns[0], earlyOpeningAppPage.PupilDropDwnOptions, pupilName);
                }
                else if (pupilType.Equals(PartialCohort))
                {
                    seleniumFunc.WaitForElementToBeVisible(earlyOpeningAppPage.PupilSelectionDropDwns[1]);
                    seleniumFunc.SelectValueFromAutoCompliteDropDown(earlyOpeningAppPage.PupilSelectionDropDwns[1], earlyOpeningAppPage.PupilDropDwnOptions, pupilName);
                }
            }

        }

        public void SelectSubjects(bool subject1, bool subject2, bool subject3)
        {

            if (subject1)
                seleniumFunc.WaitAndClickOnElement(earlyOpeningAppPage.SubjectEngGrammmerCheckBox);
            if (subject2)
                seleniumFunc.WaitAndClickOnElement(earlyOpeningAppPage.SubjectEngReaddingCheckBox);
            if (subject3)
                seleniumFunc.WaitAndClickOnElement(earlyOpeningAppPage.SubjectMathCheckBox);

        }

        public void SelectSecurityTearms(int num)
        {

            for (int i = 0; i <= num; i++)
                seleniumFunc.WaitAndClickOnElement(earlyOpeningAppPage.SecurityTearmsCheckBoxlist[i]);

        }

        public void FillEarlyOpeningApplication(string PupilDetailType, string PupilName, bool subject1, bool subject2, bool subject3, string ReasonForEarlyOpening, string NumberOfSchoolDays, string MoreDetailsEarlyOpening)
        {

            SelectPupilDetails(PupilDetailType, PupilName);

            SelectSubjects(subject1, subject2, subject3);

            seleniumFunc.SelectValueFromDropDwn(earlyOpeningAppPage.ReasonForEarlyOpeningDropdwn, ReasonForEarlyOpening);

            seleniumFunc.SelectValueFromDropDwn(earlyOpeningAppPage.NumberOfSchoolDaysDropdwn, NumberOfSchoolDays);

            seleniumFunc.WaitAndEnterText(earlyOpeningAppPage.MoreDetailsOfEarlyOpeningTextbox, MoreDetailsEarlyOpening);

            SelectSecurityTearms(3);


        }


        public void CheckContactDetailsFiledsValue(string fromType, string firstName, string lastName, string JobeTitle, string TelPhone, string emailAddress)
        {
            seleniumFunc.WaitForPageToLoad();
            string missMatchResult = "";
            string ActualfirstName = earlyOpeningAppPage.ContactFirstName.GetAttribute("value");
            string ActualLastName = earlyOpeningAppPage.ContactLastName.GetAttribute("value");
            string ActualJobTitle = earlyOpeningAppPage.JobTitle.GetAttribute("value");
            string ActualTeleNum = earlyOpeningAppPage.TelephoneNumber.GetAttribute("value");
            string ActualEmailAdd = earlyOpeningAppPage.EmailAddress.GetAttribute("value");

            seleniumFunc.ScrollElementInView(earlyOpeningAppPage.JobTitle);
            VerifyIsEquals(firstName, ActualfirstName, "Check Contact FirstName on " + fromType + "From");
            VerifyIsEquals(lastName, ActualLastName, "Check Contact lastName on " + fromType + "From");
            VerifyIsEquals(JobeTitle, ActualJobTitle, "Check Contact JobeTitle on " + fromType + "From");
            VerifyIsEquals(TelPhone, ActualTeleNum, "Check Contact TelPhone on " + fromType + "From");
            VerifyIsEquals(emailAddress, ActualEmailAdd, "Check Contact emailAddress on " + fromType + "From");

        }


        public void CheckReviewFromFieldValues(ExcelUtil excelUtil, string fromType)
        {

            string testCaseName = new StackTrace().GetFrame(1).GetMethod().Name;
            if (fromType.Equals("MoreInfo"))
                checkReviewComment(excelUtil.GetDataFromExcel(testCaseName, "Decision1Reason"));

            CheckContactDetailsFiledsValue(fromType, excelUtil.GetDataFromExcel(testCaseName, "UserFirstName"), excelUtil.GetDataFromExcel(testCaseName, "UserLastName"), excelUtil.GetDataFromExcel(testCaseName, "JobTitle"), excelUtil.GetDataFromExcel(testCaseName, "UserTeleNumber"), excelUtil.GetDataFromExcel(testCaseName, "UserEmailAddress"));
            CheckSelectedPupilDetailType(excelUtil.GetDataFromExcel(testCaseName, "PupilDetailType"), excelUtil.GetDataFromExcel(testCaseName, "PupilName"));
            CheckSelectedSubjects(true, true, false);

            CheckSelectedDropDwnOption(excelUtil.GetDataFromExcel(testCaseName, "ReasonForEarlyOpening"), earlyOpeningAppPage.ReviewFromReasonForEarlyOpeningTextbox, "Reason From Early Oprning");
            CheckSelectedDropDwnOption(excelUtil.GetDataFromExcel(testCaseName, "NumberOfSchoolDays"), earlyOpeningAppPage.ReviewFromNumberOfSchoolDaysTextbox, "Number of School Days");
            seleniumFunc.ScrollElementInView(earlyOpeningAppPage.SubmitBtn);
            CheckSelectedSecurityTearms();


        }



        public void CheckSelectedPupilDetailType(string pupilDetailType, string pupilName)
        {

            string isSelected = "";

            if (pupilDetailType.Equals(WholeCohort))
            {
                isSelected = earlyOpeningAppPage.WholeCohortRadioBtn.GetAttribute("checked");
            }
            else if (pupilDetailType.Equals(PartialCohort))
            {
                isSelected = earlyOpeningAppPage.PartialCohortRadioBtn.GetAttribute("checked");
            }
            else if (pupilDetailType.Equals(IndividualPupile))
            {
                isSelected = earlyOpeningAppPage.IndividualPupilRadioBtn.GetAttribute("checked"); ;
            }
            if (isSelected != null)
            {

                VerifyIsTrue(isSelected.Equals("true"), "Check  selected " + pupilDetailType + " radio button is checked?");

                //   if (!isSelected.Equals("true"))
                //      errorMsg = pupilDetailType + " radio button is unselected.\n";

            }
            if (!pupilDetailType.Equals(WholeCohort))
                CheckSelectedPupilName(pupilName, pupilDetailType);

        }

        public void CheckSelectedPupilName(string pupilName, string pupilDetailType)
        {


            string actualValue = "";
            if (pupilDetailType.Equals(PartialCohort))
                actualValue = seleniumFunc.GetAttributeValue(earlyOpeningAppPage.ReviewFromPartialCohortPupilNameTextbox, "value");
            else
                actualValue = seleniumFunc.GetAttributeValue(earlyOpeningAppPage.ReviewFromIndividualPupilNameTextbox, "value");

            VerifyIsEquals(pupilName, actualValue, "Check selected pupil name");

            //if (!pupilName.Equals(earlyOpeningAppPage.ReviewFromPupilNameTextbox.GetAttribute("value")))
            //  errorMsg = "Expected: " + pupilName + " Actual : " + earlyOpeningAppPage.ReviewFromPupilNameTextbox.GetAttribute("value") + " \n";



        }

        public void CheckSelectedSubjects(bool subject1, bool subject2, bool subject3)
        {
            string errorMsg = "";

            if (subject1)
            {
                if (!earlyOpeningAppPage.SubjectEngGrammmerCheckBox.Selected)
                    errorMsg = "Subject Eng Grammmer CheckBox is unchecked.\n";
            }
            if (subject2)
            {
                if (!earlyOpeningAppPage.SubjectEngReaddingCheckBox.Selected)
                    errorMsg = errorMsg + "Subject Eng Readding CheckBox is unchecked.\n";
            }

            if (subject3)
            {
                if (!earlyOpeningAppPage.SubjectMathCheckBox.Selected)
                    errorMsg = errorMsg + "Subject Math CheckBox is unchecked.\n";
            }

            seleniumFunc.ScrollElementInView(earlyOpeningAppPage.SubjectMathCheckBox);
            VerifyIsEquals("", errorMsg, "Check selected subject checkboxes");

        }

        public void CheckSelectedDropDwnOption(string value, IWebElement element, string dropdwnName)
        {
            VerifyIsEquals(value, element.GetAttribute("value"), "Check selected " + dropdwnName);

        }

        public void CheckSelectedSecurityTearms()
        {
            string errorMsg = "";
            for (int i = 3; i <= 5; i++)
            {
                int k = i - 2;

                if (!earlyOpeningAppPage.ReviewFromSecurityTramsCheckBoxes[i].Selected)
                    errorMsg = "Security teams checbox -" + k + " is not checked \n";
            }

            VerifyIsEquals("", errorMsg, "Check Security teams checbox is checked");

        }

        public void checkReviewComment(string furtherInfrmation)
        {
            if (seleniumFunc.IsElementDisplayed(moreInforPage.FurtherInfRequiredTextArea))
                VerifyIsEquals(furtherInfrmation, moreInforPage.FurtherInfRequiredTextArea.GetAttribute("value"), "Check further Infromation textarea value");
            else if (seleniumFunc.IsElementDisplayed(moreInforPage.FurtherInfRequiredTextArea))
                VerifyIsEquals(furtherInfrmation, moreInforPage.FurtherInfRequiredTextArea1.GetAttribute("value"), "Check further Infromation textarea value");

        }

    }
}
