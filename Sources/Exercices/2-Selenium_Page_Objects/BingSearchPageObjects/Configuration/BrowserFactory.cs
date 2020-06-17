using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace BingSearchPageObjectsLab.Configuration
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
    }
}
