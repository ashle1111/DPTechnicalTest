using DPTechnicalTest.Drivers;
using TechTalk.SpecFlow;

namespace DPTechnicalTest.Hooks
{
    /// <summary>
    /// This class is used by Specflow tests to initiate the driver
    /// at the start, and to close it at the end.
    /// </summary>
    [Binding]
    public sealed class Setup
    {
        [BeforeScenario()]
        public void InitializeSetup()
        {
            ObjectRepository.Driver = new Driver().Instance;
        }
        
        [AfterScenario()]
        public void Cleanup()
        {
            ObjectRepository.Driver?.Close();
        }
    }
}