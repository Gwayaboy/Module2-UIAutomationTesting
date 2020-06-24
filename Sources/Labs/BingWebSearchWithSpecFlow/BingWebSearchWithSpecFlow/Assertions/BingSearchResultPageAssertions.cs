using BingWebSearchWithSpecFlow.Pages;
using BingWebSearchWithSpecFlow.ViewModel;
using FluentAssertions;
using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingWebSearchWithSpecFlow.Assertions
{
    public class BingSearchResultPageAssertions : PageAssertions<BingSearchResultPage, BingSearchResultPageAssertions>
    {
        public BingSearchResultPageAssertions(BingSearchResultPage page) : base(page)
        {
        }

        public AndConstraint<BingSearchResultPageAssertions> HaveMoreThan(int minimumOfResults)
        {
            var actualNumberOfResults = Subject.NumberOfResults;

            Execute
               .Assertion
               .ForCondition(actualNumberOfResults > minimumOfResults)
               .FailWith($"Expected to have more than {minimumOfResults} in the page, but found {actualNumberOfResults} results");

            return new AndConstraint<BingSearchResultPageAssertions>(this);
        }

        public AndConstraint<BingSearchResultPageAssertions> SearchMatches(string currentLocation)
        {
            var actualSearchedText = Subject.SearchedText;

            Execute
               .Assertion
               .ForCondition(string.Equals(actualSearchedText, currentLocation, StringComparison.OrdinalIgnoreCase))
               .FailWith($"Expected to have searched for {currentLocation}, but actual search was for {actualSearchedText}");

            return new AndConstraint<BingSearchResultPageAssertions>(this);
        }

        public AndConstraint<BingSearchResultPageAssertions> HaveItemResult(int index, ResultItem expectedResultItem)
        {
            var actualResultItem = Subject.GetResultItemAt(index);

            Execute
               .Assertion
               .ForCondition(actualResultItem.Title.Contains(expectedResultItem.Title) && actualResultItem.Url.Contains(expectedResultItem.Url))
               .FailWith($"Expected {Ordinal(index)} result item to contains the title {expectedResultItem.Title} and the url {expectedResultItem.Url}" +
                         $", but actual title is {actualResultItem.Title} and url is {actualResultItem.Url}");

            return new AndConstraint<BingSearchResultPageAssertions>(this);
        }


        
    }
}
