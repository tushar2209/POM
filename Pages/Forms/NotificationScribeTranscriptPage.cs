using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
    public class NotificationScribeTranscriptPage
    {
        /**
         * Method to Initialise  Page Object of respective page
         **/
        public NotificationScribeTranscriptPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #region Intro Page

        // Start Apllication Button - Intro page
        [FindsBy(How = How.CssSelector, Using = "input[id='MainContent_ApplyButton']")]
        public IWebElement StartButton { get; set; }

        #endregion

        #region Notification Detail page

        [FindsBy(How = How.CssSelector, Using = ".title.introtitle")]
        public IWebElement PageTitle { get; set; }

        // Contact Details ection locaters 
        [FindsBy(How = How.XPath, Using = "//label/span[text()='Contact last name']")]
        public IWebElement ContactLastNameLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Contact last name']/../../input")]
        public IWebElement ContactLastNameTextBox { get; set; }


        [FindsBy(How = How.XPath, Using = "//label/span[text()='Contact first name']")]
        public IWebElement ContactFirstNameLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Contact first name']/../../input")]
        public IWebElement ContactFirstNameTextBox { get; set; }


        [FindsBy(How = How.XPath, Using = "//label/span[text()='Job title']")]
        public IWebElement JobTitleLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Job title']/../../input")]
        public IWebElement JobTitleTextBox { get; set; }


        [FindsBy(How = How.XPath, Using = "//label/span[text()='Telephone number']")]
        public IWebElement TelephoneNumberLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Telephone number']/../../input")]
        public IWebElement TelephoneNumberTextBox { get; set; }


        [FindsBy(How = How.XPath, Using = "//label/span[text()='Email address']")]
        public IWebElement EmailAddressLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Email address']/../../input")]
        public IWebElement EmailAddressTextBox { get; set; }

        /**
         * Type of notification* section locators
         * */
        [FindsBy(How = How.XPath, Using = "//label[text()='Type of notification']")]
        public IWebElement TypeOfNotificationLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Scribe']/../input")]
        public IWebElement ScribeRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Transcript']/../input")]
        public IWebElement TranscriptRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Word processor or other technical or electronic aid']/../input")]
        public IWebElement WordProcessorTechEleAidRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Type of notification']/..//span[@class='validationerror context-text-warning']")]
        public IWebElement TypeOfNotificationSectionErrorMsg { get; set; }

        //Name of scribe 

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Name of scribe']/../../input")]
        public IList<IWebElement> NameOFScribeTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Name of scribe']/../..//span[@class='validationerror context-text-warning']")]
        public IList<IWebElement> NameOFScribeTextBoxErrorMsg { get; set; }

        //Name of transcriber
        [FindsBy(How = How.XPath, Using = "//label/span[text()='Name of transcriber']/../../input")]
        public IList<IWebElement> NameOfTranscriberTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Name of transcriber']/../..//span[@class='validationerror context-text-warning']")]
        public IList<IWebElement> NameOfTranscriberTextBoxErrorMsg { get; set; }

        //Type of aid
        [FindsBy(How = How.XPath, Using = "//label[text()='Type of aid']/../input")]
        public IList<IWebElement> NameOFTypeOfAidTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Type of aid']/..//span[@class='validationerror context-text-warning']")]
        public IList<IWebElement> NameOfTypeOfAidTextBoxErrorMsg { get; set; }

        // Pupile dropdown
        [FindsBy(How = How.CssSelector, Using = ".custom-combobox input")]
        public IWebElement PupilSelectionDropDwn { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='custom-combobox']/..//span[@class='validationerror context-text-warning']")]
        public IWebElement PupilSelectionDropDownErrorMsg { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ui-autocomplete li[class='ui-menu-item']")]
        public IList<IWebElement> PupilSelectionDropDwnOption { get; set; }

        // Papers
        [FindsBy(How = How.XPath, Using = "//label/span[text()='English grammar, punctuation and spelling Paper 1: questions']/../..//input")]
        public IWebElement EnglishGrammarPaper1CheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='English grammar, punctuation and spelling Paper 2: spelling']/../..//input")]
        public IWebElement EnglishGrammarPaper2CheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='English reading']/../..//input")]
        public IWebElement EnglishRedingCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Mathematics Paper 1: arithmetic']/../..//input")]
        public IWebElement MathematicsPaper1CheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Mathematics Paper 2: reasoning']/../..//input")]
        public IWebElement MathematicsPaper2CheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Mathematics Paper 3: reasoning']/../..//input")]
        public IWebElement MathematicsPaper3CheckBox { get; set; }

        /**
         * Please provide a brief explanation for the use of the aid and why it was used.
            Note: This text box has a limit of 2800 characters. field and error msg
         */

        [FindsBy(How = How.CssSelector, Using = "textarea")]
        public IWebElement TextAreaBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//textarea/../div[@class='validationerror']/span")]
        public IWebElement BriefExplanationTextAreaErrorMsg { get; set; }



        [FindsBy(How = How.CssSelector, Using = "input#MainContent_NextButton")]
        public IWebElement NextBtn { get; set; }

        /**
         * English grammar, punctuation and spelling Paper 1: questions 
         * How was the aid used? locators
         */
        [FindsBy(How = How.XPath, Using = "(//label[text()='All of the test']/../input)[1]")]
        public IWebElement EngPaper1AllOfTheTestCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Part of the test']/../input)[1]")]
        public IWebElement EngPaper1PartOfTheTestCheckBox { get; set; }

        /**
         * English grammar, punctuation and spelling Paper 2: spelling 
         * How was the aid used? locators
         */
        [FindsBy(How = How.XPath, Using = "(//label[text()='All of the test']/../input)[2]")]
        public IWebElement EngPaper2AllOfTheTestCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Part of the test']/../input)[2]")]
        public IWebElement EngPaper2PartOfTheTestCheckBox { get; set; }

        /**
        * English reading 
        * How was the aid used? locators
        */
        [FindsBy(How = How.XPath, Using = "(//label[text()='All of the test']/../input)[3]")]
        public IWebElement EngReadingAllOfTheTestCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Part of the test']/../input)[3]")]
        public IWebElement EngReadingPartOfTheTestCheckBox { get; set; }

        /**
         * Mathematics Paper 1: arithmetic
        * How was the aid used? locators
         */
        [FindsBy(How = How.XPath, Using = "(//label[text()='All of the test']/../input)[4]")]
        public IWebElement MathPaper1AllOfTheTestCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Part of the test']/../input)[4]")]
        public IWebElement MathPaper1PartOfTheTestCheckBox { get; set; }
        /**
         * Mathematics Paper 2: reasoning
        * How was the aid used? locators
         * */
        [FindsBy(How = How.XPath, Using = "(//label[text()='All of the test']/../input)[5]")]
        public IWebElement MathPaper2AllOfTheTestCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Part of the test']/../input)[5]")]
        public IWebElement MathPaper2PartOfTheTestCheckBox { get; set; }

        /**
         * Mathematics Paper 3: reasoning
        * How was the aid used? locators
         */
        [FindsBy(How = How.XPath, Using = "(//label[text()='All of the test']/../input)[6]")]
        public IWebElement MathPaper3AllOfTheTestCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Part of the test']/../input)[6]")]
        public IWebElement MathPaper3PartOfTheTestCheckBox { get; set; }
        #endregion

        #region Review AndSubmit page/Section

        /**
         * Common Error Mssage and List of fields - Review and Submit page.
         */

        [FindsBy(How = How.CssSelector, Using = "#questiongroup p")]
        public IWebElement MandFiledCommonErrorMsg { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".declaration-list")]
        public IWebElement MandetoryFiledList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content-container .section.s-incomplete")]
        public IWebElement IncompletNoticeDetailsSection { get; set; }

        /**
         * I am the headteacher of the school, or I have been given the delegated authority by the headteacher to make this notification.*
         */

        [FindsBy(How = How.XPath, Using = "(//input[@type='checkbox'])[1]")]
        public IWebElement TickToConfirm1CheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@type='checkbox'])[1]/../span")]
        public IWebElement TickToConfirm1CheckBoxErrorMsg { get; set; }

        /**
         *   I confirm that this pupil has not been helped with the subject matter being tested and that the language, punctuation and phrasing are the pupil’s own.*
         */

        [FindsBy(How = How.XPath, Using = "(//input[@type='checkbox'])[2]")]
        public IWebElement TickToConfirm2CheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@type='checkbox'])[2]/../span")]
        public IWebElement TickToConfirm2CheckBoxErrorMsg { get; set; }

        // Submit & Back button

        [FindsBy(How = How.CssSelector, Using = "input[value='Submit']")]
        public IWebElement SubmitBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='Back']")]
        public IWebElement BackBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".pdfdiv a")]
        public IWebElement ReviewPdfBtn { get; set; }

        #endregion

        #region Submittion Confirmation Mssage Page
        [FindsBy(How = How.CssSelector, Using = "#content-container-response h3")]
        public IWebElement ApplicationSubMissionConfMsg { get; set; }


       
        [FindsBy(How = How.XPath, Using = " //label[text()='How was the aid used?']/..//span[@class='validationerror context-text-warning']")]
        public IList<IWebElement> HowWasAidUsedErrorMsg { get; set; }
        #endregion
    }
}
