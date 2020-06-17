using BingSearchPageObjectsLab.ViewModel;
using OpenQA.Selenium;
using System;

namespace BingSearchPageObjectsLab.Pages
{
    public class BingSearchResultPage : Page
    {
        public long NumberOfResults => 
            long.Parse(FindElement(By.CssSelector("#b_tween > span.sb_count"))
                        .Text
                        .Replace("Results", string.Empty)
                        .Replace(",", string.Empty));

        public string SearchedText => FindElement(By.Id("sb_form_q")).GetAttribute("value");

        public ResultItem FirstResultItem => GetResultItemAt(1);

        public ResultItem GetResultItemAt(int index)
        {
            var resulItemLink = FindElement(By.CssSelector($"#b_results > li:nth-child({index}) a"));

            return new ResultItem(resulItemLink.Text, resulItemLink.GetAttribute("href"));
        }
    }
}