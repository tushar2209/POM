using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
    class EventLogsOfDownloadPage
    {

        public EventLogsOfDownloadPage(IWebDriver driver) {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//select")]
        public IWebElement DoucmentSDropDwn { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='css-calender']/input[1])[1]")]
        public IWebElement FromDate { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='css-calender']/input[1])[2]")]
        public IWebElement ToDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Search']")]
        public IWebElement SearchBtn { get; set; }

        public string SearchResult = "//table //tbody/tr//td[contains(text(),'$$')]";
    }
}
