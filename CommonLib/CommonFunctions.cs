using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using log4net;
using OpenQA.Selenium;
using STA__Automation.BaseLib;
using STA__Automation.Pages.Forms;
using STA__Automation.Pages.Portal;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace STA__Automation.CommonLib
{
    public class CommonFunctions
    {

        public static ILog log;
        public static CmLoginPage cmLoginPage;
        public static PortalLoginPage portalLoginPage;
        public static IWebDriver driver;
        public static SeleniumCommFunctions seleniumFunc;
        public static MyActivityPage myActivityPage;
        public static StartApplicationCommonPage startAppPage;
        public static ReviewAndSubmitCommonPage reviewAndSubmitPage;
        public static CM_ContactDetailsPage contactDetails;

        public static MoreInfromationCommPage moreInforPage;



        public CommonFunctions()
        {
            driver = BaseClass.GetDriver();
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            cmLoginPage = new CmLoginPage(driver);
            portalLoginPage = new PortalLoginPage(driver);
            myActivityPage = new MyActivityPage(driver);
            seleniumFunc = new SeleniumCommFunctions();
            startAppPage = new StartApplicationCommonPage(driver);
            reviewAndSubmitPage = new ReviewAndSubmitCommonPage(driver);
            cmLoginPage = new CmLoginPage(driver);
            contactDetails = new CM_ContactDetailsPage(driver);
            moreInforPage = new MoreInfromationCommPage(driver);


        }

        #region Page Methods
        /// <summary>
        /// 
        /// </summary>

        public void LoginIntoCM(string appUrl, string username, string pass)
        {
            try
            {
                LaunchApplication(appUrl);

                log.Info("Entering Username and Password.");
                seleniumFunc.WaitForElementToBeVisible(cmLoginPage.UserName);
                seleniumFunc.EnterText(cmLoginPage.UserName, username);

                seleniumFunc.EnterText(cmLoginPage.Password, pass);

                seleniumFunc.WaitAndClickOnElement(cmLoginPage.SubmitBtn);
                seleniumFunc.WaitForPageToLoad();
            }
            catch (Exception e)
            {
                log.Error(" Login to application failed due to -" + e.Message);

            }

        }



        public void LaunchApplication(String appUrl)
        {
            string url = GetDataFromAppConfig(appUrl);
            if (url != null)
                driver.Url = url;
            else
                driver.Url = appUrl;
            seleniumFunc.WaitForPageToLoad();
        }

        #endregion

        public static string GetProjectPath()
        {
            String path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            String actualPath = path.Substring(0, path.LastIndexOf("bin"));
            String projectPath = new Uri(actualPath).LocalPath;
            return projectPath;
        }

        public static String GetAppConfigValue(String key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public void LoginIntoPortal(String userName, String password)
        {
            try
            {
                SignOutUser();
                if (seleniumFunc.IsElementDisplayed(portalLoginPage.UserName))
                {

                    seleniumFunc.WaitForElementToBeVisible(portalLoginPage.UserName);
                    seleniumFunc.EnterText(portalLoginPage.UserName, userName);

                    seleniumFunc.EnterText(portalLoginPage.Password, password);

                    seleniumFunc.WaitAndClickOnElement(portalLoginPage.SignInBtn);
                    seleniumFunc.WaitForPageToLoad();
                    seleniumFunc.WaitForElementDissapper(By.XPath(portalLoginPage.LoadingSpinner));
                }
            }
            catch (Exception e)
            {
                log.Error(" Login to application failed due to -" + e.Message);

            }
        }

        /// <summary>
        /// Method to Logout Current user and Login with new user into portal
        /// </summary>
        /// <param name="appUrl"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void LogoutCurrentUserAndLoginAnotherUserToPortal(string appUrl, string userName, string password)
        {
            try

            {
                LaunchApplication(appUrl);
                SignOutUser();
                LaunchApplication(appUrl);

                seleniumFunc.WaitForPageToLoad();
                LoginIntoPortal(userName, password);
            }
            catch (Exception e)
            {
                log.Error(" Login to application failed due to -" + e.Message);

            }
        }

        public void SignOutUser()
        {
            if (seleniumFunc.IsElementDisplayed(portalLoginPage.LogddingUser))
            {
                seleniumFunc.WaitAndClickOnElement(portalLoginPage.LogddingUser);
                seleniumFunc.WaitAndClickOnElement(portalLoginPage.SignOut);
                seleniumFunc.WaitForPageToLoad();
                seleniumFunc.WaitAndClickOnElement(portalLoginPage.SignIn);
                seleniumFunc.WaitForPageToLoad();
            }
        }


        public void NaviagteToFormUnderMyActivity(IWebElement formName)
        {
            NavigateToMyActivitySection();
            NavigateToFormOfPortal(formName);
        }

        public void NavigateToMyActivitySection()
        {
           // closeOpenTabs();
            seleniumFunc.WaitForPageToLoad();
            if (!BaseClass.GetDriver().Title.Equals("My Activity"))
            {
                NavigateToMyActivity();

            }

        }

        public void NavigateToMyActivity() {
            seleniumFunc.WaitForEmentToBeClickable(portalLoginPage.MyActivityLink);
            seleniumFunc.Click(portalLoginPage.MyActivityLink);
            seleniumFunc.WaitForPageToLoad();
        }

        public void NavigateToFormOfPortal(IWebElement formName)
        {
            seleniumFunc.WaitAndClickOnElement(myActivityPage.AvailableActivity);

            seleniumFunc.WaitAndClickOnElement(formName);
            seleniumFunc.WaitForPageToLoad();


        }



        /// <summary>
        /// Method to check list values order are sorted or not.
        /// </summary>
        /// <param name="ListOfValues"> value list</param>
        /// <returns></returns>

        public bool SortedOrNot(string[] ListOfValues)
        {

            for (int i = 0; i < ListOfValues.Length; i++)
            {
                int temp = ListOfValues[i].CompareTo(ListOfValues[i + 1]);
                if (temp > 1)
                {
                    return false;
                }
            }
            return true;

        }
        /// <summary>
        /// Method to click Start appliation button of from 
        /// </summary>
        public void StartApplication()
        {
            seleniumFunc.SwitchToFrame(startAppPage.Iframe);
            ClickOnStartApplicationBtn();
            HandleCookiePopup();

        }

        public void ClickOnStartApplicationBtn() {
            if (seleniumFunc.IsElementDisplayed(startAppPage.StartButton))
            {
                seleniumFunc.WaitAndClickOnElement(startAppPage.StartButton);
                seleniumFunc.WaitForPageToLoad();
            }
        }

        /// <summary>
        /// Method to get value of any key from App config base on test envrionment
        /// </summary>
        /// <param name="key"> key</param>
        /// <returns></returns>
        public static string GetDataFromAppConfig(string key)
        {
            string value = "";
            string TestEnv = CommonFunctions.GetAppConfigValue("TestEnvironment");

            if (TestEnv.Equals("QA_ENV"))
            {

                value = CommonFunctions.GetAppConfigValue("QA_ENV_" + key);
            }
            else if (TestEnv.Equals("DEV_ENV"))
            {
                value = CommonFunctions.GetAppConfigValue("DEV_ENV_" + key);
            }
            else if(TestEnv.Equals("DEV_TEST_ENV")) {
                value = CommonFunctions.GetAppConfigValue("DEV_TEST_ENV_" + key);
            }
            return value;
        }


        public bool IsCommonFieldErrorMsgDisplayed()
        {
            seleniumFunc.WaitForElementToBeVisible(reviewAndSubmitPage.BackBtn);

            return seleniumFunc.IsElementDisplayed(reviewAndSubmitPage.MandFiledCommonErrorMsg);
        }

        /// <summary>
        /// Method to check madetory filed name on common error list on review page
        /// </summary>
        /// <param name="pageNo">eg 1, 2 note: Start page is consider as '0'</param>
        /// <param name="fieldName">field name</param>
        /// <returns></returns>
        public bool IsFieldNameApperOnErrorList(int pageNo, string fieldName)
        {
            IWebElement element = null;
            if (pageNo > 0)
            {
                pageNo = pageNo - 1;
                element = reviewAndSubmitPage.PageMandetoryFieldList[pageNo];
                seleniumFunc.ScrollElementInView(element);
            }

            string errorFields = seleniumFunc.GetAttributeValue(element,"innerHTML");
            return errorFields.Contains(fieldName) ? true : false;
        }

        /// <summary>
        /// Method to navigate to Incomplet page. Note: Introduction/ Start page is consider as 0 
        /// </summary>
        /// <param name="pageNumber">page nuber eg- 1 or 2 </param>
        public void NavigatetoIncompletePage(int pageNumber)
        {

            if (pageNumber > 0)
            {
                pageNumber = pageNumber - 1;
                seleniumFunc.Click(reviewAndSubmitPage.IncompletSectionPages[pageNumber]);
            }

            seleniumFunc.WaitForPageToLoad();
            seleniumFunc.WaitForLoaddingSpinnerDisapper();
        }

        public void NavigateBackToPreiousPages(int pageNumbers) {

            for (int i = 1; i <= pageNumbers; i++) {
                seleniumFunc.WaitAndClickOnElement(reviewAndSubmitPage.BackBtn);
                seleniumFunc.WaitForPageToLoad();
            }
        }

        /// <summary>
        /// Method to check is Submit button displayed on Review and Submit page.
        /// </summary>
        /// <returns>True/False</returns>
        public bool IsSubmitButtonDisplayed()
        {
            return seleniumFunc.IsElementDisplayed(reviewAndSubmitPage.SubmitBtn);
        }

        /// <summary>
        /// Method to check is Application Review PDf button displayed on Review and Submit page.
        /// </summary>
        /// <returns>True/False</returns>
        public bool IsApplicationReviewPdfDisplayed()
        {
            return seleniumFunc.IsElementDisplayed(reviewAndSubmitPage.ReviewPdfBtn);
        }

        /// <summary>
        /// Method to submit  form
        /// </summary>
        public string SubmitForm()
        {
            string caseRefeNumber = "";
            seleniumFunc.WaitAndClickOnElement(reviewAndSubmitPage.SubmitBtn);
            seleniumFunc.WaitForPageToLoad();

            caseRefeNumber=GetReferanceCode();
            return caseRefeNumber;
        }

        /// <summary>
        /// Method to select Date form Date picker 
        /// </summary>
        /// <param name="element">DateElemet</param>
        /// <param name="date">date e.g.- 12-Dec-2018</param>
        public void SelectDateFromDatePicker(IWebElement element, string date)
        {
            //GetReqFromatDate(date, "MM-DD-yyyy");
            string[] date1 = date.Split('-');
            string date2 = date1[0];
            string month = date1[1];
            string year = date1[2];
            seleniumFunc.WaitForElementToBeVisible(element);
            seleniumFunc.ScrollElementInView(element);
            seleniumFunc.Click(element);
            seleniumFunc.WaitForElementToBeVisible(startAppPage.DatePickerYearDropDwn);
            seleniumFunc.SelectValueFromDropDwn(startAppPage.DatePickerYearDropDwn, year);
            seleniumFunc.SelectValueFromDropDwn(startAppPage.DatePickerMonthDropDwn, month);
            Thread.Sleep(1000);

            foreach (IWebElement d in startAppPage.DatePickerDates.FindElements(By.TagName("td")))
            {
                if (d.Text.Equals(date2))
                {
                    seleniumFunc.Click(d);
                    Thread.Sleep(1000);
                    break;
                }
            }


        }


        /// <summary>
        /// Method to select Date form Date Drop dwons 
        /// </summary>
        /// <param name="element">DateElemet</param>
        /// <param name="date">date e.g.- 12-Dec-2018</param>
        public void SelectDateFromDateDropDown(IList<IWebElement> element, string date)
        {
            
            string[] date1 = GetReqFromatDate(date, "dd-MMMM-yyyy").Split('-');
            string date2 = date1[0];
            string month = date1[1];
            string year = date1[2];
            seleniumFunc.WaitForElementToBeVisible(element[0]);
            seleniumFunc.ScrollElementInView(element[0]);
            seleniumFunc.SelectValueFromDropDwn(element[2], year);
            Thread.Sleep(500);
            seleniumFunc.SelectValueFromDropDwn(element[1], month);
            Thread.Sleep(500);
            seleniumFunc.SelectValueFromDropDwn(element[0], date2);
            Thread.Sleep(500);

        }


        /// <summary>
        /// Method To get Application submittion message
        /// </summary>
        /// <returns></returns>
        public string GetFormSubmissionConfirmationMsg()
        {
            string confirmationMsg = "";
            seleniumFunc.WaitForPageToLoad();

            if (seleniumFunc.IsElementDisplayed(reviewAndSubmitPage.ApplicationSubMissionConfMsg))
            {
                seleniumFunc.ScrollElementInView(reviewAndSubmitPage.ApplicationSubMissionConfMsg);
                confirmationMsg = reviewAndSubmitPage.ApplicationSubMissionConfMsg.Text;
            }
            else if (seleniumFunc.IsElementDisplayed(reviewAndSubmitPage.ApplicationSubMissionErrorMsg))
            {

                seleniumFunc.ScrollElementInView(reviewAndSubmitPage.ApplicationSubMissionErrorMsg);
                confirmationMsg = reviewAndSubmitPage.ApplicationSubMissionErrorMsg.Text;
            }
           


            //  confirmationMsg = notificationPage.ApplicationSubMissionConfMsg.GetAttribute("innerHTML");
            confirmationMsg = confirmationMsg.Replace("\r", "");
            confirmationMsg = confirmationMsg.Replace("\t", "");
            confirmationMsg = confirmationMsg.Replace("\n", "");
            return confirmationMsg;
        }

        /// <summary>
        /// Method to Search and open case referance - Case Manager
        /// </summary>
        /// <param name="caseRefeNo"> Case Referance Number</param>
        /// <param name="userEmailaddress"> EmailAddress of user who has created request </param>
        /// <param name="caseRefStatus">caseRefeStatus</param>
        public void searchAndOpenCaseReferance(string caseRefeNo, string userEmailaddress, string caseRefStatus)
        {
            SearchCaseReferance(caseRefeNo, userEmailaddress, caseRefStatus);
            OpenCaseReferance();

        }

        public void OpenCaseReferance() {
            if (seleniumFunc.IsElementDisplayed(contactDetails.FirstCaseRefs[0]))
                seleniumFunc.WaitAndClickOnElement(contactDetails.FirstCaseRefs[0]);

            seleniumFunc.WaitForPageToLoad();

        }

        public void SearchCaseReferance(string caseRefeNo, string userEmailaddress, string caseRefStatus) {
            seleniumFunc.WaitForPageToLoad();
            seleniumFunc.WaitAndEnterText(cmLoginPage.SearchCaseRefeTextBox, caseRefeNo);
            if (userEmailaddress != null)
                seleniumFunc.EnterText(cmLoginPage.emailAddressTextBox, userEmailaddress);
            if (caseRefStatus != null)
                seleniumFunc.SelectValueFromDropDwn(cmLoginPage.StatusDropdwn, caseRefStatus);
            seleniumFunc.WaitAndClickOnElement(cmLoginPage.SearchBtn);
            seleniumFunc.WaitForPageToLoad();
        }


        /// <summary>
        /// Method to Open Create new From  in Case Manager
        /// </summary>
        /// <param name="formName">from Name </param>

        public void CreateNewFrom(string formName)
        {

            seleniumFunc.WaitAndClickOnElement(contactDetails.CreateNewFormLink);
            seleniumFunc.WaitForPageToLoad();
            if (formName != null)
            {
                seleniumFunc.WaitAndEnterText(contactDetails.FormInputBox, formName.Substring(0, formName.Length - 1));
                Thread.Sleep(1000);
                foreach (IWebElement ele in contactDetails.CreateFormOptions)
                {
                    if (ele.Text.Equals(formName))
                    {
                        ele.Click();
                        Thread.Sleep(1000);
                        break;
                    }
                }
                seleniumFunc.ClickOnElement(contactDetails.CreateFormSaveBtn);
                seleniumFunc.WaitForPageToLoad();
                HandleCookiePopup();

            }
        }

        /// <summary>
        /// Method to select Decisoon and Enter Reason for Decision
        /// </summary>
        /// <param name="decision">Approved/ Rejected/..</param>
        /// <param name="decisonReason">text</param>
        public void SelectDecission(string decision, string decisonReason)
        {

            if (decision.Equals("Approved"))
            {
                seleniumFunc.ClickOnElement(reviewAndSubmitPage.ApprovedRadioBtn);
                seleniumFunc.WaitForPageToLoad();
                seleniumFunc.WaitAndEnterText(reviewAndSubmitPage.ReasonForDecisionTextBoxes[0], decisonReason);
            }
            else if (decision.Equals("Rejected"))
            {
                seleniumFunc.ClickOnElement(reviewAndSubmitPage.RejectedRadioBtn);
                seleniumFunc.WaitForPageToLoad();
                seleniumFunc.WaitAndEnterText(reviewAndSubmitPage.ReasonForDecisionTextBoxes[1], decisonReason);
            }
            else if (decision.Equals("More information required"))
            {
                try
                {
                    seleniumFunc.ClickOnElement(reviewAndSubmitPage.MoreInfroReqRadioBtn);
                    seleniumFunc.WaitForPageToLoad();
                    seleniumFunc.WaitForElementToBeVisible(reviewAndSubmitPage.MoreInfroReqRadioBtn);
                   
                    if (reviewAndSubmitPage.ReasonForDecisionTextBoxes.Count == 0) {
                        seleniumFunc.ClickOnElement(reviewAndSubmitPage.RejectedRadioBtn);
                        seleniumFunc.ClickOnElement(reviewAndSubmitPage.MoreInfroReqRadioBtn);
                        seleniumFunc.WaitForPageToLoad();
                    }

                    foreach(IWebElement ele in reviewAndSubmitPage.ReasonForDecisionTextBoxes) {
                        if (seleniumFunc.IsElementDisplayed(ele)) {
                            if (seleniumFunc.isElementEnabled(ele))
                            {
                                seleniumFunc.WaitAndEnterText(ele, decisonReason);
                                break;
                            }
                        }
                        
                    }

                   
                }
                catch (Exception e) { }


            }
        }



        /// <summary>
        /// Method to navigate next page
        /// </summary>
        public void NaviagteToNextPage()
        {
            seleniumFunc.WaitAndClickOnElement(startAppPage.NextBtn);
            seleniumFunc.WaitForPageToLoad();
            HandleCookiePopup();
            GetReferanceCode();

        }

        public void HandleCookiePopup()
        {
            try
            {
                if (startAppPage.CookiesCheckbox.Displayed)
                {
                    seleniumFunc.WaitAndClickOnElement(startAppPage.CookiesCheckbox);
                    seleniumFunc.WaitAndClickOnElement(startAppPage.CookiesContinueBtn);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        /// <summary>
        /// Method to closed opned tabs in portal
        /// </summary>
        public void closeOpenTabs()
        {
            do
            {
                foreach (IWebElement tab in myActivityPage.CloseTabs)
                {
                    seleniumFunc.Click(tab);
                    seleniumFunc.WaitForPageToLoad();

                }
            } while (myActivityPage.CloseTabs.Count != 0);

        }

        /// <summary>
        /// Method to get Past Future Date
        /// </summary>
        /// <param name="days">1 or 2 or 3 or -1</param>
        /// <param name="months">1 or 2 or 3 or -1</param>
        /// <param name="years">1 or 2 or 3 or -1</param>
        /// <param name="format">dd-MMM-yyyy</param>
        /// <returns></returns>

        public string GetPastOrFutureDate(int days, int months, int years, String format)
        {
            DateTime today = DateTime.Now;
            DateTime newDate = DateTime.Now;
            string updatedDate = "";
            if (years != 0)
            {
                newDate = today.AddYears(years);
            }
            if (months != 0)
            {
                newDate = today.AddMonths(months);
            }
            if (days != 0)
            {

                newDate = today.AddDays(days);
            }
            if (format != null)

                updatedDate = newDate.ToString(format);


            else
                updatedDate = newDate.ToString("dd-MMM-yyyy");

            return updatedDate;
        }

        public string GetPastOrFutureWeekDate(int weeks, string format)
        {
            DateTime today = DateTime.Now;

            string updatedDate = "";

            if (weeks != 0)
            {
                today = today.AddDays(7 * weeks);
            }

            if (format != null)

                updatedDate = today.ToString(format);

            else
                updatedDate = today.ToString("dd-MMM-yyyy");

            return updatedDate;

        }

        public string GetReqFromatDate(string d, string format) {
            DateTime date = DateTime.Parse(d);

            return string.Format("{0:"+format+"}", date);
            //return date.ToString(format);
        }


        /// <summary>
        /// Method to get current date 
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string GetCurrentDate(string format) {
            DateTime today = DateTime.Now;

            return string.Format("{0:" + format + "}", today);
            //return date.ToString(format);
        }

        /// <summary>
        /// Method to check madetory fields msg on Review and Submit page
        /// </summary>
        /// <param name="pageNumber">1or 2</param>
        /// <param name="fieldsErrorList"> Error Msgs</param>
        /// <returns></returns>
        public string CheckMandetoryFieldsMsgOnReviewAndSubmitPage(int pageNumber, string fieldsErrorList)
        {
            string errorMsg = "";
            string[] errorFields = fieldsErrorList.Split(';');

            foreach (string field in errorFields)
            {
                if (!IsFieldNameApperOnErrorList(pageNumber, field))

                    errorMsg = errorMsg + field + ": Error msg is not displayed.\n";
            }

            return errorMsg;

        }

        /// <summary>
        /// Method to open form from Ousting activity section
        /// </summary>
        /// <param name="formName"></param>

        public void OpenFormFromOutStadingActivity(string formName)
        {

            seleniumFunc.WaitForPageToLoad();
            NavigateToMyActivitySection();
            

            IList<IWebElement> OutStandingFromList = BaseClass.GetDriver().FindElements(By.XPath(myActivityPage.editLinks.Replace("$$", formName)));
            if (OutStandingFromList.Count > 1)
            {
                try
                {
                    seleniumFunc.WaitAndClickOnElement(OutStandingFromList[OutStandingFromList.Count - 1]);
                }
                catch (Exception e) { }
            }
                

            seleniumFunc.WaitForPageToLoad();

            seleniumFunc.SwitchToFrame(startAppPage.Iframe);

            if (seleniumFunc.IsElementDisplayed(startAppPage.StartButton))
                ClickOnStartApplicationBtn();
            HandleCookiePopup();
        }

        /// <summary>
        /// Method to Add Mor einromation of form
        /// </summary>
        /// <param name="AddtionalInformation"></param>
        /// <param name="UploadDoc1"></param>
        /// <param name="DocumentDecription1"></param>
        public void AddMoreInfromation(string AddtionalInformation, string UploadDoc1, string DocumentDecription1)
        {

            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string filePath = Path.Combine(projectPath, "TestData\\" + UploadDoc1);

            foreach (IWebElement ele in moreInforPage.AdditionalInformationTextArea) {
                if (ele.Enabled) {
                    seleniumFunc.WaitAndEnterText(ele, AddtionalInformation);
                    break;
                }
            }                

                if (!seleniumFunc.IsElementDisplayed(moreInforPage.UploadFileDescript1TextBox))
                    seleniumFunc.WaitAndClickOnElement(moreInforPage.AddDocumentBtn);
                seleniumFunc.WaitAndEnterText(moreInforPage.UploadFileDescript1TextBox, DocumentDecription1);

                seleniumFunc.EnterTextWithoutClear(moreInforPage.UploadFileInputbox, filePath);

                seleniumFunc.WaitForPageToLoad();
          
        }

        /// <summary>
        /// Metod to select checkboxes on review and Submit page 
        /// </summary>
        public void SelectTickToConfirmOnReviewAndSubmitPage()
        {

            foreach (IWebElement ele in reviewAndSubmitPage.TickToConfirmCheckBoxes)
            {
                seleniumFunc.WaitAndClickOnElement(ele);
            }
        }

        /// <summary>
        /// Method to submit form  woth select Tick toConfirm check boxes on review and submit page  
        /// </summary>
        /// <param name="TermAndCondtion"></param>
        public string SubmitForm(bool TermAndCondtion)
        {
            if (TermAndCondtion)
                SelectTickToConfirmOnReviewAndSubmitPage();
            return SubmitForm();



        }

        public void ClickOnCreateMarker(string appurl)
        {
           // seleniumFunc.WaitAndClickOnElement();
        }

        /// <summary>
        /// Method to get addtional infromation field value from re- reivew form
        /// </summary>
        /// <returns></returns>
        public List<string> GetReReviewFormAddtionalInfoValue() {
            List<string> AddtionalInfoFieldsValue = new List<string>();
            foreach (IWebElement ele in reviewAndSubmitPage.ReReviewFormAddtionalInfoTextBoxes) {
                AddtionalInfoFieldsValue.Add(ele.GetAttribute("value"));

            }
            return AddtionalInfoFieldsValue;
        }


        public int GetReReviewFormDownLoadBtnCount()
        {
            return reviewAndSubmitPage.ReReviewFormDownloadDocBtns.Count;
        }

        public string GetReferanceCode() {

            string caseRefeNumber = "";
            if (seleniumFunc.IsElementDisplayed(reviewAndSubmitPage.ApplicationCaseReferNumber))
            {
                seleniumFunc.ScrollElementInView(reviewAndSubmitPage.ApplicationCaseReferNumber);
                caseRefeNumber = seleniumFunc.GetText(reviewAndSubmitPage.ApplicationCaseReferNumber);
            }
            return caseRefeNumber;
        }

        /// <summary>
        /// Method to click on verify button of form
        /// </summary>
        public void ClickOnVerifyFormBtn() {
            seleniumFunc.WaitAndClickOnElement(reviewAndSubmitPage.VerifyBtn);
            seleniumFunc.WaitForPageToLoad();
            seleniumFunc.WaitForElementToBeVisible(reviewAndSubmitPage.VerifyBtn);

        }
        /// <summary>
        /// To upload Doucment on page
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="ele"></param>
        public void UploadDocuments(string fileName, IWebElement ele)
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string filePath = Path.Combine(projectPath, "Resources\\" + fileName);
            seleniumFunc.EnterTextWithoutClear(ele, filePath);
            seleniumFunc.WaitForPageToLoad();
        }
        public IList<IWebElement> GetIncompletFormsCmFromExpandView(string formDescription)
        {
            IList<IWebElement> records = BaseClass.GetDriver().FindElements(By.XPath(cmLoginPage.FormEditLinkFromCmFromExpandView.Replace("$$", formDescription)));
            return records;
        }


    
       /// <summary>
        /// Method to navigate backl to case manager page (Contact page)
        /// </summary>
        public void NavigateBackToCaseManager()
        {
            seleniumFunc.WaitAndClickOnElement(cmLoginPage.BackToCaseManagerBtn);
            seleniumFunc.WaitForPageToLoad();
        }
 

        /// <summary>
        /// Method to open incomplet form from CM-> Contact page
        /// </summary>
        /// <param name="formDescription"></param>
        public void openedInCompetFormCmFromExpandView(string formDescription)
        {

            IList<IWebElement> InCompleteRecords = GetIncompletFormsCmFromExpandView(formDescription);
            foreach (IWebElement IncompletForm in InCompleteRecords)
            {
                seleniumFunc.WaitAndClickOnElement(IncompletForm);
                seleniumFunc.WaitForPageToLoad();
                break;

            }
        }
        /// <summary>
        /// Method to verifyis doucment downloaded
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool IsDoucmentDownloaded(string fileName)
        {
            string DownloadedfilePath = Path.Combine(GetProjectPath(), "Resources\\Downloads\\"+fileName);

            bool fileExists = (System.IO.File.Exists(DownloadedfilePath) ? true : false);
            return fileExists;
        }

        /// <summary>
        /// Method to download document 
        /// </summary>
        /// <param name="ele"></param>
        public void DownloadDocument(IWebElement ele) {

            string[] filePaths = Directory.GetFiles(Path.Combine(GetProjectPath(), "Resources\\Downloads\\"));
            foreach (string filePath in filePaths)
                File.Delete(filePath);

            seleniumFunc.WaitAndClickOnElement(ele);
            seleniumFunc.WaitForPageToLoad();


        }

    }
}  
