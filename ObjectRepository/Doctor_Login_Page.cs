using System.Net;
using OpenQA.Selenium;

namespace Repo_Inpatient_Care.ObjectRepository
{
    public class Doctor_Login_Page
    {

        public Doctor_Login_Page(IWebDriver driver)
        {
            PageFactory.InitElement(driver, this); 
        }

        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement usernameText;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement passwordText;



    }
}