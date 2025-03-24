using OpenQA.Selenium;
using Repo_Inpatient_Care.NewFolder;
using SeleniumExtras.PageObjects;

namespace Repo_Inpatient_Care.ObjectRepository
{
    //This is the Object Repository for Admin_DashboardPage

    public sealed class Admin_DashboardPage : WebDriverUtility
    {


        public Admin_DashboardPage(IWebDriver driver) : base(driver)
        {

            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//span[@class='username']")]
        private IWebElement username;
        [FindsBy(How = How.XPath, Using = "//span[text()=' Doctors ']")]
        private IWebElement doctors;
        [FindsBy(How = How.XPath, Using = "//span[text()=' Doctor Specialization ']")]
        private IWebElement doctorSpecialization;
        [FindsBy(How = How.XPath, Using = "//span[text()=' Add Doctor']")]
        private IWebElement AddDoctor;
        [FindsBy(How = How.XPath, Using = " //span[text()=' Manage Doctors ']")]
        private IWebElement manageDoctors;

        public IWebElement Username { get => username; set => username = value; }
        public IWebElement Doctors { get => doctors; set => doctors = value; }
        public IWebElement DoctorSpecialization { get => doctorSpecialization; set => doctorSpecialization = value; }
        public IWebElement AddDoctor1 { get => AddDoctor; set => AddDoctor = value; }
        public IWebElement ManageDoctors { get => manageDoctors; set => manageDoctors = value; }

        public string GetUsername()
        {
            return GetText(username);
        }
        public void ClickOnDoctorsSection()
        {
            ClickOnElement(Doctors);
        }

        public Admin_AddDoctorSpecializationPage ClickOnDoctorSpecialization()
        {
            ClickOnElement(Doctors);
            ClickOnElement(doctorSpecialization);
            return new Admin_AddDoctorSpecializationPage(driver);

        }
        public Admin_AddDoctorPage GoToAddDoctorPage()
        {
            ClickOnElement(Doctors);
            ClickOnElement(AddDoctor1);
            return new Admin_AddDoctorPage(driver);

        }
        public Admin_ManageDoctorsPage GoToManageDoctorsPage()
        {
            ClickOnElement(Doctors);
            ImplicityWait();
            ClickOnElement(ManageDoctors);
            return new Admin_ManageDoctorsPage(driver);

        }
    }
}