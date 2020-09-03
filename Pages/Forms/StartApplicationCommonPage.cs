using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
   public  class StartApplicationCommonPage
    {
        public StartApplicationCommonPage(IWebDriver driver) {
            PageFactory.InitElements(driver, this);
        }


        #region Intro Page

        // Iframe
        public string Iframe = "available_act_iframe";

     // Start Apllication Button - Intro page
        [FindsBy(How = How.CssSelector, Using = "input[id='MainContent_ApplyButton']")]
        public IWebElement StartButton { get; set; }

        // Start Apllication Button - Intro page
        [FindsBy(How = How.CssSelector, Using = " #ui-datepicker-div .ui-datepicker-year")]
        public IWebElement DatePickerYearDropDwn { get; set; }

        [FindsBy(How = How.CssSelector, Using = " #ui-datepicker-div .ui-datepicker-month")]
        public IWebElement DatePickerMonthDropDwn { get; set; }

        [FindsBy(How = How.CssSelector, Using = " #ui-datepicker-div .ui-datepicker-calendar tbody")]
        public IWebElement DatePickerDates { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id='MainContent_NextButton']")]
        public IWebElement NextBtn { get; set; }


       
        [FindsBy(How = How.Id, Using = "epdagree")]
        public IWebElement CookiesCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "epdsubmit")]
        public IWebElement CookiesContinueBtn { get; set; }
        

        #endregion
    }
}
