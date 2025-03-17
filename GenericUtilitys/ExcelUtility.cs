using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Repo_Inpatient_Care.GenericUtilitys
{
    public class ExcelUtility
    {
        public static string ReadExcleFileAndEXtractData(string path, string sheetName, int rowNo, int cellNo)
        {
            //Code to read excel file and extract data
            XLWorkbook workbook = new XLWorkbook(path);
            IXLWorksheet data = workbook.Worksheet(sheetName);
          var excelData= data.Row(rowNo).Cell(cellNo).Value.ToString();
            return excelData;
        }
        public static List<ExcelData> ReadExcleFileAndEXtractData(string path, string sheetName)
        {
            //Code to read excel file and extract data
            var dataList = new List<ExcelData>();

            try
            {
                using (XLWorkbook workbook = new XLWorkbook(path))
                {
                    IXLWorksheet excelSheet = workbook.Worksheet(sheetName);

                    var firstRow = excelSheet.FirstRowUsed().RowNumber();
                    var lastRow = excelSheet.LastRowUsed().RowNumber();

                    for (int i = firstRow + 1; i <= lastRow; i++) // Skip header row
                    {
                        var row = excelSheet.Row(i);

                        var data = new ExcelData
                        {
                            Username = row.Cell(1).GetValue<string>().Trim() ?? string.Empty,
                            password = row.Cell(2).GetValue<string>().Trim() ?? string.Empty,
                            email = row.Cell(3).GetValue<string>().Trim() ?? string.Empty, // example of extra column
                            role = row.Cell(4).GetValue<string>().Trim() ?? string.Empty   // another extra column
                        };

                        dataList.Add(data);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle or log exception as needed
                Console.WriteLine($"Error reading Excel file: {ex.Message}");
            }

            return dataList;

        }
    }
}
