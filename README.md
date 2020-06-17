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

## Exercices:

#### Exercise 1:  Defining Bing Search Scenario with Gherkin

This exercise doesn't require to install SpecFlow extension or Visual Studio. The outcome is to learn how to write scenarios that focus on functionality rather than UI.
We can just use notepad and everyone can share their scenarios on MS Teams meeting chat
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
    _
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
    b) "Hello Word" text search scenario
      ```Gherkin
      Scenario: "Hello Word" text Search
      ```



#### 2. Finding elements with the Web Browser

  #### 3. Writing UI Automated with Selenium and Pages Objects

## Hands-on Labs:


  #### 1. Implementing a Specflow Bing Search Scenario


