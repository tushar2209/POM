
using Excel;
using Microsoft.Office.Interop.Excel;
using STA__Automation.CommonLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DataTable = System.Data.DataTable;

namespace STA.Utilities.ExcelReader
{
    public class ExcelUtil
    {
        public static ExcelUtil excelUtil;
        public static string sheetName = "";
        public static List<Datacollection> dataCol;

        public ExcelUtil() { }
        public ExcelUtil(String TestDateFileName, String SheetName)
        {
            excelUtil = null;
            sheetName = "";
            PopulateInCollection(TestDateFileName, SheetName);
        }
        private DataTable ExcelToDataTable(String TestDateFileName, String SheetName)
        {
            //open file and returns as Stream

            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;
            string ExcelPath = Path.Combine(projectPath, "TestData\\" + TestDateFileName);

            FileStream stream = File.Open(ExcelPath, FileMode.Open, FileAccess.Read);

            //Createopenxmlreader via ExcelReaderFactory
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream); //.xlsx
                                                                                           //Set the First Row as Column Name

            excelReader.IsFirstRowAsColumnNames = true;
            //Return as DataSet
            DataSet result = excelReader.AsDataSet();
            //Get all the Tables
            DataTableCollection table = result.Tables;
            //Store it in DataTable
            DataTable resultTable = table[SheetName];

            //return  
            return resultTable;

        }




        public void PopulateInCollection(String TestDateFileName, String SheetName)
        {
            dataCol = new List<Datacollection>();
            DataTable table = ExcelToDataTable(TestDateFileName, SheetName);

            //Iterate through the rows and columns of the Table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowTestCaseName = table.Rows[row - 1][0].ToString(),
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };
                    //Add all the details for each row
                    dataCol.Add(dtTable);
                }
            }
        }
        public string GetDataFromExcel(string rowTestCaseName, string columnName)
        {

            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowTestCaseName == rowTestCaseName
                               select colData.colValue).SingleOrDefault();

                //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;

                return data.ToString();

            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }

        public string GetDataFromExcel(string columnName)
        {
            string testCaseName = new StackTrace().GetFrame(1).GetMethod().Name;


            try
            {
                //Retriving Data using LINQ to reduce much of iterations
                string data = (from colData in dataCol
                               where colData.colName == columnName && colData.rowTestCaseName == testCaseName
                               select colData.colValue).ToList()[0];

                //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;

                return data.ToString();

            }
            catch (Exception e)
            {
                return e.ToString();
            }

        }

        public static ExcelUtil GetExcelUtilInstance(string TestDateFileName, string SheetName)
        {
            string TestEnv = CommonFunctions.GetAppConfigValue("TestEnvironment");
            string fileName = "";

            if (TestEnv.Equals("QA_ENV"))
                fileName = "QA_ENV_" + TestDateFileName;

            else if (TestEnv.Equals("DEV_ENV"))

              fileName = "DEV_ENV_" + TestDateFileName;

            else if (TestEnv.Equals("DEV_TEST_ENV"))
         
                fileName = "DEV_TEST_ENV_" + TestDateFileName;
           
            if (excelUtil == null || !sheetName.Equals(SheetName))
            {
                excelUtil = null;
                excelUtil = new ExcelUtil(fileName, SheetName);
                sheetName = SheetName;
            }
            return excelUtil;

        }



        public void createExcel(string fileName, DataTable DataTable)
        {
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook worKbooK;
            Microsoft.Office.Interop.Excel.Worksheet worKsheeT;
            Microsoft.Office.Interop.Excel.Range celLrangE = null;
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                worKbooK = excel.Workbooks.Add(Type.Missing);


                worKsheeT = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
                worKsheeT.Name = "ExecutionDetails";

                worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[1, 7]].Merge();
                worKsheeT.Cells[1, 1] = "STA Automation Execution Details ("+CommonFunctions.GetAppConfigValue("TestEnvironment")+")";
                worKsheeT.Cells[1, 1].Interior.Color = XlRgbColor.rgbLightGrey;
                worKsheeT.Cells[1, 1].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                worKsheeT.Cells[1, 1].Font.Bold = true;
                worKsheeT.Cells[1, 1].Font.Size = 14;
                worKsheeT.Cells.Font.Size = 12;


                int rowcount = 2;

                WriteDatAToExcelReport(fileName, excel, worKbooK, worKsheeT, celLrangE, DataTable, rowcount);

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                worKsheeT = null;
                celLrangE = null;
                worKbooK = null;
            }


        }

        public void UpdateExistingExcelReport(string fileName, DataTable DataTable)
        {

            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook wbv;
            Microsoft.Office.Interop.Excel.Worksheet worKsheeT;
            Microsoft.Office.Interop.Excel.Range celLrangE;

            excel = new Microsoft.Office.Interop.Excel.Application();
            wbv = excel.Workbooks.Open(fileName);
            worKsheeT = excel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
            celLrangE = worKsheeT.Rows;
            excel.Visible = false;
            excel.UserControl = false;
            excel.DisplayAlerts = false;
            int rowCount = worKsheeT.UsedRange.Rows.Count;


            WriteDatAToExcelReport(fileName, excel, wbv, worKsheeT, celLrangE, DataTable, 2);


        }

        public void WriteDatAToExcelReport(string fileName, Microsoft.Office.Interop.Excel.Application excel,
        Microsoft.Office.Interop.Excel.Workbook worKbooK,
        Microsoft.Office.Interop.Excel.Worksheet worKsheeT,
        Microsoft.Office.Interop.Excel.Range celLrangE, DataTable DataTable, int rowcount)
        {


            foreach (DataRow datarow in DataTable.Rows)
            {
                rowcount += 1;
                for (int i = 1; i <= DataTable.Columns.Count; i++)
                {

                    if (rowcount == 3)
                    {
                        worKsheeT.Cells[2, i] = DataTable.Columns[i - 1].ColumnName;
                        worKsheeT.Cells.Font.Color = System.Drawing.Color.Black;
                        worKsheeT.Cells[2, i].Font.Bold = true;
                        worKsheeT.Cells[2, i].Interior.Color = XlRgbColor.rgbLightSkyBlue;
                        worKsheeT.Cells[2, i].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                        worKsheeT.Cells[2, i].Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

                    }

                   worKsheeT.Cells[rowcount, i] = datarow[i - 1].ToString();


                    if (rowcount > 3)
                    {
                     
                        if (i == DataTable.Columns.Count)
                        {
                            if (rowcount % 2 == 0)
                            {
                                celLrangE = worKsheeT.Range[worKsheeT.Cells[rowcount, 1], worKsheeT.Cells[rowcount, DataTable.Columns.Count]];
                            }

                        }
                    }

                }

            }

            celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[rowcount, DataTable.Columns.Count]];
            celLrangE.EntireColumn.AutoFit();
            Microsoft.Office.Interop.Excel.Borders border = celLrangE.Borders;
            border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            border.Weight = 2d;

            celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[2, DataTable.Columns.Count]];
            Range columnBRange = worKsheeT.Range[worKsheeT.Cells[3, 2], worKsheeT.Cells[rowcount, 2]];
            Range columnFRange = worKsheeT.Range[worKsheeT.Cells[3, 6], worKsheeT.Cells[rowcount, 6]];

            columnBRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            columnBRange.VerticalAlignment= Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            columnFRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
            columnFRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

            Range columnDRange = worKsheeT.Range[worKsheeT.Cells[3, 4], worKsheeT.Cells[rowcount, 4]];
            Range columnGRange = worKsheeT.Range[worKsheeT.Cells[3, 7], worKsheeT.Cells[rowcount, 7]];
                       
            UpdateResultColors(columnDRange);
            UpdateResultColors(columnGRange);
            
            worKbooK.SaveAs(fileName);
            worKbooK.Close(true, Type.Missing, Type.Missing);
            //      worKbooK.Close();
            excel.Quit();
        } 

        public void UpdateResultColors(Range testResultcolumnRange) {
            FormatCondition cond3 = testResultcolumnRange.FormatConditions.Add(XlFormatConditionType.xlCellValue, XlFormatConditionOperator.xlEqual, "Failed");
            cond3.Font.Color = System.Drawing.Color.Red;
            cond3.Font.Bold = true;
            
            FormatCondition cond4 = testResultcolumnRange.FormatConditions.Add(XlFormatConditionType.xlCellValue, XlFormatConditionOperator.xlEqual, "Passed");
            cond4.Font.Color = System.Drawing.Color.Green;
            cond4.Font.Bold = true;

            testResultcolumnRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

        }
       


    }


    public class Datacollection
    {
        public String rowTestCaseName { get; set; }
        public string colName { get; set; }
        public string colValue { get; set; }

    }
}
