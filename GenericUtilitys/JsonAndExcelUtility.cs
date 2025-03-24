using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Newtonsoft.Json;
using Repo_Inpatient_Care.Poco_plain_old_CLR_object;

namespace Repo_Inpatient_Care.GenericUtilitys
{
    public class JsonAndExcelUtility
    {
        public static List<NewDoctorData> ReadDataFromExcel()
        {
            List<NewDoctorData> doctorData = new List<NewDoctorData>();
            string path = IConstants.EXCELPATH;
            XLWorkbook workbook = new XLWorkbook(path);
            IXLWorksheet worksheet = workbook.Worksheet(2);
            int rowCount = worksheet.RowsUsed().Count();
            for (int i = 2; i <= rowCount; i++)
            {
                doctorData.Add(new NewDoctorData()
                {
                    doctorSpecialization = worksheet.Cell(i, 1).Value.ToString(),
                    doctorName = worksheet.Cell(i, 2).Value.ToString(),
                    clinicAddress = worksheet.Cell(i, 3).Value.ToString(),
                    doctorFees = worksheet.Cell(i, 4).Value.ToString(),
                    doctorContact = worksheet.Cell(i, 5).Value.ToString(),
                    doctorEmail = worksheet.Cell(i, 6).Value.ToString(),
                    newPassword = worksheet.Cell(i, 7).Value.ToString(),
                    confirmPassword = worksheet.Cell(i, 8).Value.ToString()
                });

            }
            return doctorData;
        }


        public static IEnumerable<TestCaseData> CombinedTestDataSource()
        {
            
                // Load JSON data
                string jsonPath = IConstants.JSONFILEPATH;
                string jsonContent = File.ReadAllText(jsonPath);
                GetJsonData jsonData = JsonConvert.DeserializeObject<GetJsonData>(jsonContent);

                // Load Excel doctor data
                List<NewDoctorData> doctors = ReadDataFromExcel();

                foreach (var doctor in doctors)
                {
                    yield return new TestCaseData(jsonData, doctor);
                }
            }
        }

    }


