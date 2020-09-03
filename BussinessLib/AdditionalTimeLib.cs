using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using STA.Utilities.ExcelReader;
using STA__Automation.BaseLib;
using STA__Automation.CommonLib;
using STA__Automation.Pages.Forms;
using STA__Automation.Pages.Portal;

namespace STA__Automation.BussinessLib
{
    class AdditionalTimeLib :BaseTestClass
    {
        public static SeleniumCommFunctions seleniumFunc;
        public static AdditionalTimePage addtionalTimePage;
        public static IWebDriver driver;
        public static CommonFunctions comFunc;
        public static MyActivityPage myActivityPage;

        public void InitialisePageObjects()
        {
            addtionalTimePage = new AdditionalTimePage(driver);
            myActivityPage = new MyActivityPage(driver);


        }

        /// <summary>
        /// Metod to set up pre condition for test case.
        /// </summary>
        /// <param name="appURL"></param>
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

        /// <summary>
        /// Method to Login and Navigate to My Activity -> Avilabel  -> Application For Additional Time form
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void LoginAndNavigatToAdditionTimeForm(string userName, string password)
        {   log.Info("Login to application");
            comFunc.LoginIntoPortal(userName, password);

            log.Info("Navigate to From");
            comFunc.NaviagteToFormUnderMyActivity(myActivityPage.ApplicationForAdditionalTimeLink);

        }

        /// <summary>
        /// Method to check Madetory fields
        /// </summary>
        public void CheckMandetoryFields() {

            comFunc.SubmitForm();

            seleniumFunc.ScrollElementInView(addtionalTimePage.QuestionErrorMsgs[5]);

            VerifyIsTrue(addtionalTimePage.QuestionErrorMsgs.Count == 7, "Check all Questions should Madetory fileds.");

        }

        public void SelectPupil(string PupilName) {

              seleniumFunc.SelectValueFromAutoCompliteDropDown(addtionalTimePage.PupilDropDwn, addtionalTimePage.PupilDropDwnOptions, PupilName);
           // seleniumFunc.SelectValueFromDropDwn(addtionalTimePage.pupildrpdwn1, PupilName);
        }


        /// <summary>
        /// Method to select Question Answers 
        /// </summary>
        /// <param name="q1">array of True/ False i.e. True = Yes & False =No</param>
       
        public void SelectQuestionsAnswers(bool[] q) {

            for (int i = 0; i < q.Length; i++)
            {
                if (q[i])
                    seleniumFunc.WaitAndClickOnElement(addtionalTimePage.YesRadioBtns[i]);
                else
                    seleniumFunc.WaitAndClickOnElement(addtionalTimePage.NoRadioBtns[i]);
            }

            comFunc.SubmitForm();

        }

        public void CheckAdvicesAndMessage(bool[] q, ExcelUtil excelUtil) {
            string testCaseName = "SetUp";
            string Advice1 = excelUtil.GetDataFromExcel(testCaseName, "Advice1");
            string Advice2 = excelUtil.GetDataFromExcel(testCaseName, "Advice2");
            string Advice3 = excelUtil.GetDataFromExcel(testCaseName, "Advice3");
                  
        

            string MessageA = excelUtil.GetDataFromExcel(testCaseName, "MessageA");
            string MessageB = excelUtil.GetDataFromExcel(testCaseName, "MessageB");
            string MessageC = excelUtil.GetDataFromExcel(testCaseName, "MessageC");
            string MessageD = excelUtil.GetDataFromExcel(testCaseName, "MessageD");
            string MessageE = excelUtil.GetDataFromExcel(testCaseName, "MessageE");
            string MessageF = excelUtil.GetDataFromExcel(testCaseName, "MessageF");
            string MessageG = excelUtil.GetDataFromExcel(testCaseName, "MessageG");
            string MessageH = excelUtil.GetDataFromExcel(testCaseName, "MessageH");
            string MessageI = excelUtil.GetDataFromExcel(testCaseName, "MessageI");

            string MessageJ = excelUtil.GetDataFromExcel(testCaseName, "MessageJ");
            string MessageK = excelUtil.GetDataFromExcel(testCaseName, "MessageK");
            string MessageL = excelUtil.GetDataFromExcel(testCaseName, "MessageL");
            string MessageM = excelUtil.GetDataFromExcel(testCaseName, "MessageM");
            string MessageN = excelUtil.GetDataFromExcel(testCaseName, "MessageN");
            string MessageO = excelUtil.GetDataFromExcel(testCaseName, "MessageO");
            string MessageP = excelUtil.GetDataFromExcel(testCaseName, "MessageP");

            comFunc.GetReferanceCode();
            seleniumFunc.ScrollPageDown(500);
            // Verify Advice 1,2 & 3
            if (q[1]) {
                
                    // Verify Message
                    VerifyIsContains(Advice1.Split('\n'), GetTextFromHTML("<hr><b>Advice: </b>",null), "Check Advice 1 should displayed");
               
            }
            if (q[2])
            {

                // Verify Message
                VerifyIsContains(Advice2.Split('\n'), GetTextFromHTML("<hr><b>Advice: </b>", null), "Check Advice 2 should displayed");
            }
            if(!q[3])
            
            {  // Verify Message
                VerifyIsContains(Advice3.Split('\n'), GetTextFromHTML("<hr><b>Advice: </b>", null), "Check Advice 3 should displayed");
            }


            // Verify messages 

            if (!q[0]  && !q[4] && q[5] && !q[6])
            {
                // Verify Message
                VerifyIsContains(MessageA.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message A should displayed");
            }

                                 
            if (q[0] && q[4] && q[5] && !q[6])
            {
                // Verify Message
                VerifyIsContains(MessageB.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message B should displayed");
            }

            if (q[0] && !q[4] && !q[5] && !q[6])
            {
                // Verify Message
                VerifyIsContains(MessageC.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message C should displayed");
            }

            if (q[0] && !q[4] && q[5] && q[6])
            {
                // Verify Message  br><mark id
                VerifyIsContains(MessageD.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message D should displayed");

            }

            if (!q[0] && q[4] && q[5] && !q[6])
            {
                // Verify Message  br><mark id
                VerifyIsContains(MessageE.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message E should displayed");

            }

            if (!q[0] && !q[4] && !q[5] && !q[6])
            {
               
                // Verify Message
                VerifyIsContains(MessageF.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message F should displayed");


            }


            if (!q[0] && !q[4] && q[5] && q[6])
            {
                // Verify Message
                VerifyIsContains(MessageG.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message G should displayed");

            }

            if (q[0] && q[4] && !q[5] && !q[6])
            {
                // Verify Message
                VerifyIsContains(MessageH.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message H should displayed");

            }


            if (q[0] && q[4] && q[5] && q[6])
            {
                // Verify Message
                VerifyIsContains(MessageI.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message I should displayed");

            }


            if (q[0] && !q[4] && !q[5] && q[6])
            {
                // Verify Message
                VerifyIsContains(MessageJ.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message J should displayed");

            }

            if (!q[0] && q[4] && !q[5] && !q[6])
            {
                // Verify Message
                VerifyIsContains(MessageK.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message K should displayed");

            }

            if (!q[0] && q[4] && q[5] && q[6])
            {
                // Verify Message
                VerifyIsContains(MessageL.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message L should displayed");

            }

            if (!q[0] && !q[4] && !q[5] && q[6])
            {
                // Verify Message
                VerifyIsContains(MessageM.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message M should displayed");

            }


            if (q[0] && q[4] && !q[5] && q[6])
            {
                // Verify Message
                VerifyIsContains(MessageN.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message N should displayed");

            }


            if (!q[0] && q[4] && !q[5] && q[6])
            {
                // Verify Message
                VerifyIsContains(MessageO.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message O should displayed");

            }

            if (q[0] && !q[4] && q[5] && !q[6])
            {
                // Verify Message
                VerifyIsContains(MessageP.Split('\n'), GetTextFromHTML("<b>Outcome: </b>", "<hr><b>Advice: </b>"), "Check Message P should displayed");

            }

        }



        public string GetTextFromHTML(string startTag, string endTag) {
            string subStringText = null;
            string textList = addtionalTimePage.ResponceBody.GetAttribute("innerHTML");
            textList = textList.Substring(textList.IndexOf(startTag));
            if (endTag != null)
            {
                subStringText = textList.Substring(startTag.Length, textList.IndexOf(endTag));
            }
            else {
                subStringText = textList.Substring(startTag.Length);
            }
            //      string subStringText = textList.Substring(startTag.Length, textList.LastIndexOf(endTag));
            
            subStringText = subStringText.Replace("<br>","");
            subStringText = subStringText.Replace("<b>", "");
           
            subStringText = subStringText.Replace("</br>", "");
            subStringText = subStringText.Replace("</b>", "");
            subStringText = subStringText.Replace("</mark>", "");
            subStringText = subStringText.Replace("<strong>", "");
            subStringText = subStringText.Replace("</strong>", "");
            subStringText = subStringText.Replace("<u>", "");
            subStringText = subStringText.Replace("</u>", "");
            subStringText = subStringText.Replace("<ul>", "");
            subStringText = subStringText.Replace("</ul>", "");
            subStringText = subStringText.Replace("<li>", "");
            subStringText = subStringText.Replace("</li>", "");


            return subStringText.Trim();

        }

        public string CheckAdviceOrMessageText(string startTag, string endTag , string msg) {

            string text = GetTextFromHTML(startTag, endTag);
            string[] messageAList = msg.Split('\n');
            string errorMsg ="";
            foreach (string s in messageAList)
            {                
                if (!text.Contains(s.Trim()))
                {
                    errorMsg = errorMsg + s;
                }

            }
            return errorMsg;

        }




    }
}
