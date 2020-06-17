# Module 2: Web Front-end Test Automation

Please [view and download ](https://github.com/Gwayaboy/Module2-UIAutomationTesting/blob/master/Content/AutomationTesting-Module2-18th.pdf) Module 2's Slide deck

## Agenda

 1.  **[Brief overview of Behaviour Driven Development (BDD)](https://cucumber.io/docs/bdd/)**
    - [Gherkin Fundamentals](https://cucumber.io/docs/gherkin/reference/)
    - [Acceptance Testing](https://www.google.com/url?sa=t&rct=j&q=&esrc=s&source=web&cd=&cad=rja&uact=8&ved=2ahUKEwjA2K28lIfqAhWIiVwKHUXsDBsQFjARegQIAhAB&url=https%3A%2F%2Fwww.agilealliance.org%2Fglossary%2Facceptance%2F&usg=AOvVaw13fcTzx2cJZV5vviaQwrM-)
 2. **Web UI Testing**
    - [Anatomy of a web page](https://developer.mozilla.org/en-US/docs/Learn/HTML/Introduction_to_HTML/Document_and_website_structure) & [accessing DOM elements](https://www.protechtraining.com/content/selenium_tutorial-locators)
    - Designing Testable Web Pages
 3. **[SpecFlow Fundamentals](https://specflow.org/documentation/About-SpecFlow/)**
    - Business stack
      - Features, Scenarios & [Gherkin support](https://specflow.org/documentation/Using-Gherkin-Language-in-SpecFlow/)
    - Testing stack
      - [Bindings](https://specflow.org/documentation/Bindings/), [Step definition](https://specflow.org/documentation/Step-Definitions/) & [Hooks](https://specflow.org/documentation/Hooks/)
      - [Sharing Data between steps](https://specflow.org/documentation/Sharing-Data-between-Bindings/)
      - Anti-patterns & best practices
4. **Next steps**
    - [Reference](https://github.com/Gwayaboy/Module2-UIAutomationTesting/blob/master/Content/references.md) 
    - [FeedBack for the session](https://forms.office.com/Pages/ResponsePage.aspx?id=v4j5cvGGr0GRqy180BHbRzkcgooWh0tLpfJnJxlZV4xUNVVDWEU0NzJDRjlMMkJIOUVJRlVGMUowVi4u)
    - Preparing for the next session

## Exercices

  #### Exercise 1: Defining Bing Search Scenario with Gherkin

This exercise doesn't require to install SpecFlow extension or Visual Studio. The outcome is to learn how to write scenarios that focus on functionality rather than UI.
We can just use notepad and everyone can share their scenarios on MS Teams meeting chat
![MS Team Chat Gherkin scenario](https://demosta.blob.core.windows.net/images/MSTeamChatGherkin.PNG)
1. An example scenario looks as follow:
    ```Gherkin
      Feature: Pascal's calculator can perform arithmetic operations
        As a User
        I want to be able to perform arithmetic operations
        So that I can keep track of my accounts

      Scenario: Adding 2 integers 

      Given the calculator has started
        And 10 was entered 
        And 20 was entered
      When selecting the addition operator
      Then the result should be 30 
      ```
2. Using Gherkin's ``` Given\When\Then ``` Syntax write the 2 following scenarios to validate 

    ```Gherkin
    Feature: Web Bing Search engine text search
        As a User
        I want to be able to perform searches
        So that I can find the information I need easily
    ```
    
    a) Empty text search scenario
      ```Gherkin
      Scenario: Empty text Search
      ``` 
    b) "Hello Word!" text search scenario
      ```Gherkin
      Scenario: "Hello Word!" text Search
      ```
    c) Current Pin location search scenario
     ```Gherkin
      Scenario: Current pin location Search
      ```
3. Example of Gherkin scenarios and recommendations [here](https://github.com/Gwayaboy/Module2-UIAutomationTesting/blob/Finished/Sources/Exercices/1-Describe_Scenario_with_Gherkin/Exercise1.md)

  #### Exercise 2: Finding elements with the Web Browser

  1. Open Chrome, Firefox or Edge Chromium and navigate to https://bing.com 

  ![](https://demosta.blob.core.windows.net/images/BingLandingPage.PNG)

  2. At the bottom right corner, right click on location pin button pointing at the location of the background image and 

       - Select the inspect item in the contextual menu
       - Locate the link that would look like:
         ```html 
         <a href="search?q=beaver+falls+havasu+creek">
          <div class="icon">
            <svg class="mappin" height="16" width="16" viewBox="0 0 12 12">
              <!-- svg paths-->
            </svg>
          </div>
         </a>
 ![](https://demosta.blob.core.windows.net/images/InspectElementsHighLighted.png)

  3. right click on the html link element above to bring up another contextual menu and select the following menu items to
      - copy selector to get the css selector to that element as follow
        ```css 
        #vs_cont > div.mc_caro > div > div.headline > div.icon_text > a
        ```
      - copy Xpath to get the xpath selector
        ```xpath
        //*[@id="vs_cont"]/div[1]/div/div[2]/div[1]/a
        ```
      - optionally copy the javascript path
        ```javascript
        document.querySelector("#vs_cont > div.mc_caro > div > div.headline > div.icon_text > a")
        ```

 ![](https://demosta.blob.core.windows.net/images/TypeOfLocators.PNG)
 
  #### Exercise 3: Writing UI Automated with Selenium and Pages Objects

   1. Ensure you have Chrome Web Browser on the machine your using for this exercise.    
      - You can [install Chrome here](https://www.google.com/chrome/)
   2. Clone this repository to get started at ![https://github.com/Gwayaboy/Module2-UIAutomationTesting.git](https://github.com/Gwayaboy/Module2-UIAutomationTesting.git) following the instructions below:

      ![](https://demosta.blob.core.windows.net/images/CloneRepoToGetStarted.png)

      - Click on the "Clone or download" button
      - Clone the repository direclty into Visual studio
        
        or
      - Copy the git repository url and execute the command:
        ```bash
        git clone https://github.com/Gwayaboy/Module2-UIAutomationTesting.git
        ```

        or  
      - Download as a zip file to your local drive 
         
  3. Once you a copy in your local drive open the solution at
        ```
        /Sources/Exercices/2-Selenium_Page_Objects/BingSearchPageObjects.sln
        ```
  4. The plumbing code should be written to allow to execute 3 failing non implemented tests on Chrome
      - Build the solution in Visual Studio
      - Run all the test using the Test Explorer then should start a instance of your Chrome Web Browser and fail because the pages methods and property are not yet implemented

        ![](https://demosta.blob.core.windows.net/images/FailingTests.PNG)

  5. Let's implements these 3 test scenarions
      1. First get started with the simplest scenario and read through the expected behaviour of the test method
      ```csharp
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
      ```

      2. Let's implement the Search method in our ```BingSearchPage``` by navigating to its definition by pressing F12 which should look like:
          ```csharp 
          public BingSearchResultPage Search(string textToSearch = "")
          {
              throw new NotImplementedException();
          }
          ```
          We need in a nutshell to
            - using ```FindElement``` utility method from the base ```Page class```  the  find the text input element using Chrome to get its CSS or XPath selector.
            - send the search text 
            - find the form  which the input seach text belongs and submit it
            - use the base Page class ```GoTo``` utility method to return a strongly typed ```BingSearchResultPage``` to look something like
              
              ```csharp
              FindElement(By.Id("{searchInputId}")).SendKeys(textToSearch)
              return GoTo<BingSearchResultPage>(By.Id("{formId}"), e => e.Submit());

              ```
              once you've replaced  ```{searchInputId} ``` and  ```{formId} ``` placeholders by the ids you found using the chrome browser to explore these DOM elements, run the test and **see whether it passes** 
          
      3. Next we'll implemenent our next scenario
          ```csharp
          public void SelectingTheLocationPinShouldSearchAndReturnSeveralResultsRelatedToLocation()
          ```
          We need to
          - implement in the ```BingSearchResultPage``` the  property  
            ```csharp
            public string CurrentPinLocation 
            ```
            which reads the landing page's current location that will be used for validating the search
          - and the method 
            ```csharp
            public BingSearchResultPage SelectCurrentPinLocation() { }
            ```
            which selects and clicks on current location pin link

          - Similary we need to find the ```<a href="">``` HTML element using the Chrome's inspect element and copy selector options in the contextual menu to retrieve the location, retrieve the string that will be used to search (we'd need to do a bit of string manipulation)
          - With the same ```FindElement``` method you can find the link and click on it to navigate to  ```BingSearchResultPage``` with ```GoTo```  like we did for 
              ```csharp
              BingSearchResultPage Search(string textToSearch = "")
              ```

          - **Tip**: to read a DOM Element attribute you'll need Selnium's ```GetAttribute()``` 
          method. This would look like:
              ```csharp
              var href = FindElement(By.CssSelector(currentLocationPinLinkSelector)).GetAttribute("href");
              ```
          For our assertions 
            
            ```csharp
            Assert.IsTrue(returnedPage.NumberOfResults > 1);
            Assert.AreEqual(currentLocation, returnedPage.SearchedText);
            ```
          - we need to implement as you guessed ```NumberOfResults``` and ```SearchedText``` property on ```BingSearchResultPage```

      4. Finally we'll finished we are last test scenario
          ```csharp
          public void HelloWordSeachFirstResultShouldBeHelloWordProgram() {}
          ```

          ```BingSearchPage.Search``` and  ```BingSearchResultPage.SearchedText``` should both be already implemented.
          
          What's left to do is implement:
          ```csharp
          public ResultItem FirstResultItem => throw new NotImplementedException();
          public ResultItem GetResultItemAt(int index)
          {
              throw new NotImplementedException();
          }
          ```

          We need to: 
            - Find the nth-child of some sort of list in the result search page to display the result items. we'll use a 1 based ```li:nth-child({index}``` to find the nth element
            - Create an instance of ```ResultItem``` with the page's result item title and URL from the ```<a href="{url}">{title}</a>```


Switch to the the [Finished](https://github.com/Gwayaboy/Module2-UIAutomationTesting/tree/Finished) branch to see the complete Page implenmentation [here](https://github.com/Gwayaboy/Module2-UIAutomationTesting/tree/Finished/Sources/Exercices/2-Selenium_Page_Objects/BingSearchPageObjects/Pages) 
    

## Hands-on Labs

  #### Implementing a Specflow Bing Search Scenario



