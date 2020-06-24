using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
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

            var directory = Directory.GetCurrentDirectory();

            return new ChromeDriver(directory, options);
        }

        public static IWebDriver EdgeChromium()
        {
            var options = new EdgeOptions();
            options.UseChromium = true;

            return new EdgeDriver(options);
        }
    }
}
