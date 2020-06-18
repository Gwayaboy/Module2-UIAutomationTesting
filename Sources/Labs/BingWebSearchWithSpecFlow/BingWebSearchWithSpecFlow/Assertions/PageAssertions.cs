using BingWebSearchWithSpecFlow.Pages;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System;

namespace BingWebSearchWithSpecFlow.Assertions
{
    public abstract class PageAssertions<TPage, TParentAssertion> : ReferenceTypeAssertions<TPage, PageAssertions<TPage, TParentAssertion>>
      where TPage : Page, new()
      where TParentAssertion : PageAssertions<TPage, TParentAssertion>
    {
        protected override string Identifier => typeof(TPage).Name;

        public PageAssertions(TPage page)
        {
            Subject = page;
        }

        public AndConstraint<TParentAssertion> HaveUrlStartingWith(string expectedUrl)
        {
            var actualUrl = Subject.Url;
            Execute
               .Assertion
               .ForCondition(actualUrl != null && actualUrl.StartsWith(expectedUrl, StringComparison.InvariantCultureIgnoreCase))
               .FailWith($"Expected page's url to start with {expectedUrl}, but was {actualUrl}");

            return new AndConstraint<TParentAssertion>((TParentAssertion)this);

        }

        public AndConstraint<TParentAssertion> Be<TExpectedPage>(string withExpectedTitle)
            where TExpectedPage : Page, new()
        {
            var actualPageTitle = Subject.Title;
            Execute
               .Assertion
               .ForCondition(typeof(TExpectedPage) == typeof(TPage) && string.Equals(actualPageTitle, withExpectedTitle, StringComparison.InvariantCultureIgnoreCase))
               .FailWith($"Expected page to be {typeof(TExpectedPage).Name} with {withExpectedTitle}, " +
                         $"but was {typeof(TPage).Name} with {actualPageTitle}");

            return new AndConstraint<TParentAssertion>((TParentAssertion)this);

        }

        public AndConstraint<TParentAssertion> NotContainInUrl(string urlPath)
        {
            var actualUrl = Subject.Url;
            Execute
               .Assertion
               .ForCondition(!Subject.Url.Contains(urlPath))
               .FailWith($"Expected page's url not contain  {urlPath}, but has {actualUrl}");

            return new AndConstraint<TParentAssertion>((TParentAssertion)this);
        }

        protected string Ordinal(int number)
        {
            if (number < 0) return number.ToString();
            long rem = number % 100;
            if (rem >= 11 && rem <= 13) return number + "th";
            switch (number)
            {
                case 1:
                    return number + "st";
                case 2:
                    return number + "nd";
                case 3:
                    return number + "rd";
                default:
                    return number + "th";
            }
        }

    }
}

