using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
    class OperationalIncResolutionPage
    {
        public OperationalIncResolutionPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//label[text()='Contact name']/..//input")]
        public IWebElement ContactName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Contact email']/..//input")]
        public IWebElement Contactemail { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Contact number']/..//input")]
        public IWebElement ContactNumber { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Contact reason']/../select)[1]")]
        public IWebElement ContactDisposition { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='KS1']/..//input")]
        public IWebElement ContactArea { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Area for KS1']/..//select")]
        public IWebElement AreaforKS1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Contact type']/..//select")]
        public IWebElement ContactType { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Marker']/..//select")]
        public IWebElement MarkerDropDown { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Email']/..//input")]
        public IWebElement CommunicationType { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Contact reason']/../select)[3]")]
        public IWebElement ContactReason { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='High']/..//input")]
        public IWebElement IssuePriority { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Type of issue']/..//select")]
        public IWebElement TypeofIssue { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Issue category']/..//select")]
        public IWebElement IssueCategory { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Site']/..//select")]
        public IWebElement Site { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Function']/..//select")]
        public IWebElement Function { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Date of issue occurence']/..//input")]
        public IWebElement DateofIssueOccurence { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Time of issue occurence']/..//input")]
        public IWebElement TimeofIssueOccurence { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Details of issue']/..//textarea")]
        public IWebElement DetailsofIssue { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Agent notes']/..//textarea")]
        public IWebElement AgentNotes { get; set; }

        [FindsBy(How = How.ClassName, Using = "saveFileId")]
        public IList<IWebElement> Attachments { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Activity']/..//select")]
        public IWebElement Activity { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Information (notes)']/..//textarea")]
        public IWebElement InformationNotes { get; set; }


        [FindsBy(How = How.XPath, Using = "(//label[text()='Review date']/..//input)[1]")]
        public IWebElement ReviewDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Review time']/..//input")]
        public IWebElement ReviewTime { get; set; }



    }
}
