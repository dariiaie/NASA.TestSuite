Feature: NASA Open APIs Sign-up
  As a user
  I want to register for an API key
  So that I can access NASA APIs

  Scenario: User registers successfully
    Given I navigate to the NASA Open APIs home page
    When I open the sign-up form
    And I fill the registration form with valid details
    And I submit the registration form
    Then I should see a registration confirmation message
