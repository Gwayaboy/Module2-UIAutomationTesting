﻿using BingWebSearchWithSpecFlow.Configuration;
using BingWebSearchWithSpecFlow.Pages;
using BoDi;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using BingWebSearchWithSpecFlow.Assertions;
using BingWebSearchWithSpecFlow.ViewModel;

namespace BingWebSearchWithSpecFlow.Steps
{
    [Binding]
    public class WebBingSearchEngineTextSearchSteps : Specs
    {
        public BingSearchPage SearchPage { get; private set; }
        public BingSearchResultPage ResultPage { get; private set; }
        public string CurrentLocation { get; private set; }

        public WebBingSearchEngineTextSearchSteps(IObjectContainer container) : base(container, BrowserFactory.Chrome)
        {
        }

        [Given(@"the user navigated to the url ""(.*)""")]
        public void GivenTheUserNavigatedToTheUrl(string url)
        {
            SearchPage = NavigateTo<BingSearchPage>(url);
        }
        
        [Given(@"the user typed ""(.*)""")]
        public void GivenTheUserTyped(string searchText)
        {
            SearchPage.TypeSearchText(searchText);
        }
        
        [When(@"the user submits the search")]
        public void WhenTheUserSubmitsTheSearch()
        {
            ResultPage = SearchPage.Search();
        }

        [When(@"the user select the current pin location")]
        public void WhenTheUserSelectTheCurrentPinLocation()
        {
            CurrentLocation = SearchPage.CurrentPinLocation;
            ResultPage = SearchPage.SelectCurrentPinLocation();
        }


        [Then(@"the the URL should remain ""(.*)""")]
        public void ThenTheTheURLShouldRemain(string url)
        {
            ResultPage.Should().HaveUrlStartingWith(url);
        }
        
        [Then(@"the URL should not contains ""(.*)""")]
        public void ThenTheURLShouldNotContains(string urlPath)
        {
            ResultPage.Should().NotContainInUrl(urlPath);
        }
        
        [Then(@"the Page's title should be ""(.*)""")]
        public void ThenThePageSTitleShouldBe(string expectedTitle)
        {
            ResultPage.Should().Be<BingSearchResultPage>(expectedTitle);
        }
        
        [Then(@"the results related to the background's image location should be listed")]
        public void ThenTheResultsRelatedToTheBackgroundSImageLocationShouldBeListed()
        {
            ResultPage.Should().HaveMoreThan(1).And.SearchMatches(CurrentLocation);
        }
        
        [Then(@"more than (.*) result\(s\) should be listed")]
        public void ThenMoreThanOneResultsShouldBeListed(int minimumNumberResults)
        {
            ResultPage.Should().HaveMoreThan(minimumNumberResults);
        }

        [Then(@"the (.*) result item's title and url should contain ""(.*)"" and ""(.*)""")]
        public void ThenTheStResultItemSTitleAndUrlShouldContainAnd(int index, string itemResultTitle, string itemResultUrl)
        {
            ResultPage.Should().HaveItemResult(index, new ResultItem(itemResultTitle, itemResultUrl));
        }
    }
}
