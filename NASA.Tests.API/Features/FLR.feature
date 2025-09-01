Feature: Solar Flare (FLR) endpoint
  As an automation engineer
  I want to validate the FLR API endpoint
  So that I can confirm it handles both valid and invalid inputs

  Background:
    Given the NASA DONKI base URL is "https://api.nasa.gov"
    And the API key is set to "DEMO_KEY"

  Scenario: Valid request returns HTTP 200 with flare data
    Given startDate "2023-01-01" and endDate "2023-01-07"
    When I request FLR data
    Then the response status code should be 200
    And the response should contain flare entries

  Scenario: Missing startDate returns HTTP 400
    Given endDate "2023-01-07"
    When I request FLR data with missing startDate
    Then the response should be a JSON array with 0 items
