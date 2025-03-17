using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Repo_Inpatient_Care.ObjectRepository;

namespace Repo_Inpatient_Care.TestScripts
{
    //Doctor add the Patient details and logout from the application;
    public class Doctor_Login_Test : BaseTest
    {
        private  ExcelFileUtility es = new ExcelFileUtility();

        [Test]

        public void login()
        {
           HomePage homePage = new HomePage(driver);
            homePage.GoToDoctorLoginPage().Doctor_DashboardPage();
           Doctor_Homepage hm = new Doctor_Homepage(driver);
            hm.patients_l.Click();
            hm.addPatient_l.Click();
            Add_patient ap = new Add_patient(driver);
            string patientname = es.toReadtheDataFromExcelfile("doctor data", 1, 1);
            string contact = es.toReadtheDataFromExcelfile("doctor data", 1, 4);
            string email = es.toReadtheDataFromExcelfile("doctor data", 1, 5);
            string patientadd=es.toReadtheDataFromExcelfile("doctor data", 1, 2);
            string age = es.toReadtheDataFromExcelfile("doctor data", 1, 8);
            string medicalhistory = es.toReadtheDataFromExcelfile("doctor data", 1, 9);
            ap.patname_l.SendKeys(patientname);
            ap.patcontact_l.SendKeys(contact);
            ap.patemail_l.SendKeys(email);
            ap.pataddress_l.SendKeys(patientadd);
            ap.patage_l.SendKeys(age);
            ap.medhis_l.SendKeys(medicalhistory);
            ap.submit_l.Click();
            hm.Logout_l.Click();
        }
    }
}
