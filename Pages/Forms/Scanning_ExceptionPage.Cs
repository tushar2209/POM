using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
    class Scanning_ExceptionPage
    {

        public Scanning_ExceptionPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//label[text()='Exception category']/span/../../select")]
        public IWebElement ExceptionCategory { get; set; }


        //[FindsBy(How = How.XPath, Using = "//label[text()='CIC Resolved']")]
        //public IWebElement CICClosure{ get; set; }




        [FindsBy(How = How.XPath, Using = "//label[text()='Site']/span/../../select")]
        public IWebElement Site { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Function']/span/../../select")]
        public IWebElement Function { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Test paper']/span/../../select")]
        public IWebElement TestPaper { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Batch ID']/span/../../input")]
        public IWebElement BatchID{ get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Description']/../textarea")]
        public IWebElement Description { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='MainContent_cdgridview_pencilbutton94789_0']")]
        public IWebElement ClickImageOfCM { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='MainContent_filter']")]
        public IWebElement ClickFilter { get; set; }
    }
}
