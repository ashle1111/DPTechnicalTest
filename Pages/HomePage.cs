using DPTechnicalTest.Drivers;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Org.BouncyCastle.Asn1.Mozilla;

namespace DPTechnicalTest.Pages
{
    public class HomePage : BasePage
    {
        #region Variables

        #region By XPath at Home page
        private readonly By _FromLocation = By.Id("InputFrom");
        private readonly By _ToLocation = By.Id("InputTo");
        private readonly By _PlanMyJourneyBtn = By.Id("plan-journey-button");
        private readonly By _ChangeTimeBtn = By.ClassName("change-departure-time");
        private readonly By _AcceptAllCookiesBtn = By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll");
        private readonly By _JourneyTime = By.ClassName("journey-time");
        private readonly By _LeavingBtn = By.XPath("//label[@for=\"departing\"]");
        private readonly By _ArrivingBtn = By.XPath("//label[@for=\"arriving\"]");
        private readonly By _EditJourneyBtn = By.ClassName("edit-journey");
        private readonly By _InfoMessageBox = By.ClassName("info-message");
        private readonly By _HomeBtn = By.ClassName("home");
        private readonly By _RecentTabBtn = By.Id("jp-recent-tab-home");
        private readonly By _RecentJourneyList = By.XPath("//*[@id=\"jp-recent-content-home-\"]/a[1]");

        private readonly By _InputFromErrorMessageTag = By.Id("InputFrom-error");
        private readonly By _InputToErrorMessageTag = By.Id("InputTo-error");
        private IWebElement _InputFromErrorMessage => Driver.FindElement(By.Id("InputFrom-error"));
        private IWebElement _InputToErrorMessage => Driver.FindElement(By.Id("InputTo-error"));
        private IWebElement _InfoMessageText => Driver.FindElement(By.CssSelector("div.info-message.disambiguation > span"));
        private IWebElement _FromLocationInput => Driver.FindElement(By.Id("InputFrom"));
        private IWebElement _ToLocationInput => Driver.FindElement(By.Id("InputTo"));
        public HomePage(IWebDriver driver) : base(driver)
        {
        }


        private IWebElement Title => Driver.FindElement(By.CssSelector("#full-width-content > div > div:nth-child(2) > div > h1 > span"));

        public void NavigateToHome()
        {
            Driver.Navigate().GoToUrl(AppConfigReader.GetUrl);
        }

        public string GetTitle() => Title.Text;

        public void AcceptAllCookie()
        {
            WaitForPageLoad();
            Click(_AcceptAllCookiesBtn);
        }

        public void SetFromToLocation(string fromLocation, string toLocation)
        {
            ClearInputField(_FromLocationInput, _FromLocation);
            SendKeys(_FromLocation, fromLocation);
            ClearInputField(_ToLocationInput, _ToLocation);
            SendKeys(_ToLocation, toLocation);
            PressTabFromKeyBoard();
            ScrollByScale(0, 100);
        }

        public void ClickButtonByLocater(string BtnName)
        {
            if(BtnName == "plan my journey")
            {
                WaitForElementToExist(_PlanMyJourneyBtn);
                Click(_PlanMyJourneyBtn);
            }
            else if(BtnName == "change time")
            {
                WaitForElementToExist(_ChangeTimeBtn);
                Click(_ChangeTimeBtn);
            }
            else if(BtnName == "Accept all cookies")
            {
                AcceptAllCookie();
            }
            else if (BtnName == "Update journey")
            {
                WaitForElementToExist(_PlanMyJourneyBtn);
                Click(_PlanMyJourneyBtn);
            }
            else if(BtnName == "Edit journey")
            {
                ScrollToTop();
                WaitForElementToExist(_EditJourneyBtn);
                Click(_EditJourneyBtn);
            }
            else if (BtnName == "Home")
            {
                ScrollToTop();
                WaitForElementToExist(_HomeBtn);
                Click(_HomeBtn);
            }
            else if (BtnName == "Recent Journey")
            {
                WaitForElementToExist(_RecentTabBtn);
                Click(_RecentTabBtn);
            }
            else
            {
                Console.WriteLine("Button (" + BtnName + ") is not available.");
            }
        }

        public void WaitFroResultPageWhereJourneyTimeWillBeValidated()
        {
            WaitForPageLoad();
            String.Equals(GetTitle(), "Journey results");
            ScrollByScale(0, 400);
            WaitForElementToExist(_JourneyTime);
            Thread.Sleep(5000);
        }

        public void PlanAjourneyBasedOnArrivalLeavingTime(string type)
        {
            if(type == "Arrival")
            {
                Click(_ArrivingBtn);
            }
            else if(type == "Leaving")
            {
                Click(_LeavingBtn);
            }
            
        }

        public bool VerifyText(string MsgType, string Message)
        {
            if (MsgType == "From")
            {
                String ActualMessage = _InputFromErrorMessage.Text;
                WaitForElementToExist(_InputFromErrorMessageTag);
                Assert.AreEqual(Message, ActualMessage);

            }
            else if(MsgType == "To")
            {
                String ActualMessage = _InputToErrorMessage.Text;
                WaitForElementToExist(_InputToErrorMessageTag);
                Assert.AreEqual(Message, ActualMessage);
            }

            return false;
        }

        public void JourneyResultUnableToProvideResult()
        {
            WaitForPageLoad();
            String.Equals(GetTitle(), "Journey results");
            ScrollByScale(0, 400);
            WaitForElementToExist(_InfoMessageBox);
            String ActualMessage = _InfoMessageText.Text;
            ActualMessage.Contains("We found more than one location");
            Thread.Sleep(5000);
        }

        public void ListOfRecentPlannedJourneyShouldBeDisplayed()
        {
            WaitForPageLoad();
            WaitForElementToExist(_RecentJourneyList);
            Thread.Sleep(5000);
        }


    }
    #endregion
}
#endregion