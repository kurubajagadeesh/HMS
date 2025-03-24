

using OpenQA.Selenium;
using Repo_Inpatient_Care.NewFolder;
 
using SeleniumExtras.PageObjects;
using System.Net;



namespace Repo_Inpatient_Care.ObjectRepository
{
    //This is the Object Repository for Doctor_Login_Page

    public class Doctor_Login_Page : WebDriverUtility
    {

        public Doctor_Login_Page(IWebDriver driver):base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        } 
        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement submit;


        public IWebElement username_1 { get => username; set => username = value; }
        public IWebElement password_1 { get => password; set => password = value; }
        public IWebElement submit_1 { get => submit; set => submit = value; }

        //Business logic
        
    }
}