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
    [TestFixture]
    public class ModifiedKSTwoTestCases : ModifiedKS2Lib

    {
        public ModifiedKS2Lib ModifiedKS2;
        public static ExcelUtil excelUtil;
        CommonFunctions commFunc;


        [SetUp]

        public void SetUp()
        {
            ModifiedKS2 = new ModifiedKS2Lib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "ModifiedKS2");

            // Launch portal appliation
            ModifiedKS2.SetUpPreCondition("STA_PORTAL");

        }

        [Test]
        public void VerifyKS2FormPrepopulatedValues ()
        {

            // Login to portal and navigate to respective form
            ModifiedKS2.LoginAndNavigateToModifiedKS2Form(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            commFunc.StartApplication();
            ModifiedKS2.CheckPrePopulatedFiledsValue(excelUtil.GetDataFromExcel("FullName"), excelUtil.GetDataFromExcel("Email"));

            }

        [Test]
        public void VerifySubmitKS2Order()
        {
            // Login to portal and navigate to respective form
            ModifiedKS2.LoginAndNavigateToModifiedKS2Form(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // start application
            commFunc.StartApplication();

            // fill ks2 order details
            ModifiedKS2.SubmitKs2OrderDetails(excelUtil.GetDataFromExcel("totalPupilNo"), excelUtil.GetDataFromExcel("pupilVisual"), excelUtil.GetDataFromExcel("pupilSpcl"));

            ModifiedKS2.KS2_EnglishOrder(excelUtil.GetDataFromExcel("EngGramarPunct_EP"), excelUtil.GetDataFromExcel("Eng_GP_SPLP"), excelUtil.GetDataFromExcel("EngGramarPunct_braille"),
                excelUtil.GetDataFromExcel("EngReading_EP"), excelUtil.GetDataFromExcel("EngReading_MLP"), excelUtil.GetDataFromExcel("EngReading_Braile"));
            ModifiedKS2.KS2_Mathematics(excelUtil.GetDataFromExcel("Math_EP"), excelUtil.GetDataFromExcel("Math_MLP"), excelUtil.GetDataFromExcel("Math_Braille"));

            ModifiedKS2.VerifySubmiteddInfo();
            // Submit form and verify form submission  confirmation message

            ModifiedKS2.SubmitForm();
            VerifyIsEquals(excelUtil.GetDataFromExcel("FormSubmissionMsg"), commFunc.GetFormSubmissionConfirmationMsg(),"Check Modify KSTwo form submisstion msg.");

        }


        [Test, Property("TestCaseIDs", "49886 \n 49888")]
        public void VerifyPrivacyPolicyForIndependentSchools()
        {
            // Login user and Navigate to respective form
            ModifiedKS2.LoginAndNavigateToModifiedKS2Form(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();

            // Fill Form
            ModifiedKS2.CheckPrivacyNotice(true);

        }

        [Test, Property("TestCaseIDs", "49890")]
        public void VerifyPrivacyPolicyForAcademySchools()
        {
            // Login user and Navigate to respective form
            ModifiedKS2.LoginAndNavigateToModifiedKS2Form(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));

            // Start application
            commFunc.StartApplication();

            // Check privecy Form
            ModifiedKS2.CheckPrivacyNotice(false);

        }


    }
}
