Feature: Home

Background: 
	Given user navigates to Home page
	And click "Accept all cookies" button


Scenario Outline: Verify a valid journey
	When enter journey start from "<From>" to "<To>"
	And click "plan my journey" button
	Then wait for results page where journey time will be validated

	Examples: 
	| From    | To      |
	| HA8 5DN | TW3 1QQ |
	| HA8 9EX | HA9 6LN |



Scenario Outline: Verify an invalid journey for one or more invalid locations
	When enter journey start from "<From>" to "<To>"
	And click "plan my journey" button
	Then journey result unable to provide results

	Examples: 
	| From    | To      |
	| edg     | TW3 1QQ |
	| edg     | toi     |



Scenario Outline: Verify valid journey using "Change time" button
	When enter journey start from "<From>" to "<To>"
	And click "change time" button
	And plan a journey based on "<JourneyBasedOn>" time
	And click "plan my journey" button
	Then wait for results page where journey time will be validated

	Examples: 
	| From    | To      | JourneyBasedOn |
	| HA8 5DN | TW3 1QQ | Arrival        |
	| HA8 9EX | HA9 6LN | Leaving        |



Scenario Outline: Verift that a invalid journey
	When click "plan my journey" button
	And verify the "From" error message as "The From field is required."
	Then verify the "To" error message as "The To field is required."


Scenario Outline: Verify that a journey can be amended by using the "Edit Journey" button
	When enter journey start from "<From>" to "<To>"
	And click "plan my journey" button
	And wait for results page where journey time will be validated
	And click "Edit journey" button
	And enter journey start from "<EditFrom>" to "<EditTo>"
	And click "Update journey" button
	Then wait for results page where journey time will be validated

	Examples: 
	| From    | To      | EditFrom | EditTo  |
	| HA8 5DN | TW3 1QQ | TW3 1QQ  | HA8 5DN |
	| HA8 9EX | HA9 6LN | HA9 6LN  | HA8 9EX |



Scenario Outline: Verify that the "Recents" tab should have list of recently planned journeys
	When enter journey start from "<From>" to "<To>"
	And click "plan my journey" button
	And wait for results page where journey time will be validated
	And click "Edit journey" button
	And enter journey start from "<EditFrom>" to "<EditTo>"
	And click "Update journey" button
	And wait for results page where journey time will be validated
	And click "Home" button
	And click "Recent Journey" button
	Then list of recently planned journeys should be displayed

	Examples: 
	| From    | To      | EditFrom | EditTo  |
	| HA8 5DN | TW3 1QQ | TW3 1QQ  | HA8 5DN |
	| HA8 9EX | HA9 6LN | HA9 6LN  | HA8 9EX |