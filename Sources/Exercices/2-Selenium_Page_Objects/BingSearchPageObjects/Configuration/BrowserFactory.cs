using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace BingSearchPageObjectsLab.Configuration
{
    public class BrowserFactory
    {
        public static IWebDriver Chrome()
        {
            var options = new ChromeOptions();
            options.AddArgument("test-type");

            //var directory = Environment.GetEnvironmentVariable("ChromeWebDriver");
            var directory = Directory.GetCurrentDirectory();

            return new ChromeDriver(directory, options);
        }
    }
}
