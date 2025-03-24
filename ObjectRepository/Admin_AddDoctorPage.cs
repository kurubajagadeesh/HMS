using OpenQA.Selenium;
using Repo_Inpatient_Care.NewFolder;
using SeleniumExtras.PageObjects;

namespace Repo_Inpatient_Care.ObjectRepository
{
    public sealed class Admin_AddDoctorPage : WebDriverUtility
    {


        public Admin_AddDoctorPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Name, Using = "Doctorspecialization")]
        private IWebElement doctorSpecialization;
        [FindsBy(How = How.Name, Using = "docname")]
        private IWebElement doctorName;
        [FindsBy(How = How.Name, Using = "clinicaddress")]
        private IWebElement clinicAddress;
        [FindsBy(How = How.Name, Using = "docfees")]
        private IWebElement doctorFees;
        [FindsBy(How = How.Name, Using = "doccontact")]
        private IWebElement doctorContact;
        [FindsBy(How = How.Id, Using = "docemail")]
        private IWebElement doctorEmail;
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='New Password']")]
        private IWebElement newPassword;
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Confirm Password']")]
        private IWebElement confirmPassword;
        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement submitButton;

        public IWebElement DoctorSpecialization { get => doctorSpecialization; set => doctorSpecialization = value; }
        public IWebElement DoctorName { get => doctorName; set => doctorName = value; }
        public IWebElement ClinicAddress { get => clinicAddress; set => clinicAddress = value; }
        public IWebElement DoctorFees { get => doctorFees; set => doctorFees = value; }
        public IWebElement DoctorContact { get => doctorContact; set => doctorContact = value; }
        public IWebElement DoctorEmail { get => doctorEmail; set => doctorEmail = value; }
        public IWebElement NewPassword { get => newPassword; set => newPassword = value; }
        public IWebElement ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
        public IWebElement SubmitButton { get => submitButton; set => submitButton = value; }

        public Admin_ManageDoctorsPage EnterDoctorDetails(string specialization, string name, string address, string fees, string contact, string email, string password,string ConformPassword)
        {
            SelectByValue(DoctorSpecialization, specialization);
            DoctorName.SendKeys(name);
            ClinicAddress.SendKeys(address);
            DoctorFees.SendKeys(fees);
            DoctorContact.SendKeys(contact);
            DoctorEmail.SendKeys(email);
            NewPassword.SendKeys(password);
            ConfirmPassword.SendKeys(password);
            ClickOnElement(SubmitButton);
            AcceptAlertIfPresent();
            return new Admin_ManageDoctorsPage(driver);
        }
    }
}