using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
   public class KSTwoTestOrderPage
    {

        public KSTwoTestOrderPage(IWebDriver driver) {

            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//label[text()='Your email address']/../input")]
        public IWebElement YourEmailAddressTextBox { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Your full name']/../input")]
        public IWebElement YourFullNameTextBox { get; set; }


                

        [FindsBy(How = How.XPath, Using = "//*[text()='Last person to update order']/../../input")]
        public IWebElement LastPersonToUpdateOrder { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[text()='Email address']/../../input")]
        public IWebElement EmailAddress { get; set; }

       


        [FindsBy(How = How.XPath, Using = "//label[text()='Confirmed - privacy notices issued']/../input")]
        public IWebElement ConfirmedPrivecyNoticeIssuedRadionBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Privacy notices have not been issued']/../input")]
        public IWebElement PrivecyNoticeNotIssuedRadiobtn { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@value='Yes']")]
        public IList<IWebElement> YesRadioButtons { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='No']")]
        public IList<IWebElement> NoRadioButtons { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Paper')]/../input[@type='text']")]
        public IList<IWebElement> PaperTextBoxes { get; set; }

    }
}
