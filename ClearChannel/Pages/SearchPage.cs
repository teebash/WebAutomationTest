using System;
using System.Collections.Generic;
using System.Linq;
using ClearChannel.Base;
using ClearChannel.Extensions;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ClearChannel.Pages
{
    /// <summary>
    /// Page object has been used
    /// </summary>
    public class SearchPage : BasePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverHelpers _webDriverHelpers;
        private const string Endpoint = "/";

        public SearchPage(IWebDriver driver, WebDriverHelpers webDriverHelpers)
        {
            _driver = driver;
            _webDriverHelpers = webDriverHelpers;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#icon-search")]
        private IWebElement SearchIconElement { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[name*='keywords']")]
        private IList<IWebElement> SearchTextPlaceholderElement { get; set; }

        /// <summary>
        /// This function helps to navigate to the home page
        /// Different pages can be skipped by appending the pages endpoint by passing it to the getUrl method.
        /// </summary>
        public void Open()
        {
            _driver.Navigate().GoToUrl(GetUrl(Endpoint));
        }

        /// <summary>
        /// Method performs search on the webpage.
        /// </summary>
        /// <param name="valueToBeSearched"></param>
        public ResultsPage PerformSearchOnWebSite(string valueToBeSearched)
        {
            _webDriverHelpers.WaitForTimeSpan(2000); // Bad coding, we shouldn't have to wait, I need more time to investigate why i am getting element not clickable because of another element obscures it.
            _webDriverHelpers.WaitUntilVisibleAndClick(_driver, By.CssSelector("#icon-search"));
            _webDriverHelpers.WaitUntilElementIsVisible(_driver, By.CssSelector("[name*='keywords']"));

            var firstOrDefaultElement = SearchTextPlaceholderElement.FirstOrDefault(x => x.Text == "");
            if (firstOrDefaultElement == null) throw new Exception("SearchTextplaceholder element was null");

            _webDriverHelpers.WaitUntilVisibleAndSendKeys(_driver, firstOrDefaultElement, valueToBeSearched);
            firstOrDefaultElement.Submit();

            return new ResultsPage(_driver, _webDriverHelpers);
        }
    }
}
