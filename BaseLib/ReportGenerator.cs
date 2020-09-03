using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.Drawing;

using System.Drawing.Imaging;
using System.IO;
using STA__Automation.CommonLib;
using RelevantCodes.ExtentReports;
using STA.Utilities.ExcelReader;
using System.Data;

namespace STA__Automation.BaseLib
{
    [TestFixture]
    public class ReportGenerator
    {

        #region Properties
        string StyleScript = @"<style>.hidden {display: none;}.show {display: inline !important;}.error{color:red;font-weight: 700; } a#myBtn {cursor: pointer;} .pass{color:green;font-weight: 700;} .skip{color:gray; font-weight: 700;} td{width:49%;}</style>
            <script type = 'text/javascript' src='https://code.jquery.com/jquery-1.10.2.js'></script>
            <script type = 'text/javascript'>
                function myFunction(event)
                {
                    if (event.target.textContent == 'Read more...') 
				            {
					            event.target.textContent = 'Read less...'; 
					            event.target.parentNode.children[1].style.display='inline';
				            }
				            else if (event.target.textContent == 'Read less...') 

                            {
					            event.target.textContent = 'Read more...'; 
					            event.target.parentNode.children[1].style.display = 'none';

                            }
				            event.preventDefault();
                }
            </script>";

        string HtmlContent = @"<div><b><h6 class='error'>{0}</h6> </b></div>
                <div>
                <b>ErrorMessage: {1}</b>
                <p id='more' class='hidden'>StackTrace:{2}</p>
                <a onclick='myFunction(event)' id='myBtn'>Read more...</a>
                <div>{3}</div>
                </div>
                {4}";

        string HtmlContent2 = @"<div><b><h6 class='pass'>{0}</h6></b></div>
                <div>
                <b>Message : {1}</b>
                <div>{2}</div>
                </div>
                {3}";
        string HtmlContent3 = @"<div><b><h6 class='skip'>{0}</h6></b></div>
                <div>
                <b>Message : {1}</b>
                <div>{2}</div>
                </div>
                {3}";

        #endregion

        #region ReportGenerator Constructor
        public ReportGenerator()
        {
            if (test == null)
                test = new ExtentTest("", "");

            AcceptanceCriteriaNo = new List<string>();
            TestCaseName = new List<string>();
            TestCaseStatus = new List<string>();
            TestClassName = new List<string>();
            TestCaseIDs = new List<string>();


        }
        #endregion

        #region Variables

        public static ExtentReports extent;

        public static ExtentTest test;
        public static String executionDate;
        public CommonFunctions comFun;
        public static string Todaysdate = DateTime.Now.ToString("dd-MMM-yyyy");
        public static string reportPath;

        public List<string> AcceptanceCriteriaNo;
        public List<string> TestCaseName;
        public List<string> TestCaseStatus;
        public List<string> TestClassName;
        public List<string> TestCaseIDs;
        public bool TestScenarioStatus;
        static System.Data.DataTable table = new System.Data.DataTable();

        #endregion
        /// <summary>
        /// Method to configer extend HTML report properties 
        /// </summary>

        public void StartReport()
        {

            string currentDateFolder = CommonFunctions.GetProjectPath() + "Reports\\" + Todaysdate;
            var testClassName = TestContext.CurrentContext.Test.Name;
            if (!Directory.Exists(currentDateFolder))
            {
                Directory.CreateDirectory(currentDateFolder);
            }

            if (reportPath == null)
            {
               reportPath = currentDateFolder + "\\" + testClassName + "_" + CommonFunctions.GetAppConfigValue("TestEnvironment") + "_" + DateTime.Now.ToString("hh_mm_ss") + ".html";
              //  reportPath = currentDateFolder + "\\ Automation Execution Report_" + CommonFunctions.GetAppConfigValue("TestEnvironment") + "_" + DateTime.Now.ToString("hh_mm_ss") + ".html";

            }//Keep the parameter false if u need new report after every execution

            if (extent == null)
                extent = new ExtentReports(reportPath, false);

            //Loading the config file of extent report
            extent.LoadConfig(CommonFunctions.GetProjectPath() + "extent-config.xml");

        }


        /// <summary>
        /// Method to update Test case result in Report
        /// </summary>
        public void UpdateTestResultInReport()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            string _className = TestContext.CurrentContext.Test.ClassName.Substring(TestContext.CurrentContext.Test.ClassName.LastIndexOf(".") + 1);
            string _AcceptanceCriteriaNo = "";
            string _TestCaseIDs = "";
            try
            {
                try
                { _AcceptanceCriteriaNo = TestContext.CurrentContext.Test.Properties.Get("AcceptanceCriteria").ToString();} catch (Exception e) { }
                try
                { _TestCaseIDs = TestContext.CurrentContext.Test.Properties.Get("TestCaseIDs").ToString(); } catch (Exception e) { }
                
                if (errorMessage != null && stackTrace != null )
                    AnalyseTestResult("Exception Occured", LogStatus.Fail, errorMessage);

                if (errorMessage==null && !TestScenarioStatus) //status.Equals("Inconclusive") 
                {
                    status = TestStatus.Failed;
                    Assert.Fail("Multiple check points of testScenario are failed, please check automation execution report for details.");
                   
                }
            }
            finally
            {
                extent.EndTest(test);
                extent.Flush();

                TestClassName.Add(_className.Substring(0, _className.Length - 9));
                AcceptanceCriteriaNo.Add(_AcceptanceCriteriaNo);
                TestCaseName.Add(TestContext.CurrentContext.Test.MethodName);
                TestCaseStatus.Add(status.ToString());
                TestCaseIDs.Add(_TestCaseIDs);
            }

        }

        public void AnalyseTestResult(string testStep, LogStatus status, string errorMessage)
        {
            IWebDriver driver = BaseClass.GetDriver();
            var testClassName = TestContext.CurrentContext.Test.ClassName.Substring(TestContext.CurrentContext.Test.ClassName.LastIndexOf(".") + 1);
            if (errorMessage == "")
                errorMessage = TestContext.CurrentContext.Result.Message;

            //  var testCaseName = "<b>" + TestContext.CurrentContext.Test.MethodName + "</b>";
            var testStepDec = "<b>" + testStep + "</b>";

            string screenShotPath = TakeScreenshot(driver);

            if (status.Equals(LogStatus.Fail))
            {
                var Details = string.Format(HtmlContent, GetTestCaseFailureReason(errorMessage), errorMessage, TestContext.CurrentContext.Result.StackTrace, test.AddScreenCapture(screenShotPath), StyleScript);

                test.Log(LogStatus.Fail, testStepDec, Details);
                TestScenarioStatus = false;
            }
            else if (status.Equals(LogStatus.Pass))
            {
                var Details = string.Format(HtmlContent2, "Test case passed.", "As per Expected Result", test.AddScreenCapture(screenShotPath), StyleScript);

                test.Log(LogStatus.Pass, testStepDec, Details);

            }
            else if (status.Equals(TestStatus.Skipped))
            {
                var Details = string.Format(HtmlContent3, "Test case skipped.", " Not Executed need to re-Run", test.AddScreenCapture(screenShotPath), StyleScript);

                test.Log(LogStatus.Skip, testStepDec, Details);
            }
            
        }


        public void AddTestInReport()
        {
            var testCaseName = TestContext.CurrentContext.Test.MethodName;
            var testClassName = TestContext.CurrentContext.Test.ClassName.Substring(TestContext.CurrentContext.Test.ClassName.LastIndexOf(".") + 1);
            test = extent.StartTest(testCaseName + " - " + testClassName, testClassName);
            TestScenarioStatus = true;
        }

        /// <summary>
        /// Method to get screeenshots during automation execution.
        /// </summary>
        /// <param name="driver"> IWEbDriver</param>
        /// <returns></returns>
        public static String TakeScreenshot(IWebDriver driver)
        {
            ITakesScreenshot ssdriver = driver as ITakesScreenshot;
            String currentDateFolder = CommonFunctions.GetProjectPath() + "Screenshots\\" + Todaysdate;
            var testCaseName = TestContext.CurrentContext.Test.MethodName;
            var testClassName = TestContext.CurrentContext.Test.ClassName.Substring(TestContext.CurrentContext.Test.ClassName.LastIndexOf(".") + 1);
            if (!Directory.Exists(currentDateFolder))
            {
                Directory.CreateDirectory(currentDateFolder);
            }
            string screenshotPath = currentDateFolder + "\\Automation Report_" + DateTime.Now.ToString("hh_mm_ss") + ".png";

            try
            {
                Screenshot screenshot = ssdriver.GetScreenshot();
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
            }
            return screenshotPath;
        }

        public string GetTestCaseFailureReason(string errorMessage)
        {
            string testCaseFailureReason = "";
            if (errorMessage.Contains("TimeOut"))
            {
                testCaseFailureReason = "Environment Or Automation Script Issue";

            }
            else if (errorMessage.Contains("NoSuchElementException"))
            {
                testCaseFailureReason = "Automation script is unable to find WebElement";
            }
            else if (errorMessage.Contains("NullPointerException"))
            {

                testCaseFailureReason = "Automation Script Isue";
            }
            else if (errorMessage.Contains("AssertFailedException"))
            {
                testCaseFailureReason = "Functional Issue";
            }
            else
            {
                testCaseFailureReason = "Need to Analyse";
            }
            return testCaseFailureReason;
        }


        public void GenerateExcelReport()
        {
            var ExcelReportName = reportPath.Replace(".html", ".xlsx");
            if (File.Exists(ExcelReportName))
            {
                new ExcelUtil().UpdateExistingExcelReport(ExcelReportName, AddDataToDataTabel(table));
            }
            else
            {
                new ExcelUtil().createExcel(ExcelReportName, CreateExcelReport());
            }


        }

        System.Data.DataTable CreateExcelReport()
        {

            table.Columns.Add("Sr No", typeof(int));
            table.Columns.Add("PBI/User Story Name", typeof(string));
            table.Columns.Add("Acceptance Criteria Number", typeof(string));
            table.Columns.Add("Acceptance Criteria Status", typeof(string));
            table.Columns.Add("Test Case IDs", typeof(string));
            table.Columns.Add("Test Scenario Name", typeof(string));
            table.Columns.Add("Test Sccenario Status", typeof(string));

            return AddDataToDataTabel(table);

        }

        public System.Data.DataTable AddDataToDataTabel(System.Data.DataTable table)
        {

            if (table == null)
            {
                table = new System.Data.DataTable();
            }
            if (table.Columns.Count <= 0)
            {
                table.Columns.Add("Sr No", typeof(int));
                table.Columns.Add("PBI/User Story Name", typeof(string));
                table.Columns.Add("Acceptance Criteria Number", typeof(string));
                table.Columns.Add("Acceptance Criteria Status", typeof(string));
                table.Columns.Add("Test Case IDs", typeof(string));
                table.Columns.Add("Test Scenario Name", typeof(string));
                table.Columns.Add("Test Sccenario Status", typeof(string));
            }
            string _storyName = string.Empty;
            string _sAcceptanceCriteria = string.Empty;
            string _sAcceptanceStatus = "Passed";
            int rowNo = table.Rows.Count+1;
            for (int i = 0; i < TestCaseName.Count; i++)
            {

                if (String.IsNullOrEmpty(_storyName))
                {
                    table.Rows.Add(rowNo, TestClassName[i], AcceptanceCriteriaNo[i], TestCaseStatus[i], TestCaseIDs[i],TestCaseName[i], TestCaseStatus[i]);
                    _storyName = TestClassName[i];
                    _sAcceptanceCriteria = AcceptanceCriteriaNo[i];
                    _sAcceptanceStatus = TestCaseStatus[i];

                }
                else
                {
                    if (TestClassName[i] == _storyName)
                    {
                        if (AcceptanceCriteriaNo[i] == _sAcceptanceCriteria && AcceptanceCriteriaNo[i]!="")
                        {
                            if (TestCaseStatus[i] == "Failed")
                            {
                                _sAcceptanceStatus = "Failed";
                                table.Rows.Add(rowNo, TestClassName[i], AcceptanceCriteriaNo[i], _sAcceptanceStatus, TestCaseIDs[i], TestCaseName[i], TestCaseStatus[i]);
                                _storyName = TestClassName[i];
                                _sAcceptanceCriteria = AcceptanceCriteriaNo[i];

                                //if Acceptance Criteria changed
                                //Update all the record having same user story and criteria

                                if (table.AsEnumerable().Where(x => x["Test Sccenario Status"].ToString() == "Failed" && x["PBI/User Story Name"].ToString() == _storyName && x["Acceptance Criteria Number"].ToString() == _sAcceptanceCriteria).Count() > 0)
                                {
                                    foreach (DataRow row in table.AsEnumerable().Where(x => x["Test Sccenario Status"].ToString() == "Passed" && x["PBI/User Story Name"].ToString() == _storyName && x["Acceptance Criteria Number"].ToString() == _sAcceptanceCriteria).ToList<DataRow>())
                                    {
                                        row["Acceptance Criteria Status"] = "Failed";
                                    }

                                }

                            }
                            else
                            {
                                if (_sAcceptanceStatus == "Failed")
                                {

                                    table.Rows.Add(rowNo, TestClassName[i], AcceptanceCriteriaNo[i], _sAcceptanceStatus, TestCaseIDs[i], TestCaseName[i], TestCaseStatus[i]);
                                    _storyName = TestClassName[i];
                                    _sAcceptanceCriteria = AcceptanceCriteriaNo[i];

                                }
                                else
                                {
                                    table.Rows.Add(rowNo, TestClassName[i], AcceptanceCriteriaNo[i], _sAcceptanceStatus, TestCaseIDs[i],TestCaseName[i], TestCaseStatus[i]);
                                    _storyName = TestClassName[i];
                                    _sAcceptanceCriteria = AcceptanceCriteriaNo[i];

                                }
                            }

                        }
                        else
                        {
                            //if Acceptance Criteria changed
                            //Update all the record having same user story and criteria

                            table.Rows.Add(rowNo, TestClassName[i], AcceptanceCriteriaNo[i], TestCaseStatus[i], TestCaseIDs[i], TestCaseName[i], TestCaseStatus[i]);
                            _storyName = TestClassName[i];
                            _sAcceptanceCriteria = AcceptanceCriteriaNo[i];
                            _sAcceptanceStatus = TestCaseStatus[i];
                        }

                    }
                    else
                    {

                        table.Rows.Add(rowNo, TestClassName[i], AcceptanceCriteriaNo[i], TestCaseStatus[i], TestCaseIDs[i],TestCaseName[i], TestCaseStatus[i]);
                        _storyName = TestClassName[i];
                        _sAcceptanceCriteria = AcceptanceCriteriaNo[i];
                        _sAcceptanceStatus = TestCaseStatus[i];
                    }

                }

                rowNo++;
            }
            return table;


        }

    }
}