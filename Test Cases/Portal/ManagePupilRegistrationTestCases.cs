using NUnit.Framework;
using STA.Utilities.ExcelReader;
using STA__Automation.BussinessLib;
using STA__Automation.CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.TestCases.Portal
{
    class ManagePupilRegistrationTestCases : ManagePupilRegistrationLib
    {

        ExcelUtil excelUtil;
        CommonFunctions commFunc;
        ManagePupilRegistrationLib managePupilLib;

        [SetUp]
        public void SetUp()
        {
            managePupilLib = new ManagePupilRegistrationLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "ManagePupil");

            // Launch application Portal application
            managePupilLib.SetUpPreCondition("STA_PORTAL");

            // Login user and Navigate to respective form
            managePupilLib.LoginAndNavigatToManagePupilForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
        }
        [Test]
        public void VerifyAddPupil()
        {
            // Start Application
            commFunc.StartApplication();
            managePupilLib.AddPupil("X80155521900K","test","","lastName", "18-Mar-2013","Male");
            managePupilLib.VerifyAndSubmit();


        }
    }
}
