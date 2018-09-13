using System.Collections.Generic;
using System.Linq;
using ClearChannel.Base;
using ClearChannel.Extensions;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ClearChannel.Pages
{
    public class ResultsPage : BasePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverHelpers _webDriverHelpers;
        private const string Endpoint = "search/";

        public ResultsPage(IWebDriver driver, WebDriverHelpers webDriverHelpers)
        {
            _driver = driver;
            _webDriverHelpers = webDriverHelpers;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "[class*='grid_3 cat-']")]
        private IList<IWebElement> SearchResultElemet { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[class*='h5']")]
        private IWebElement SearchResultTitleElemet { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#content")]
        private IWebElement ErrorEncountedElemet { get; set; }

        /// <summary>
        ///     This function helps to navigate to the home page
        /// Different pages can be skipped by appending the pages endpoint by passing it to the getUrl method.
        /// </summary>
        public void Open()
        {
            _driver.Navigate().GoToUrl(GetUrl(Endpoint));
        }

        /// <summary>
        ///     This function tries to verify the search result is relevant to the search term
        /// </summary>
        /// <param name="searchTerm"></param>
        public void AssertSearchTermIsContainedOnTheSearchResut(string searchTerm)
        {
            _webDriverHelpers.WaitUntilElementIsVisibleAndClickable(_driver, SearchResultTitleElemet);
            var searchResult = SearchResultElemet.FirstOrDefault(x => x.FindElement(By.XPath("//p[contains(text(), '" + searchTerm +"')]")).Displayed);
            searchResult.Should().NotBeNull();
        }

        /// <summary>
        ///     Verify the right error message was displayed
        /// </summary>
        /// <param name="errorMessage"></param>
        public void AssertErrorMessageWasDisplayed(string errorMessage)
        {
            _webDriverHelpers.WaitUntilElementIsVisible(_driver, By.CssSelector("#content"));
            var searchResult = ErrorEncountedElemet.Text;
            Assert.That(searchResult.Contains(errorMessage), "Friendly Error message was not displayed as expected");
        }

        /// <summary>
        ///     This function helps to verify the term "No results found." is displayed
        /// as part of the search result for positve and no result respectively.
        /// </summary>
        /// <param name="errorMessage"></param>
        public void AssertNoResultErrorMessageWasDisplayed(string errorMessage)
        {
            _webDriverHelpers.WaitUntilElementIsVisible(_driver, By.CssSelector("[class*='h5']"));
            var actualResult = SearchResultTitleElemet.Text;
            Assert.AreEqual(errorMessage, actualResult, "No result friendly message was not displayed as expected !!!");
        }

    }
}
