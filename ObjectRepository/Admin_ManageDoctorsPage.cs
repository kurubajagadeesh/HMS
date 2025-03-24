using OpenQA.Selenium;
using Repo_Inpatient_Care.NewFolder;
using SeleniumExtras.PageObjects;

namespace Repo_Inpatient_Care.ObjectRepository
{
    public sealed class Admin_ManageDoctorsPage: WebDriverUtility
    {
         

        public Admin_ManageDoctorsPage(IWebDriver driver): base(driver)
        {
             PageFactory.InitElements(driver, this);
        }
        [FindsBy(How=How.XPath,Using = "//p[normalize-space(text()='data deleted')]")]
        private IWebElement dataDeleted;
        [FindsBy(How = How.XPath, Using = " //span[text()=' Manage Doctors ']")]
        private IWebElement manageDoctors;

        public IWebElement DataDeleted { get => dataDeleted; set => dataDeleted = value; }
        public IWebElement ManageDoctors { get => manageDoctors; set => manageDoctors = value; }

        //public IWebElement DoctorName => WaitAndFindElement(By.XPath("//table//tr//td[.='Homeopath']"));


        public string GetDoctorName(string doctorName)
        {
        string name= WaitAndFindElement(By.XPath($"//table//tr//td[.='{doctorName}']")).Text;
            return name;
        }
        public string DeleteDoctorAccount(string doctorName)
        {
             
           // WaitAndFindElement(By.XPath($"//tr//td[.='{doctorName}']/following-sibling::td//a[@tooltip='Remove']")).Click();
            WaitUntilEleIsVisibleAndScrollToEleAndClick(By.XPath($"//tr//td[.='{doctorName}']/following-sibling::td//a[@tooltip='Remove']/i"));
            AcceptAlertIfPresent();
         string elementPresent= DataDeleted.Text;
            return elementPresent;

            //table//tr//td[.='Sarita Pandey']/..//following-sibling::div//a[@href='manage-doctors.php?id=2&del=delete']
        }
        public void EditDoctorAccount(string doctorName)
        {
            ClickOnElement(ManageDoctors);
            WaitAndFindElement(By.XPath($"//tr//td[.='{doctorName}']/following-sibling::td//a[@tooltip='Edit']")).Click();
        }
    }
}