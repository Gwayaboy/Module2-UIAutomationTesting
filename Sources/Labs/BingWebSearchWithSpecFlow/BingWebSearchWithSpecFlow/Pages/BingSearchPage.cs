using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingWebSearchWithSpecFlow.Pages
{
    public class BingSearchPage : Page
    {
        private const string currentLocationPinLinkSelector = "#vs_cont > div.mc_caro > div > div.headline > div.icon_text > a";

        public string CurrentPinLocation
        {
            get
            {
                var href = FindElement(By.CssSelector(currentLocationPinLinkSelector)).GetAttribute("href");
                var start = href.IndexOf("search?q=") + 9;
                var length = href.IndexOf('&') - start;

                return href.Substring(start, length).Replace('+', ' '); ;
            }
        }

        public BingSearchResultPage Search(string textToSearch = "")
        {
            return GoTo<BingSearchResultPage>(By.Id("sb_form"), form => form.Submit());
        }

        public BingSearchPage TypeSearchText(string textToSearch)
        {
            FindElement(By.Id("sb_form_q")).SendKeys(textToSearch);

            return this;
        }

        public BingSearchResultPage SelectCurrentPinLocation()
        {
            return GoTo<BingSearchResultPage>(By.CssSelector(currentLocationPinLinkSelector));
        }
    }
}
