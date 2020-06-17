
There are multiple ways to express the acceptance criteria into a scenario.

Here is an example of our _Empty text_ and _"Hello World"_ [scenarios](https://cucumber.io/docs/gherkin/reference/#example) :

```Gherkin
Feature: Web Bing Search engine text search
    As a User
    I want to be able to perform searches 
    So that I can find the information I need easily

Scenario: Empty Search Text

  Given the user navigated to the url "http://bing.com/" 
  When the user submits the search 
  Then the results related to the background's image location should be listed


Scenario: "Hello World" Search Text

  Given the user navigated to the url "http://bing.com/" 
    And the user typed "Hello World" 
  When the user submits the search 
  Then more than 1 result(s) should be listed 
    And one of the result item's title should contain "Hello, World! program - Wikipedia"
```

Please, when writing Gherkin scenarions, keep in mind my these recommendations to focus on functionalities rather than User Interface (UI) and flow (UX) or technological platform:
1. Try to ignore the medium/platform on which the functionality is implemented on (web, desktop, mobile or anything else) whenever it makes sense
    - However, you can have feature specific to a platform for example:
      - Web search
      - Mobile Search
      - Windows Start Bar Search      
2. Regardless, do no express pre-requisites ([Given] (https://cucumber.io/docs/gherkin/reference/#given)) actions ([When](https://cucumber.io/docs/gherkin/reference/#when)) and  and assertions ([Then](https://cucumber.io/docs/gherkin/reference/#then)) on UI elements such as Pages, Forms, button, links, etc.

3. It can be tempting to introduced a steps for the empty search scenario to highlight that the user hasn't typed anything into the search but that will add noise and will result in step defintion that effectively does nothing usefull (unnecessary ode)

    ```Gherkin
    Scenario: Empty Search Text

      Given the user navigated to the url "http://bing.com/" 
        And the user didn't type anything 
      When the user submits the search 
      Then the results related to the background's image location should be listed
    ```

  
4. Keep it impersonal whenever possible and avoid using **I** _(as being the user acting on the web site)_, try instead to using specific user role (administrator, the user)

5. Try to express your scenario to enable then to be later data-driven and with the right level of granualirty so steps can be reused and composed in different [Feature]((https://cucumber.io/docs/gherkin/reference/#example)/[Scenarios])_ 

6. You can notice some [steps](https://cucumber.io/docs/gherkin/reference/#steps) are common between the 2 [scenarios](https://cucumber.io/docs/gherkin/reference/#example) and can be extracted to span accross multiple scenarios without repeating for each by using the [background](https://cucumber.io/docs/gherkin/reference/#background) keyword as follow:


    ```Gherkin
    Feature: Web Bing Search engine text search
        As a User
        I want to be able to perform searches 
        So that I can find the information I need easily

    Background: 
      Given the user navigated to the url "http://bing.com/" 

    Scenario: Empty Search Text

      When the user submits the search 
      Then the results related to the background's image location should be listed


    Scenario: "Hello World" Search Text

      Given the user typed "Hello World" 
      When the user submits the search 
      Then more than 1 result(s) should be listed 
        And one of the result item's title should contain "Hello, World! program - Wikipedia"
    ```