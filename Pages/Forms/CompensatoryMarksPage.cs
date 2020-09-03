using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
    class CompensatoryMarksPage
    {

        public CompensatoryMarksPage(IWebDriver driver) {

            PageFactory.InitElements(driver, this);

        }

        // Contact details 
        [FindsBy(How = How.XPath, Using = "//*[text()='Contact first name']/../../input")]
        public IWebElement ContactFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Contact last name']/../input")]
        public IWebElement ContactLastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Job title']/../../input")]
        public IWebElement JobTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Email address']/../../input")]
        public IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Telephone number']/../../input")]
        public IWebElement TelephoneNumber { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[@class='custom-combobox']/input")]
        public IWebElement PupilSelectionDropDwns { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ui-autocomplete li[class='ui-menu-item']")]
        public IList<IWebElement> AutoCompletDropDwnOptions { get; set; }


        [FindsBy(How = How.XPath, Using = " //table//input")]
        public IList<IWebElement> ConfirmationCheckBoxes { get; set; }



        [FindsBy(How = How.XPath, Using = "//textarea")]
        public IWebElement ReasonForCompansantoryMarks { get; set; }
   

    }
}
