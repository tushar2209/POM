using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
    class CM_UserCreationPage
    {

        #region UserCreationPage Constructor
        public CM_UserCreationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #endregion

        #region School user loctors 

        [FindsBy(How = How.XPath, Using = "//input[@value='Update existing portal contact']")]
        public IWebElement UpdateContactRadio { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Create new portal contact']")]
        public IWebElement CreateNewContactRadio { get; set; }

       

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'contacts first name')]/../input")]
        public IList<IWebElement> NewContactFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'contacts last name')]/../input")]
        public IList<IWebElement> NewContactSurname { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Job title')]/../input")]
        public IList<IWebElement> JobTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'What is the new portal contacts email address')]/../input")]
        public IList<IWebElement> EmailAdd { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Confirm')]/../input")]
        public IList<IWebElement> ConfirmEmailAdd { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'contacts telephone number')]/../input")]
        public IList<IWebElement> TelephoneNo { get; set; }


        /////////////////////Checkbox to Select Portal Contact Role///////////////////////////////////


        [FindsBy(How = How.XPath, Using = "//input[@value='Schools - Head Teacher']")]
        public IList<IWebElement> HeadTeacherCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Schools - Super User']")]
        public IList<IWebElement> SuperUserCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Schools - User']")]
        public IList<IWebElement> NormalUserCheckbox { get; set; }

       

        [FindsBy(How = How.XPath, Using = " //p[@class='context-box-warning context-text-warning']/strong/span")]
        public IWebElement  UserCreationLimitMsg { get; set; }

        #endregion
        #region LA from creation

        [FindsBy(How = How.XPath, Using = "//label/../input")]
        public IList<IWebElement> LACreationTextboxes { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Role']/../select")]
        public IWebElement LACreationRole { get; set; }

        #endregion

    }
}