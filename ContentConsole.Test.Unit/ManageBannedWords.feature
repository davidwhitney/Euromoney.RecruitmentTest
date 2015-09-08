Feature: ManageBannedWords
	In order to mange the words

Background: 
	Given bad is a banned word
	Given I have a banned words manager
	

@add
Scenario: Add a new word
	Given I want to add epistemy
	When I add to the list or words 1 time
	Then epistemy must appear 1

@add
Scenario: If I add the same word twice
	Given I want to add word1
	When I add to the list or words 2 time
	Then word1 must appear 1
