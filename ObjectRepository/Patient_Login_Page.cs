using OpenQA.Selenium;
using Repo_Inpatient_Care.NewFolder;
using SeleniumExtras.PageObjects;

namespace Repo_Inpatient_Care.ObjectRepository
{
    public sealed class Patient_Login_Page : WebDriverUtility
    {


        public Patient_Login_Page(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Name, Using = "username")]
        private IWebElement username;
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;
        [FindsBy(How = How.Name, Using = "submit")]
        private IWebElement exestingUserlogin;
        [FindsBy(How = How.XPath, Using = "//a[@href='registration.php']")]
        private IWebElement createAccount;



        public IWebElement Username { get => username; set => username = value; }
        public IWebElement Password { get => password; set => password = value; }
        public IWebElement Login { get => exestingUserlogin; set => exestingUserlogin = value; }
        public IWebElement CreateAccount { get => createAccount; set => createAccount = value; }
        

        public Patient_Registration_Page ClickOnCreateAccount()
        {
            ClickOnElement(CreateAccount);
            return new Patient_Registration_Page(driver);
        }


        public Patient_DashboardPage EnterUserUsernameAndPassword(string username, string password)
        {
            
            Username.SendKeys(username);
            Password.SendKeys(password);
            Login.Click();
            return new Patient_DashboardPage(driver);

        }

    }
}