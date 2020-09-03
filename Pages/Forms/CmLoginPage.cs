using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
    public class CmLoginPage
    {
        #region CM Login Constructor
        public CmLoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        #endregion

        #region Page Objects
        [FindsBy(How = How.XPath, Using = "//input[@id='UserName']")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='Password']")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='submit' and @value='Log On' and @class='btn-submit']")]
        public IWebElement SubmitBtn { get; set; }

        #endregion

        #region CM DashBoard webelement 

        [FindsBy(How = How.CssSelector, Using = "input[id='MainContent_caseRef']")]
        public IWebElement SearchCaseRefeTextBox { get; set; }


        [FindsBy(How = How.CssSelector, Using = "input[id='MainContent_emailaddress']")]
        public IWebElement emailAddressTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "MainContent_SearchDropDownListStatus")]
        public IWebElement StatusDropdwn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id='MainContent_searchButton']")]
        public IWebElement SearchBtn { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#MainContent_GridViewContacts td a")]
        public IWebElement CaseRefeSearchResultRecord { get; set; }

        [FindsBy(How = How.Id, Using = "btnReturn")]
        public IWebElement BackToCaseManagerBtn { get; set; }

        public string FormEditLinkFromCmFromExpandView = "//table[@id='MainContent_cdgridview']//span[text()='$$']/../..//input[@data-tooltip='Edit form']";


        // public string FormEditLinkFromCmFromExpandView = "//table[@id='MainContent_cdgridview']//span[text()='$$']/../..//input[@data-tooltip='Edit form']";

        #endregion

//[FindsBy(How = How.Id, Using = "btnReturn")]
        //  public IWebElement BackToCaseManagerBtn { get; set; }
    }
}

