using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    class TimeTableVariationLib : BaseTestClass
    {

        public static SeleniumCommFunctions seleniumFunc;
        public static TimeTableVariationPage timeTableVarPage;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;

        const string WholeCohort = "Whole cohort";
        const string PartialCohort = "Partial cohort";
        const string IndividualPupile = "Individual pupil";


        const string Illness = "Illness";
        const string Funeral = "Funeral";
        const string Religious = "Religious or cultural festival";
        const string Appointment = "Appointment that cannot be rearranged(please specify)";
        const string other = "Other (please specify)";


        /// <summary>
        ///  Method to  set up pre condition for test case.
        /// </summary>
        /// <param name="appURL">URL Application U</param>
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

        /// <summary>
        /// Method to initialise  page objects
        /// </summary>
        public void InitialisePageObjects()
        {
            timeTableVarPage = new TimeTableVariationPage(driver);
            myActivityPage = new MyActivityPage(driver);


        }

        /// <summary>
        /// Method to login to portal and navigate to MyActivity-> Available Activity -> timetable  
        /// </summary>
        /// <param name="userName"> userName</param>
        /// <param name="password">passWord</param>
        public void LoginAndNavigatToTimeTableVariationForm(string userName, string password)
        {
            comFunc.SignOutUser();

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.TimeTableVariationAppLink);

        }





        /// <summary>
        /// Method to select pupli detail type with subject, date  and time
        /// </summary>
        /// <param name="pupilType">Indivdula/ WholeCohort / Partial Cohort</param>
        /// <param name="subject1"></param>
        /// <param name="Date1"></param>
        /// <param name="time1"></param>
        public void SelectPupilAndTestSubjectDetails(string pupilType, String pupilName, string subject1, string Date1, string time1)
        {
            seleniumFunc.ScrollElementInView(timeTableVarPage.IndividualPupilRadioBtn);
            if (pupilType != null)
                if (pupilType.Equals(WholeCohort))
                {
                    seleniumFunc.WaitAndClickOnElement(timeTableVarPage.WholeCohortRadioBtn);
                }
                else if (pupilType.Equals(PartialCohort))
                {
                    seleniumFunc.WaitAndClickOnElement(timeTableVarPage.PartialCohortRadioBtn);
                    seleniumFunc.WaitForPageToLoad();
                }
                else if (pupilType.Equals(IndividualPupile))
                {
                    seleniumFunc.WaitAndClickOnElement(timeTableVarPage.IndividualPupilRadioBtn);
                }

            seleniumFunc.WaitForElementToBeVisible(timeTableVarPage.SubjectDropDwns[0]);

            if (pupilName != null)
            {
                if (pupilType.Equals(IndividualPupile))
                {
                    seleniumFunc.WaitForElementToBeVisible(timeTableVarPage.PupilSelectionDropDwns[0]);
                    seleniumFunc.SelectValueFromAutoCompliteDropDown(timeTableVarPage.PupilSelectionDropDwns[0], timeTableVarPage.PupilDropDwnOptions, pupilName);
                }
                else if (pupilType.Equals(PartialCohort))
                {
                    seleniumFunc.WaitForElementToBeVisible(timeTableVarPage.PupilSelectionDropDwns[1]);
                    seleniumFunc.WaitForPageToLoad();
                    seleniumFunc.SelectValueFromAutoCompliteDropDown(timeTableVarPage.PupilSelectionDropDwns[1], timeTableVarPage.PupilDropDwnOptions, pupilName);
                }
            }

            SelectSubjectDateAndTime(subject1, Date1, time1);

        }

        public void SelectSubjectDateAndTime(string subject1, string Date1, string time1) {

            if (subject1 != null)
                seleniumFunc.SelectValueFromDropDwn(timeTableVarPage.SubjectDropDwns[0], subject1);

            if (Date1 != null)
            {
               // seleniumFunc.WaitAndClickOnElement(timeTableVarPage.DateScheduledToClearBtn[0]);
                comFunc.SelectDateFromDatePicker(timeTableVarPage.DateScheduledToInputBoxes[0], Date1);
            }

            if (time1 != null)
                seleniumFunc.SelectValueFromDropDwn(timeTableVarPage.TimeDropdwns[0], time1);
        }

        /// <summary>
        /// Method to add more subject 
        /// </summary>
        /// <param name="subject2"></param>
        /// <param name="Date2"></param>
        /// <param name="time2"></param>
        public void AddMoreSubjectPapers(string subject2, string Date2, string time2)
        {

            seleniumFunc.ClickOnElement(timeTableVarPage.AddSubjectPaperBtn);
            seleniumFunc.WaitForPageToLoad();

            SelectSecondSubjectDateAndTime(subject2, Date2, time2);
        }

        public void SelectSecondSubjectDateAndTime(string subject2, string Date2, string time2) {

            seleniumFunc.WaitForElementToBeVisible(timeTableVarPage.SubjectDropDwns[1]);

            if (subject2 != null)
                seleniumFunc.SelectValueFromDropDwn(timeTableVarPage.SubjectDropDwns[1], subject2);

            if (Date2 != null)
            {
               // seleniumFunc.WaitAndClickOnElement(timeTableVarPage.DateScheduledToClearBtn[1]);
                comFunc.SelectDateFromDatePicker(timeTableVarPage.DateScheduledToInputBoxes[1], Date2);
            }

            if (time2 != null)
                seleniumFunc.SelectValueFromDropDwn(timeTableVarPage.TimeDropdwns[1], time2);
        }

        /// <summary>
        /// Method to select Reason section A and enter note 
        /// </summary>
        /// <param name="reasonName">Illness/Funeral/Other ..</param>
        /// <param name="note"></param>
        public void SelectReasonSectionA(string reasonName, string note)
        {
            if (reasonName.Equals(Illness))
            {
                seleniumFunc.ClickOnElement(timeTableVarPage.IllnessRadioBtn);

                // Verify addtional question
                verifyAdditionalQuestionOnIllnessSelection();

               seleniumFunc.WaitAndClickOnElement(timeTableVarPage.Illness_PupleFitYesRadioBtn);
            }
            else if (reasonName.Equals(Funeral))
            {
                seleniumFunc.ClickOnElement(timeTableVarPage.FuneralRadioBtn);
            }
            else if (reasonName.Equals(Religious))
            {
                seleniumFunc.ClickOnElement(timeTableVarPage.ReligiousRadioBtn);
            }
            else if (reasonName.Equals(Appointment))
            {
                seleniumFunc.ClickOnElement(timeTableVarPage.AppointmensRadioBtn);
            }
            else if (reasonName.Equals(other))
            {
                seleniumFunc.ClickOnElement(timeTableVarPage.OtherRadioBtn);
            }

            if (note != null)
            {
                seleniumFunc.EnterText(timeTableVarPage.NoteTextArea, note);
            }
        }

        public void verifyAdditionalQuestionOnIllnessSelection()
        {
            seleniumFunc.ScrollElementInView(timeTableVarPage.SectionBQ1YesRadioBtn);
            VerifyIsTrue(seleniumFunc.IsElementDisplayed(timeTableVarPage.Illness_PupleFitYesRadioBtn), "Check 'Has the pupil(s) returned to school and is fit to take the test?' question should displayed on Illness selection");
            seleniumFunc.WaitAndClickOnElement(timeTableVarPage.Illness_PupleFitNoRadioBtn);
            seleniumFunc.WaitForPageToLoad();
            VerifyIsTrue(seleniumFunc.IsElementDisplayed(timeTableVarPage.Illness_PupleFitNoRadioBtnErrorMsg), "Check Error Mssage should display on 'Has the pupil(s) returned to school and is fit to take the test?' No radio btn selected.");
        }

        /// <summary>
        /// Method to add More Pupils
        /// </summary>
        /// <param name="pupilName"></param>
        public void AddMorePupils(string pupilName)
        {
            if (pupilName != null)
            {
                seleniumFunc.ClickOnElement(timeTableVarPage.AddPupilBtn);

                seleniumFunc.WaitForEmentToBeClickable(timeTableVarPage.PupilSelectionDropDwns[1]);

                seleniumFunc.SelectValueFromAutoCompliteDropDown(timeTableVarPage.PartailCohortPupilSelectionDropDwn1, timeTableVarPage.PupilDropDwnOptions, pupilName);

            }
        }

        /// <summary>
        /// Method to select section B reasons
        /// </summary>
        /// <param name="q1">True/False (ie- Yes/No)</param>
        /// <param name="q2">True/False (ie- Yes/No)</param>
        /// <param name="q3">True/False (ie- Yes/No)</param>
        /// <param name="q4">True/False (ie- Yes/No)</param>
        public void SelectSectionBReason(bool q1, bool q2, bool q3, bool q4)
        {
            if (q1) seleniumFunc.ClickOnElement(timeTableVarPage.SectionBQ1YesRadioBtn);
            else seleniumFunc.ClickOnElement(timeTableVarPage.SectionBQ1NoRadioBtn);

            if (q2) seleniumFunc.ClickOnElement(timeTableVarPage.SectionBQ2YesRadioBtn);
            else seleniumFunc.ClickOnElement(timeTableVarPage.SectionBQ2NoRadioBtn);

            if (q3) seleniumFunc.ClickOnElement(timeTableVarPage.SectionBQ3YesRadioBtn);
            else seleniumFunc.ClickOnElement(timeTableVarPage.SectionBQ3NoRadioBtn);

            if (q4) seleniumFunc.ClickOnElement(timeTableVarPage.SectionBQ4YesRadioBtn);
            else seleniumFunc.ClickOnElement(timeTableVarPage.SectionBQ4NoRadioBtn);

        }

        /// <summary>
        /// Method to fill application page1 and navigate to next page
        /// </summary>
        /// <param name="pupilType"></param>
        /// <param name="pupilName"></param>
        /// <param name="subject1"></param>
        /// <param name="Date1"></param>
        /// <param name="time1"></param>

        public void FillApplicationPage1(string pupilType, String pupilName, string subject1, string Date1, string time1)
        {

            SelectPupilAndTestSubjectDetails(pupilType, pupilName, subject1, Date1, time1);
            comFunc.NaviagteToNextPage();
        }

        /// <summary>
        /// Method to fill Reasean sections and naviagteto Next page
        /// </summary>
        /// <param name="SectionAReason"></param>
        /// <param name="Note"></param>
        /// <param name="SectionBQ1"></param>
        /// <param name="SectionBQ2"></param>
        /// <param name="SectionBQ3"></param>
        /// <param name="SectionBQ4"></param>
        public void FillReasonSections(string SectionAReason, string Note, bool[] SectionBQAns)
        {
            SelectReasonSectionA(SectionAReason, Note);
            SelectSectionBReason(SectionBQAns[0], SectionBQAns[1], SectionBQAns[2], SectionBQAns[3]);
            comFunc.NaviagteToNextPage();
        }

        public void CheckContactDetailsFiledsValue(string formName,string firstName, string lastName,  string JobeTitle, string TelPhone, string emailAddress)
        {
           
             VerifyIsEquals(firstName, seleniumFunc.GetAttributeValue(timeTableVarPage.ContactFirstName, "value"), "Check Contact FirstName on "+ formName + "form");
            VerifyIsEquals(lastName, seleniumFunc.GetAttributeValue(timeTableVarPage.ContactLastName, "value"), "Check Contact lastName on " + formName + "form");
            VerifyIsEquals(JobeTitle, seleniumFunc.GetAttributeValue(timeTableVarPage.JobTitle, "value"), "Check Contact JobeTitle on " + formName + "form");
            VerifyIsEquals(TelPhone, seleniumFunc.GetAttributeValue(timeTableVarPage.TelephoneNumber, "value"), "Check Contact TelPhone on " + formName + "form");
            VerifyIsEquals(emailAddress, seleniumFunc.GetAttributeValue(timeTableVarPage.EmailAddress, "value"), "Check Contact emailAddress on " + formName + "form");

        }


        public void CheckReviewFromFieldValues(ExcelUtil excelUtil, string fromType,bool[] sectionBAns)
        {
            try
            {
                string testCaseName = new StackTrace().GetFrame(1).GetMethod().Name;
                string[] subjects = { excelUtil.GetDataFromExcel(testCaseName, "Subject1"), excelUtil.GetDataFromExcel(testCaseName, "Subject2") };
                string[] dates = { excelUtil.GetDataFromExcel(testCaseName, "Date1"), excelUtil.GetDataFromExcel(testCaseName, "Date2") };
                string[] times = { excelUtil.GetDataFromExcel(testCaseName, "Time1"), excelUtil.GetDataFromExcel(testCaseName, "Time2") };
                string[] pupils = { excelUtil.GetDataFromExcel(testCaseName, "PupilName1"), excelUtil.GetDataFromExcel(testCaseName, "PupilName2") };

                if (fromType.Equals("MoreInfo"))
                    checkReviewComment(excelUtil.GetDataFromExcel(testCaseName, "Decision1Reason"));

                CheckContactDetailsFiledsValue(fromType,excelUtil.GetDataFromExcel(testCaseName, "UserFirstName"), excelUtil.GetDataFromExcel(testCaseName, "UserLastName"), excelUtil.GetDataFromExcel(testCaseName, "JobTitle"), excelUtil.GetDataFromExcel(testCaseName, "UserTeleNumber"),  excelUtil.GetDataFromExcel(testCaseName, "UserEmailAddress"));
                CheckSelectedPupilDetailType(excelUtil.GetDataFromExcel(testCaseName, "PupilType"), pupils);

                CheckSelectedSubjects(subjects, dates, times);
                comFunc.NaviagteToNextPage();
                CheckReasonSectionA(excelUtil.GetDataFromExcel(testCaseName, "SectionAReason"), excelUtil.GetDataFromExcel(testCaseName, "Note"));
                CheckReasonSectionB(sectionBAns);
            }
            catch (Exception e) { }


        }

        public void checkReviewComment(string AddtionalInformation) {
     
            VerifyIsEquals(AddtionalInformation, seleniumFunc.GetAttributeValue(timeTableVarPage.MoreInfoFurtherInfoReqTextarea,"value"), "Check More info - Further information field value ");
           
        }


        public void CheckSelectedPupilDetailType(string pupilDetailType, string[] pupilName)
        {
          
            string isSelected = "";
            seleniumFunc.ScrollElementInView(timeTableVarPage.WholeCohortRadioBtn);
            if (pupilDetailType.Equals(WholeCohort))
            {
                
                isSelected = seleniumFunc.GetAttributeValue(timeTableVarPage.WholeCohortRadioBtn,"checked");
            }
            else if (pupilDetailType.Equals(PartialCohort))
            {
                isSelected = seleniumFunc.GetAttributeValue(timeTableVarPage.PartialCohortRadioBtn,"checked");
            }
            else if (pupilDetailType.Equals(IndividualPupile))
            {
                isSelected = seleniumFunc.GetAttributeValue(timeTableVarPage.IndividualPupilRadioBtn,"checked");
            }
            if (isSelected != null)
            {
                VerifyIsEquals("true", isSelected, "Check " + pupilDetailType + " radio button is unselected.");

            }
            if (!pupilDetailType.Equals(WholeCohort))
                try
                {
                    for (int i = 0; i < pupilName.Count(); i++)
                    {
                        if (pupilDetailType.Equals(IndividualPupile) && i == 1)
                            break;

                        VerifyIsEquals(pupilName[i], seleniumFunc.GetAttributeValue(timeTableVarPage.ReviewFromPupilNameTextbox[i],"value"), "Check Selcted Pupil Name");
                    }
                }
                catch (Exception e) { }
           
        }


        public void CheckSelectedSubjects(string[] subjects, string[] dates, string[] times)
        {
           
                for (int i = 0; i < subjects.Count(); i++)
                {
                    if (subjects[i] != "" && dates[i] != "" && times[i] != "")
                    {
                       
                        VerifyIsEquals(subjects[i], seleniumFunc.GetAttributeValue(timeTableVarPage.ReviewFormSubjectTextboxes[i],"value"), "Check selected Subject " + i + 1 + " field value.");
                        string actualDate = comFunc.GetReqFromatDate(timeTableVarPage.ReviewFromDateSchduledToTextBoxex[i].GetAttribute("value"), "dd-MMM-yyyy");
                        VerifyIsEquals(dates[i], actualDate, "Check selected Date " + i + 1 + " field value.");
                        VerifyIsEquals(times[i], seleniumFunc.GetAttributeValue(timeTableVarPage.ReviewFromTimeTextBoxes[i],"value"), "Check selected time " + i + 1 + " field value.");

                    }
                }
          
           


        }

        public void CheckReasonSectionA(string reasonName, string note)
        {
            string isSelected = "";

            if (reasonName.Equals(Illness))
            {
                isSelected = seleniumFunc.GetAttributeValue(timeTableVarPage.IllnessRadioBtn, "checked");

                VerifyIsEquals("true", seleniumFunc.GetAttributeValue(timeTableVarPage.Illness_PupleFitYesRadioBtn, "checked"), "Check 'Has the pupil(s) returned to school and is fit to take the test?' Yes radio button shuold selected");

            }

            else if (reasonName.Equals(Funeral))
                isSelected = seleniumFunc.GetAttributeValue(timeTableVarPage.FuneralRadioBtn, "checked");
            else if (reasonName.Equals(Religious))
                isSelected = seleniumFunc.GetAttributeValue(timeTableVarPage.ReligiousRadioBtn, "checked");
            else if (reasonName.Equals(Appointment))
                isSelected = seleniumFunc.GetAttributeValue(timeTableVarPage.AppointmensRadioBtn, "checked");
            else if (reasonName.Equals(other))
                isSelected = seleniumFunc.GetAttributeValue(timeTableVarPage.OtherRadioBtn, "checked");

            VerifyIsEquals("true", isSelected, "Check " + reasonName + " radio button should selected.");
            VerifyIsEquals(note, seleniumFunc.GetAttributeValue(timeTableVarPage.NoteTextArea,"value"), "Check note textarea field value.");

        }

        public void CheckReasonSectionB(bool[] sectionBQAns)
        {
            seleniumFunc.ScrollElementInView(timeTableVarPage.SectionBQ2YesRadioBtn);
            if (sectionBQAns[0])
            {
                VerifyIsEquals("true", seleniumFunc.GetAttributeValue(timeTableVarPage.SectionBQ1YesRadioBtn,"checked"), "Check SectionB Q1 Yes radio button should selected.");
            }
            else
            { VerifyIsEquals("true", seleniumFunc.GetAttributeValue(timeTableVarPage.SectionBQ1NoRadioBtn,"checked"), "Check SectionB Q1 No radio button should selected.");
            }

            if (sectionBQAns[1])
            {  
                VerifyIsEquals("true", seleniumFunc.GetAttributeValue(timeTableVarPage.SectionBQ2YesRadioBtn,"checked"), "Check SectionB Q2 Yes radio button should selected.");
            }
            else
            { 
                VerifyIsEquals("true", seleniumFunc.GetAttributeValue(timeTableVarPage.SectionBQ2NoRadioBtn,"checked"), "Check SectionB Q2 No radio button should selected.");
            }
            if (sectionBQAns[2])
            {
                VerifyIsEquals("true", seleniumFunc.GetAttributeValue(timeTableVarPage.SectionBQ3YesRadioBtn,"checked"), "Check SectionB Q3 Yes radio button should selected.");
            }
            else
            {
                VerifyIsEquals("true", seleniumFunc.GetAttributeValue(timeTableVarPage.SectionBQ3NoRadioBtn,"checked"), "Check SectionB Q3 No radio button should selected.");
             }
            if (sectionBQAns[3])
            {
                VerifyIsEquals("true", seleniumFunc.GetAttributeValue(timeTableVarPage.SectionBQ4YesRadioBtn,"checked"), "Check SectionB Q4 Yes radio button should selected.");
            }
            else
            {
                 VerifyIsEquals("true", seleniumFunc.GetAttributeValue(timeTableVarPage.SectionBQ4NoRadioBtn,"checked"), "Check SectionB Q4 No radio button should selected.");
            }

        }

        /// <summary>
        /// Method to select checkbox of field- I am the headteacher of the school, or I have been given the delegated authority by the headteacher
        /// to make this application
        /// </summary>
        public void SelectDelegatedAuthority()
        {
            seleniumFunc.WaitAndClickOnElement(timeTableVarPage.ReviewFromDelegatedAuthorityCheckBox);
            comFunc.NaviagteToNextPage();
        }

        public void CheckReReviewAddtionalInfromation( string addtionalInfromation, string uploadedDocName) {
            
            VerifyIsEquals(addtionalInfromation, comFunc.GetReReviewFormAddtionalInfoValue()[0], "Check review from Addtional infromation field value");

            VerifyIsTrue( comFunc.GetReReviewFormDownLoadBtnCount()==1, "Check review from donwloaded doc count");

        }


        public void CheckValidationMsgForSubjectDateAndTime(string expectedErrorMsg) {

            seleniumFunc.WaitAndClickOnElement(timeTableVarPage.VerifyBtn);
            seleniumFunc.WaitForPageToLoad();

            VerifyIsEquals(expectedErrorMsg, seleniumFunc.GetText(timeTableVarPage.SubjectDateTimeErrorMsg), "Check follwoing Error msg should displayed.<br>" + expectedErrorMsg);

        }


    }
}
