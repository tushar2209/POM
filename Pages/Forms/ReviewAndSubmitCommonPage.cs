using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
    public class ReviewAndSubmitCommonPage
    {
        public ReviewAndSubmitCommonPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);

        }

        #region Submittion Confirmation Mssage Page

        // Submit & Back button

        [FindsBy(How = How.CssSelector, Using = "input[id='MainContent_SubmitButton']")]
        public IWebElement SubmitBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='Back']")]
        public IWebElement BackBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".pdfdiv a")]
        public IWebElement ReviewPdfBtn { get; set; }

        //  Apllication submition confirmation message WebLocator
        [FindsBy(How = How.ClassName, Using = "formQuestion")]
        public IWebElement ApplicationSubMissionConfMsg { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#main")]
        public IWebElement ApplicationSubMissionErrorMsg { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#MainContent_CaseRef")]
        public IWebElement ApplicationCaseReferNumber { get; set; }


        #endregion
        #region     Common Error Mssage and List of fields - Review and Submit page.


        [FindsBy(How = How.CssSelector, Using = "#questiongroup p")]
        public IWebElement MandFiledCommonErrorMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='declaration-list']")]
        public IList<IWebElement> PageMandetoryFieldList { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='content-container']//li[@class='section s-incomplete']")]
        public IList<IWebElement> IncompletSectionPages { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='checkbox']")]
        public IList<IWebElement> TickToConfirmCheckBoxes { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_SaveButton'")]
        public IWebElement SaveBtn { get; set; }
        #endregion

        #region Review from loactores - Case Manager
        [FindsBy(How = How.CssSelector, Using = "input[value='Rejected']")]
        public IWebElement RejectedRadioBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='Approved']")]
        public IWebElement ApprovedRadioBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='More information required']")]
        public IWebElement MoreInfroReqRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Reason for decision']/../../textarea")]
        public IList<IWebElement> ReasonForDecisionTextBoxes { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Additional Information']/../textarea")]
        public IList<IWebElement> ReReviewFormAddtionalInfoTextBoxes { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnDownload')]")]
        public IList<IWebElement> ReReviewFormDownloadDocBtns { get; set; }

               
        [FindsBy(How = How.XPath, Using = "//input[@value='Verify']")]
        public IWebElement VerifyBtn { get; set; }
        #endregion
    }
}
