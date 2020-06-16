


**Scenario Outline**: Add Two Numbers
```Gherkin  
Given I the browser is <browser> <version> on <osName> <osVersion> for <resolution>
  And I navigated to "http://www.theonlinecalculator.com/"
  And I have entered 10 into the calculator
  And I have entered 20 into the calculator
 When I press add
 Then the result should be 30 on the screen
```