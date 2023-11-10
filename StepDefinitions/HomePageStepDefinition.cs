using DPTechnicalTest.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace DPTechnicalTest.StepDefinitions
{
    [Binding]
    public sealed class HomePageStepDefinition : StepDefinitionBase
    {
        private readonly HomePage _homePage;

        public HomePageStepDefinition()
        {
            _homePage = new HomePage(Driver);
        }

        [Given(@"user navigates to Home page")]
        public void GivenUserNavigatesToTheHomePage()
        {
            _homePage.NavigateToHome();
        }

        [Then(@"the title should be ""(.*)""")]
        public void ThenTheTitleShouldBe(string title)
        {
            _homePage.GetTitle().Should().Be(title);
        }

        [Given(@"enter journey start from ""(.*)"" to ""(.*)""")]
        [When(@"enter journey start from ""(.*)"" to ""(.*)""")]
        [Then(@"enter journey start from ""(.*)"" to ""(.*)""")]
        public void JourneyStartFrom(string fromLocation, string toLocation)
        {
            _homePage.SetFromToLocation(fromLocation, toLocation);
        }

        [Given(@"click ""(.*)"" button")]
        [When(@"click ""(.*)"" button")]
        [Then(@"click ""(.*)"" button")]
        public void ClickButtonByLocater(String BtnName)
        {
            _homePage.ClickButtonByLocater(BtnName);
        }

        [Given(@"wait for results page where journey time will be validated")]
        [When(@"wait for results page where journey time will be validated")]
        [Then(@"wait for results page where journey time will be validated")]
        public void WaitFroResultPageWhereJourneyTimeWillBeValidated()
        {
            _homePage.WaitFroResultPageWhereJourneyTimeWillBeValidated();
        }

        [Then(@"journey result unable to provide results")]
        public void JourneyResultUnableToProvideResult()
        {
            _homePage.JourneyResultUnableToProvideResult();
        }

        [Given(@"plan a journey based on ""(.*)"" time")]
        [When(@"plan a journey based on ""(.*)"" time")]
        [Then(@"plan a journey based on ""(.*)"" time")]
        public void PlanAjourneyBasedOnArrivalLeavingTime(String type)
        {
            _homePage.PlanAjourneyBasedOnArrivalLeavingTime(type);
        }

        [Given(@"verify the ""(.*)"" error message as ""(.*)""")]
        [When(@"verify the ""(.*)"" error message as ""(.*)""")]
        [Then(@"verify the ""(.*)"" error message as ""(.*)""")]
        public void VerifyTheErrorMessage(String MsgType, String Message)
        {
            bool result = _homePage.VerifyText(MsgType, Message);
            if(!result)
            {
                Console.WriteLine("Fail to validate Error message (" + Message + ")");
            }
            else
            {
                Console.WriteLine("Successfully validate Error message (" + Message + ")");
            }
        }

        [Then(@"list of recently planned journeys should be displayed")]
        public void ListOfRecentPlannedJourneyShouldBeDisplayed()
        {
            _homePage.ListOfRecentPlannedJourneyShouldBeDisplayed();
        }
    }
}