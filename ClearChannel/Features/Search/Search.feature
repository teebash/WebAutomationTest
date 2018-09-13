
Feature: Search
	As a clear channel potential customer
	I want to be able to search the website
	So that I can find the information I am looking for

@Chrome 
#@FireFox
Scenario Outline: Search and verify result displayed returns a match
	Given I am on the homePage
	When I search for "<searchTerm>"
	Then the result should have the term "<searchTerm>" somewhere within the returned result

Examples: 
	| searchTerm |
	| test       |
	
@Chrome
Scenario Outline: Search and verify user gets the appropriate error message for invalid searches
	Given I am on the homePage
	When I search for an invalid term "<searchTerm>"
	Then the result should have the friendly error message "<errorMessage>"

Examples: 
	| searchTerm | errorMessage                     |
	| food       | No results found.                |
	|            | You did not submit a search term |


	# I am not sure if this should be valid searches, as i expect them to return an error message,
	# however it does return some addresses and personnel details respectively,
	# this might be a bug worth investigating as i do not expect both parameters to return a valid result.
@Chrome
Scenario Outline: Search and verify that random searches displays the right results 
	Given I am on the homePage
	When I search for "<searchTerm>"
	Then the result should be have the search term "<searchTerm>" displayed as part of the result

Examples: 
	| searchTerm |
	| 123        |
	| 98-        |