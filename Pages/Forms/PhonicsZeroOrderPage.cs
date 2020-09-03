using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
    class PhonicsZeroOrderPage
    {
        /// <summary>
        /// Method to Initialise page Opbjects
        /// </summary>
        /// <param name="driver"> driver</param>
        public PhonicsZeroOrderPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        // Contact details 
        [FindsBy(How = How.XPath, Using = "//*[text()='Contact first name']/../../input")]
        public IWebElement ContactFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Contact last name']/../input")]
        public IWebElement ContactLastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Job title']/../input")]
        public IWebElement JobTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Email address']/../input")]
        public IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Telephone number']/../input")]
        public IWebElement TelephoneNumber { get; set; }
               

        [FindsBy(How = How.XPath, Using = " //input[@type='checkbox']")]
        public IWebElement ConfirmZeroOrderCheckBox { get; set; }

        
        [FindsBy(How = How.XPath, Using = "//span[contains (@id,'RequiredFieldValidatorChBox')]")]
        public IWebElement ConfirmZeroOrderCheckBoxErrorMsg { get; set; }


    }
}
