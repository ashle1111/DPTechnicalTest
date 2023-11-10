using DPTechnicalTest.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DPTechnicalTest.StepDefinitions
{
    [Binding]
    public sealed class CreatePageStepDefinition : StepDefinitionBase
    {
        private readonly CreatePage _createPage;

        public CreatePageStepDefinition()
        {
            _createPage = new CreatePage(Driver);
        }

        [Then(@"enter details for create new client")]
        public void EnterDetailsForCreateNewClient()
        {
            _createPage.CreateNewClient();
        }
    }
}
