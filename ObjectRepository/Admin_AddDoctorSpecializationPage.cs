using OpenQA.Selenium;
using Repo_Inpatient_Care.NewFolder;
using SeleniumExtras.PageObjects;

namespace Repo_Inpatient_Care.ObjectRepository
{
    public sealed class Admin_AddDoctorSpecializationPage: WebDriverUtility
    {
        public Admin_AddDoctorSpecializationPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.Name,Using= "doctorspecilization")]
        private IWebElement doctorSpecialization;
        [FindsBy(How = How.XPath, Using = "//button[@name='submit']")]
        private IWebElement submitButton;
        [FindsBy(How = How.XPath, Using = " //p[normalize-space(text()='Doctor Specialization added successfully')]")]
        private IWebElement successMessage;

        public IWebElement DoctorSpecialization { get => doctorSpecialization; set => doctorSpecialization = value; }
        public IWebElement SubmitButton { get => submitButton; set => submitButton = value; }
        public IWebElement SuccessMessage { get => successMessage; set => successMessage = value; }

        public bool EnterDoctorSpecializationAndSubmit(string specialization)
        {
            DoctorSpecialization.SendKeys(specialization);
            ClickOnElement(SubmitButton);
          bool  element=successMessage.Displayed;
            return element;

        }
    }

    
    
}