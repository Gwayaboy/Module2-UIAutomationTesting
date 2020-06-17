using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.IO;

namespace BingWebSearchWithSpecFlow.Configuration
{
    class BrowserFactory
    {
        public static IWebDriver Chrome()
        {
            var options = new ChromeOptions();
            options.AddArgument("test-type");

            var directory = Environment.GetEnvironmentVariable("ChromeWebDriver") ?? Directory.GetCurrentDirectory();

            return new ChromeDriver(directory, options);
        }

        public static IWebDriver EdgeChromium()
        {
            //https://docs.microsoft.com/en-us/microsoft-edge/webdriver-chromium?tabs=c-sharp
            var options = new EdgeOptions();
            options.UseChromium = true;

            return new EdgeDriver(options);
        }
    }
}
