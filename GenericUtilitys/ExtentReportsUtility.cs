using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Repo_Inpatient_Care.GenericUtilitys
{
    public class ExtentReportsUtility
    {
        private static ExtentReports extetReports;
         public static ThreadLocal<ExtentTest> extentTest = new ThreadLocal<ExtentTest>();
      //  private static ExtentTest extentTest;



        public static void SetupSparkReporter(string reportName)
        {
            var dateTime = CsharpUtility.Date_time();
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            
            string fileName = reportName + ".html";
            string path = Path.Combine(projectPath, "Reports", "ExtentReports", dateTime, fileName);

            ExtentSparkReporter extentSparkReporter = new ExtentSparkReporter(path);
            extetReports = new ExtentReports();
            extetReports.AttachReporter(extentSparkReporter);
        }

        public static void createExtentTest(string testName)
        {
            ExtentTest test = extetReports.CreateTest(testName);
            extentTest.Value = test;
        }
        public static ExtentTest GetTest()
        {
            return extentTest.Value;
        }
        public static void EndReporting()
        {
            extetReports.Flush();
        }
        public static void ExtentReport(string testMethodName)
        {
            var dateTime = CsharpUtility.Date_time();
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            string fileName = testMethodName + ".html";
            string path = Path.Combine(projectPath, "Reports", "ExtentReports", dateTime, fileName);
            ExtentSparkReporter extentSparkReporter = new ExtentSparkReporter(path);
            extetReports = new ExtentReports();
            extetReports.AttachReporter(extentSparkReporter);
            ExtentTest extentTest = extetReports.CreateTest(testMethodName);
             extetReports.Flush();

        }
    }
}

