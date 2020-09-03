using OpenQA.Selenium;
using STA.Utilities.ExcelReader;
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
    class KS2HeadteachersDeclarationFormLib : BaseTestClass
    {
        public static KS2HeadTeacherDecPage ks2page;
        public static SeleniumCommFunctions seleniumFunc;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;
        public static ExcelUtil excelUtil;
        public static CommonFunctions commFunc;

        public void InitialisePageObjects()
        {
            ks2page = new KS2HeadTeacherDecPage(driver);
            myActivityPage = new MyActivityPage(driver);
            commFunc = new CommonFunctions();
        }

        public void SetUpPreCondition(string appURL)
        {
            driver = GetDriver();
            seleniumFunc = new SeleniumCommFunctions();
            log.Info("Test method setup started");
            InitialisePageObjects();
            comFunc = new CommonFunctions();

            log.Info("launch application");
            comFunc.LaunchApplication(appURL);
        }

        public void LoginAndNavigatToForm(string userName, string password)
        {

            log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);
            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.KS2headteacherdeclarationform);
        }

        public void FillKS2HeadTeacherForm(string subjectpaper,string nooftestscript)
        {
            seleniumFunc.SwitchToFrame(0);
            seleniumFunc.WaitAndEnterText(ks2page.NumberOfTestScripts, nooftestscript);
            seleniumFunc.SelectValueFromDropDwn(ks2page.SubjectPaper, subjectpaper);
            seleniumFunc.WaitAndClickOnElement(ks2page.ConfirmRadioButton);
        }

        public void SectionACheckBox()
        {
           
            seleniumFunc.WaitAndClickOnElement(ks2page.SectionAcheckbox);
        }

        public void SectionBCheckbox()
        {

            seleniumFunc.WaitAndClickOnElement(ks2page.SectionBFirstcheckbox);
            seleniumFunc.WaitAndClickOnElement(ks2page.SectionBSecondcheckbox);
            seleniumFunc.WaitAndClickOnElement(ks2page.SectionBThirdcheckbox);
            seleniumFunc.WaitAndClickOnElement(ks2page.SectionBFourthcheckbox);
            seleniumFunc.WaitAndClickOnElement(ks2page.SectionBFifthcheckbox);

        }
        public void ConfirmationCheckbox()
        {

            seleniumFunc.WaitAndClickOnElement(ks2page.TicktoConfirmcheckbox);
        }
    }
}
