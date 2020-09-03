using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using STA.Utilities.ExcelReader;
using STA__Automation.BussinessLib;
using STA__Automation.CommonLib;


namespace STA__Automation.TestCases.Portal
{
    class AdditionalTimeTestCases : AdditionalTimeLib
    {

        public AdditionalTimeLib additionalTimeLib;
        public static ExcelUtil excelUtil;
        CommonFunctions comFunc;

        /// <summary>
        ///  Method to set up pre-condition of test case
        /// </summary>
        [SetUp]
        public void SetUp()
        {            
            additionalTimeLib = new AdditionalTimeLib();
            comFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "AdditionalTimeForm");
            
            // Launch Portal application
            additionalTimeLib.SetUpPreCondition("STA_PORTAL");

            // Logint ot portal and naviagte to respective form
            additionalTimeLib.LoginAndNavigatToAdditionTimeForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

        }

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "40901 \n 40914 \n 40915")]
        public void VerifyMandetoryFileds() {
            // Start Application
            comFunc.StartApplication();

            // Veriyf Mandetory Fields
            additionalTimeLib.CheckMandetoryFields();
        }
        /// <summary>
        /// Verify multiple Advice messages
        /// </summary>
        [Test, Category("RegressionTest"), Property("TestCaseIDs", "40894 \n 40895 \n 40896")]
        public void VerifyMultipleAdvicesScenarion() {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { false, true, true, false, false, false, false };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList,excelUtil);

        }

    
        /// <summary>
        /// Verify message A is generated  on  selection of  mentioned option for Q1 Q5 Q6,Q7
        /// </summary>
        [Test, Category("SmokeTest"), Category("RegressionTest"), Category("SanityTest"), Property("TestCaseIDs", "40898 \n 40913")]
        public void VerifyMessageAAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));


            // Select Question
            bool[] QuestionAnsList = { false, true, true, true, false, true, false };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }
        /// <summary>
        /// Verify message B is generated  on  selection of  option no in Q7 
        /// </summary>
        [Test, Category("RegressionTest"), Property("TestCaseIDs", "40899")]
        public void VerifyMessageBAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { true, true, true, true, true, true, false };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }
        /// <summary>
        /// Verify message C is generated  when selection of option yes in Q1 
        /// </summary>
        [Test, Category("RegressionTest"), Property("TestCaseIDs", "40900")]
        public void VerifyMessageCAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { true, true, true, true, false, false, false };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }

        /// <summary>
        /// Verify message D is generated on selction of below option for Q1,Q5,Q6,Q7
        /// </summary>

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "43409")]
        public void VerifyMessageDAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { true, true, true, true, false, true, true };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }


        /// <summary>
        /// Verify message E is generated when slection of mentioned option in Q1 ,Q5,Q6,Q7
        /// </summary>
        [Test, Category("RegressionTest"), Property("TestCaseIDs", "40901")]
        public void VerifyMessageEAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { false, true, true, true, true, true, false };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }



        /// <summary>
        /// Verify message F is generated when selction of yes option in Q1,Q5,Q6,Q7
        /// </summary>
        [Test, Category("RegressionTest"), Property("TestCaseIDs", "40902")]
        public void VerifyMessageFAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { false, true, true, true, false, false, false };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }


        /// <summary>
        /// Verify messge G is generated when selection of mentioned option in Q1,Q5,Q6,Q7
        /// </summary>
        [Test, Category("RegressionTest"), Property("TestCaseIDs", "40903")]
        public void VerifyMessageGAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { false, true, true, true, false, true, true };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }


        /// <summary>
        /// Verify message H is generated on selection of mentioned option for Q1 ,Q5,6,Q7
        /// </summary>
        [Test,Category("RegressionTest"), Property("TestCaseIDs", "40904")]
        public void VerifyMessageHAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { true, true, true, true, true, false, false };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }

        /// <summary>
        /// Verify message I is generated on selction of below option for Q1,Q5,Q6,Q7
        /// </summary>

        [Test ,Category("RegressionTest"), Property("TestCaseIDs", "40905")]
        public void VerifyMessageIAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { true, true, true, true, true, true, true };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }

       
        /// <summary>
        /// Verify Advice message when  Q4 is slected with No option
        /// </summary>
        [Test,  Category("RegressionTest"), Property("TestCaseIDs", "40896")]
        public void VerifyAdviceMessageWhenSelectedNoForQ4()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { true, true, true, false, true, true, true };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }



        /// <summary>
        /// Verify message J is generated on selction of below option for Q1,Q5,Q6,Q7
        /// </summary>

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "43402")]
        public void VerifyMessageJAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { true, true, true, true, false, false, true };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }

        /// <summary>
        /// Verify message K is generated on selction of below option for Q1,Q5,Q6,Q7
        /// </summary>

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "43403")]
        public void VerifyMessageKAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { false, true, true, true, true, false, false };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }

        /// <summary>
        /// Verify message L is generated on selction of below option for Q1,Q5,Q6,Q7
        /// </summary>

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "43404")]
        public void VerifyMessageLAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { false, true, true, true, true, true, true };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }

        /// <summary>
        /// Verify message M is generated on selction of below option for Q1,Q5,Q6,Q7
        /// </summary>

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "43405")]
        public void VerifyMessageMAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { false, true, true, true, false, false, true };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }


        /// <summary>
        /// Verify message N is generated on selction of below option for Q1,Q5,Q6,Q7
        /// </summary>

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "43406")]
        public void VerifyMessageNAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { true, true, true, true, true, false, true };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }

        /// <summary>
        /// Verify message O is generated on selction of below option for Q1,Q5,Q6,Q7
        /// </summary>

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "43407")]
        public void VerifyMessageOAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { false, true, true, true, true, false, true };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }


        /// <summary>
        /// Verify message P is generated on selction of below option for Q1,Q5,Q6,Q7
        /// </summary>

        [Test, Category("RegressionTest"), Property("TestCaseIDs", "43408")]
        public void VerifyMessagePAndAdvices()
        {

            // Start Application
            comFunc.StartApplication();

            //Select Pupile 
            additionalTimeLib.SelectPupil(excelUtil.GetDataFromExcel("PupilName"));

            // Select Question
            bool[] QuestionAnsList = { true, true, true, true, false, true, false };

            additionalTimeLib.SelectQuestionsAnswers(QuestionAnsList);

            // Verify Message and Advice
            additionalTimeLib.CheckAdvicesAndMessage(QuestionAnsList, excelUtil);

        }


        

    }
}
