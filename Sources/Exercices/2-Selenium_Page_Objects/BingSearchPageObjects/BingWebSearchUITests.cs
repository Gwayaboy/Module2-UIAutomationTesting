using System;
using BingSearchPageObjectsLab.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BingSearchPageObjectsLab
{
    [TestClass]
    public class BingWebSearchUITests
    {
        [TestMethod]
        public void HelloWordSeachShouldReturnMoreThanOneResult()
        {
            // Arrange
            var searchPage = Page.GoToInitial<BingSearchPage>("https://bing.com");

            // Act
            var resultPage = searchPage.Search("Hello World!");

            // Assertions
            Assert.IsTrue(resultPage.NumberOfResults >= 1);
        }
    }
}
