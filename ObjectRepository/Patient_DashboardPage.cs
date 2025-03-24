using OpenQA.Selenium;
using Repo_Inpatient_Care.GenericUtilitys;
using Repo_Inpatient_Care.NewFolder;
using SeleniumExtras.PageObjects;

namespace Repo_Inpatient_Care.ObjectRepository
{
    public sealed class Patient_DashboardPage: WebDriverUtility
    {
         

        public Patient_DashboardPage(IWebDriver driver): base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How=How.XPath,Using = "//span[text()=' Book Appointment ']")]
        private IWebElement bookAppointment;
        [FindsBy(How = How.Name, Using = "Doctorspecialization")]
        private IWebElement Doctorspecialization;
        [FindsBy(How=How.Id,Using = "doctor")]
        private IWebElement Doctors;
        [FindsBy(How = How.Id, Using = "fees")]
        private IWebElement ConsultancyFees;
        [FindsBy(How = How.Name, Using = "appdate")]
        private IWebElement appdate;
        [FindsBy(How = How.Name, Using = "submit")]
        private IWebElement submit;
        [FindsBy(How = How.XPath, Using = "//span[text()=' Appointment History ']")]
        private IWebElement appointmentHistory;
        [FindsBy(How = How.XPath, Using = "//span[text()=' Medical History ']")]
        private IWebElement medicalHistory;

        public IWebElement BookAppointment { get => bookAppointment; set => bookAppointment = value; }
        public IWebElement Doctorspecialization1 { get => Doctorspecialization; set => Doctorspecialization = value; }
        public IWebElement Doctors1 { get => Doctors; set => Doctors = value; }
        public IWebElement ConsultancyFees1 { get => ConsultancyFees; set => ConsultancyFees = value; }
        public IWebElement Appdate { get => appdate; set => appdate = value; }
        public IWebElement Submit { get => submit; set => submit = value; }
        public IWebElement MedicalHistory { get => medicalHistory; set => medicalHistory = value; }

        public Patient_DashboardPage UserBookAppointment(string doctorspecialization,string doctorsName,string consultancyFees)
        {
            ClickOnElement(BookAppointment);
            SelectByValue(Doctorspecialization1, doctorspecialization);
            SelectByValue(Doctors1, doctorsName);
           // SelectByValue(ConsultancyFees1, consultancyFees);
            Appdate.SendKeys(CsharpUtility.Date());
            ClickOnElement(Submit);
            AcceptAlertIfPresent();
            return new Patient_DashboardPage(driver);

        }
        public void UserAppointmentHistory()
        {
            ClickOnElement(appointmentHistory);

        }
        public void UsersMedicalHistory()
        {
            ClickOnElement(medicalHistory);

        }
    }
}