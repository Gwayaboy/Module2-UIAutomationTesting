Feature: Web Bing Search engine text search
    As a User
    I want to be able to perform searches 
    So that I can find the information I need easily

Background: 
  Given the user navigated to the url "http://bing.com/" 

Scenario: Empty Search Text

When the user submits the search 
Then the the URL should remain "http://bing.com/"
  And the URL should not contains "search?q="
  And the Page's title should be "Bing"

Scenario: Current Pin location search

  When the user submits the search 
  Then the results related to the background's image location should be listed


Scenario: "Hello World" Search Text

  Given the user typed "Hello World!" 
  When the user submits the search 
  Then more than 1 result(s) should be listed 
    And one of the result item's title should contain "Hello, World! program - Wikipedia"