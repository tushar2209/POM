using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;

namespace STA__Automation.BussinessLib
{
    class CM_UploadTestMaterialLib : BaseTestClass
    {
        public static SeleniumCommFunctions seleniumFunc;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static CmUploadTestMaterialPage uploadTestMaterialPage;



        /// <summary>
        ///  Method to  set up pre condition for test case.
        /// </summary>
        
        public void SetUpPreCondition()
        {
            driver = GetDriver();
            seleniumFunc = new SeleniumCommFunctions();
            comFunc = new CommonFunctions();

            log.Info("Test method setup started");
            InitialisePageObjects();


        }

        /// <summary>
        /// Method to initialise  page objects
        /// </summary>
        public void InitialisePageObjects()
        {
            uploadTestMaterialPage = new CmUploadTestMaterialPage(driver);

        }

        /// <summary>
        /// Method to select Uplod popose 
        /// </summary>
        /// <param name="uploadNew">True/False</param>
        /// <param name="DeletePrevious">True/False</param>
        public void selectUploadDocumentType(bool uploadNew , bool DeletePrevious) {

            if (uploadNew)
            {
                seleniumFunc.WaitAndClickOnElement(uploadTestMaterialPage.UploadNewCheckBox);
            }
            if (DeletePrevious) {
                seleniumFunc.WaitAndClickOnElement(uploadTestMaterialPage.DeletePreviousCheckbox);
            }
            comFunc.NaviagteToNextPage();
        }

        public void DeletePreviouslyUploadTestMaterial() {
            seleniumFunc.WaitForPageToLoad();
            foreach (IWebElement ele in uploadTestMaterialPage.DeleteCheckBoxes) {

                seleniumFunc.WaitAndClickOnElement(ele);
            }
            comFunc.NaviagteToNextPage();

        }


        public void UploadDocuments(string fileName, IWebElement ele)
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string filePath = Path.Combine(projectPath, "Resources\\" + fileName);
            seleniumFunc.EnterTextWithoutClear(ele, filePath);
            seleniumFunc.WaitForPageToLoad();
        }

        public void FillUploadTestMaterialSection(string uploadFileName, string fileDec, String fromdate, string toDate) {

            UploadDocuments(uploadFileName, uploadTestMaterialPage.fileUploads[0]);

            seleniumFunc.WaitAndEnterText(uploadTestMaterialPage.fileUploadDescriptions[0],fileDec);

            comFunc.SelectDateFromDatePicker(uploadTestMaterialPage.FromDates[0], fromdate);
            comFunc.SelectDateFromDatePicker(uploadTestMaterialPage.ToDates[0], toDate);
        }

        public void FillUploadTestMaterialSection(int i, string uploadFileName, string fileDec, string fromdate, string toDate)
        {
          
                UploadDocuments(uploadFileName, uploadTestMaterialPage.fileUploads[i]);

                seleniumFunc.WaitAndEnterText(uploadTestMaterialPage.fileUploadDescriptions[i], fileDec);

                comFunc.SelectDateFromDatePicker(uploadTestMaterialPage.FromDates[i], fromdate);
                comFunc.SelectDateFromDatePicker(uploadTestMaterialPage.ToDates[i], toDate);
            
        }



        public void SelectCategoriesAndSubject(string catagiory,string subCategory ,string subject) {
            seleniumFunc.WaitForPageToLoad();
            seleniumFunc.SelectValueFromDropDwn(uploadTestMaterialPage.SelectCategoryDrpDwn[0],catagiory);
            seleniumFunc.WaitForPageToLoad();

            if (subCategory != null)
            {
                seleniumFunc.SelectValueFromDropDwn(uploadTestMaterialPage.SelectSubCategoryDrpDwn[0], subCategory);
                seleniumFunc.WaitForPageToLoad();
            }
            if (subject != null)
            {
                seleniumFunc.WaitForPageToLoad();
                seleniumFunc.SelectValueFromDropDwn(uploadTestMaterialPage.SelectSubjectDrpDwn[0], subject);
                seleniumFunc.WaitForPageToLoad();
            }
        }

        public void FillUploadtestMaterilForm(string[] catagiory, string[] subCategory, string[] subject, string uploadFileName, string[] fileDec, string fromdate, string toDate)
        {
            for (int i = 0; i < catagiory.Length; i++)
            {
                seleniumFunc.WaitForPageToLoad();
                seleniumFunc.SelectValueFromDropDwn(uploadTestMaterialPage.SelectCategoryDrpDwn[i], catagiory[i]);
                seleniumFunc.WaitForPageToLoad();

                seleniumFunc.SelectValueFromDropDwn(uploadTestMaterialPage.SelectSubCategoryDrpDwn[i], subCategory[i]);
                seleniumFunc.WaitForPageToLoad();
                if (subject != null)
                {
                    seleniumFunc.WaitForPageToLoad();
                    seleniumFunc.SelectValueFromDropDwn(uploadTestMaterialPage.SelectSubjectDrpDwn[i], subject[i]);
                    seleniumFunc.WaitForPageToLoad();
                }

                // Upload Files with decription and date
                FillUploadTestMaterialSection(i, uploadFileName, fileDec[i], fromdate, toDate);

                if (catagiory.Length > 1 && i < catagiory.Length - 1) {
                    seleniumFunc.WaitAndClickOnElement(uploadTestMaterialPage.AddBtn);
                    seleniumFunc.WaitForPageToLoad();
                }
            }
        }


        public void UploadMoreTestMaterial(string uploadFileName, string fileDec, String fromdate, string toDate) {

            UploadDocuments(uploadFileName, uploadTestMaterialPage.fileUploads[1]);

            seleniumFunc.WaitAndEnterText(uploadTestMaterialPage.fileUploadDescriptions[1], fileDec);

            comFunc.SelectDateFromDatePicker(uploadTestMaterialPage.FromDates[1], fromdate);
            comFunc.SelectDateFromDatePicker(uploadTestMaterialPage.ToDates[1], toDate);
        }


        public void FillUploadDocForm(string uploadFileName, string fileDec, String fromdate, string toDate, string role, string subRole) {
            UploadDocuments(uploadFileName, uploadTestMaterialPage.FileUpload);
            seleniumFunc.WaitAndEnterText(uploadTestMaterialPage.Description, fileDec);
            string[] fromDate = fromdate.Split('-');
            seleniumFunc.SelectValueFromDropDwn(uploadTestMaterialPage.fromday, fromDate[0]);
            seleniumFunc.SelectValueFromDropDwn(uploadTestMaterialPage.frommonth, fromDate[1]);
            seleniumFunc.SelectValueFromDropDwn(uploadTestMaterialPage.fromyear, fromDate[2]);

            string[] toDates = toDate.Split('-');
            seleniumFunc.SelectValueFromDropDwn(uploadTestMaterialPage.todate, toDates[0]);
            seleniumFunc.SelectValueFromDropDwn(uploadTestMaterialPage.tomonth, toDates[1]);
            seleniumFunc.SelectValueFromDropDwn(uploadTestMaterialPage.toyear, toDates[2]);

            seleniumFunc.SelectValueFromDropDwn(uploadTestMaterialPage.userorrole, role);
            seleniumFunc.SelectValueFromDropDwn(uploadTestMaterialPage.SubRoleOrUser, subRole);
        }
    }
}
