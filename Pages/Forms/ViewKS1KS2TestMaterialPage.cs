using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.Pages.Forms
{
    class KS2HeadteachersDeclarationFormPage
    {

        /// <summary>
        /// Method to Initialise page Opbjects
        /// </summary>
        /// <param name="driver"> driver</param>
        public KS2HeadteachersDeclarationFormPage (IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='file-download']//div[@class='file-download__description']/span")]
        public IList<IWebElement> DownloadFileNames { get; set; }

       public string DonwloadFileBtn ="//div[@class='file-download__description']/span[text()='$$']/../../input[@value='Download']";


        [FindsBy(How = How.XPath, Using = "//div[@class='file-download']//div[@class='file-download__description']/span")]
        public IList<IWebElement> SectionNames { get; set; }

        

        [FindsBy(How = How.XPath, Using = "(//div[@class='formQuestion ']//label[@class='QuestLabel'])[1]")]
        public IWebElement SubCategorySection { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='config-element css-panel'])[1]//label[@class='QuestLabel']")]
        public IList<IWebElement> SubjectSection { get; set; }


    }
}
