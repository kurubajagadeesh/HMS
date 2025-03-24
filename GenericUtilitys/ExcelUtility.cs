using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Repo_Inpatient_Care.Poco_plain_old_CLR_object;

namespace Repo_Inpatient_Care.GenericUtilitys
{
    public class ExcelUtility
    {
        //public static string ReadExcleFileAndEXtractData(string path, string sheetName, int rowNo, int cellNo)
        //{
        //    //Code to read excel file and extract data
        //    XLWorkbook workbook = new XLWorkbook(path);
        //    IXLWorksheet data = workbook.Worksheet(sheetName);
        //  var excelData= data.Row(rowNo).Cell(cellNo).Value.ToString();
        //    return excelData;
        //}
        public static IEnumerable<object[]> ReadExcleFileAndEXtractData()
        {
            string path = IConstants.EXCELPATH;
            //Code to read excel file and extract data
            using (var workbook = new XLWorkbook(path))
            {
                var excelSheet = workbook.Worksheet("UserInformation");
                var firstRow = excelSheet.FirstRowUsed().RowNumber();
                var lastRow = excelSheet.LastRowUsed().RowNumber();

                for (int i = firstRow + 1; i <= lastRow; i++)
                {
                    var row = excelSheet.Row(i);

                    var data = new NewPatientData
                    {
                        FirstName = row.Cell(1).GetValue<string>().Trim() ?? string.Empty,
                        Address = row.Cell(2).GetValue<string>().Trim() ?? string.Empty,
                        City = row.Cell(3).GetValue<string>().Trim() ?? string.Empty,
                        Gender = row.Cell(4).GetValue<string>().Trim() ?? string.Empty,
                        Email = row.Cell(5).GetValue<string>().Trim() ?? string.Empty,
                        password = row.Cell(6).GetValue<string>().Trim() ?? string.Empty,
                        ConfirmPassword = row.Cell(7).GetValue<string>().Trim() ?? string.Empty

                    };

                    yield return new object[] { data };
                }
            }





        }
    }
}
