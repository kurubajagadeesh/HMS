using Repo_Inpatient_Care.GenericUtilitys;
using Repo_Inpatient_Care.Poco_plain_old_CLR_object;

namespace Repo_Inpatient_Care.TestScripts
{
    [TestFixture]
    //[TestFixtureSource(typeof(JsonAndExcelUtility), nameof(JsonAndExcelUtility.CombinedTestDataSource))]

    public class AdminTests : BaseTest
    {




        [Test(Description = "Admin login to application"), Category("Sanity Test")]
        [TestCaseSource(typeof(JsonUtility), nameof(JsonUtility.JsonDataSet))]
        public void AdminLoginToApp(GetJsonData data)
        {

            Assert.AreEqual(homePage.GoToAdminLoginPage().EnterUsernameAndPassword(data.adminloginConfig.username, data.adminloginConfig.password)
                .GetUsername(), "Admin");

        }
        [Test(Description = "Admin Create New DoctorSpecialization")]
        [Category("Sanity Test")]
        [Category("Regression Test")]
        [Order(1)]
        [TestCaseSource(typeof(JsonUtility), nameof(JsonUtility.JsonDataSet))]

        public void AdminCreateNewDoctorSpecialization(GetJsonData data)
        {
             
            Assert.True(homePage.GoToAdminLoginPage().EnterUsernameAndPassword(data.adminloginConfig.username, data.adminloginConfig.password)
                .ClickOnDoctorSpecialization().EnterDoctorSpecializationAndSubmit("Neurologist"));
        }
        [Test(Description = "Admin Create New Doctor")]
        [Category("Sanity Test")]
        [Category("Regression Test")]
        [Order(2)]

        [TestCaseSource(typeof(JsonAndExcelUtility), nameof(JsonAndExcelUtility.CombinedTestDataSource))]
        public void AdminCreateNewDoctor(GetJsonData data, NewDoctorData doctorData)
        {
           Assert.AreEqual(homePage.GoToAdminLoginPage().EnterUsernameAndPassword(data.adminloginConfig.username, data.adminloginConfig.password)
               .GoToAddDoctorPage().EnterDoctorDetails(doctorData.doctorSpecialization, doctorData.doctorName, doctorData.clinicAddress, doctorData.doctorFees, doctorData.doctorContact, doctorData.doctorEmail, doctorData.newPassword, doctorData.confirmPassword)
               .GetDoctorName(doctorData.doctorName),doctorData.doctorName);
        }

        [Test(Description = "Admin Delete Doctor Account")]
        [Category("Regression Test")]
        [Order(3)]
        [TestCaseSource(typeof(JsonAndExcelUtility), nameof(JsonAndExcelUtility.CombinedTestDataSource))]
        public void AdminDeleteDoctorAccount(GetJsonData data, NewDoctorData doctorData)
        {
            Assert.AreEqual(homePage.GoToAdminLoginPage().EnterUsernameAndPassword(data.adminloginConfig.username, data.adminloginConfig.password)
                 .GoToManageDoctorsPage().DeleteDoctorAccount(doctorData.doctorName), "data deleted !!");


        }


    } 

}
