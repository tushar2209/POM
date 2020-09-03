using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
    public class LodgeComplaintPage
    {
        public LodgeComplaintPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //label[text()='Please enter details below regarding the nature of your query']/span/../../textarea


        [FindsBy(How = How.XPath, Using ="//label[text()='Enquiry type']/span/../../select")]
        public IWebElement EnquiryTypedrpdown { get; set; }


        //[FindsBy(How = How.XPath, Using = "//label[text()='Enquiry type']/span/../../select/option[@value='Appeal']")]
        //public IWebElement Selectappeal { get; set; }

        [FindsBy(How = How.XPath, Using ="//label[text()='Please select the category to which your complaint relates']/span/../../select")]
        public IWebElement ComplaintReleated { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Please provide further details regarding the nature of your complaint']/span/../../textarea[@class='css-textarea']")]
        public IWebElement NatureOfQuery { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Please enter details below regarding the nature of your query']/span/../../textarea[@class='css-textarea']")]
        public IWebElement NatureOfQuery2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//label['Please provide further details regarding your appeal']/span/../../textarea[@id='MainContent_CUSTOM_FIELD_78f2b9c278434ca38dfd4d563a87592feead78b003ba4a778e52442c44b2b1fa']")]
        public IWebElement NaturofAppeal { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Please select the category to which your complaint relates']/span/../../select")]
        public IWebElement SelectAppeal { get; set; }


        [FindsBy(How = How.XPath, Using ="//label[text()='Name']/../input")]
        public IWebElement Name { get; set; }


        [FindsBy(How = How.XPath, Using ="//label[text()='Email address']/../input")]
        public IWebElement Emailaddress { get; set; }

       




    }
}
