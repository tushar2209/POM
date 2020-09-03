using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
    class MarkerTrainingConfirmationPage
    {

        public MarkerTrainingConfirmationPage(IWebDriver driver) {

            PageFactory.InitElements(driver,this);
        }

       

        [FindsBy(How = How.XPath, Using = "//label[text()='Training attended']/../input[@type='checkbox']")]
        public IWebElement ConfirmTrainingAttendCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Visual check']/../input[@type='checkbox']")]
        public IWebElement ConfirmVisualCheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='RTW description']/../input")]
        public IWebElement RTWDescription { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@ctrltype='date']//select")]
        public IList<IWebElement> RTWDOcExppriryDate { get; set; }

        [FindsBy(How = How.ClassName, Using = "saveFileId")]
        public IList<IWebElement> fileUploads { get; set; }



    }
}
