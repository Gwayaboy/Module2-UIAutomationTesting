using System;
using BingSearchPageObjectsLab.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace BingSearchPageObjectsLab.Configuration
{
    public class WebUISpecs : IDisposable
    {
        private IWebDriver _webDriver;

        public WebUISpecs() : this(BrowserFactory.Chrome) { }

        protected WebUISpecs(Func<IWebDriver> webDriverFactory)
        {
            _webDriver = webDriverFactory();
            _webDriver.Manage().Window.Maximize();
        }

        protected TPage NavigateTo<TPage>(string startUpUrl) where TPage : Page, new()
        {
            return Page.GoToInitial<TPage>(startUpUrl, _webDriver);
        }

        [TestCleanup]
        public void TearDownWebDriver()
        {
            Dispose(true);
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_webDriver != null)
                    {
                        _webDriver.Quit();
                        _webDriver.Dispose();
                        _webDriver = null;
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
