using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
    class CmUploadTestMaterialPage
    {
        #region UploadDocsPage Constructor
        public CmUploadTestMaterialPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        #endregion

        #region Page Objects
        //private object Driver;

  
        [FindsBy(How = How.Id, Using = "epdagree")]
        public IWebElement CookiesCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "epdsubmit")]
        public IWebElement CookiesSubmitBtn { get; set; }

        [FindsBy(How = How.Id, Using = "epd")]
        public IWebElement CookiePopUp { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Upload Document']/..//input[2]")]
        public IWebElement FileUpload { get; set; }


        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_813ab6cf3089450e81db2057d8a2abccf379bae94f184fb1ac686bba6f87bfec")]
        public IWebElement Description { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_813ab6cf3089450e81db2057d8a2abcc0e5dab87fd3644a9aa5249f531bef556_DropDownListDD")]
        public IWebElement fromday { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_813ab6cf3089450e81db2057d8a2abcc0e5dab87fd3644a9aa5249f531bef556_DropDownListMMM")]
        public IWebElement frommonth { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_813ab6cf3089450e81db2057d8a2abcc0e5dab87fd3644a9aa5249f531bef556_DropDownListYY")]
        public IWebElement fromyear { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_813ab6cf3089450e81db2057d8a2abcc22c9f6a7277a408aa948ef5712263a01_DropDownListDD")]
        public IWebElement todate { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_813ab6cf3089450e81db2057d8a2abcc22c9f6a7277a408aa948ef5712263a01_DropDownListMMM")]
        public IWebElement tomonth { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_813ab6cf3089450e81db2057d8a2abcc22c9f6a7277a408aa948ef5712263a01_DropDownListYY")]
        public IWebElement toyear { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_813ab6cf3089450e81db2057d8a2abccb4ad8c2e2ef14e25b28fb2e1aa7bf3a4")]
        public IWebElement userorrole { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Users']/../select")]
        public IWebElement SubRoleOrUser { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='submit' and @id='MainContent_SubmitButton']")]
        public IWebElement SubmitBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='formQuestion']")]
        public IWebElement textverify { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='MainContent_CaseRef']")]
        public IWebElement refcode { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_caseRef")]
        public IWebElement STACaseRef { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_searchButton")]

        public IWebElement CMSearchBtn { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_ctl3655_newFormButtonID")]

        public IWebElement CreateNewFormBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnReturn")]

        public IWebElement ReturnToCMBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Category']/../select")]
        public IList<IWebElement> SelectCategoryDrpDwn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Sub-category']/../select")]
        public IList<IWebElement> SelectSubCategoryDrpDwn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Subject']/../select")]
        public IList<IWebElement> SelectSubjectDrpDwn { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox']")]
        public IList<IWebElement> DeleteCheckBoxes { get; set; }
        

        //new locatores - vilas 



        [FindsBy(How = How.XPath, Using = "//input[@value='Upload new test materials']")]
        public IWebElement UploadNewCheckBox { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@value='Delete previously uploaded test materials']")]
        public IWebElement DeletePreviousCheckbox { get; set; }


        [FindsBy(How = How.ClassName, Using = "saveFileId")]
        public IList<IWebElement> fileUploads { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='From date']/../..//div[1]/input[1]")]
        public IList<IWebElement> FromDates { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='To date']/..//div[1]/input[1]")]
        public IList<IWebElement> ToDates { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Document name']/..//input[1]")]
        public IList<IWebElement> fileUploadDescriptions { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[text()='Add']")]
        public IWebElement AddBtn { get; set; }



        #endregion
    }
}
