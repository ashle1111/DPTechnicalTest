using OpenQA.Selenium;
using System;
using System.Threading;

namespace DPTechnicalTest.Pages
{
    public class CreatePage : BasePage
    {

        #region Variables

        #region By XPath at Create clint page

        private readonly By _CreateBtn = By.XPath("/html/body/div/main/div[1]/div/form/div[4]/input");
        private readonly By _ForenameTxtField = By.XPath("//*[@id='Forename']");
        private readonly By _SurnameTxtField = By.XPath("//*[@id='Surname']");
        private readonly By _DOBTxtField = By.XPath("//*[@id='DateOfBirth']");
        private readonly By _BackToListLink = By.XPath("/html/body/div/main/div[2]/a");

        public CreatePage(IWebDriver driver) : base(driver)
        {
        }


        public void CreateNewClient()
        {
            SendKeys(_ForenameTxtField, Forename());
            SendKeys(_SurnameTxtField, Surname());
            SendKeys(_DOBTxtField, DOB());
            Thread.Sleep(1000);
            Click(_CreateBtn);
            WaitForPageLoad();
            Thread.Sleep(5000);
        }

        #region Input Methods
        public static int randome()
        {
            Random rand = new Random();
            return rand.Next(1000, 9999);
        }

        public static string Forename()
        {
            return "Test " + randome();
        }

        public static string Surname()
        {
            return "Test " + randome();
        }

        public static string DOB()
        {
            DateTime currentDate = DateTime.Now;
            string dob = currentDate.ToString("MM/dd/yyyy");
            return dob;
        }

        #endregion
        #endregion
    }
    #endregion
}
