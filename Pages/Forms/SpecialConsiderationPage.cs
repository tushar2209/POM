using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
    class SpecialConsiderationPage
    {


        public SpecialConsiderationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        // Contact details 
        [FindsBy(How = How.XPath, Using = "//label/span[text()='Contact first name']/../../input")]
        public IWebElement ContactFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Contact last name']/../input")]
        public IWebElement ContactLastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Job title']/../../input")]
        public IWebElement JobTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Email address']/../../input")]
        public IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Telephone number']/../../input")]
        public IWebElement TelephoneNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='School name']/../input")]
        public IWebElement SchoolName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='DFE number']/../input")]
        public IWebElement DFENumber { get; set; }

        // Pupile Details

        [FindsBy(How = How.XPath, Using = "//label[text()='Whole cohort']/../input")]
        public IWebElement WholeCohortRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Individual pupil']/../input")]
        public IWebElement IndividualPupilRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//table//input")]
        public IList<IWebElement> SubjectsCheckBoxes { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='custom-combobox']/input")]
        public IWebElement PupilDropDwn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ui-autocomplete li[class='ui-menu-item']")]
        public IList<IWebElement> PupilDropDwnOptions { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@ctrltype='rbtnlist']//input[@value='No']")]
        public IList<IWebElement> QuestionsNoRadioBtns { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@ctrltype='rbtnlist']//input[@value='Yes']")]
        public IList<IWebElement> QuestionsYesRadioBtns { get; set; }

        [FindsBy(How = How.XPath, Using = " //label[text()='Reason why special consideration is being requested.']/following-sibling:: select")]
        public IWebElement ReasonForSpecialConsiderDropDwn { get; set; }


        [FindsBy(How = How.XPath, Using = " //input[contains(@class,'hasDatepicker')]")]
        public IWebElement DateOfIncidentTextbox { get; set; }



        [FindsBy(How = How.XPath, Using = "//label/span[text()='Relationship to pupil (if not applicable answer N/A)']/../../input")]
                                          
        public IWebElement RelationshipToPupilNATextbox { get; set; }


        [FindsBy(How = How.XPath, Using = "//label/span[text()='Relationship to pupil']/../../select")]        public IWebElement RelationshipToPupilDropDwn { get; set; }


        [FindsBy(How = How.XPath, Using = "//textarea")]
        public IWebElement BrieflyExplainTextArea { get; set; }


        #region  Review from Loclatores

        [FindsBy(How = How.XPath, Using = "//label[contains(.,'whom special consideration')]/following-sibling::input")]
        public IWebElement ReviewFromPupilTextbox { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Relationship to pupil (if not applicable answer N/A)']/../input")]

        public IWebElement ReviewFormRelationshipToPupilTextbox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//textarea)[1]")]
        public IWebElement ReviewFormBrieflyExplainTextArea { get; set; }
        #endregion

       
        
        
        #region Additional Information/ More information


        [FindsBy(How = How.XPath, Using = "//label/span[text()='Reason for request']/../following-sibling:: select")]
        public IWebElement MoreInfoFormReasonForRequest { get; set; }
        [FindsBy(How = How.PartialLinkText, Using = "linkLogOff")]
        public IWebElement logoffCM { get; set; }



        [FindsBy(How = How.XPath, Using = "//*[text()='Relationship to pupil (if not applicable answer N/A)']/../../input")]
        public IWebElement MoreInfoFormRelationshipToPupil { get; set; }

        [FindsBy(How = How.XPath, Using = "(//textarea)[3]")]
        public IWebElement MoreInfoFormBrieflyExplainTextArea { get; set; }
        
        #endregion

        #region History Details  WebElement on Revire and more information form
     
        [FindsBy(How = How.XPath, Using = "//strong[contains(text(),'Comment History')]/../../../div/input")]
        public IList<IWebElement> HistoryOfDateAndTimeList { get; set; }

        [FindsBy(How = How.XPath, Using = "//strong[contains(text(),'Comment History')]/../../../div//span[contains(text(),'Reason for decision')]/../following-sibling::textarea")]
        public IList<IWebElement> HistoryOfReasonForDecisionList { get; set; }

        [FindsBy(How = How.XPath, Using = "//strong[contains(text(),'Comment History')]/../../../div/label[contains(text(),'Additional information')]/following-sibling::textarea")]
        public IList<IWebElement> HistoryOfAdditionalInformationList { get; set; }

        #endregion
    }
}
