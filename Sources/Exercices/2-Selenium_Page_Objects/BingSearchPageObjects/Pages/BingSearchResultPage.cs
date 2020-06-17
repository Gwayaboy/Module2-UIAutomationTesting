using BingSearchPageObjectsLab.ViewModel;
using System;

namespace BingSearchPageObjectsLab.Pages
{
    public class BingSearchResultPage : Page
    {
        public int NumberOfResults => throw new NotImplementedException();

        public string SearchedText => throw new NotImplementedException();

        public ResultItem FirstResultItem => GetResultItemAt(0);

        public ResultItem GetResultItemAt(int index = 0)
        {
            throw new NotImplementedException();
        }
    }
}