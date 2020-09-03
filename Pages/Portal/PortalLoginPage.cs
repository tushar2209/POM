using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Portal
{
    public class PortalLoginPage
    {

        #region Portal Login Constructor
        public PortalLoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        #endregion

        #region Page Objects
        [FindsBy(How = How.Id, Using = "username-input")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "password-input")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Name, Using = "_login")]
        public IWebElement SignInBtn { get; set; }
        #endregion



        [FindsBy(How = How.Id, Using = "capita-myactivitybadge-widget-container")]
        public IList<IWebElement> ActivityBadgeList { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@id='capita-myprofile-widget-container-mobile']//li//a")]
        public IWebElement MyActivityLink { get; set; }



        [FindsBy(How = How.CssSelector, Using = "#profile_nav")]
        public IWebElement LogddingUser { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#logout a")]
        public IWebElement SignOut { get; set; }

       

        [FindsBy(How = How.XPath, Using = " //a[text()=' Sign In ']")]
        public IWebElement SignIn { get; set; }


        public string LoadingSpinner = "//img[@class='loader-wheel']";
    }
}
