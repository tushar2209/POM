using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
    class ScaningExceptionResolution
    {

        public ScaningExceptionResolution(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@name='ctl00$MainContent$ApplyButton']")]
        public IWebElement Start { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Resolved']")]
        public IWebElement Resolved { get; set; }


        [FindsBy(How = How.XPath, Using = "//textarea[@name='ctl00$MainContent$CUSTOM_FIELD_53c77c5ff5894222847f4e92d5d221bf933881f72bf246828a36e843fc3a6f6e_REPEAT1']")]
        public IWebElement Notes { get; set; }

        [FindsBy(How = How.XPath, Using = "//span/input[@id='MainContent_CUSTOM_FIELD_53c77c5ff5894222847f4e92d5d221bf6602bcce1fac4516b3ec4b26a3f17c87']")]
        public IWebElement NotCreateClosure { get; set; }

    }
}
