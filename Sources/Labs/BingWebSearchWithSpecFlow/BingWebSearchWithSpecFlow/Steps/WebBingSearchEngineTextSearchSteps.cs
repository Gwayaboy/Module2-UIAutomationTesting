using BingWebSearchWithSpecFlow.Configuration;
using BoDi;
using System;
using TechTalk.SpecFlow;
using BingWebSearchWithSpecFlow.Assertions;

namespace BingWebSearchWithSpecFlow.Steps
{
    [Binding]
    public class WebBingSearchEngineTextSearchSteps : Specs
    {
        public WebBingSearchEngineTextSearchSteps(IObjectContainer container) 
            : base(container, BrowserFactory.Chrome)
        { }

        [Given(@"the user navigated to the url ""(.*)""")]
        public void GivenTheUserNavigatedToTheUrl(string url)
        {
            NotImplemented();
        }
        
        [Given(@"the user typed ""(.*)""")]
        public void GivenTheUserTyped(string searchText)
        {
            NotImplemented();
        }
        
        [When(@"the user submits the search")]
        public void WhenTheUserSubmitsTheSearch()
        {
            NotImplemented();
        }

        [When(@"the user select the current pin location")]
        public void WhenTheUserSelectTheCurrentPinLocation()
        {
            NotImplemented();
        }


        [Then(@"the the URL should remain ""(.*)""")]
        public void ThenTheTheURLShouldRemain(string url)
        {
            NotImplemented();
        }
        
        [Then(@"the URL should not contains ""(.*)""")]
        public void ThenTheURLShouldNotContains(string urlPath)
        {
            NotImplemented();
        }
        
        [Then(@"the Page's title should be ""(.*)""")]
        public void ThenThePageSTitleShouldBe(string expectedTitle)
        {
            NotImplemented();
        }
        
        [Then(@"the results related to the background's image location should be listed")]
        public void ThenTheResultsRelatedToTheBackgroundSImageLocationShouldBeListed()
        {
            NotImplemented();
        }
        
        [Then(@"more than (.*) result\(s\) should be listed")]
        public void ThenMoreThanOneResultsShouldBeListed(int minimumNumberResults)
        {
            NotImplemented();
        }

        [Then(@"the (.*) result item's title and url should contain ""(.*)"" and ""(.*)""")]
        public void ThenTheStResultItemSTitleAndUrlShouldContainAnd(int index, string itemResultTitle, string itemResultUrl)
        {
            NotImplemented();
        }
    }
}
