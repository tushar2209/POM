using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
    class CM_UploadDocumentPage
    {
        #region ContactDetailsPage Constructor
        public CM_UploadDocumentPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #endregion
        //private object Driver;

        [FindsBy(How = How.ClassName, Using = "saveFileId")]
        public IList<IWebElement> FileUploadInfo { get; set; }


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

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_813ab6cf3089450e81db2057d8a2abcc1046c3ddbb004ae988a6d5a6c06a3da9")]
        public IWebElement rolevalue { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='submit' and @id='MainContent_SubmitButton']")]
        public IWebElement SubmitBtn { get; set; }


   


    }
}