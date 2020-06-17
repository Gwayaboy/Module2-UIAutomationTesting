using BingSearchPageObjectsLab.ViewModel;
using OpenQA.Selenium;
using System;

namespace BingSearchPageObjectsLab.Pages
{
    public class BingSearchResultPage : Page
    {
        public long NumberOfResults => throw new NotImplementedException();

        public string SearchedText => throw new NotImplementedException();

        public ResultItem FirstResultItem => throw new NotImplementedException();

        public ResultItem GetResultItemAt(int index)
        {
            throw new NotImplementedException();
        }
    }
}