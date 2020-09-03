using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
    class PupilCheatingPage
    {
        /// <summary>
        /// Method to Initialise page Opbjects
        /// </summary>
        /// <param name="driver"> driver</param>
        public PupilCheatingPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


        #region   Application from section
        // Contact details 
        [FindsBy(How = How.XPath, Using = "//*[text()='Contact first name']/../../input")]
        public IWebElement ContactFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Contact last name']/../input")]
        public IWebElement ContactLastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Job title']/../input")]
        public IWebElement JobTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Email address']/../../input")]
        public IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Telephone number']/../../input")]
        public IWebElement TelephoneNumber { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[@class='custom-combobox']/input")]
        public IWebElement PupilSelectionDropDwns { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ui-autocomplete li[class='ui-menu-item']")]
        public IList<IWebElement> AutoCompletDropDwnOptions { get; set; }


        [FindsBy(How = How.XPath, Using = "(//input[@type='radio'])")]
        public IList<IWebElement> TypeOfActionReqRadioBtns { get; set; }


        [FindsBy(How = How.XPath, Using = "(//span[@class='custom-combobox']/input)[2]")]
        public IWebElement TestDropDwn { get; set; }

       [FindsBy(How = How.XPath, Using = "//div[contains(@id,'_REPEAT')]//input[@type='text']")]
        public IList<IWebElement>  NoQMarkedRemoveTextBoxes { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'_addbutton')]")]
        public IWebElement AddQuestionBtn { get; set; }


        #endregion
    }
}