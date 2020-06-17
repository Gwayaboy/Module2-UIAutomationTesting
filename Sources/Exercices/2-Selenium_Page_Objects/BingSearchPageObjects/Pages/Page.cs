using BingSearchPageObjectsLab.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingSearchPageObjectsLab.Pages
{

    public abstract class Page : IDisposable
    {
        protected IWebDriver WebDriver { get; private set; }

        public string Title => WebDriver.Title;

        public string Url => WebDriver.Url;

        protected TPage GoTo<TPage>(By byLocator, Action<IWebElement> performAction = null)
           where TPage : Page, new()
        {
            var action = performAction ?? (e => e.Click());
            action(WebDriver.FindElement(byLocator));

            return new TPage { WebDriver = WebDriver };
        }

        internal static TPage GoToInitial<TPage>(string startUpUrl, Func<IWebDriver> webDriverFactory = null)
                where TPage : Page, new()
        {
            var webDriver = (webDriverFactory ?? BrowserFactory.Chrome).Invoke();
            if (webDriver == null) throw new ApplicationException("Please provide with an instance of web driver to proceed");
            if (string.IsNullOrWhiteSpace(startUpUrl)) throw new ApplicationException("Please provide with a start up url");

            webDriver.Navigate().GoToUrl(startUpUrl);

            return new TPage { WebDriver = webDriver };
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (WebDriver != null)
                    {
                        WebDriver.Quit();
                        WebDriver.Dispose();
                        WebDriver = null;
                    }
                }
                disposedValue = true;
            }
        }


        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }

        #endregion


    }
}
