using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
    class KS2HeadTeacherDecPage
    {
        public KS2HeadTeacherDecPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//th[text()='Subject-Paper']/../../..//select)[1]")]
        public IWebElement SubjectPaper { get; set; }

        [FindsBy(How = How.XPath, Using = "(//th[text()='Subject-Paper']/../../..//input)[1]")]
        public IWebElement NumberOfTestScripts { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='I confirm that invited observers oversaw the administration of some or all of my school’s tests.']/..//input)[1]")]
        public IWebElement ConfirmRadioButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='I am unable to confirm all the statements below, but have let the Standards and Testing Agency (STA) know the reason why.']/..//input")]
        public IWebElement SectionAcheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='all test materials were kept secure and treated as confidential until the date of each test, except where permission for early opening was given by STA']/..//input")]
        public IWebElement SectionBFirstcheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='the tests were administered according to the published timetable except where a timetable variation was approved by STA']/..//input")]
        public IWebElement SectionBSecondcheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='all staff involved in the administrative arrangements confirmed that the tests were administered according to the 2020 test administration guidance']/..//input")]
        public IWebElement SectionBThirdcheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='the test scripts were stored securely immediately after each test and until they were dispatched for marking']/..//input")]
        public IWebElement SectionBFourthcheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='any incident which may have affected the integrity, security or confidentiality of the tests was reported to STA']/..//input")]
        public IWebElement SectionBFifthcheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Tick to confirm']/..//input")]
        public IWebElement TicktoConfirmcheckbox { get; set; }


    }
}
