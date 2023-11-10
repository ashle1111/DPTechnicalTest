using DPTechnicalTest.Hooks;
using OpenQA.Selenium;

namespace DPTechnicalTest.StepDefinitions
{
    /// <summary>
    /// This is the base class for all step definitions in this project.
    /// 
    /// Every child class should have a feature file defined.
    /// </summary>
    public class StepDefinitionBase
    {
        protected IWebDriver Driver {get; set;}

        public StepDefinitionBase()
        {
            Driver = ObjectRepository.Driver ?? throw new WebDriverException("Driver is null");
        }
    }
}
