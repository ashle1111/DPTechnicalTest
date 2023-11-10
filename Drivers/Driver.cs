using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace DPTechnicalTest.Drivers
{
    /// <summary>
    /// This class is responsible for instantiating and closing the driver.
    /// </summary>
    public class Driver
    {
        private IWebDriver? _Instance;

        public IWebDriver Instance
        {
            get
            {
                if (_Instance is null)
                {
                    _Instance = GetInstance();
                }
                return _Instance;
            }
        }

        private IWebDriver GetInstance()
        {
            switch (AppConfigReader.GetBrowser)
            {
                case "Chrome":
                    {
                        var instance = new ChromeDriver();
                        instance.Manage().Window.Maximize();
                        return instance;
                    }
                case "Firefox":
                    {
                        var instance = new FirefoxDriver();
                        instance.Manage().Window.Maximize();
                        return instance;
                    }
                case "Edge":
                    {
                        var instance = new EdgeDriver();
                        instance.Manage().Window.Maximize();
                        return instance;
                    }
                default:
                    throw new Exception("Browser not supported");
            }
        }

        public void Close()
        {
            if (_Instance is not null)
            {
                _Instance.Close();
            }
        }
    }
}
