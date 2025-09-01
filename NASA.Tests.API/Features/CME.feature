Feature: Coronal Mass Ejection (CME) endpoint
  As an automation engineer
  I want to validate the CME API endpoint
  So that I can confirm it meets functional requirements

  Background:
    Given the NASA DONKI base URL is "https://api.nasa.gov"
    And the API key is set to "DEMO_KEY"

  Scenario: Valid request returns HTTP 200 with a non-empty list
    Given startDate "2023-01-01" and endDate "2023-01-07"
    When I request CME data
    Then the response status code should be 200
    And the response should be a JSON array with at least one item

Scenario: Invalid date format returns HTTP 200 with an empty list
    Given startDate "2023-01-32" and endDate "2023-01-07"
    When I request CME data
    Then the response should be a JSON array with 0 items