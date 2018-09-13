using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace ClearChannel.Extensions
{
    [Binding]
    public class WebDriverHelpers
    {
        private readonly IWebDriver _driver;

        public WebDriverHelpers(IWebDriver driver)
        {
            _driver = driver;
        }

        /// <summary>
        ///     Method helps to wait of a by locator to be visible with in 2 seconds, this time can be increased.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="time"></param>
        public void WaitUntilElementIsVisible(IWebDriver driver, By locator, int time = 2000)
        {
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(time)).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        /// <summary>
        ///     Method helps to wait of a element to be visible with in 2 seconds, this time can be increased.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <param name="time"></param>
        public void WaitUntilElementIsVisibleAndClickable(IWebDriver driver, IWebElement element, int time = 2000)
        {
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(time)).Until(ExpectedConditions.ElementToBeClickable(element));
        }

        /// <summary>
        ///     Method helps to wait of a by locator to be visible with in 2 seconds, and performs a click operation.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="time"></param>
        public void WaitUntilVisibleAndClick(IWebDriver driver, By locator, int time = 2000)
        {
            WaitUntilAsserted(driver, () =>
            {
                var webElement = driver.FindElement(locator);
                ScrollToElement(driver, webElement).Click();
                return true;
            }, time);
        }

        /// <summary>
        ///     Method helps to wait of a element to be visible with in 2 seconds, and performs a click operation.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <param name="time"></param>
        public void WaitUntilVisibleAndClick(IWebDriver driver, IWebElement element, int time = 2000)
        {
            WaitUntilAsserted(driver, () =>
            {
                ScrollToElement(driver, element).Click();
                return true;
            }, time);
        }

        /// <summary>
        ///     Method helps to wait of a by locator to be visible with in 2 seconds, and performs a sendkeys operation.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <param name="text"></param>
        /// <param name="time"></param>
        public void WaitUntilVisibleAndSendKeys(IWebDriver driver, By locator, string text, int time = 2000)
        {
            WaitUntilAsserted(driver, () =>
            {
                var webElement = driver.FindElement(locator);
                ScrollToElement(driver, webElement).SendKeys(text);
                return true;
            }, time);
        }

        /// <summary>
        ///     Wait for a period of time
        /// </summary>
        /// <param name="milliseconds"></param>
        public void WaitForTimeSpan(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        /// <summary>
        ///     Method helps to wait of a element to be visible with in 2 seconds, and performs a click operation.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <param name="text"></param>
        /// <param name="time"></param>
        public void WaitUntilVisibleAndSendKeys(IWebDriver driver, IWebElement element, string text, int time = 2000)
        {
            WaitUntilAsserted(driver, () =>
            {
                ScrollToElement(driver, element).Click();
                ScrollToElement(driver, element).SendKeys(text);
                return true;
            }, time);
        }

        /// <summary>
        ///    This method helps to scroll element into view before perform any operation
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        private IWebElement ScrollToElement(IWebDriver driver, IWebElement element)
        {
            var actions = new Actions(driver);
            actions.MoveToElement(element).Build().Perform();
            return element;
        }

        /// <summary>
        ///     Wait for a period of time till assertion is done.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="function"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private bool WaitUntilAsserted(IWebDriver driver, Func<bool> function, int time = 2000)
        {
            return new WebDriverWait(driver, TimeSpan.FromMilliseconds(time)).Until(webdriver => function());
        }
    }
}
