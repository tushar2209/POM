using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
    class SQAPortalContactManagementPage
    {
        public SQAPortalContactManagementPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//input[@type='radio' and @value='Create new SQA contact']")]
        public IWebElement CreateNewSQA { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='radio' and @value='Update existing SQA contact']")]
        public IWebElement UpdateExistingSQA { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='SQA contact first name']/..//input")]
        public IWebElement SQAFirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='SQA contact last name']/../input)[1]")]
        public IWebElement SQALastName { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='SQA contact middle name']/../input)[1]")]
        public IWebElement SQAMiddleName { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Job title']/../input)[1]")]
        public IWebElement JobTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='SQA contact email address']/../input)[1]")]
        public IWebElement SQAEmailAdd { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Confirm email address']/../input)[1]")]
        public IWebElement SQAConfirmEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='SQA contact telephone number']/../input)[1]")]
        public IWebElement SQAContactNo { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@type='checkbox' and @value='Scottish qualifications Authority - Super User'])[1]")]
        public IWebElement SQASuperUser { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@type='checkbox' and @value='Scottish qualifications Authority - User'])[1]")]
        public IWebElement SQANormalUSer { get; set; }
    }
}
