using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
    class BecomeMarkerPage
    {
        public BecomeMarkerPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }


       

        [FindsBy(How = How.XPath, Using = " //label[text()='Title']/../select")]
        public IWebElement TitleDropdwon { get; set; }

        // Contact details 
        [FindsBy(How = How.XPath, Using = "//label[text()='First name']/../div[@class='validationerror']")]
        public IWebElement FirstNameErrorMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='First name']/..//input")]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Last name']/..//input")]
        public IWebElement LastName{ get; set; }

            [FindsBy(How = How.XPath, Using = "//label[text()='Last name']/../div[@class='validationerror']")]
        public IWebElement LastNameErrorMsg { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Address line')]/../div[@class='validationerror'][2]")]
        public IList<IWebElement>AddressLineErrorMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Address line')]/..//input")]
        public IList<IWebElement> AddressLines { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Town/City']/../div[@class='validationerror'][2]")]
        public IWebElement TownErrorMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Town/City']/..//input")]
        public IWebElement TownAndCity { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Postcode']/../div[@class='validationerror'][2]")]
        public IWebElement PostcodeErrorMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Postcode']/..//input")]
        public IWebElement Postcode { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[text()='Region']/../select")]
        public IWebElement RegionDropDwon { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Region']/../div[@class='validationerror']")]
        public IWebElement RegionErrorMsg { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'number')]/../div[@class='validationerror'][2]")]
        public IList<IWebElement> ContactNumberErrorMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'number')]/..//input")]
        public IList<IWebElement> ContactNumber{ get; set; }


        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Email address')]/../div[@class='validationerror'][2]")]
        public IWebElement EmailAddressErrorMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'Email address')]/..//input")]
        public IWebElement EmailAddress { get; set; }


    }
}
