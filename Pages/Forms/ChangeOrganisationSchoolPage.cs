using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
    class ChangeOrganisationSchoolPage
    {

        public ChangeOrganisationSchoolPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "input#MainContent_ApplyButton")]
        public IWebElement StartFormBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//h2[@class='action-title']")]
        public IWebElement FormTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'School name')]/../input")]
        public IWebElement SchoolNameTextbox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[contains(text(),'Address:')]/..//div[contains(@class,'css-Address')]/input)[1]")]
        public IWebElement SchoolAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[contains(text(),'Address:')]/..//div[contains(@class,'css-Address')]/input)[5]")]
        public IWebElement SchoolPostcode { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Telephone number')]/../input")]
        public IWebElement TelephoneNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Email address')]/../input")]
        public IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//strong[text()='DfE number']/../../p")]
        public IWebElement SchoolDFENumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Telephone number')]/../div[2]/span")]
        public IWebElement TelephoneNumberErrorMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Email address')]/../div[2]/span")]
        public IWebElement EmailAddressErrorMsg { get; set; }





        // Contact details 
        [FindsBy(How = How.XPath, Using = "//label/span[text()='Contact first name']/../../input")]
        public IWebElement ContactFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Contact last name']/../input")]
        public IWebElement ContactLastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Job title']/../../input")]
        public IWebElement JobTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='User email address']/../../input")]
        public IWebElement UserEmailAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='User telephone number']/../../input")]
        public IWebElement UserTelephoneNumber { get; set; }

    }
}
