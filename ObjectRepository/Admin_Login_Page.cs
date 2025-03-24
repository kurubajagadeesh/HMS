using DocumentFormat.OpenXml.Spreadsheet;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Repo_Inpatient_Care.NewFolder;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Repo_Inpatient_Care.ObjectRepository
{
    //This is the Object Repository for Admin_Login_Page
    public sealed class Admin_Login_Page : WebDriverUtility
    {
       
        public Admin_Login_Page(IWebDriver driver): base(driver)
        {
             
             this.driver = driver;


            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.Name,Using = "username")]
        private IWebElement username_L;
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password_L;
        [FindsBy(How=How.Name, Using = "submit")]
        private IWebElement submit_L;
        public IWebElement Username_L { get => username_L; set => username_L = value; }
        public IWebElement Password_L { get => password_L; set => password_L = value; }
        public IWebElement Submit_L { get => submit_L; set => submit_L = value; }
       

        public Admin_DashboardPage EnterUsernameAndPassword(string username,string password)
        {
            Console.WriteLine("navigated to Admin login page");
         
            Username_L.SendKeys(username);
            Password_L.SendKeys(password);
            Submit_L.Click();

            return new Admin_DashboardPage(driver);
        }
    }
}