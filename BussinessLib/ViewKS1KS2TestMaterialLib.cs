using OpenQA.Selenium;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;
using STA__Automation.Pages.Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.BussinessLib
{
    class ViewKS1KS2TestMaterialLib : BaseTestClass
    {

        public static SeleniumCommFunctions seleniumFunc;
       
        public static KS2HeadteachersDeclarationFormPage viewKS1TestMaterialPage;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;

        /// <summary>
        ///  Method to  set up pre condition for test case.
        /// </summary>
        /// <param name="appURL">URL Application U</param>
        public void SetUpPreCondition(string appURL)
        {
            driver = GetDriver();
            seleniumFunc = new SeleniumCommFunctions();
            comFunc = new CommonFunctions();

            log.Info("Test method setup started");
            InitialisePageObjects();


            log.Info("launch application");
            comFunc.LaunchApplication(appURL);

        }

        /// <summary>
        /// Method to initialise  page objects
        /// </summary>
        public void InitialisePageObjects()
        {
            viewKS1TestMaterialPage = new KS2HeadteachersDeclarationFormPage(driver);
            myActivityPage = new MyActivityPage(driver);


        }

        /// <summary>
        /// Method to login to portal and navigate to MyActivity-> Available Activity -> View KS1 Test Material from
        /// </summary>
        /// <param name="userName"> userName</param>
        /// <param name="password">passWord</param>
      
        public void LoginAndNavigatToViewTestMaterialForm(string userName, string password, string formName)
        {
            comFunc.SignOutUser();

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            if(formName=="KS1")
           
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.ViewKS1TestMaterialFromLink);
            else if (formName == "KS2")
                comFunc.NaviagteToFormUnderMyActivity(myActivityPage.ViewKS2TestMaterialFromLink);
            else if (formName == "Phonics")
                comFunc.NaviagteToFormUnderMyActivity(myActivityPage.ViewPhonicsTestMaterialFromLink);
            else
                comFunc.NaviagteToFormUnderMyActivity(myActivityPage.ViewTeacherAssessmentTestMaterial);
        }




    
        public bool IsUploadedDocDisplayed(string fileName) {

            IWebElement ele = GetDriver().FindElement(By.XPath(viewKS1TestMaterialPage.DonwloadFileBtn.Replace("$$", fileName)));
            return seleniumFunc.IsElementDisplayed(ele);

        }

        public void DownloadDocument(string fileName) {
            IWebElement ele = GetDriver().FindElement(By.XPath(viewKS1TestMaterialPage.DonwloadFileBtn.Replace("$$", fileName)));
            comFunc.DownloadDocument(ele);
        }

        public string GetNameofViewScection(int sectionNo) {
            return seleniumFunc.GetText(viewKS1TestMaterialPage.SubjectSection[sectionNo]);
        }

        public string getSubCategoryOfViewMaterial() {
                             
           return seleniumFunc.GetText(viewKS1TestMaterialPage.SubCategorySection);

        }

    }
}
