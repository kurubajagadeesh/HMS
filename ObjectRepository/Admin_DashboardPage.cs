using OpenQA.Selenium;

namespace Repo_Inpatient_Care.ObjectRepository
{
    //This is the Object Repository for Admin_DashboardPage

    public class Admin_DashboardPage
    {
        private IWebDriver driver;

        public Admin_DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}