﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingWebSearchWithSpecFlow.Pages
{

    public abstract class Page
    {
        protected IWebDriver WebDriver { get; private set; }

        public const int DefaultSecondTimeout = 60;

        public string Title => WaitUntil(d => d.Title);

        public string Url => WebDriver.Url;

        protected TPage GoTo<TPage>(By byLocator, Action<IWebElement> performAction = null)
           where TPage : Page, new()
        {
            var action = performAction ?? (e => e.Click());
            action(WaitUntil(d => { var e = d.FindElement(byLocator); return e.Enabled && e.Displayed ? e : null; }));

            return new TPage { WebDriver = WebDriver };
        }

        protected IWebElement FindElement(By byLocator, TimeSpan maxWait = default)
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

        protected void ExecuteScript(string scriptToExecute)
        {
            var javascriptExecutor = (IJavaScriptExecutor)WebDriver;

            var untypedValue = javascriptExecutor.ExecuteScript(scriptToExecute);

        }

        internal static TPage GoToInitial<TPage>(string startUpUrl, IWebDriver webDriver)
                where TPage : Page, new()
        {
            if (webDriver == null) throw new ApplicationException("Please provide with an instance of web driver to proceed");
            if (string.IsNullOrWhiteSpace(startUpUrl)) throw new ApplicationException("Please provide with a start up url");

            webDriver.Navigate().GoToUrl(startUpUrl);

            return new TPage { WebDriver = webDriver };
        }

        private TReturn WaitUntil<TReturn>(Func<IWebDriver, TReturn> elementFinder, TimeSpan maxWait = default)
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
