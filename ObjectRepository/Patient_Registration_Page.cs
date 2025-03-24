using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using OpenQA.Selenium;
using Repo_Inpatient_Care.NewFolder;
using SeleniumExtras.PageObjects;

namespace Repo_Inpatient_Care.ObjectRepository
{
    public sealed class Patient_Registration_Page:WebDriverUtility
    {
        public Patient_Registration_Page(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);

        }
        
        [FindsBy(How = How.Name, Using = "full_name")]
        private IWebElement fullName;
        [FindsBy(How = How.Name, Using = "address")]
        private IWebElement address;
        [FindsBy(How = How.Name, Using = "city")]
        private IWebElement city;
        [FindsBy(How = How.XPath, Using = "//label[@for='rg-female']")]
        private IWebElement radioButtonF;
        [FindsBy(How = How.XPath, Using = "//label[@for='rg-male']")]
        private IWebElement radioButtonM;
        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement email;
        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement Emailpassword;
        [FindsBy(How = How.Id, Using = "password_again")]
        private IWebElement passwordAgain;
        [FindsBy(How = How.Id, Using = "submit")]
        private IWebElement submit;
        [FindsBy(How = How.XPath, Using = "//a[@href='user-login.php']")]
        private IWebElement newUserlogin;
        public IWebElement FullName { get => fullName; set => fullName = value; }
        public IWebElement Address { get => address; set => address = value; }
        public IWebElement City { get => city; set => city = value; }
        public IWebElement RadioButtonF { get => radioButtonF; set => radioButtonF = value; }
        public IWebElement RadioButtonM { get => radioButtonM; set => radioButtonM = value; }
        public IWebElement Email { get => email; set => email = value; }
        public IWebElement Emailpassword1 { get => Emailpassword; set => Emailpassword = value; }
        public IWebElement PasswordAgain { get => passwordAgain; set => passwordAgain = value; }
        public IWebElement Submit { get => submit; set => submit = value; }
        public IWebElement NewUserlogin { get => newUserlogin; set => newUserlogin = value; }

        public Patient_Registration_Page CreateNewUserAccount(string firstName, string address, string city,
           string gender, string email, string password, string ConfirmPassword)
        {

             
            FullName.SendKeys(firstName);
            Address.SendKeys(address);
            City.SendKeys(city);
            if (gender.Equals("mail"))
            {
                ClickOnElement(RadioButtonM);
            }
            else
            {
                ClickOnElement(RadioButtonF);
            }
            Email.SendKeys(email);
            Emailpassword.SendKeys(password);
            PasswordAgain.SendKeys(ConfirmPassword);
            // WaitUntilEleIsVisibleAndScrollToEleAndClick(By.XPath("//a[@href='registration.php']"), 10);
            ClickElementThroughJavaScript(Submit);
            AcceptAlertIfPresent();
            return new Patient_Registration_Page(driver);
        }
        public Patient_Login_Page ClickOnLoginButtonInPatirntRegistrationPage()
        {
            ClickElementThroughJavaScript(NewUserlogin);
            //ClickOnElement(NewUserlogin);
            
            return new Patient_Login_Page(driver);

        }
    }
}
