using Repo_Inpatient_Care.GenericUtilitys;
using Repo_Inpatient_Care.Poco_plain_old_CLR_object;

namespace Repo_Inpatient_Care.TestScripts
{
    public class PatientTests : BaseTest
    {
        [Test(Description = "New User Create Account By Enter  personal details"),Ignore("user should create account and login")]
        [Category("Regression Test")]
        [TestCaseSource(typeof(ExcelUtility), nameof(ExcelUtility.ReadExcleFileAndEXtractData))]
        public void CreateNewPatientAccount(NewPatientData data)
        {
            homePage.GoToPatientLoginPage().ClickOnCreateAccount().CreateNewUserAccount(data.FirstName, data.Address, data.City, data.Gender, data.Email, data.password, data.ConfirmPassword);
        }
        [Test(Description = "New User Create Account By Enter  personal details And Login")]
        [Category("Regression Test")]
        [TestCaseSource(typeof(ExcelUtility), nameof(ExcelUtility.ReadExcleFileAndEXtractData))]

        public void CreateNewPatientAccountAndLogin(NewPatientData data)
        {
            homePage.GoToPatientLoginPage().ClickOnCreateAccount().CreateNewUserAccount(data.FirstName, data.Address, data.City, data.Gender, data.Email, data.password, data.ConfirmPassword).
                ClickOnLoginButtonInPatirntRegistrationPage().EnterUserUsernameAndPassword(data.Email, data.password);
        }
        [Test(Description = "User Checks His Appointment History")]
        [TestCaseSource(typeof(JsonUtility), nameof(JsonUtility.JsonDataSet))]
        public void PatientAppointment(GetJsonData data)
        {
            homePage.GoToPatientLoginPage().EnterUserUsernameAndPassword(data.patientloginConfig.username, data.patientloginConfig.password).UserAppointmentHistory();
        }

    }
}
