using ClearChannel.Pages;
using TechTalk.SpecFlow;

namespace ClearChannel.Steps
{ 
    [Binding]

    public class SearchSteps
    {
        private readonly SearchPage _searchPage;
        private readonly ResultsPage _resultsPage;

        public SearchSteps(SearchPage searchPage, ResultsPage resultsPage)
        {
            _searchPage = searchPage;
            _resultsPage = resultsPage;
        }

        [Given(@"I am on the homePage")]
        public void GivenIAmOnTheHomePage()
        {
            _searchPage.Open();
        }

        [When(@"I search for ""(.*)""")]
        [When(@"I search for an invalid term ""(.*)""")]
        public void WhenISearchFor(string searchTerm)
        {
            _searchPage.PerformSearchOnWebSite(searchTerm);
        }

        //[Then(@"the result should be ""(.*)""")]
        //public void ThenTheResultShouldBe(string searchReuslt)
        //{
        //    _resultsPage.AssertSearchResultWasDisplayed(searchReuslt);
        //}

        [Then(@"the result should have the term ""(.*)"" in it")]
        [Then(@"the result should have the term ""(.*)"" somewhere within the returned result")]
        [Then(@"the result should be have the search term ""(.*)"" displayed as part of the result")]
        public void ThenTheResultShouldBeHaveTheSearchTermDisplayedAsPartOfTheResult(string searchTerm)
        {
            _resultsPage.AssertSearchTermIsContainedOnTheSearchResut(searchTerm);
        }

        [Then(@"the result should have the friendly error message ""(.*)""")]
        public void ThenTheResultShouldHaveTheFriendlyErrorMessage(string errorMessage)
        {
            if (errorMessage == "No results found.")
            {
                _resultsPage.AssertNoResultErrorMessageWasDisplayed(errorMessage);
            }
            else
            {
                _resultsPage.AssertErrorMessageWasDisplayed(errorMessage);
            }
        }
    }
}
