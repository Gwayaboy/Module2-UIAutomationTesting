using System;
using BingSearchPageObjectsLab.Configuration;
using BingSearchPageObjectsLab.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BingSearchPageObjectsLab
{
    [TestClass]
    public class BingWebSearchUITests
    {
        [TestMethod]
        public void EmptySearchShouldReturnSeveralResultsRelatedToBackgroundImageLocation()
        {
            //Arrange
            var searchPage = Page.GoToInitial<BingSearchPage>("https://bing.com");
            var defaultLocationSearchText = searchPage.LocationSearchText;

            // Act
            var resultsPage = searchPage.Search();

            // Assertions
            Assert.IsTrue(resultsPage.NumberOfResults > 1);
            Assert.AreEqual(defaultLocationSearchText, resultsPage.SearchedText);
        }


        [TestMethod]
        public void HelloWordSeachFirstResultShouldBeHelloWordProgram()
        {
            // Arrange
            var searchPage = Page.GoToInitial<BingSearchPage>("https://bing.com");

            // Act
            var resultsPage = searchPage.Search("Hello World!");

            // Assertions
            Assert.AreEqual("Hello World!", resultsPage.SearchedText);

            Assert.IsTrue(resultsPage.FirstResultItem.Title.Contains("\"Hello, World!\" program - Wikipedia"));
        }
    }
}
