using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
    class ManagePupilRegistrationPage
    {

        /**
        * Method to Initialise  Page Object of respective page
        **/
        public ManagePupilRegistrationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #region Manage Pupil Registration page.

        [FindsBy(How = How.XPath, Using = "//span[text()='Add pupil(s)']")]
        public IWebElement AddPupilBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Verify']")]
        public IWebElement VerifyBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='TableWrapper'])[2]//th[text()='UPN']/../../../..//tr[1]//td[2]//input")]
        public IWebElement AddPupilUPN { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='TableWrapper'])[2]//th[text()='UPN']/../../../..//tr[1]//td[3]//input")]
        public IWebElement PupilFName { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='TableWrapper'])[2]//th[text()='UPN']/../../../..//tr[1]//td[4]//input")]
        public IWebElement PupilMName { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='TableWrapper'])[2]//th[text()='UPN']/../../../..//tr[1]//td[5]//input")]
        public IWebElement PupilLName { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@type='radio' and @value='M'])[1]")]
        public IWebElement PupilGenderMale { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@type='radio' and @value='F'])[1]")]
        public IWebElement PupilGenderFemale { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='TableWrapper'])[2]//th[text()='UPN']/../../../..//tr[1]//td[7]//input")]
        public IWebElement PupilDOB { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input[id='MainContent_SubmitButton']")]
        public IWebElement SubmitBtn { get; set; }


        #endregion Manage Pupil Registration page.
    }
}
