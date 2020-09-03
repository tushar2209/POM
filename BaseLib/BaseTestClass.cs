using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RelevantCodes.ExtentReports;
using STA__Automation.CommonLib;

namespace STA__Automation.BaseLib
{
   
    public class BaseTestClass : BaseClass
    {
        public static ReportGenerator rportGenerator;
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        [OneTimeSetUp]
        public void BeforeStartExecution() {
            log.Info(" Before  Execution start call");
            BaseClass.LaunchBrowser("Browser");
            rportGenerator = new ReportGenerator();
            rportGenerator.StartReport();
          

        }
        [SetUp]
        public void BeforeTestMeethodExecution() {

            rportGenerator.AddTestInReport();
        }


        [TearDown]
        public void AfterTestMethodExecution() {
            log.Info(" After Test Method Execution method call");
           // rportGenerator.AnalyseTestResult();
            rportGenerator.UpdateTestResultInReport();

        }

        [OneTimeTearDownAttribute]
        public void AfterEndExecution()
        {
         
            log.Info(" After  Execution end call");
            rportGenerator.GenerateExcelReport();
            new SeleniumCommFunctions().ClosedAllBrowser();
            driver = null;
        }

        public void VerifyIsEquals( string ExpectedResult , string ActualResult, string testStepDec) {
            ExpectedResult = ExpectedResult.Trim();
            ActualResult = ActualResult.Trim();
            if (ExpectedResult.Equals(ActualResult))
            {   
                rportGenerator.AnalyseTestResult(testStepDec, LogStatus.Pass, "Result-> Value is as per the expected result.");
            }
            else {
                string ErrroMsg = " Result -> Value is not as per the expected result. <br> Expected :" + ExpectedResult + " <br> Actual :" + ActualResult;
                rportGenerator.AnalyseTestResult(testStepDec, LogStatus.Fail, ErrroMsg);
            }

        }
         
        public void VerifyIsTrue(bool condition, string testStepDec)
        {
            if (condition)
            {
                rportGenerator.AnalyseTestResult(testStepDec, LogStatus.Pass, "Result-> As per the expected result");
            }
            else
            {
                rportGenerator.AnalyseTestResult(testStepDec, LogStatus.Fail, "Result-> Not as per the expected result.");
            }

        }

        public void VerifyIsFalse(bool condition, string testStepDec)
        {
            if (condition)
            {
                rportGenerator.AnalyseTestResult( testStepDec,  LogStatus.Fail, "Result-> Not as per the expected result.");
            }
            else
            {
                rportGenerator.AnalyseTestResult( testStepDec, LogStatus.Pass, "Result-> As per the expected result");
            }

        }


        public void VerifyIsContains(string[] ExpectedResult, string ActualResult, string testStepDec)
        {
            string errorMsg = "";
            foreach (string s in ExpectedResult) {

               
                    if (!ActualResult.Contains(s.Trim()))
                    {
                        errorMsg = errorMsg + s;
                    }

            }
          
            if (errorMsg.Equals(""))
            {
                rportGenerator.AnalyseTestResult(testStepDec, LogStatus.Pass, "Result-> Value is as per the expected result.");
            }
            else
            {
                string ErrroMsg = " Result -> Value is not as per the expected result. <br> Expected :" + errorMsg + " <br> Actual :" + ActualResult;
                rportGenerator.AnalyseTestResult(testStepDec, LogStatus.Fail, ErrroMsg);
            }

        }


        public void VerifyIsContains(string ExpectedResult, string ActualResult, string testStepDec)
        {          

            if (ActualResult.Contains(ExpectedResult))
            {
                rportGenerator.AnalyseTestResult(testStepDec, LogStatus.Pass, "Result-> Value is as per the expected result.");
            }
            else
            {
                string ErrroMsg = " Result -> Value is not as per the expected result. <br> Expected :" + ExpectedResult + " <br> Actual :" + ActualResult;
                rportGenerator.AnalyseTestResult(testStepDec, LogStatus.Fail, ErrroMsg);
            }

        }


    }
}
