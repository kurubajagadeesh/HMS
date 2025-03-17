using System;
using Repo_Inpatient_Care.ObjectRepository;

public class Profile_management
{
    //Check if a doctor can update personal information.
    WebDriverUtlity ms = new WebDriverUtlity();
    [Test]
    public Profile_management()
	{
        HomePage homePage = new HomePage(driver);
        homePage.GoToDoctorLoginPage().Doctor_DashboardPage();
        Doctor_Homepage hm = new Doctor_Homepage(driver);
        hm.dropdownToggle_l.Click();
        hm.Myprofile_l.Click();
        Doctor_profile_editPage dpe = new Doctor_profile_editPage(driver);
        
        

        

    }
}
