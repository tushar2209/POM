using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
   public  class EarlyOpeningApplicationPage
    {


        public EarlyOpeningApplicationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        // Contact details 
        [FindsBy(How = How.XPath, Using = "//label/span[text()='Contact first name']/../../input")]
        public IWebElement ContactFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Contact last name']/../input")]
        public IWebElement ContactLastName { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Job title']/../input")]
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

        [FindsBy(How = How.XPath, Using = "//span[@class='custom-combobox']/input")]
        public IList<IWebElement> PupilSelectionDropDwns { get; set; }
                     

        [FindsBy(How = How.CssSelector, Using = ".ui-autocomplete li[class='ui-menu-item']")]
        public IList<IWebElement> PupilDropDwnOptions { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Add pupil']")]
        public IWebElement AddPupilBtn { get; set; }


        // Subjects 

        [FindsBy(How = How.XPath, Using = "//label[text()='English grammar, punctuation and spelling']/../input")]
        public IWebElement SubjectEngGrammmerCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='English reading']/../input")]
        public IWebElement SubjectEngReaddingCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Mathematics']/../input")]
        public IWebElement SubjectMathCheckBox { get; set; }
       

        [FindsBy(How = How.XPath, Using = " //label[text()='Reason for requesting early opening']/../select")]
        public IWebElement ReasonForEarlyOpeningDropdwn { get; set; }


        [FindsBy(How = How.XPath, Using = " //label[text()='Number of school days']/../select")]
        public IWebElement NumberOfSchoolDaysDropdwn { get; set; }
        

        [FindsBy(How = How.XPath, Using = " //textarea")]
        public IWebElement MoreDetailsOfEarlyOpeningTextbox { get; set; }


        [FindsBy(How = How.XPath, Using = " //span[@class='inline-label blockradio css-checkbox']/input")]
        public IList<IWebElement> SecurityTearmsCheckBoxlist { get; set; }

        [FindsBy(How = How.CssSelector, Using = " input[type = 'checkbox']")]
        public IWebElement TickToConfirmCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Reason for requesting early opening']/../input")]
        public IWebElement ReviewFromReasonForEarlyOpeningTextbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Number of school days']/../input")]
        public IWebElement ReviewFromNumberOfSchoolDaysTextbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//span/input[@type='checkbox']")]
        public IList<IWebElement> ReviewFromSecurityTramsCheckBoxes { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Details of the pupil(s) for whom Application for early opening is requested']/../input")]
        public IWebElement ReviewFromPartialCohortPupilNameTextbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Please provide the following pupil details']/../input")]
        public IWebElement ReviewFromIndividualPupilNameTextbox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id='MainContent_SubmitButton']")]
        public IWebElement SubmitBtn { get; set; }



    }
}
