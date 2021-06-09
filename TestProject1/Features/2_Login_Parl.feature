Feature:2_LoginFeature parallel
	Login To MID Application

@mytag
Scenario: (1) Home page Functionality parallel
	Given Launch Application with URL
	| URL |
	| https://www.yahoo.com/ |
	And   Enter Username and Password and Click on Submit
	| Username | Password |
	| rajiv    | test     |
	Then  Verify Home page
	
Scenario:(2) Home page Functionality2 parallel
	Given Launch Application with URL
	| URL |
	| https://www.yahoo.com/ |
	And   Enter Username and Password and Click on Submit
	| Username | Password |
	| sai    | test2     |
	Then  Verify Home page
