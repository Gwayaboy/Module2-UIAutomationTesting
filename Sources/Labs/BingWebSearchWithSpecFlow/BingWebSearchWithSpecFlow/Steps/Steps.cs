using BingWebSearchWithSpecFlow.Pages;
using BoDi;
using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace BingWebSearchWithSpecFlow.Steps
{
    public class Steps : IDisposable
    {
        protected IObjectContainer Container { get; private set; }


        private readonly Func<IWebDriver> _webDriverFactory;

        public Steps(IObjectContainer container, Func<IWebDriver> webDriverFactory)
        {
            Container = container;
            _webDriverFactory = webDriverFactory;
        }


        [BeforeScenario]
        public void RegisterDefaultBrowserFactory()
        {
            if (!Container.IsRegistered<IWebDriver>())
            {
                Container.RegisterFactoryAs(BrowserFactory);
            }
        }


        [AfterScenario]
        public void DisposeBrowser()
        {
            Dispose();
        }

        protected TPage NavigateToInitial<TPage>(string startUpUrl) where TPage : Page, new()
        {
            return Register(Page.GoToInitial<TPage>(startUpUrl, Container.Resolve<IWebDriver>()));
        }

        protected TPage Register<TPage>(TPage page) where TPage : Page, new()
        {
            Container.RegisterInstanceAs(page);
            return page;
        }

        protected TPage Retrieve<TPage>() where TPage : Page, new()
        {
            return Container.Resolve<TPage>();
        }

        protected void NotImplemented()
        {
            Container.Resolve<ScenarioContext>().Pending();
        }

        private IWebDriver BrowserFactory(IObjectContainer container)
        {
            var webDriver = _webDriverFactory();
            webDriver.Manage().Window.Maximize();
            return webDriver;
        }

        [StepArgumentTransformation]
        public int ToCardinal(string ordinal)
        {
            var value = new Regex(@"\d+").Match(ordinal).Value;

            if (string.IsNullOrWhiteSpace(value))
            {
                return 1;
            }

            return int.Parse(value);
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {

            if (!disposedValue)
            {
                if (disposing)
                {

                    if (Container.IsRegistered<IWebDriver>())
                    {
                        var webDriver = Container.Resolve<IWebDriver>();
                        webDriver.Quit();
                        webDriver.Dispose();
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
