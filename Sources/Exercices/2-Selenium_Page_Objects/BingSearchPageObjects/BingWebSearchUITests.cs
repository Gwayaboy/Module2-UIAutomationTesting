using BingSearchPageObjectsLab.Configuration;
using BingSearchPageObjectsLab.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BingSearchPageObjectsLab
{
    [TestClass]
    [TestCategory("Selenium")]
    public class BingWebSearchUITests : WebUISpecs
    {
        [TestCategory("BingTextSearch")]
        [TestMethod]
        public void EmptySearchShouldNotTriggerAnySearch()
        {
            //Arrange
            var searchPage = NavigateTo<BingSearchPage>("https://bing.com");

            // Act
            var returnedPage = searchPage.Search();

            // Assertions
            Assert.AreEqual("Bing",returnedPage.Title);
            Assert.IsFalse(returnedPage.Url.Contains("search?q="));
        }

        [TestCategory("BingLocationSearch")]
        [TestMethod]
        public void SelectingTheLocationPinShouldSearchAndReturnSeveralResultsRelatedToLocation()
        {
            //Arrange
            var searchPage = NavigateTo<BingSearchPage>("https://bing.com");
            var currentLocation = searchPage.CurrentPinLocation;

            // Act
            var returnedPage = searchPage.SelectCurrentPinLocation();

            // Assertions
            Assert.IsTrue(returnedPage.NumberOfResults > 1);
            Assert.AreEqual(currentLocation, returnedPage.SearchedText);
        }

        [TestCategory("BingTextSearch")]
        [TestMethod]
        public void HelloWordSeachFirstResultShouldBeHelloWordProgram()
        {
            // Arrange
            var searchPage = NavigateTo<BingSearchPage>("https://bing.com");

            // Act
            var returnedPage = searchPage.Search("Hello World!");
            var firstResultItem = returnedPage.FirstResultItem;

            // Assertions
            Assert.AreEqual("Hello World!", returnedPage.SearchedText);
            Assert.IsTrue(firstResultItem.Title.Contains("\"Hello, World!\" program - Wikipedia"));
            Assert.IsTrue(firstResultItem.Url.Contains("https://en.wikipedia.org/wiki/%22Hello,_World!%22_program"));
        }
    }
}
