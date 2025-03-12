using OpenQA.Selenium;

namespace Repo_Inpatient_Care.ObjectRepository
{
    public class Doctor_Login_Page
    {
        private IWebDriver driver;

        public Doctor_Login_Page(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}