using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace STA__Automation.Pages.Portal
{
   public class KS2PortalPage
    {
        #region KS2PortalPage Constructor
        public KS2PortalPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        #endregion

        #region Page Objects
        [FindsBy(How = How.Name, Using = "epdagree")]
        [FindsBy(How = How.Id, Using = "epdagree")]
        public IWebElement CookiesCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "epd")]
        public IWebElement CookiePopUp { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_ApplyButton")]
        public IWebElement StartFormBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_f5d9e3b5821c4c18950ea8de9a22be2d242024f63abb485a8f785c9a3d4fbd29']")]
        public IWebElement PrivacyCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_f5d9e3b5821c4c18950ea8de9a22be2dec892edee12a453e95471cc3767a3cff")]
        public IWebElement FullName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_f5d9e3b5821c4c18950ea8de9a22be2dd045179a4993486ea5106013690eb520']")]
        public IWebElement EmailAdd { get; set; }

        /// <summary>
        ///Working Below standard yes or No radio button on KS2 Form
        /// If we Select Yes in the radio button, the text box in the form gets hidden
        /// </summary>

        //these elements are for English grammar, punctuation and spelling (Written as GPS)

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_f5d9e3b5821c4c18950ea8de9a22be2d252ca9c81ef54ee3a1116887897b00e2_REPEAT1_0")]
        public IWebElement RadioYesBelowGPS { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_f5d9e3b5821c4c18950ea8de9a22be2d252ca9c81ef54ee3a1116887897b00e2_REPEAT1_1")]
        public IWebElement RadioNoBelowGPS { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_f5d9e3b5821c4c18950ea8de9a22be2dfd9ccac053da4116acdf796bf3410985_REPEAT1")]
        public IWebElement TxtBoxGPS { get; set; }

        //these elements are for English (Written as Eng)

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_f5d9e3b5821c4c18950ea8de9a22be2d252ca9c81ef54ee3a1116887897b00e2_REPEAT2_0")]
        public IWebElement RadioYesBelowEng { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_f5d9e3b5821c4c18950ea8de9a22be2d252ca9c81ef54ee3a1116887897b00e2_REPEAT2_1")]
        public IWebElement RadioNoBelowEng { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_f5d9e3b5821c4c18950ea8de9a22be2dfd9ccac053da4116acdf796bf3410985_REPEAT2")]
        public IWebElement TxtBoxEng { get; set; }


        //these elements are for Mathematics(Written as Math)

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_f5d9e3b5821c4c18950ea8de9a22be2d252ca9c81ef54ee3a1116887897b00e2_REPEAT3_0")]
        public IWebElement RadioYesBelowMath { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_f5d9e3b5821c4c18950ea8de9a22be2d252ca9c81ef54ee3a1116887897b00e2_REPEAT3_1")]
        public IWebElement RadioNoBelowMath { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_f5d9e3b5821c4c18950ea8de9a22be2dfd9ccac053da4116acdf796bf3410985_REPEAT3")]
        public IWebElement TxtBoxMath { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_CUSTOM_FIELD_f5d9e3b5821c4c18950ea8de9a22be2d9db67f8dbd2c4f4ebd5870b237e41236")]
        public IWebElement ConfirmCheckbox { get; set; }

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$SubmitButton")]
        public IWebElement SubmitBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@id='MainContent_CaseRef']")]
        public IWebElement ReferenceCode { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_SaveButton2]")]
        public IWebElement SaveBtn { get; set; }
        #endregion

     
    }
}
