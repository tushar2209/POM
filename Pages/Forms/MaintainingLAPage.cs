using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
    class MaintainingLAPage
    {

        public MaintainingLAPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

  
        [FindsBy(How = How.XPath, Using = "//li[@class='ui-menu-item']")]

        public IList<IWebElement> LADrpdownOptions { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'ui-autocomplete-input')]")]
        public IWebElement LADropdown { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='formsummary']/strong[text()='Review your application']")]
        public IWebElement ReviewText { get; set; }



        #region   Application from section
        // Contact details 
        [FindsBy(How = How.XPath, Using = "//label/span[text()='Contact first name']/../../input")]
        public IWebElement ContactFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Contact last name']/../input")]
        public IWebElement ContactLastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Job title']/../../input")]
        public IWebElement JobTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Email address']/../../input")]
        public IWebElement EmailAddress { get; set; }

        [FindsBy(How = How.XPath, Using = "//label/span[text()='Telephone number']/../../input")]
        public IWebElement TelephoneNumber { get; set; }

        #endregion



    }
}
