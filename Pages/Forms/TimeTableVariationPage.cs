using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using STA__Automation.BussinessLib;

namespace STA__Automation.Pages.Forms
{
    class TimeTableVariationPage
    {
        /// <summary>
        /// Method to Initialise page Opbjects
        /// </summary>
        /// <param name="driver"> driver</param>
        public TimeTableVariationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #region   Application from section
        // Contact details 
        [FindsBy(How = How.XPath, Using = "//label[text()='Contact first name']/../input")]
        public IWebElement ContactFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Contact last name']/../input")]
        public IWebElement ContactLastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Job title']/../../input")]
        public IWebElement JobTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Email address']/../../input")]
        public IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Telephone number']/../../input")]
        public IWebElement TelephoneNumber { get; set; }

        // Pupile Details

        [FindsBy(How = How.XPath, Using = "//label[text()='Whole cohort']/../input")]
        public IWebElement WholeCohortRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Individual pupil']/../input")]
        public IWebElement IndividualPupilRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Partial cohort']/../input")]
        public IWebElement PartialCohortRadioBtn { get; set; }


        //pupil drop down

/*
        [FindsBy(How = How.XPath, Using = "//span[@class='custom-combobox']/..//span[@class='validationerror context-text-warning']")]
        public IWebElement PupilSelectionDropDownErrorMsg { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ui-autocomplete li[class='ui-menu-item']")]
        public IWebElement PupilSelectionDropDwnOption { get; set; }
        */

        [FindsBy(How = How.XPath, Using = "//span[@class='custom-combobox']/input")]
        public IList< IWebElement> PupilSelectionDropDwns { get; set; }


        [FindsBy(How = How.XPath, Using = "(//span[@class='custom-combobox'])[2]/input")]
        public IWebElement PartailCohortPupilSelectionDropDwn1 { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ui-autocomplete li[class='ui-menu-item']")]
        public IList <IWebElement> PupilDropDwnOptions { get; set; }
    /*

        [FindsBy(How = How.XPath, Using = "(//span[@class='custom-combobox'])[3]/input")]
        public IWebElement PartailCohortPupilDropDwn2 { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#ui-id-3 li")]
        public IWebElement PartailCohortPupilDropDwn2Options { get; set; }
        */

        [FindsBy(How = How.XPath, Using = "//span[text()='Add pupil']")]
        public IWebElement AddPupilBtn { get; set; }

               
        // Subjects Date and Time

        [FindsBy(How = How.XPath, Using = "//label[text()='Subject']/../select")]
        public IList<IWebElement> SubjectDropDwns { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Date scheduled to']/../div/input[1]")]
        public IList<IWebElement> DateScheduledToInputBoxes { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Date scheduled to']/../div/input[1]/following-sibling::a")]
        public IList<IWebElement> DateScheduledToClearBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Time']/../select")]
        public IList<IWebElement> TimeDropdwns { get; set; }

      

        [FindsBy(How = How.XPath, Using = "//span[text()='Add subject paper']")]
        public IWebElement AddSubjectPaperBtn { get; set; }
      

        [FindsBy(How = How.XPath, Using = "//input[@value='Verify']")]
        public IWebElement VerifyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@class='context-box-warning context-text-warning']//strong/span")]
        public IWebElement SubjectDateTimeErrorMsg { get; set; }

        

        #endregion


        #region   Reason For Variation

        [FindsBy(How = How.XPath, Using = "//label[text()='Illness']/../input")]
        public IWebElement IllnessRadioBtn { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Funeral']/../input")]
        public IWebElement FuneralRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Religious or cultural festival']/../input")]
        public IWebElement ReligiousRadioBtn { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Appointment that cannot be rearranged (please specify)']/../input")]
        public IWebElement AppointmensRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Other (please specify)']/../input")]
        public IWebElement OtherRadioBtn { get; set; }

        [FindsBy(How = How.TagName, Using = "textarea")]
        public IWebElement NoteTextArea { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Has the pupil(s) returned to school and is fit to take the test?']/..//input[@value='Yes']")]
        public IWebElement Illness_PupleFitYesRadioBtn { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Has the pupil(s) returned to school and is fit to take the test?']/..//input[@value='No']")]
        public IWebElement Illness_PupleFitNoRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@class='context-box-warning context-text-warning']//strong")]
        public IWebElement Illness_PupleFitNoRadioBtnErrorMsg { get; set; }

        


        // selection B

        [FindsBy(How = How.XPath, Using = "//label[text()='Has the pupil(s) had any contact with pupils who have already taken the test(s)?']/..//input[@value='Yes']")]
        public IWebElement SectionBQ1YesRadioBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[text()='Has the pupil(s) had any contact with pupils who have already taken the test(s)?']/..//input[@value='No']")]
        public IWebElement SectionBQ1NoRadioBtn { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Has the pupil(s) had access to the content of the tests via the internet or social media?']/..//input[@value='Yes']")]
        public IWebElement SectionBQ2YesRadioBtn { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Has the pupil(s) had access to the content of the tests via the internet or social media?']/..//input[@value='No']")]
        public IWebElement SectionBQ2NoRadioBtn { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='If approved, can you confirm that the security and integrity of the test will be maintained?']/..//input[@value='Yes']")]
        public IWebElement SectionBQ3YesRadioBtn { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='If approved, can you confirm that the security and integrity of the test will be maintained?']/..//input[@value='No']")]
        public IWebElement SectionBQ3NoRadioBtn { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Has the school authorised the absence?']/..//input[@value='Yes']")]
        public IWebElement SectionBQ4YesRadioBtn { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Has the school authorised the absence?']/..//input[@value='No']")]
        public IWebElement SectionBQ4NoRadioBtn { get; set; }


        #endregion

        #region Review From Locatore

        [FindsBy(How = How.XPath, Using = "//label[text()='Details of the pupil(s) for whom time variation is being requested']/../input")]
        public IList<IWebElement> ReviewFromPupilNameTextbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Subject']/../input")]
        public IList<IWebElement> ReviewFormSubjectTextboxes { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Date scheduled to']/../div/input[1]")]
        public IList<IWebElement> ReviewFromDateSchduledToTextBoxex { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Time']/../input")]
        public IList<IWebElement> ReviewFromTimeTextBoxes { get; set; }

        
        [FindsBy(How = How.XPath, Using = "(//input[@type='checkbox'])[1]")]
        public IWebElement ReviewFromDelegatedAuthorityCheckBox { get; set; }

        #endregion

        #region More infromation

        

        [FindsBy(How = How.XPath, Using = "//*[text()='Further information required']/../../textarea")]
        public IWebElement MoreInfoFurtherInfoReqTextarea { get; set; }

        #endregion


    }
}
