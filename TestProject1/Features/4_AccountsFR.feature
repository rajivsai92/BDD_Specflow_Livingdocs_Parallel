Feature:4_AccountsFR
	Simple calculator for adding two numbers

@mytag
Scenario: (1) Home page Functionality
	Given Launch Application with URL
	| URL |
	| https://www.Amazon.com/|
	And   Enter Username and Password and Click on Submit
	| Username | Password |
	| rajiv    | test     |
	Then  Verify Home page
	
Scenario:(2) Home page Functionality2
	Given Launch Application with URL
	| URL |
	| https://www.Amazon.com/ |
	And   Enter Username and Password and Click on Submit
	| Username | Password |