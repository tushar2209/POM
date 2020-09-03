using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
   public class ConfirmHolidayDatesPage
    {

        public ConfirmHolidayDatesPage(IWebDriver driver) {
            PageFactory.InitElements(driver, this);
        }

        #region   
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

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Start date')]/../div[1]/input[1]")]
        public IList<IWebElement> StartDates { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'End date')]/../div[1]/input[1]")]
        public IList<IWebElement> EndDates { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='Yes']")]
        public IWebElement NextAcademicHolidaysYesRadioBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[value='No']")]
        public IWebElement NextAcademicHolidaysNoRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Start date')]/../div[1]/span[@class='validationerror context-text-warning']")]
        public IList<IWebElement> StartDateMandErrorMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'End date')]/../div[1]/span[@class='validationerror context-text-warning']")]
        public IList<IWebElement> EndtDateMandErrorMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Do you wish to add holidays for the next academic year?']/../div/span")]
        public IWebElement NextAcademicHolidaysMandErrorMsg { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id='MainContent_SubmitButton']")]
        public IWebElement SubmitBtn { get; set; }


        [FindsBy(How = How.XPath, Using = "//a[text()='X']")]
        public IList<IWebElement> ClearDates { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[@class='context-box-warning context-text-warning']")]
        public IList<IWebElement> DatesValidatetionMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='form-group']//span/strong)")]
        public IList<IWebElement> DatesWarrningMsg { get; set; }


    }
}
