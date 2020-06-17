using BingSearchPageObjectsLab.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSearchPageObjectsLab.Pages
{

    public abstract class Page
    { 
        protected IWebDriver WebDriver { get; private set; }

        public const int DefaultSecondTimeout = 60;

        public string Title => WaitUntil(d => d.Title);

        public string Url => WaitUntil(d => d.Url);

        protected TPage GoTo<TPage>(By byLocator, Action<IWebElement> performAction = null)
           where TPage : Page, new()
        {
            var action = performAction ?? (e => e.Click());
            action(FindElement(byLocator));

            return new TPage { WebDriver = WebDriver };
        }

        protected IWebElement FindElement(By byLocator, TimeSpan maxWait = default(TimeSpan))
        {
            try
            {
                return WaitUntil(d => d.FindElement(byLocator));
            }
            catch (WebDriverTimeoutException e)
            {
                throw e.InnerException;
            }
        }

        internal static TPage GoToInitial<TPage>(string startUpUrl, IWebDriver webDriver)
                where TPage : Page, new()
        {
            if (webDriver == null) throw new ApplicationException("Please provide with an instance of web driver to proceed");
            if (string.IsNullOrWhiteSpace(startUpUrl)) throw new ApplicationException("Please provide with a start up url");

            webDriver.Navigate().GoToUrl(startUpUrl);

            return new TPage { WebDriver = webDriver };
        }

        private TReturn WaitUntil<TReturn>(Func<IWebDriver, TReturn> elementFinder, TimeSpan maxWait = default(TimeSpan))
        {
            if (maxWait == default)
            {
                maxWait = TimeSpan.FromSeconds(DefaultSecondTimeout);
            }
            var wait = new WebDriverWait(WebDriver, maxWait);
            return wait.Until(elementFinder);
        }
    }
}
