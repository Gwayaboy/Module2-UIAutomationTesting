using BingWebSearchWithSpecFlow.Configuration;
using BingWebSearchWithSpecFlow.Pages;
using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BingWebSearchWithSpecFlow.Steps
{
    public class Specs : IDisposable
    {
        private IObjectContainer _container;
        private readonly Func<IWebDriver> _webDriverFactory;

        public Specs(IObjectContainer container, Func<IWebDriver> webDriverFactory)
        {
            _container = container;
            _webDriverFactory = webDriverFactory;
        }
        

        [BeforeScenario]
        public void RegisterDefaultBrowserFactory()
        {
            var webDriver = _webDriverFactory();
            webDriver.Manage().Window.Maximize();
            _container.RegisterFactoryAs(c => webDriver);
        }

        [AfterScenario]
        public void DisposeBrowser()
        {
            Dispose();
        }

        protected TPage NavigateTo<TPage>(string startUpUrl) where TPage : Page, new()
        {
            return Page.GoToInitial<TPage>(startUpUrl, _container.Resolve<IWebDriver>());
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
                   
                    if (_container.IsRegistered<IWebDriver>())
                    {
                        var webDriver = _container.Resolve<IWebDriver>();
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
