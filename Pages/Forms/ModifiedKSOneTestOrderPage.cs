using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
   public class ModifiedKSOneTestOrderPage
    {
        #region ModifiedKSOneTestOrderPage Constructor
        public ModifiedKSOneTestOrderPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #endregion

        #region Page Object


        [FindsBy(How = How.XPath, Using = "//label[text()='Your full name']/..//input")]
        public IWebElement YourFullName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Your email address']/..//input")]
        public IWebElement YourEmail { get; set; }


        [FindsBy(How = How.XPath, Using = "//label/span[text()='Last person to update order']/../following-sibling::input")]
        public IWebElement LastPersonFullName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Email address']/../following-sibling::input")]
        public IWebElement LastPersonEmail { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Total number of pupils requiring modified tests']/..//input")]
        public IWebElement TotalPupilReqModifiedTest { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Number of pupils with visual impairment']/..//input")]
        public IWebElement NoPupilVisualImpairment { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Number of pupils with other special needs']/../input")]
        public IWebElement NoPupilOtherSpecialNeeds { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='English reading modified large print (MLP)']/..//input")]
        public IWebElement EnglishReadingMLP { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='English reading braille']/..//input")]
        public IWebElement EnglishReadingBraille { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[text()='English reading modified large print (MLP)']/../../div//strong[text()='Warning: A large quantity has been entered.']")]
        public IWebElement EnglishReadingMLPErrorMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='English reading braille']/../../div//strong[text()='Warning: A large quantity has been entered.']")]
        public IWebElement EnglishReadingBrailleErrorMsg { get; set; }




        [FindsBy(How = How.XPath, Using = "//label[text()='English grammar, punctuation and spelling MLP']/..//input")]
        public IWebElement EnglishGrammergMLP { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='English grammar, punctuation and spelling braille']/../input")]
        public IWebElement EnglishGrammergBraille { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[text()='English grammar, punctuation and spelling MLP']/../../div//strong[text()='Warning: A large quantity has been entered.']")]
        public IWebElement EnglishGrammergMLPErrorMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='English grammar, punctuation and spelling braille']/../../div//strong[text()='Warning: A large quantity has been entered.']")]
        public IWebElement EnglishGrammergBrailleErrorMsg { get; set; }



        [FindsBy(How = How.XPath, Using = "//label[text()='Mathematics MLP']/..//input")]
        public IWebElement MathematicsMLP { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Mathematics braille']/..//input")]
        public IWebElement MathematicsBraille { get; set; }


        

        [FindsBy(How = How.XPath, Using = "//*[text()='Mathematics MLP']/../../div//strong[text()='Warning: A large quantity has been entered.']")]
        public IWebElement MathematicsMLPErrorMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='Mathematics braille']/../../div//strong[text()='Warning: A large quantity has been entered.']")]
        public IWebElement MathematicsBrailleErrorMsg { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Confirmed - privacy notices issued']/../input")]
        public IWebElement ConfirmedPrivecyNoticeIssuedRadionBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Privacy notices have not been issued']/../input")]
        public IWebElement PrivecyNoticeNotIssuedRadiobtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@class='context-box-warning context-text-warning']")]
        public IWebElement PrivecyNoticeNotIssuedErrorMsg { get; set; }



        #endregion
    }
}
