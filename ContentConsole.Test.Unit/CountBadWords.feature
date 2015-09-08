Feature: CountBadWords
	In order to filter the messages
	I need to be able to count the bad words on it

Background: 
	Given I have a text parser

@success
Scenario: No bad words 
	Given I have the input "This is a good input"
	When I evaluate the message
	Then the number of bad words should be 0
