using NUnit.Framework;
using STA.Utilities.ExcelReader;
using STA__Automation.BussinessLib;
using STA__Automation.CommonLib;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA__Automation.TestCases.Portal
{
    class KS2HeadteachersDeclarationFormTestCase : KS2HeadteachersDeclarationFormLib
    {
        static ExcelUtil excelUtil;
        CommonFunctions commFunc;
        KS2HeadteachersDeclarationFormLib ks2lib;
        [SetUp]
        public void SetUp()
        {
            ks2lib = new KS2HeadteachersDeclarationFormLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "KS2HeadTeacherDec");
            ks2lib.SetUpPreCondition("STA_PORTAL");
            ks2lib.LoginAndNavigatToForm(excelUtil.GetDataFromExcel("UserName"), excelUtil.GetDataFromExcel("Password"));
        }
        [Test]
        public void VerifyKS2HeadTeacherSecA()
        {
            //Fill Form
            ks2lib.FillKS2HeadTeacherForm(excelUtil.GetDataFromExcel("subjectpaper"), excelUtil.GetDataFromExcel("nooftestscript"));
            ks2lib.SectionACheckBox();
            ks2lib.ConfirmationCheckbox();
            commFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check KS2 HeadTeacherForm Submission confrmation message.");
        }
        [Test]
        public void VerifyKS2HeadTeacherSecB()
        {
            //Fill Form
            ks2lib.FillKS2HeadTeacherForm(excelUtil.GetDataFromExcel("subjectpaper"), excelUtil.GetDataFromExcel("nooftestscript"));
            ks2lib.SectionBCheckbox();
            ks2lib.ConfirmationCheckbox();
            commFunc.SubmitForm();
            VerifyIsContains(excelUtil.GetDataFromExcel("FormSubmissionConfMsg"), commFunc.GetFormSubmissionConfirmationMsg(), "Check KS2 HeadTeacherForm Submission confrmation message.");
        }
    }
}
