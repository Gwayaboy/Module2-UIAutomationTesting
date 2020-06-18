using BingWebSearchWithSpecFlow.Pages;

namespace BingWebSearchWithSpecFlow.Assertions
{
    public static class ShouldExtensions
    {
        public static BingSearchResultPageAssertions Should(this BingSearchResultPage page)
        {
            return new BingSearchResultPageAssertions(page);
        }


    }
}
