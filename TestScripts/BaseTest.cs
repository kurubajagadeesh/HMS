using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using Repo_Inpatient_Care.Constants;
using Repo_Inpatient_Care.GenericUtilitys;
using Repo_Inpatient_Care.NewFolder;
using Repo_Inpatient_Care.ObjectRepository;

namespace Repo_Inpatient_Care.TestScripts
{

    public class BaseTest
    {

      protected  HomePage homePage;


        
        /*
         * when you need global setup/teardown logic (e.g., setting up a database connection,
         * initializing configurations, or cleaning up resources after all tests run).
         * */
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Console.WriteLine("OneTimeSetUp");
            Console.WriteLine("🔌 Connecting to Database...");
            Console.WriteLine("⚙️  Configuring Application...");
            ExtentReportsUtility.SetupSparkReporter("TestReports");


        }
        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("SetUp");
            Console.WriteLine("========Open Browser========");
            string testName = TestContext.CurrentContext.Test.Name;
            ExtentReportsUtility.createExtentTest(testName);

        homePage = new HomePage(Browsers.CHROME);
        }
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown");
            Console.WriteLine("========Close Browser========");
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var testName = TestContext.CurrentContext.Test.Name;
            var test = ExtentReportsUtility.GetTest();

            switch (testStatus)
            {
                case TestStatus.Passed:
                    test.Pass("Test passed");
                    break;
                case TestStatus.Failed:
                    string errorMessage = TestContext.CurrentContext.Result.Message;
                    string stackTrace = TestContext.CurrentContext.Result.StackTrace;
                    var screenshot = homePage.TakeScreenshotToReport();
                    test.Fail($"Test failed: {errorMessage}")
                        .Fail($"Stack Trace: {stackTrace}")
                        .AddScreenCaptureFromBase64String(screenshot);  


                    break;
                case TestStatus.Skipped:
                    test.Skip("Test skipped");
                    break;
                default:
                    test.Info("Test completed with status: " + testStatus);
                    break;
            }
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("OneTimeTearDown");
            Console.WriteLine("========Close Database Connection========");
            ExtentReportsUtility.EndReporting();

        }
    }
}
