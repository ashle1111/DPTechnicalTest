using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;

namespace DPTechnicalTest.Pages
{
    /// <summary>
    /// This is the base for all Page Object Models.
    /// </summary>
    public class BasePage
    {
        private WebDriverWait _wait;
        private const int DefaultTimeout = 60;

        protected IWebDriver Driver { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void WaitForElementToBeClickable(By locator, int timer = DefaultTimeout)
        {
            TimeSpan timeOut = TimeSpan.FromSeconds(timer);
            _wait = new WebDriverWait(Driver, timeOut);
        }

        public void SendKeys(By locator, string sendValues)
        {
            var inputFieldId = Driver.FindElement(locator);
            inputFieldId.SendKeys(sendValues);
        }

        public void Click(By locator, int timeoutOveride = DefaultTimeout)
        {
            WaitForElementToBeClickable(locator, timeoutOveride);
            var clickButton = Driver.FindElement(locator);
            clickButton.Click();
        }

        public void ScrollToTop()
        {
            IJavaScriptExecutor jsDriver = ((IJavaScriptExecutor)Driver);
            jsDriver.ExecuteScript(string.Format("window.scroll(0, 0)"));
        }

        public void ScrollToBottom()
        {
            IJavaScriptExecutor jsDriver = ((IJavaScriptExecutor)Driver);
            jsDriver.ExecuteScript(string.Format("window.scroll(0, 1000)"));
        }

        public void ScrollByScale(int x, int y)
        {
            IJavaScriptExecutor jsDriver = ((IJavaScriptExecutor)Driver);
            jsDriver.ExecuteScript(string.Format("window.scroll(" + x + ", " + y + ")"));
        }

        public void PressTabFromKeyBoard() => new Actions(Driver).KeyDown(Keys.Tab).Perform();
        public void PressDownKeyFromKeyBoard() => new Actions(Driver).KeyDown(Keys.Down).Perform();
        public void PressEnterKeyFromKeyBoard() => new Actions(Driver).KeyDown(Keys.Return).Perform();

        public void WaitForPageLoad()
        {
            string state = string.Empty;
            _wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(DefaultTimeout));
            _wait.Until(d =>
            {
                try
                {
                    state = ((IJavaScriptExecutor)Driver).ExecuteScript(@"return document.readyState").ToString();
                }
                catch (InvalidOperationException)
                {
                    //Ignore
                }
                catch (NoSuchWindowException)
                {
                    //when popup is closed, switch to last windows
                    Driver.SwitchTo().Window(Driver.WindowHandles.Last());
                }

                return (state.Equals("complete", StringComparison.InvariantCultureIgnoreCase) || state.Equals("loaded", StringComparison.InvariantCultureIgnoreCase));
            });
        }

        public bool VerifyBrowserTitle(string title)
        {
            return Driver.Title.ToLower().Contains(title.ToLower());
        }

        public void WaitForElementToExist(By locator, int timer = DefaultTimeout)
        {
            TimeSpan timeOut = TimeSpan.FromSeconds(timer);
            _wait = new WebDriverWait(Driver, timeOut);
            _wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public void WaitForElementToBeInvisible(By locator, int timer = DefaultTimeout)
        {
            TimeSpan timeOut = TimeSpan.FromSeconds(timer);
            _wait = new WebDriverWait(Driver, timeOut);
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public bool IsElementPresent(By selector)
        {
            try
            {
                Driver.FindElement(selector);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClearInputField(IWebElement locater1, By locater2)
        {
            string InputValue = locater1.GetAttribute("value");
            if (InputValue.Length > 0)
            {
                SendKeys(locater2, Keys.Control + "a");
                SendKeys(locater2, Keys.Delete);
            }
        }

    }
}
