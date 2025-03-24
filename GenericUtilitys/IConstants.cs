using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo_Inpatient_Care.GenericUtilitys
{
     public interface IConstants
    {
        public static string JSONFILEPATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName+"\\Resources\\CommonData.json";
        public static string EXCELPATH = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName+ "\\Resources\\TestData.xlsx";
         

    }
}
