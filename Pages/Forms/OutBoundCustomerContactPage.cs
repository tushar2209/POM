using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
    public class OutBoundCustomerContactPage
    {

        public OutBoundCustomerContactPage(IWebDriver driver)
        {

            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//label[text()='Dialed number']/../input")]
        public IList<IWebElement> DialedNumbers { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Contact name']/../input")]
        public IWebElement ContactName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Preferred number (if given)']/../input")]
        public IWebElement PreferredNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Outbound call outcome']/../select")]
        public IWebElement OutBondCallOutcomeDropdwon { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Schedule callback']/..//input[@type='radio']")]
        public IList<IWebElement> ScheduleCallbackRadiobtns { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Email for follow up:']/../input")]
        public IWebElement EmailForFollowup { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Agent notes' or text()='Agent Notes']/../textarea")]
        public IWebElement AgentNotesTextArea { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Name of person to call :']/../input")]
        public IWebElement NameOfPersonToCallTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Telephone number to call :']/../input")]
        public IWebElement TelePhNumToCallTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Date of follow up call :']/../div/input)")]
        public IList<IWebElement> DateOfFollowUpToCall { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Time of follow up call :']/../input")]
        public IWebElement TimeOfFollowUpToCallTextbox { get; set; }

        [FindsBy(How = How.ClassName, Using = "saveFileId")]
        public IList<IWebElement> UploadFile { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Description']/../input")]
        public IList<IWebElement> DescriptionTestBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Add']")]
        public IWebElement AddBtn { get; set; }


        /*********** Outbound Customer Contacts Call back Webelement *****/

        [FindsBy(How = How.XPath, Using = "//input[@disabled='disabled']")]
        public IList<IWebElement> PrePopulatedDetails { get; set; }


        [FindsBy(How = How.XPath, Using = "(//div[@class='css-calender']/input)[1]")]
        public IWebElement DateOfFollowUpCallDatePicker { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label)[2]/../input")]
        public IWebElement TimeOfFollowUpCall { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label)[3]/../input")]
        public IWebElement NameOfPersonToCall { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label)[4]/../input")]
        public IWebElement TelephoneNumberToCall { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label)[5]/../input")]
        public IWebElement EmailAddress { get; set; }


        [FindsBy(How = How.XPath, Using = " //input[@type='radio']")]
        public IList<IWebElement> OutcomeRadioBtns { get; set; }

    }
}
