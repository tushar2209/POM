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
    class SpecialConsiderationLib : BaseTestClass
    {
        public static SeleniumCommFunctions seleniumFunc;

        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public MyActivityPage myActivityPage;
        public SpecialConsiderationPage specialConsiderationPage;
        public MoreInfromationCommPage moreInforPage;


        const string WholeCohort = "Whole cohort";
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
            specialConsiderationPage = new SpecialConsiderationPage(driver);
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
           // comFunc. LogoutCurrentUserAndLoginAnotherUserToPortal(appUrl, userName, password);

            log.Info("Navigate to From");

            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.ApplicationForSpecialConsiderationLink);

        }
       
        /// <summary>
        /// Method to fill Application form of Special Consideration
        /// </summary>
        /// <param name="pupilType"></param>
        /// <param name="PupilName"></param>
        /// <param name="subjects"></param>
        /// <param name="QuestionsAns"></param>
        /// <param name="ReasonForSC"></param>
        /// <param name="dateofIncident"></param>
        /// <param name="RelationToPupil"></param>
        /// <param name="BrifExpalination"></param>
        public void fillApplication(string pupilType, string PupilName, bool[] subjects, bool[] QuestionsAns, string ReasonForSC, string dateofIncident, string RelationToPupil, string BrifExpalination)
        {

            // Slect Pupli detail Type
            if (pupilType.Equals(WholeCohort))
                seleniumFunc.WaitAndClickOnElement(specialConsiderationPage.WholeCohortRadioBtn);
            else if (pupilType.Equals(IndividualPupile))
            {
                seleniumFunc.WaitAndClickOnElement(specialConsiderationPage.IndividualPupilRadioBtn);

                // select Date 
                seleniumFunc.SelectValueFromAutoCompliteDropDown(specialConsiderationPage.PupilDropDwn, specialConsiderationPage.PupilDropDwnOptions, PupilName);
            }
            try
            {
                // Select Subjects
                for (int i = 0; i < subjects.Length; i++)
                {
                    if (subjects[i])
                        seleniumFunc.WaitAndClickOnElement(specialConsiderationPage.SubjectsCheckBoxes[i]);
                }
            }
            catch (Exception e) { }

            // Select Questions ansewer
            for (int i = 0; i < QuestionsAns.Length; i++)
            {
                if (QuestionsAns[i])
                    seleniumFunc.WaitAndClickOnElement(specialConsiderationPage.QuestionsYesRadioBtns[i]);
                else
                    seleniumFunc.WaitAndClickOnElement(specialConsiderationPage.QuestionsNoRadioBtns[i]);
            }

            // Selese Reason fro Special Consideration
            seleniumFunc.SelectValueFromDropDwn(specialConsiderationPage.ReasonForSpecialConsiderDropDwn, ReasonForSC);

            // Select Date
            comFunc.SelectDateFromDatePicker(specialConsiderationPage.DateOfIncidentTextbox, dateofIncident);

            // enter Relation to pupil
            if (ReasonForSC.Equals("Criteria 1 : Death of family member or close friend of pupil"))
            {
                seleniumFunc.SelectValueFromDropDwn(specialConsiderationPage.RelationshipToPupilDropDwn, RelationToPupil);
            }
            else
            {
                seleniumFunc.WaitAndEnterText(specialConsiderationPage.RelationshipToPupilNATextbox, RelationToPupil);
            }

            seleniumFunc.WaitAndEnterText(specialConsiderationPage.BrieflyExplainTextArea, BrifExpalination);

           // comFunc.NaviagteToNextPage();

        }

        public void CheckReviewFromFieldValues(ExcelUtil excelUtil, string formType, bool[] Subjects,bool[] QuestionsAns)
        {

            string testCaseName = new StackTrace().GetFrame(1).GetMethod().Name;

            if (formType.Equals("MoreInfo"))
                checkReviewComment(excelUtil.GetDataFromExcel(testCaseName, "Decision1Reason"));

            CheckContactDetailsFiledsValue(excelUtil.GetDataFromExcel(testCaseName, "UserFirstName"), excelUtil.GetDataFromExcel(testCaseName, "UserLastName"), excelUtil.GetDataFromExcel(testCaseName, "JobTitle"), excelUtil.GetDataFromExcel(testCaseName, "UserTeleNumber"), excelUtil.GetDataFromExcel(testCaseName, "UserEmailAddress"));

            CheckSelectedPupilDetailType(excelUtil.GetDataFromExcel(testCaseName, "PupilDetailType"), excelUtil.GetDataFromExcel(testCaseName, "PupilName"));

            CheckSelectedSubjects(Subjects);
            checkedSelctedQuestionsAns(QuestionsAns);

            string actualDate = comFunc.GetReqFromatDate(seleniumFunc.GetAttributeValue( specialConsiderationPage.DateOfIncidentTextbox,"value"), "dd-MMM-yyyy");
            VerifyIsEquals(excelUtil.GetDataFromExcel(testCaseName, "DateOfincident"), actualDate, "Check selected Date of incidenet value");

            if (formType.Equals("MoreInfo"))
                VerifyIsEquals(excelUtil.GetDataFromExcel(testCaseName, "ReasonForSpecialConsideration"), seleniumFunc.GetSelectedTextFromDropdown(specialConsiderationPage.MoreInfoFormReasonForRequest), "Check selected Reaspon for Special Consideration field value");
            else
                VerifyIsEquals(excelUtil.GetDataFromExcel(testCaseName, "ReasonForSpecialConsideration"), seleniumFunc.GetSelectedTextFromDropdown(specialConsiderationPage.ReasonForSpecialConsiderDropDwn), "Check selected Reaspon for Special Consideration field value");

            checkSelectedResonForSpecialConsideration(excelUtil.GetDataFromExcel(testCaseName, "ReasonForSpecialConsideration"), excelUtil.GetDataFromExcel(testCaseName, "RelationshipToPupil"), formType);

            if (formType.Equals("MoreInfo"))
                VerifyIsEquals(excelUtil.GetDataFromExcel(testCaseName, "BrieflyExplain"), specialConsiderationPage.MoreInfoFormBrieflyExplainTextArea.GetAttribute("value"), "Check Briefly Explain field value more info form");
            else
                VerifyIsEquals(excelUtil.GetDataFromExcel(testCaseName, "BrieflyExplain"), specialConsiderationPage.ReviewFormBrieflyExplainTextArea.GetAttribute("value"), "Check Briefly Explain field value");

        }

        private void checkSelectedResonForSpecialConsideration(string expectedReason, string expectedRelationsToPupil, string formType)
        {
            if (expectedReason.Equals("Criteria 1 : Death of family member or close friend of pupil"))
            {
                VerifyIsEquals(expectedRelationsToPupil, seleniumFunc.GetSelectedTextFromDropdown(specialConsiderationPage.RelationshipToPupilDropDwn), "Check selected reason for special consideration");
            }
            else if (formType.Equals("MoreInfo"))
            {

                VerifyIsEquals(expectedRelationsToPupil, seleniumFunc.GetAttributeValue( specialConsiderationPage.MoreInfoFormRelationshipToPupil,"value"), "Check selected reason for special consideration");
            }
            else
            {
                VerifyIsEquals(expectedRelationsToPupil, seleniumFunc.GetAttributeValue( specialConsiderationPage.ReviewFormRelationshipToPupilTextbox,"value"), "Check selected reason for special consideration");

            }
        }

        public void CheckContactDetailsFiledsValue(string firstName, string lastName, string JobeTitle, string TelPhone, string emailAddress)
        {
            seleniumFunc.WaitForPageToLoad();
            /*string ActualfirstName = specialConsiderationPage.ContactFirstName.GetAttribute("value");
            string ActualLastName = specialConsiderationPage.ContactLastName.GetAttribute("value");
            string ActualJobTitle = specialConsiderationPage.JobTitle.GetAttribute("value");
            string ActualTeleNum = specialConsiderationPage.TelephoneNumber.GetAttribute("value");
            string ActualEmailAdd = specialConsiderationPage.EmailAddress.GetAttribute("value");
            */

           
            VerifyIsEquals(firstName, seleniumFunc.GetAttributeValue(specialConsiderationPage.ContactFirstName,"value"), "Check Contact FirstName");
            VerifyIsEquals(lastName, seleniumFunc.GetAttributeValue(specialConsiderationPage.ContactLastName, "value"), "Check Contact lastName");
            VerifyIsEquals(JobeTitle, seleniumFunc.GetAttributeValue(specialConsiderationPage.JobTitle, "value"), "Check Contact JobeTitle");
            VerifyIsEquals(TelPhone, seleniumFunc.GetAttributeValue(specialConsiderationPage.TelephoneNumber, "value"), "Check Contact TelPhone");
            VerifyIsEquals(emailAddress, seleniumFunc.GetAttributeValue(specialConsiderationPage.EmailAddress, "value"), "Check Contact emailAddress");
        }

        public void CheckSelectedPupilDetailType(string pupilDetailType, string pupilName)
        {
            string isSelected = "";

            if (pupilDetailType.Equals(WholeCohort))
            {
                isSelected = seleniumFunc.GetAttributeValue( specialConsiderationPage.WholeCohortRadioBtn,"checked");
            }
            else if (pupilDetailType.Equals(IndividualPupile))
            {
                isSelected = seleniumFunc.GetAttributeValue(specialConsiderationPage.IndividualPupilRadioBtn,"checked");
            }
            if (isSelected != null)
            {
                VerifyIsTrue(isSelected.Equals("true"), "Check  selected " + pupilDetailType + " radio button is checked?");

            }
            if (!pupilDetailType.Equals(WholeCohort))

                VerifyIsEquals(pupilName, specialConsiderationPage.ReviewFromPupilTextbox.GetAttribute("value"), "Check selected pupil name");
        }

        public void CheckSelectedSubjects(bool[] subjects)
        {
            string errorMsg = "";
            int subjectNo = 1;
            for (int i = 0; i < subjects.Length; i++)
            {
                if (subjects[i])
                {
                    if (!specialConsiderationPage.SubjectsCheckBoxes[i].Selected)
                        errorMsg = "Subject " + subjectNo + " CheckBox is unchecked.\n";
                }
                subjectNo++;
            }

            seleniumFunc.ScrollElementInView(specialConsiderationPage.SubjectsCheckBoxes[subjects.Length - 1]);
            VerifyIsEquals("", errorMsg, "Check selected subject checkboxes");

        }

        public void checkedSelctedQuestionsAns(bool[] QuestionsAns) {
            int count = 1;
            // Select Questions ansewer
            for (int i = 0; i < QuestionsAns.Length; i++)
            {
                try
                {
                    if (QuestionsAns[i])
                        VerifyIsEquals("true", seleniumFunc.GetAttributeValue(specialConsiderationPage.QuestionsYesRadioBtns[i], "checked"), "Check Question" + count + "Yes radio button should selected.");
                    else

                        VerifyIsEquals("true", seleniumFunc.GetAttributeValue(specialConsiderationPage.QuestionsNoRadioBtns[i], "checked"), "Check Question" + count + "No radio button should selected.");
                }
             
                catch (Exception e) { }
                count++;
            }


        }

        public void checkReviewComment(string furtherInfrmation)
        {
            if(seleniumFunc.IsElementDisplayed(moreInforPage.FurtherInfRequiredTextArea))
            VerifyIsEquals(furtherInfrmation, moreInforPage.FurtherInfRequiredTextArea.GetAttribute("value"), "Check further Infromation textarea value");
            else if (seleniumFunc.IsElementDisplayed(moreInforPage.FurtherInfRequiredTextArea))
             VerifyIsEquals(furtherInfrmation, moreInforPage.FurtherInfRequiredTextArea1.GetAttribute("value"), "Check further Infromation textarea value");

            
        }

        public void CheckReReviewAddtionalInfromation(string addtionalInfromation, string uploadedDocName)
        {

            VerifyIsEquals(addtionalInfromation, comFunc.GetReReviewFormAddtionalInfoValue()[0], "Check review from Addtional infromation field value");

            VerifyIsTrue(comFunc.GetReReviewFormDownLoadBtnCount() == 1, "Check review from donwloaded doc count");

        }

        public void CheckMaintainedHistory(int count ,string formName,string[] historyDates , string[] historReasonFrorDecistion, string[] historyAddtionalInfro) {
            int historyCount = 1;
            for (int i = 0; i < count; i++) {

                VerifyIsEquals(historyDates[i], seleniumFunc.GetAttributeValue(specialConsiderationPage.HistoryOfDateAndTimeList[i],"value"), "Check "+ formName + " form History "+ historyCount + " Date and time field value");

                VerifyIsEquals(historReasonFrorDecistion[i], seleniumFunc.GetAttributeValue(specialConsiderationPage.HistoryOfReasonForDecisionList[i], "value"), "Check " + formName + "form History " + historyCount + " Reason for decision field value");

                if(historyAddtionalInfro[i]!="")
                VerifyIsEquals(historyAddtionalInfro[i], seleniumFunc.GetAttributeValue(specialConsiderationPage.HistoryOfAdditionalInformationList[i], "value"), "Check " + formName + "form History " + historyCount + " Additional information field value");
                
                historyCount++;
            }
            
        }

        public string GetReviewCommentDateAndTime(int number) {
            string value = "";
            try
            {
                value =seleniumFunc.GetAttributeValue(specialConsiderationPage.HistoryOfDateAndTimeList[number], "value");
            }
            catch (Exception e) { }
            return value;
        }

    }
}
