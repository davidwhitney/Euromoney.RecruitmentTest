Feature: CountBadWords
	In order to filter the messages
	I need to be able to count the bad words on it

Background: 
	Given The banned words are 
		| bannedWords |
		| nasty       |
		| bad         |
	Given I have a text parser

@success
Scenario: No bad words 
	Given I have the input "This is a good input"
	When I evaluate the message
	Then the number of bad words should be 0

Scenario: 1 bad word 
	Given I have the input "This is a bad input"
	When I evaluate the message
	Then the number of bad words should be 1

Scenario: 2 diferent bad words 
	Given I have the input "This is a bad and nasty input"
	When I evaluate the message
	Then the number of bad words should be 2

Scenario: Repetition bad words 
	Given I have the input "This is a bad bad bad input"
	When I evaluate the message
	Then the number of bad words should be 3
