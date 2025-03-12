using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Repo_Inpatient_Care.Constants;
using SeleniumExtras.WaitHelpers;

namespace Repo_Inpatient_Care.NewFolder
{
    public abstract class WebDriverUtility
    {
       protected IWebDriver driver;

        public IWebDriver Driver { get => driver; }

        public WebDriverUtility(IWebDriver driver)
        {
            this.driver = driver;
        }

        public WebDriverUtility(Browsers browsersName)
        {
            if (browsersName.Equals(Browsers.CHROME))
            {
                driver = new ChromeDriver();

            }
            else if (browsersName.Equals(Browsers.FIREFOX))
            {
                driver = new FirefoxDriver();

            }
            else if (browsersName.Equals(Browsers.EDGE))
            {
                driver = new EdgeDriver();

            }
            else
            {
                throw new Exception(browsersName + "is null");
            }
             
        }
        public IWebDriver GetDriver()
        {
            return Driver;
        }
        /**
 * This method is used to opent new browser by using browser name
 * @param string
 
 */

        public IWebDriver LuanchEmptyBrowser(string browser)
        {
            //Launch an empty browser
            if (browser.Equals("chrome", StringComparison.CurrentCultureIgnoreCase))
            {
                driver = new ChromeDriver();
                return Driver;
            }
            else if (browser.Equals("FireFox", StringComparison.CurrentCultureIgnoreCase))
            {
                driver = new FirefoxDriver();
                return Driver;
            }
            else if (browser.Equals("Edge", StringComparison.CurrentCultureIgnoreCase))
            {
                driver = new EdgeDriver();
                return Driver;
            }
            else
            {
                throw new Exception(browser + "is null");
            }

        }

        public IWebDriver getDriver()
        {
            return driver;
        }
        //this method is used to load new app
        public void loadWebapp(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
        public void ClickOnElement(IWebElement element)
        {
            element.Click();
        }
        /**
	 * This method is to maximize window
	 * @param driver
	 */
        public void MaximizeWindow()
        {
            Driver.Manage().Window.Maximize();

        }

        /**
	 * This method is to minimize window
	 * @param driver
	 */
        public void minimizeWindow()
        {
            Driver.Manage().Window.Minimize();
        }

        public void ImplicityWait(long sec)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(sec);
        }
        /**
 * This method is used to wait until page load
 * @param driver
 * @param sec
 */
        public void waitForPageLoad(int sec)
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }



        /*
         * this method is used to send text to element
         *@param element
         *@param value
     */
        public void SendTextTo(IWebElement element, string value)
        {

            element.SendKeys(value);
        }

        /**
 * This method is used to wait until element to be visible
 * @param driver
 * @param locator
 * @param sec
 */
        public void waituntilEleIsVisible(By locators, int sec,string username)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement usernameElement = wait.Until(ExpectedConditions.ElementIsVisible(locators));
            usernameElement.SendKeys(username);

        }
        /** 
 * This method is used to wait until element to be Clickable
 * @param driver
 * @param locator
 * @param sec
 */
        public void waitUntilEleToBeClickable(IWebElement locator, int sec)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(sec));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }


        public string GetText(IWebElement element)
        {
            string eleValue = element.Text;
            return eleValue;
        }
        /**
 * This method is used to select dropdown by using index
 * @param element
 * @param index
 */
        public void dropdown(IWebElement element, int index)
        {
            SelectElement selct = new SelectElement(element);
            selct.SelectByIndex(index);
        }
        /**
 * This method is used to select dropdown by using value
 * @param element
 * @param value
 */
        public void dropdown(IWebElement element, string value)
        {
            SelectElement selct = new SelectElement(element);
            selct.SelectByValue(value);
        }
        /**
 * This method is used to select dropdown by using visible text
 * @param text
 * @param element
 */
        public void dropdown(string text, IWebElement element)
        {
            SelectElement selct = new SelectElement(element);
            selct.SelectByText(text);
        }
        /**
         * this method is used to move to element
         * @param element
         */
        public void mouseHoverToElement(IWebElement element)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Click().Perform();
        }
        /*
       * this method is used Performs a drag-and-drop operation from one element to another.
    
     Parameters:
       source:The element on which the drag operation is started.
    
       target: The element on which the drop is performed.
    
     Returns:A self-reference to this OpenQA.Selenium.Interactions.Actions.
        @param driver
        @param element1
        @Param element2
        */
        public void dragAndDrop(IWebElement src, IWebElement dst)
        {
            Actions action = new Actions(Driver);
            action.DragAndDrop(src, dst).Perform();
        }
        /*
         * this method is used to Double-clicks the mouse at the last known mouse coordinates.
           Returns: A self-reference to this OpenQA.Selenium.Interactions.Actions.
        @param driver
        */
        public void doubleClick()
        {
            Actions action = new Actions(Driver);
            action.DoubleClick().Perform();
        }
        /*
         this method is used to Double-clicks the mouse on the specified element.
          @Parameter:Element The element on which to double-click.
          @Parameter driver
        
        Returns:
           A self-reference to this OpenQA.Selenium.Interactions.Actions.
        */
        public void doubleClickOnElement(IWebElement element)
        {
            Actions action = new Actions(Driver);
            action.DoubleClick(element).Perform();
        }
        /* 
         this method is used to pefgorm Right-clicks the mouse at the last known mouse coordinates.
    
     Returns:
        A self-reference to this OpenQA.Selenium.Interactions.Actions.
        @Param driver
        */
        public void rightClickOnWebPage()
        {
            Actions act = new Actions(Driver);
            act.ContextClick().Perform();
        }
        /* 
         this method is used to pefgorm Right-clicks the mouse at the last known mouse coordinates.
    
     Returns:
        A self-reference to this OpenQA.Selenium.Interactions.Actions.
        @Param driver
        @param element
        */
        public void rightClickOnWebElement(WebElement element)
        {
            Actions act = new Actions(Driver);
            act.ContextClick(element).Perform();
        }
        /*
         this method is used to  Sends a sequence of keystrokes to the browser.

         Parameters:
           1.keysToSend: The keystrokes to send to the browser.
           2.drover

         Returns:
             A self-reference to this OpenQA.Selenium.Interactions.Actions.
        */
        public void keyEnter()
        {
            Actions act = new Actions(Driver);
             
            act.KeyDown(Keys.Control).SendKeys("c").KeyUp(Keys.Control).Perform();
            act.KeyDown(Keys.Tab).Perform();
            act.KeyDown(Keys.Control).SendKeys("v").KeyUp(Keys.Control).Perform();

        }
        /*
            this  Method to give you access to switch frames by using index
        @param driver
        @param index

         Returns:
             Returns an Object that allows you to Switch Frames and Windows
        */
        public void switchToFrame(int index)
        {
            Driver.SwitchTo().Frame(index);
        }
        /*
           this  Method to give you access to switch frames by using name or id
       @param driver
       @param name or id

        Returns:
            Returns an Object that allows you to Switch Frames and Windows
       */
        public void switchToFrame(string nameOrId)
        {
            Driver.SwitchTo().Frame(nameOrId);
        }
        /*
           this  Method to give you access to switch frames by using address
       @param driver
       @param  address

        Returns:
            Returns an Object that allows you to Switch Frames and Windows
       */
        public void switchToFrame(WebElement address)
        {
            Driver.SwitchTo().Frame(address);
        }
        /*
           this  Method to give you access to switch Window by using window session id
       @param driver
       @param  ExpTitle

        Returns:
            Returns an Object that allows you to Switch Frames and Windows
       */
        public void switchToWindows()
        {
            // IReadOnlyCollection<string> windows = Driver.WindowHandles;
            //IEnumerator<string> window = windows.GetEnumerator();
            //while (window.MoveNext())
            //{
            //    string key = window.Current;
            //    string currentWindow = Driver.SwitchTo().Window(key).Title;
            //    if (currentWindow.Contains(ExpTitle))
            //    {
            //        break;
            //    }
            //}
            string parentWindow = driver.CurrentWindowHandle;
            var allWindows = driver.WindowHandles;

            foreach (var window in allWindows)
            {
                if (window != parentWindow)
                {
                     
                    driver.SwitchTo().Window(window);
                    Console.WriteLine(driver.Title);
                    break;
                }
            }


        }
        public void SwitchToChildWindow()
        {
            string parent = Driver.CurrentWindowHandle;
            System.Collections.ObjectModel.ReadOnlyCollection<string> windows = Driver.WindowHandles;
            foreach (string window in windows)
            {
                if (!window.Equals(parent))
                {
                    Driver.SwitchTo().Window(window);
                }
            }
        }
        /*
         * this method is used to swith to alert and acceptAlert
         * @param driver
         * */
        public void acceptAlert()
        {
            Driver.SwitchTo().Alert().Accept();
        }
        /*
         * this method is used to swith to alert and cancleAlert
         * @param driver
         * */
        public void cancelAlert()
        {
            Driver.SwitchTo().Alert().Dismiss();
        }
        /*
         * this method is used to scroll scrollbar by axces
         * @param xcordinate
         * @parm ycordinate
         * */
        public void scrollBarAction(int xcordinate, int ycordinate)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("Window.scrollInBy(" + xcordinate + "," + ycordinate + ")");

        }
        public void ClickElementThroughJavaScript(IWebElement element)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", element);
        }

        public void SendTextUsingJavaScript(IWebElement element, string value)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].value='" + value + "'", element);
        }
        /*
         * this method is used to scroll to element
         * @param driver
         * @param element
         * */
        public void scrollToElement(  WebElement element)
        {

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            // IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            //int y = element.getLocation().getY();
            //jse.executeScript("window.scrollBy(0,"+y+")");
            //jse.executeScript("argument[0].scrollIntoView()", element);

        }

        public string TakeScreenshotToReport( )
        {

            ITakesScreenshot screenshot = (ITakesScreenshot)Driver;
            string ScrrenshotData = screenshot.GetScreenshot().AsBase64EncodedString;
            return ScrrenshotData;

        }
        public void TakeScreenshot(IWebDriver driver,string screenshotName)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            Screenshot image = screenshot.GetScreenshot();
            // string path =Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            // string title = driver.Title+".Png";

            //string filePath = Path.Combine(path , title);
            string path = "C:\\Users\\91996\\source\\repos\\Repo Inpatient Care\\Repo Inpatient Care\\Screenshot\\";

            string filepath=Path.Combine(path + screenshotName+".png");
            image.SaveAsFile(filepath);
             
        }





    }



}

