using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace STA__Automation.Pages.Forms
{
  public  class MoreInfromationCommPage
    {
        public MoreInfromationCommPage(IWebDriver driver) {

            PageFactory.InitElements(driver, this);

        }

        #region more infromation required from locators

        // [FindsBy(How = How.XPath, Using = "//label/span[text()='Further information required']/../../textarea")]
       
        [FindsBy(How = How.XPath, Using = "//*[text()='Further information required']/../../textarea")]
        public IWebElement FurtherInfRequiredTextArea { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[text()='Further information required']/../../../textarea")]
        public IWebElement FurtherInfRequiredTextArea1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[text()='Additional information' | text()='Additional Information' ]/../textarea")]
        public IList<IWebElement> AdditionalInformationTextArea { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@value='Select File'])[1]")]
              
        public IWebElement UploadFile1Inputbox { get; set; }

        [FindsBy(How = How.XPath, Using = " (//input[@type='file'])[1]")]
        public IWebElement UploadFileInputbox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@value='Select File'])[1]")]
        public IWebElement UploadFile2Inputbox { get; set; }

        [FindsBy(How = How.XPath, Using = "(//label[text()='Description']/../input)[1]")]
        public IWebElement UploadFileDescript1TextBox { get; set; }


        [FindsBy(How = How.XPath, Using = "(//label[text()='Description']/../input)[2]")]
        public IWebElement UploadFileDescript2TextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@id,'_addbutton')]")]
        public IWebElement AddDocumentBtn { get; set; }

        


        #endregion
    }
}
