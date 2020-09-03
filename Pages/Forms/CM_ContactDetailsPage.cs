using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
 
   public  class CM_ContactDetailsPage
    {
        #region ContactDetailsPage Constructor
        public CM_ContactDetailsPage(IWebDriver driver) 
        {
            PageFactory.InitElements(driver, this);
        }
        #endregion

        #region Page Objects

        [FindsBy(How = How.Id, Using = "MainContent_filter")]
        public IWebElement FilterBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[@class='roundel roundel-img roundel-blue tooltip-left'])[1]")]
        //[FindsBy(How = How.XPath, Using = "//td[@class='cd-action']/span[@class='roundel roundel-img roundel-blue tooltip-left']/img[@class='dropbtn' and @onclick='menuDisplay(0)']")]
        public IWebElement Dropbtn { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "Create New Form")]
        public IWebElement CreateNewFormLink { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[@class='roundel roundel-img roundel-blue tooltip-left']//a[text()='View'])[1]")]
        public IWebElement ViewBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='question-answer'][2]//tr[2]/td[@class='answer']/span")]
        public IWebElement FullNameonCM { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='question-answer'][2]//tr[3]/td[@class='answer']/span")]
        public IWebElement EmailOnCM { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='question-answer'][2]//tr[4]/td[@class='answer']/span")]
        public IWebElement WorkingBSforGPS { get; set; }

        [FindsBy(How = How.XPath, Using = "//table[@class='question-answer'][2]//tr//span[text()='Paper 1: questions and Paper 2: spelling']//following::span[1]")]
        public IWebElement PaperCountGPS { get; set; }

        /////////Elements to on the Create A New Form Window//////////////////////////////

        [FindsBy(How = How.XPath, Using = "//li[@class='ui-menu-item']/a")]
        public IWebElement CreateLA { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Form']//following::span[@class='ui-button-icon-primary ui-icon ui-icon-triangle-1-s']")]
        public IWebElement FormSelectionIcon { get; set; }

        [FindsBy(How = How.Id, Using = "combobox")]
        //[FindsBy(How = How.XPath, Using = "//label[text()='Form']//following::select[@id='combobox']")]
        public IWebElement FormSelectDropdown { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//ul/li[@class='ui-menu-item']/a")]
        public IList <IWebElement> CreateFormOptions { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@type='submit' and @value='Save']")]
        public IWebElement CreateFormSaveBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@class='ui-menu-item']/a[text()='Manage Local Authority Portal Contacts']")]
        public IWebElement CreateLAUserLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@class='ui-menu-item']/a[text()='Manage School Portal Contacts']")]
        public IWebElement CreatSchoolLink { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@class='custom-combobox-input ui-widget ui-widget-content ui-state-default ui-corner-left ui-autocomplete-input'])[2]")]
        public IWebElement FormInputBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@class='ui-menu-item']/a[text()='Document upload']")]
        public IWebElement DocumentUpload { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@class='ui-menu-item']/a[text()='Upload Test Materials']")]
        public IWebElement UploadTestMaterial { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_ccedba1958124905b26c150764b36e4935c2b42098df46519195adde0f3c22c0_0")]

        public IWebElement UplNewTestMatChkBox { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_ccedba1958124905b26c150764b36e4935c2b42098df46519195adde0f3c22c0_1")]

        public IWebElement DelPrevUplTestMatChkBox { get; set; }


        [FindsBy(How = How.Id, Using = "MainContent_NextButton")]

        public IWebElement NxtBtn { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_6fdbcb9a2bf947bbbd36e7a1182b98419c296c0a415b4fbeafcf56512ce07f42_REPEAT1")]

        public IWebElement CategoryTxtDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_6fdbcb9a2bf947bbbd36e7a1182b9841b08562c0527a478b9a1ddba03ea2deec_REPEAT1")]

        public IWebElement SubCategoryTxtDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_6fdbcb9a2bf947bbbd36e7a1182b984168a253a767cc4636a65690060314c613_REPEAT1")]

        public IWebElement SubjectTxtDropDown { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_6fdbcb9a2bf947bbbd36e7a1182b98416438860b709341c5a46e5805d2a07d6a_REPEAT1_LabelNoFile")]

        public IWebElement UplDocSelFileField { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_6fdbcb9a2bf947bbbd36e7a1182b98411d7d5ba943d64f92a52cf24c8d49012e_REPEAT1")]

        public IWebElement DocName { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_6fdbcb9a2bf947bbbd36e7a1182b9841cbb5cc8a6567467a9a2bb74583251591_REPEAT1_Calendar")]
        public IWebElement FromCal { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_6fdbcb9a2bf947bbbd36e7a1182b98413f5d9939031c473db18f6bf98088da2e_REPEAT1_Calendar")]
        public IWebElement ToCal { get; set; }


        [FindsBy(How = How.XPath, Using = "//select[@class = 'ui-datepicker-year']")]
        public IWebElement SelectYear { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@class = 'ui-datepicker-month']")]
        public IWebElement SelectMonth { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@class = 'ui-state-default']")]
        public IWebElement SelectDay { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_NextButton")]
        public IWebElement FormNxtBtn { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_BackButton")]
        public IWebElement SubSecBackBtn { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_SubmitButton")]
        public IWebElement SubSecSubmitBtn { get; set; }



        //select[@class = "ui-datepicker-month"]


        [FindsBy(How = How.Id, Using = "MainContent_BackButton")]
        public IWebElement SubSelectionBckBtn { get; set; }



        /// <summary>
        /// Below is to select Document Upload from the Form dropdown
        /// </summary>
        /// <summary>
        /// Below is to select Document Upload from the Form dropdown
        /// </summary>
        /// 
        [FindsBy(How = How.XPath, Using = "//input[@type='hidden' and @value='Document upload']")]
        public IWebElement FormDocUpload { get; set; }

        [FindsBy(How = How.XPath, Using = "//tr//td[text()='Incomplete']/../td[@class='cd-action']//input[@src='images/icon-pencil.png']")]
        public IList<IWebElement> FirstCaseRefs { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='marTop']//input)[1]")]
        public IWebElement EditTooltip { get; set; }

        #endregion


    }
}
