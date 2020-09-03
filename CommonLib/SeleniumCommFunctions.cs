using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using RelevantCodes.ExtentReports.Model;
using STA__Automation.BaseLib;

namespace STA__Automation.CommonLib
{
    public class SeleniumCommFunctions
    {
        IWebDriver driver = BaseClass.GetDriver();
        public static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Method to clear and enter text 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public void EnterText(IWebElement element, string value)
        {
           // element.Clear();
            element.SendKeys(value);

        }

        /// <summary>
        /// Method to enter text without clear
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public void EnterTextWithoutClear(IWebElement element, string value)
        {
           element.SendKeys(value);

        }

        internal void WaitAndEnterText(object e)
        {
            throw new NotImplementedException();
        }

        public void WaitAndEnterText(IWebElement element, string value)
        {
           // WaitForEmentToBeClickable(element);
            EnterText(element, value);

        }

        public string GetText(IWebElement element)
        {
            WaitForElementToBeVisible(element);
            ScrollElementInView(element);
            return element.Text;
        }

        public string GetCssTagValue(IWebElement element, string TagName)
        {
            return element.GetCssValue(TagName);
        }

        public string GetAttributeValue(IWebElement element, string TagName)
        {
            ScrollElementInView(element);
            return element.GetAttribute(TagName);
        }



        public void WaitAndClickOnElement(IWebElement element)
        {
            WaitForEmentToBeClickable(element);
            ClickOnElement(element);

        }

        /// <summary>
        /// Method to click on element using Javascript function
        /// </summary>
        /// <param name="element"></param>
        public void ClickOnElement(IWebElement element)
        {
            ScrollElementInView(element);
            //element.Click();
            ClickOnElementViaJavaScript(element);
        }

        /// <summary>
        /// Method to Click On element using Selenium click function
        /// </summary>
        /// <param name="element"></param>
        public void Click(IWebElement element)
        {
            try
            {
                ScrollElementInView(element);
                element.Click();
            }
            catch (Exception e) {
                log.Info(e.Message);
            }


        }

        public void ClickOnElementViaJavaScript(IWebElement element) {
            try
            {
                ((IJavaScriptExecutor)BaseClass.GetDriver()).ExecuteScript("arguments[0].click();", element);
            }
            catch (Exception e) {
                log.Info(e.Message);
            }
            }

        internal void SelectValueFromDropDwn(IWebElement selectCategoryDrpDwn, object categorie)
        {
            throw new NotImplementedException();
        }

        public string GetSelectedTextFromDropdown(IWebElement element)
        {
            SelectElement elm = new SelectElement(element);
            string UIText = elm.SelectedOption.Text;
            return UIText;
        }

        /// <summary>
        /// Method to wait for element to be visisble on screen.
        /// </summary>
        /// <param name="element">WebElement</param>
        public void WaitForElementToBeVisible(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(BaseClass.GetDriver(), TimeSpan.FromSeconds(CommonConstants.MINI_WAIT));
            wait.Until(driver => element.Displayed);
        }

        public void WaitForPageToLoad()
        {
            IWait<IWebDriver> wait = new WebDriverWait(BaseClass.GetDriver(), TimeSpan.FromSeconds(CommonConstants.PAGE_LOAD_WAIT));
            try
            {
                Thread.Sleep(2500);
                wait.Until(driver => ((IJavaScriptExecutor)BaseClass.GetDriver()).ExecuteScript("return document.readyState").ToString() == "complete");
                WaitForLoaddingSpinnerDisapper();
            }
            catch (Exception e)
            {
                WaitForLoaddingSpinnerDisapper();
                Thread.Sleep(10000);

                log.Info("Error occure during page loading" + e.Message);
            }

        }

        public void WaitForEmentToBeClickable(IWebElement element)
        {

            IWait<IWebDriver> wait = new WebDriverWait(BaseClass.GetDriver(), TimeSpan.FromSeconds(CommonConstants.MINI_WAIT));
            try
            {

                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (Exception e)
            {
                log.Info("Page Loading spinner takes time to load page.");
            }

        }

        public Boolean IsElementDisplayed(IWebElement element)
        {

            Boolean isElementDisplayed = false;
            try
            {

                isElementDisplayed = element.Displayed;
                if (isElementDisplayed)
                    ScrollElementInView(element);
            }
            catch (Exception e)
            {
                log.Info("Element is not visible/ displayed on screen.");
            }
            return isElementDisplayed;
        }

        public Boolean isElementEnabled(IWebElement element)
        {

            Boolean isElementEnabled = false;
            try
            {

                isElementEnabled = element.Enabled;
            }
            catch (Exception e)
            {
                log.Info("Element is not enable on screen.");
            }
            return isElementEnabled;
        }


        public void WaitForElementDissapper(By element)
        {
            IWait<IWebDriver> wait = new WebDriverWait(BaseClass.GetDriver(), TimeSpan.FromSeconds(CommonConstants.PAGE_LOAD_WAIT));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(element));
        }

        /// <summary>
        /// Method to Select value form Autocomplet drodown.
        /// </summary>
        /// <param name="dropdwnElement"> dropdown Input box element</param>
        /// <param name="dropDwnOptionElementList"> dropdwon liat element</param>
        /// <param name="Value"> value</param>
        public void SelectValueFromAutoCompliteDropDown(IWebElement dropdwnElement, IList<IWebElement> dropDwnOptionsElements, String Value)
        {
            WaitAndClickOnElement(dropdwnElement);
            Thread.Sleep(500);
            EnterTextWithoutClear(dropdwnElement, Value.Substring(0, Value.Length - 1));
            Thread.Sleep(1000);
           foreach(IWebElement ele  in dropDwnOptionsElements)
            if (ele.Text.Equals(Value))
            {
                ele.Click();
                Thread.Sleep(1000);
                    break;
            }
        }

        /// <summary>
        /// Method to scroll element into view
        /// Method to scroll element into view
        /// </summary>
        /// <param name="element"></param>
        public void ScrollElementInView(IWebElement element)
        {

            ((IJavaScriptExecutor)BaseClass.GetDriver()).ExecuteScript("arguments[0].scrollIntoViewIfNeeded(true);", element);
            Thread.Sleep(1200);
        }


        public void SwitchToFrame(int number) {
            BaseClass.GetDriver().SwitchTo().Frame(number);
        }


        public void SwitchToFrame(string frameName)
        {
           
            BaseClass.GetDriver().SwitchTo().Frame(frameName);
          }
        /// <summary>
        /// Metho toscroll page down
        /// </summary>
        /// <param name="yPosition"></param>

        public void ScrollPageDown(int yPosition) {
            IJavaScriptExecutor js = (IJavaScriptExecutor)BaseClass.GetDriver();
        
            var jsScript = String.Format("window.scrollTo({0}, {1})", 0, yPosition);
            js.ExecuteScript(jsScript);
            Thread.Sleep(1000);
           
        }

        /// <summary>
        /// Method to select value from drop down using text. Note- Drop down is with select tag
        /// </summary>
        /// <param name="dropDwn"> WebElement</param>
        /// <param name="value"> value</param>
        public void SelectValueFromDropDwn( IWebElement dropDwn , String value ) {
            ScrollElementInView(dropDwn);
            SelectElement elm = new SelectElement(dropDwn);
            elm.SelectByText(value);

        }

        /// <summary>
        /// Method to select value from drop down using index. Note- Drop down is with select tag
        /// </summary>
        /// <param name="dropDwn"> WebElement</param>
        /// <param name="index"> option index</param>
        public void SelectValueFromDropDwn(IWebElement dropDwn, int index)
        {
            SelectElement elm = new SelectElement(dropDwn);
            elm.SelectByIndex(index);

        }

        /// <summary>
        /// Method to select value from drop down using value. Note- Drop down is with select tag
        /// </summary>
        /// <param name="dropDwn"> WebElement</param>
        /// <param name="value"> value</param>
        public void SelectValueFromDropDwnUsingValue(IWebElement dropDwn, String value)
        {
            SelectElement elm = new SelectElement(dropDwn);
            elm.SelectByValue(value);

        }

        

        /// <summary>
        /// Method to wait fro loadding spiiner disappers
        /// </summary>
        public void WaitForLoaddingSpinnerDisapper()
        {

            IWait<IWebDriver> wait = new WebDriverWait(BaseClass.GetDriver(), TimeSpan.FromSeconds(CommonConstants.LOADING_SPINNER_WAIT));
            try
            {   if( BaseClass.GetDriver().FindElement(By.Id("loaderSubmitImage")).Displayed)

                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("loaderSubmitImage")));
                else
                Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                log.Info("Loading Spinner did not disappeared");
            }
            
        }


        /// <summary>
        /// Method to wait fro loadding spiiner disappers
        /// </summary>
        public void WaitForLoaddingSpinnerDisapper(By element)
        {

            IWait<IWebDriver> wait = new WebDriverWait(BaseClass.GetDriver(), TimeSpan.FromSeconds(CommonConstants.LOADING_SPINNER_WAIT));
            try
            {
                if (BaseClass.GetDriver().FindElement(element).Displayed)

                    wait.Until(ExpectedConditions.InvisibilityOfElementLocated(element));
                else
                    Thread.Sleep(1000);
            }
            catch (Exception e)
            {
                log.Info("Loading Spinner did not disappeared");
            }

        }



        public void ClosedBrowser()
        {
            driver.Close();
        }

        public void ClosedAllBrowser()
        {
            driver.Quit();
        }

    }


}

