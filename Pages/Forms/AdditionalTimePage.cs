using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
    class AdditionalTimePage
    {

        public AdditionalTimePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

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

        [FindsBy(How = How.XPath, Using = "//div[@ctrltype='rbtnlist']/span//input[@value='Yes']")]
        public IList<IWebElement> YesRadioBtns { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@ctrltype='rbtnlist']/span//input[@value='No']")]
        public IList<IWebElement> NoRadioBtns { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@ctrltype='rbtnlist']/div/span[@class='validationerror context-text-warning']")]
        public IList<IWebElement> QuestionErrorMsgs { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@ctrltype='textbox']/div/span[@class='validationerror context-text-warning']")]
        public IList<IWebElement> ContactDetailsErrorMsgs { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='custom-combobox']/input")]
        public IWebElement PupilDropDwn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".ui-autocomplete li[class='ui-menu-item']")]
        public IList<IWebElement> PupilDropDwnOptions { get; set; }


        [FindsBy(How = How.XPath, Using = "//b[text()='Advice 1: ']/following-sibling::mark[1]")]
        public IWebElement Advice1 { get; set; }


        [FindsBy(How = How.XPath, Using = "//mark[@id='marking2']")]
        public IList<IWebElement> AlternativeArrangements { get; set; }

        [FindsBy(How = How.XPath, Using = "//mark[@id='marking3']")]
        public IWebElement Advice3 { get; set; }

        [FindsBy(How = How.XPath, Using = "//mark[@id='marking4']")]
        public IWebElement Advice4 { get; set; }

        [FindsBy(How = How.XPath, Using = "//mark[@id='marking5']")]
        public IWebElement Advice5 { get; set; }

        [FindsBy(How = How.XPath, Using = "//mark[@id='marking6']")]
        public IWebElement Advice6 { get; set; }

        [FindsBy(How = How.XPath, Using = "//mark[@id='marking7']")]
        public IWebElement Advice7{ get; set; }

        [FindsBy(How = How.XPath, Using = "//mark[@id='marking3']")]
        public IWebElement Message { get; set; }


        [FindsBy(How = How.XPath, Using = "//mark[@id='marking4']/following-sibling::mark[1]/following-sibling::text()")]
        public IList<IWebElement> Advicess { get; set; }

       

        [FindsBy(How = How.XPath, Using = "//mark[@id='marking1']/../following-sibling::br[2]")]
        public IList<IWebElement> MessageADec { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='content-container-response']/div[1]")]
        public IWebElement ResponceBody { get; set; }


        [FindsBy(How = How.XPath, Using = "//select")]
        public IWebElement pupildrpdwn1 { get; set; }

        

    }
}
