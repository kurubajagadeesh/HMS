using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Bibliography;
using OpenQA.Selenium;
using Repo_Inpatient_Care.Constants;
using Repo_Inpatient_Care.NewFolder;
using SeleniumExtras.PageObjects;

namespace Repo_Inpatient_Care.ObjectRepository
{
    public class HomePage
    {
        private IWebDriver driver;
        //This is the Object Repository for HomePag
        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            MaximizeWindow();
            loadWebapp("http://49.249.28.218:8081/AppServer/Hospital_Doctor_Patient_Management_System/");

        }
        [FindsBy(How = How.XPath, Using = "//a[text()='Logins']")]
        private IWebElement logins;
        [FindsBy(How = How.XPath, Using = "//a[@href='hms/admin']")]
        private IWebElement adminLog_L;
        [FindsBy(How = How.XPath, Using = "//a[@href='hms/doctor']")]
        private IWebElement doctorLog_L;
        [FindsBy(How = How.XPath, Using = "//a[@href='hms/patient']")]
        private IWebElement patientLog_L;


        public IWebElement Logins_L { get => logins; set => logins = value; }
        public IWebElement AdminLog_L { get => adminLog_L; set => adminLog_L = value; }
        public IWebElement DoctorLog_L { get => doctorLog_L; set => doctorLog_L = value; }
        public IWebElement PatientLog_L { get => patientLog_L; set => patientLog_L = value; }

        public void GoToLogins()
        {
            ClickOnElement(logins);
            // ClickOnElement(logs);
        }
        public Admin_Login_Page GoToAdminLoginPage()
        {
            ClickOnElement(logins);

            ClickOnElement(adminLog_L);
            switchToWindows();

            return new Admin_Login_Page(driver);
        }
        public Doctor_Login_Page GoToDoctorLoginPage()
        {

            ClickOnElement(logins);
            ClickOnElement(doctorLog_L);
            switchToWindows();
            return new Doctor_Login_Page(driver);
        }
        public void GoToPationLoginPage()
        {
            ClickOnElement(logins);
            ClickOnElement(PatientLog_L);
        }
    }
}

   
