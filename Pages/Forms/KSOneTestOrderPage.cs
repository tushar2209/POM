using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
   public class KSOneTestOrderPage
    {
        /// <summary>
        /// Method to Initialise page Opbjects
        /// </summary>
        /// <param name="driver"> driver</param>
        public KSOneTestOrderPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        // Contact details 
        [FindsBy(How = How.XPath, Using = "//input[@value='Yes']")]
        public IList<IWebElement> YesRadioButtons { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='No']")]
        public IList<IWebElement> NoRadioButtons { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Paper')]/../input[@type='text']")]
        public IList<IWebElement> PaperTextBoxes { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Your email address']/../input")]
        public IWebElement YourEmailAddressTextBox { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Your full name']/../input")]
        public IWebElement YourFullNameTextBox { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Confirmed - privacy notices issued']/../input")]
        public IWebElement ConfirmedPrivecyNoticeIssuedRadionBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Privacy notices have not been issued']/../input")]
        public IWebElement PrivecyNoticeNotIssuedRadiobtn { get; set; }


    }
}
