using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
   public class ModifiedKS2Page
    {
        #region KS2Page Constructor
        public ModifiedKS2Page(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #endregion

        #region Page Object

        [FindsBy(How = How.XPath, Using = "//label[text()='Your full name']/..//input")]
        public IWebElement YourFullName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Your email address']/..//input")]
        public IWebElement YourEmail { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input#MainContent_ApplyButton")]
        public IWebElement StartFormBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8b562664c922d04ecb9dd0d79591eb4e31']")]
        public IWebElement PrivacyCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8b9d761e47e7c640949ab3fd6b9a6af22c']")]
        public IWebElement FullName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8ba93d52f8b4fe426c86e98c51576a0899']")]
        public IWebElement EmailAdd { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8bdece3888f6944853a03184b5ec0cfd1b']")]
        public IWebElement TotalPupilNo { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8b73db00a9e85f4f86a51b2aefec3dd26b']")]
        public IWebElement PupilVisual { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8b5017696d7f474bacb808eb2dd424315b']")]
        public IWebElement PupilSpcl { get; set; }
        ///////////// for English grammar, punctuation and spelling enlarged print(EP)//////////////////////

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8b1e29a76964904afba4a77e5197d94f94_REPEAT1_REPEAT1']")]
        public IWebElement EngGramarPunct_EP { get; set; }

        ///////////////// For English GP and SPLP(MLP)*////////////////////////////////

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8b1e29a76964904afba4a77e5197d94f94_REPEAT1_REPEAT2']")]
        public IWebElement Eng_GP_SPLP { get; set; }

        //////////////////////////For English grammar, punctuation and spelling braille/////////////////

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8b1e29a76964904afba4a77e5197d94f94_REPEAT1_REPEAT3']")]
        public IWebElement EngGramarPunct_braille { get; set; }

        ///////////////For English reading EP///////////////////////

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8b1e29a76964904afba4a77e5197d94f94_REPEAT1_REPEAT4']")]
        public IWebElement EngReading_EP { get; set; }

        ///////////////For English reading MLP///////////////////////

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8b1e29a76964904afba4a77e5197d94f94_REPEAT1_REPEAT5']")]
        public IWebElement EngReading_MLP { get; set; }

        ///////////////For English reading Braile///////////////////////

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8b1e29a76964904afba4a77e5197d94f94_REPEAT1_REPEAT6']")]
        public IWebElement EngReading_Braile { get; set; }


        ////////////////////// for Mathematics //////////////////////////////

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8b1e29a76964904afba4a77e5197d94f94_REPEAT2_REPEAT1']")]
        public IWebElement Math_EP { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8b1e29a76964904afba4a77e5197d94f94_REPEAT2_REPEAT2']")]
        public IWebElement Math_MLP { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8b1e29a76964904afba4a77e5197d94f94_REPEAT2_REPEAT3']")]
        public IWebElement Math_Braille { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8b4e374af6fc56488a8a934be75b6d7456']")]
        public IWebElement Confirm_chckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='MainContent_CUSTOM_FIELD_bd50746c232d4bd981c38dd8018b3f8b02b7ec8e2a77463394be04dfbc2c7590']")]
        public IWebElement VerifyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='submit' and @id='MainContent_SubmitButton']")]
        public IWebElement SubmitBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#main")]
        public IWebElement FormSubmitConfMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Confirmed - privacy notices issued']/../input")]
        public IWebElement ConfirmedPrivecyNoticeIssuedRadionBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Privacy notices have not been issued']/../input")]
        public IWebElement PrivecyNoticeNotIssuedRadiobtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@class='context-box-warning context-text-warning']")]
        public IWebElement PrivecyNoticeNotIssuedErrorMsg { get; set; }


        #endregion
    }
}
