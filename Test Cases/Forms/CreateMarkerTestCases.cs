using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using STA.Utilities.ExcelReader;
using STA__Automation.BussinessLib;
using STA__Automation.CommonLib;

namespace STA__Automation.Test_Cases.Forms
{
    class CreateMarkerTestCases: CreateMarkerLib
    {

        static ExcelUtil excelUtil;
        CommonFunctions commFunc;
        CreateMarkerLib createmarkerlib;


        [SetUp]
        public void SetUp()
        {
            createmarkerlib = new CreateMarkerLib();
            commFunc = new CommonFunctions();
            excelUtil = ExcelUtil.GetExcelUtilInstance(CommonConstants.TEST_DATA_EXL, "CreateMarker");
            createmarkerlib.SetUpPreCondition();

        }

        [Test]
        public void VerifyAddEmployeeDetails()
        {
            comFunc.ClickOnCreateMarker("CRT_MRK");
            createmarkerlib.AddPersonalDetails(excelUtil.GetDataFromExcel("EmployeeCode"), excelUtil.GetDataFromExcel("Gender"), excelUtil.GetDataFromExcel("TitleFirst"), excelUtil.GetDataFromExcel("Forename"), excelUtil.GetDataFromExcel("Surname"),excelUtil.GetDataFromExcel("Address Line1"), excelUtil.GetDataFromExcel("Address Line2"), excelUtil.GetDataFromExcel("Address Line3"), excelUtil.GetDataFromExcel("Address Line4"), excelUtil.GetDataFromExcel("PostCode"), excelUtil.GetDataFromExcel("Country"), excelUtil.GetDataFromExcel("Material Status"),excelUtil.GetDataFromExcel("Day"), excelUtil.GetDataFromExcel("Month"), excelUtil.GetDataFromExcel("Year"));


        }



        [Test]
        public void VerifyAddMarkerDetails()
        {
            //comFunc.ClickOnCreateMarker("CRT_MRK");
            createmarkerlib.AddMarkerDetails(excelUtil.GetDataFromExcel("Title"), excelUtil.GetDataFromExcel("Marker familyName"), excelUtil.GetDataFromExcel("Marker Other name"), excelUtil.GetDataFromExcel("School ID"), excelUtil.GetDataFromExcel("Mobile number"), excelUtil.GetDataFromExcel("Landline number"), excelUtil.GetDataFromExcel("Email address"), excelUtil.GetDataFromExcel("Preferred method of contact"),excelUtil.GetDataFromExcel("Contract state"), excelUtil.GetDataFromExcel("Contract State Change Date"), excelUtil.GetDataFromExcel("Marker role"), excelUtil.GetDataFromExcel("Marker subject"), excelUtil.GetDataFromExcel("markerpreviousrole"), excelUtil.GetDataFromExcel("capitarole"), excelUtil.GetDataFromExcel("capitasubject"));
            //seleniumFunc.WaitAndClickOnElement(markercreate.TPTMarkingNo);
            //seleniumFunc.WaitAndClickOnElement(markercreate.NewMarkeryes);

        }




        




        [Test]
        public void VerifyEmploymentDetails()
        {
          // comFunc.ClickOnCreateMarker("CRT_MRK");
            createmarkerlib.EmploymentDetails(excelUtil.GetDataFromExcel("Employment Status"), excelUtil.GetDataFromExcel("Leaver"), excelUtil.GetDataFromExcel("Branch"));


        }



        [Test]
        public void VerifyfinalSubmission()
        {
            //comFunc.ClickOnCreateMarker("CRT_MRK");
            createmarkerlib.PayrollDetails(excelUtil.GetDataFromExcel("Branch"), excelUtil.GetDataFromExcel("BankAccountName"), excelUtil.GetDataFromExcel("BankAccountNo"), excelUtil.GetDataFromExcel("BankName"), excelUtil.GetDataFromExcel("SortCode"), excelUtil.GetDataFromExcel("PaasportNumber"), excelUtil.GetDataFromExcel("NINumber"));

        }



        [Test]
        public void VerifySubmit()
        {
            //comFunc.ClickOnCreateMarker("CRT_MRK");
            comFunc.SubmitForm();


        }
    }
}
