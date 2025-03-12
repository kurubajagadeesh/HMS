using Repo_Inpatient_Care.Constants;
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


        }
        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("SetUp");
            Console.WriteLine("========Open Browser========");
            homePage = new HomePage(Browsers.CHROME);
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("OneTimeTearDown");
            Console.WriteLine("========Close Database Connection========");

        }
    }
}
