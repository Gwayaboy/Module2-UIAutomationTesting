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
   2. Clone [this repository to get started](https://github.com/Gwayaboy/Module2-UIAutomationTesting) following the instructions below:

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
  4. The plumbing code should be written to allow to execute a 3 failing non implemented tests on Chrome
      - Build the solution in Visual Studio
      - Run all the test using the Test Explorer then should start a instance of your Chrome Web Browser and fail because the pages methods and property are not yet implemented

        ![](https://demosta.blob.core.windows.net/images/FailingTests.PNG)

  5. Let's get started with the simplest scenario and read through the expected behaviour of the test method
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

      - let's implement the Search method in our ``` BingSearchPage ``` by navigating to its definition by pressing F12
      
## Hands-on Labs

  #### Implementing a Specflow Bing Search Scenario



