using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Repo_Inpatient_Care.TestScripts
{
    public class Class1
    {

        [Test]
        public void login()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://49.249.28.218:8081/AppServer/Hospital_Doctor_Patient_Management_System/hms/admin/");
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("Test@12345");
            driver.FindElement(By.Name("submit")).Click();
        }
    }
}
