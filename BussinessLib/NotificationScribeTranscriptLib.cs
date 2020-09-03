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
    class NotificationScribeTranscriptLib : BaseTestClass
    {

        public static SeleniumCommFunctions seleniumFunc;
        public static NotificationScribeTranscriptPage notificationPage;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;

        const string Scribe = "Scribe";
        const string Transcript = "Transcript";
        const string WordProcess = "Word processor or other technical or electronic aid";
        const string EnglishPaper1 = "English grammar, punctuation and spelling Paper 1: questions";
        const string EnglishPaper2 = "English grammar, punctuation and spelling Paper 2: spelling";
        const string EnglishReading = "English reading";
        const string MathPaper1 = "Mathematics Paper 1: arithmetic";
        const string MathPaper2 = "Mathematics Paper 2: reasoning";
        const string MathPaper3 = "Mathematics Paper 3: reasoning";
        const string AllOfTheTest = "All of the test";
        const string PartOfTheTest = "Part of the test";
        const string BriefExplanation = "BriefExplanation";
        const string TickToConfirm1 = "TickToConfirm1";
        const string TickToConfirm2 = "TickToConfirm2";

          

        public void InitialisePageObjects()
        {
            notificationPage = new NotificationScribeTranscriptPage(driver);
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

        public void LoginAndNavigatToNotificationScribForm(string userName, string password)
        {

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.NotificationScribeTranscriptFromLink);

        }

        /**
         *  Method to Select Type of Notificationa and ente Name oof respective type.
         **/

        public void SelectTypeOfNotification(string typeOfNotification)
        {
            if (typeOfNotification.Equals(Scribe))
            {
                seleniumFunc.ClickOnElement(notificationPage.ScribeRadioBtn);
                
            }
            else if (typeOfNotification.Equals(Transcript))
            {
                seleniumFunc.ClickOnElement(notificationPage.TranscriptRadioBtn);
                
            }
            else if (typeOfNotification.Equals(WordProcess))
            {
                seleniumFunc.ClickOnElement(notificationPage.WordProcessorTechEleAidRadioBtn);
                
            }

        }

        public void EnterNameOfTypeOfNotificationForSubject(string typeOfNotification, int subjectNo, string nameOfNotificationType) {
            if (typeOfNotification.Equals(Scribe))
            {               
                seleniumFunc.WaitAndEnterText(notificationPage.NameOFScribeTextBox[subjectNo], nameOfNotificationType);
            }
            else if (typeOfNotification.Equals(Transcript))
            {
                
                seleniumFunc.WaitAndEnterText(notificationPage.NameOfTranscriberTextBox[subjectNo], nameOfNotificationType);
            }
            else if (typeOfNotification.Equals(WordProcess))
            {
                seleniumFunc.WaitAndEnterText(notificationPage.NameOFTypeOfAidTextBox[subjectNo], nameOfNotificationType);
            }
        }

        public void SelectPupilFromPupilDropDwn(string pupilName)
        {

            seleniumFunc.SelectValueFromAutoCompliteDropDown(notificationPage.PupilSelectionDropDwn, notificationPage.PupilSelectionDropDwnOption, pupilName);
        }
        /// <summary>
        /// Method to select Paper and It oprions
        /// </summary>
        /// <param name="PaperName"></param>
        /// <param name="PaperType"></param>
        public void SelectPapers(string PaperName, string PaperType ,string typeOfNotification , string nameOfNotificationType)
        {
            if (PaperName.Equals(EnglishPaper1))
            {
                seleniumFunc.WaitAndClickOnElement(notificationPage.EngPaper1PartOfTheTestCheckBox);
                EnterNameOfTypeOfNotificationForSubject(typeOfNotification, 0, nameOfNotificationType);
                if (PaperType.Equals(AllOfTheTest))
                {
                    seleniumFunc.WaitAndClickOnElement(notificationPage.EngPaper1AllOfTheTestCheckBox);
                }
                else if (PaperType.Equals(PartOfTheTest))
                {
                    seleniumFunc.WaitAndClickOnElement(notificationPage.EngPaper1PartOfTheTestCheckBox);
                }
            }
            else if (PaperName.Equals(EnglishPaper2))
            {
                seleniumFunc.WaitAndClickOnElement(notificationPage.EngPaper2PartOfTheTestCheckBox);
                EnterNameOfTypeOfNotificationForSubject(typeOfNotification, 1, nameOfNotificationType);
                if (PaperType.Equals(AllOfTheTest))
                {
                    seleniumFunc.WaitAndClickOnElement(notificationPage.EngPaper2AllOfTheTestCheckBox);
                }
                else if (PaperType.Equals(PartOfTheTest))
                {
                    seleniumFunc.WaitAndClickOnElement(notificationPage.EngPaper2PartOfTheTestCheckBox);
                }
            }
            else if (PaperName.Equals(EnglishReading))
            {
                seleniumFunc.WaitAndClickOnElement(notificationPage.EnglishRedingCheckBox);
                EnterNameOfTypeOfNotificationForSubject(typeOfNotification, 2, nameOfNotificationType);
                if (PaperType.Equals(AllOfTheTest))
                {
                   seleniumFunc.WaitAndClickOnElement(notificationPage.EngReadingAllOfTheTestCheckBox);
               }
                else if (PaperType.Equals(PartOfTheTest))
                {
                    seleniumFunc.WaitAndClickOnElement(notificationPage.EngReadingPartOfTheTestCheckBox);
                }
            }
            else if (PaperName.Equals(MathPaper1))
            {
                seleniumFunc.WaitAndClickOnElement(notificationPage.MathematicsPaper1CheckBox);
                EnterNameOfTypeOfNotificationForSubject(typeOfNotification, 3, nameOfNotificationType);
                if (PaperType.Equals(AllOfTheTest))
                {
                    seleniumFunc.WaitAndClickOnElement(notificationPage.MathPaper1AllOfTheTestCheckBox);
                }
                else if (PaperType.Equals(PartOfTheTest))
                {
                    seleniumFunc.WaitAndClickOnElement(notificationPage.MathPaper1PartOfTheTestCheckBox);
                }
            }
            else if (PaperName.Equals(MathPaper2))
            {
                seleniumFunc.WaitAndClickOnElement(notificationPage.MathematicsPaper2CheckBox);
                EnterNameOfTypeOfNotificationForSubject(typeOfNotification, 4, nameOfNotificationType);
                if (PaperType.Equals(AllOfTheTest))
                {
                    seleniumFunc.WaitAndClickOnElement(notificationPage.MathPaper2AllOfTheTestCheckBox);
                }
                else if (PaperType.Equals(PartOfTheTest))
                {
                    seleniumFunc.WaitAndClickOnElement(notificationPage.MathPaper2PartOfTheTestCheckBox);
                }
            }
            else if (PaperName.Equals(MathPaper3))
            {
                seleniumFunc.WaitAndClickOnElement(notificationPage.MathematicsPaper3CheckBox);
                EnterNameOfTypeOfNotificationForSubject(typeOfNotification, 5, nameOfNotificationType);
                if (PaperType.Equals(AllOfTheTest))
                {
                    seleniumFunc.WaitAndClickOnElement(notificationPage.MathPaper3AllOfTheTestCheckBox);
                }
                else if (PaperType.Equals(PartOfTheTest))
                {
                    seleniumFunc.WaitAndClickOnElement(notificationPage.MathPaper3PartOfTheTestCheckBox);
                }
            }

        }

        public void AddBrifExplanation(string explanationDetails)
        {
            seleniumFunc.EnterText(notificationPage.TextAreaBox, explanationDetails);

        }

        public void SelectConfirmationCheckBox(bool TickToConfirm1, bool TickToConfirm2)
        {
       
            if (TickToConfirm1)
            {
                seleniumFunc.WaitAndClickOnElement(notificationPage.TickToConfirm1CheckBox);
            }
            if (TickToConfirm2)
            {

                seleniumFunc.WaitAndClickOnElement(notificationPage.TickToConfirm2CheckBox);
            }
        }

        public void SubmitForm()
        {
            seleniumFunc.ClickOnElement(notificationPage.SubmitBtn);
            seleniumFunc.WaitForPageToLoad();
        }

       

        public void NavigateBackToNotificationPage()
        {
            seleniumFunc.ClickOnElement(notificationPage.BackBtn);
            seleniumFunc.WaitForPageToLoad();

        }

        public bool CheckMandetoryFields(string fieldName, String ErrorMsg)
        {
            bool value = false;
            switch (fieldName)
            {
                case Scribe:
                    seleniumFunc.ClickOnElement(notificationPage.ScribeRadioBtn);
                    seleniumFunc.WaitAndClickOnElement(notificationPage.EnglishGrammarPaper1CheckBox);
                    comFunc.SubmitForm();
                    seleniumFunc.WaitForElementToBeVisible(notificationPage.NameOFScribeTextBoxErrorMsg[0]);
                    //value = notificationPage.NameOFScribeTextBoxErrorMsg.Text.Equals(ErrorMsg) ? true : false;
                    VerifyIsEquals(ErrorMsg, seleniumFunc.GetText( notificationPage.NameOFScribeTextBoxErrorMsg[0]), "Check Name of Scribe field error msg");
                    VerifyIsEquals(ErrorMsg, seleniumFunc.GetText(notificationPage.HowWasAidUsedErrorMsg[0]), "Check 'How was the aid used?' error msg when Scribe selected");
                    seleniumFunc.WaitAndClickOnElement(notificationPage.EnglishGrammarPaper1CheckBox);
                    break;
                case Transcript:
                    seleniumFunc.ClickOnElement(notificationPage.TranscriptRadioBtn);
                    seleniumFunc.WaitAndClickOnElement(notificationPage.EnglishGrammarPaper1CheckBox);
                    comFunc.SubmitForm();
                    seleniumFunc.WaitForElementToBeVisible(notificationPage.NameOfTranscriberTextBoxErrorMsg[0]);
                    // value = notificationPage.NameOfTranscriberTextBoxErrorMsg.Text.Equals(ErrorMsg) ? true : false;
                    VerifyIsEquals(ErrorMsg, notificationPage.NameOfTranscriberTextBoxErrorMsg[0].Text, "Check Name of Transcript field error msg");
                    VerifyIsEquals(ErrorMsg, seleniumFunc.GetText(notificationPage.HowWasAidUsedErrorMsg[0]), "Check 'How was the aid used?' error msg when Transcript selected");

                    seleniumFunc.WaitAndClickOnElement(notificationPage.EnglishGrammarPaper1CheckBox); break;
                case WordProcess:

                    seleniumFunc.ClickOnElement(notificationPage.WordProcessorTechEleAidRadioBtn);
                    seleniumFunc.WaitAndClickOnElement(notificationPage.EnglishGrammarPaper1CheckBox);
                    comFunc.SubmitForm();
                    seleniumFunc.WaitForElementToBeVisible(notificationPage.NameOfTypeOfAidTextBoxErrorMsg[0]);
                    // value = notificationPage.NameOfTypeOfAidTextBoxErrorMsg.Text.Equals(ErrorMsg) ? true : false;
                    VerifyIsEquals(ErrorMsg, notificationPage.NameOfTypeOfAidTextBoxErrorMsg[0].Text, "Check Name of WordProcess field error msg");
                    VerifyIsEquals(ErrorMsg, seleniumFunc.GetText(notificationPage.HowWasAidUsedErrorMsg[0]), "Check 'How was the aid used?' error msg when WordProcess selected");
                    seleniumFunc.WaitAndClickOnElement(notificationPage.EnglishGrammarPaper1CheckBox);

                    break;

                case BriefExplanation:
                    seleniumFunc.ScrollElementInView(notificationPage.TextAreaBox);
                     comFunc.SubmitForm();
                    seleniumFunc.WaitForElementToBeVisible(notificationPage.BriefExplanationTextAreaErrorMsg);
                    // value = notificationPage.BriefExplanationTextAreaErrorMsg.Text.Equals(ErrorMsg) ? true : false;

                    VerifyIsEquals(ErrorMsg, notificationPage.BriefExplanationTextAreaErrorMsg.Text, "Check BriefExplanation field error msg");

                    break;

             
                default:                    
                         VerifyIsEquals(ErrorMsg, seleniumFunc.GetText( notificationPage.TypeOfNotificationSectionErrorMsg), "Check Type of Notification field error msg");
                    break;

            }
           
            return value;

        }

        public string GetUserLastName()
        {
            seleniumFunc.ScrollElementInView(notificationPage.ContactLastNameTextBox);
            return notificationPage.ContactLastNameTextBox.GetAttribute("value");
        }

        public string GetUserFirstName()
        {
            return notificationPage.ContactFirstNameTextBox.GetAttribute("value");
        }

        public string GetUserTeleNumberName()
        {
            return notificationPage.TelephoneNumberTextBox.GetAttribute("value");
        }

        public string GetUserEmailAddress()
        {
            return notificationPage.EmailAddressTextBox.GetAttribute("value");
        }


        public string GetUserJobTitle()
        {
            return notificationPage.JobTitleTextBox.GetAttribute("value");
        }

        public void CheckContactDetails(string UserLastName, string UserFirstName, string JobTitle, string UserTeleNumber, string UserEmailAddress) {

            // Verify contact details 
            VerifyIsEquals(notificationPage.ContactLastNameTextBox.GetAttribute("value"), UserLastName, "Check Contact Last Name ");
            VerifyIsEquals(notificationPage.ContactFirstNameTextBox.GetAttribute("value"), UserFirstName, "Check Contact First Name ");

            VerifyIsEquals(notificationPage.JobTitleTextBox.GetAttribute("value"), JobTitle, "Check Job tile");

            VerifyIsEquals(notificationPage.TelephoneNumberTextBox.GetAttribute("value"), UserTeleNumber, "Check Contact Telephone number ");
            VerifyIsEquals(notificationPage.EmailAddressTextBox.GetAttribute("value"), UserEmailAddress, "Check Contact Email address ");

        }

        /*
        public bool isPupileDropdownValuesSorted() {
            seleniumFunc.ClickOnElement(notificationPage.PupilSelectionDropDwn);


            string[] pupileList = notificationPage.PupilSelectionDropDwnOption.Text;
           return comFunc.SortedOrNot(pupileList);
        }
        */

    }
}
