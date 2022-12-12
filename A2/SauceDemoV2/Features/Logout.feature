Feature: Logout
	Testing the logout of the application

@Regression
@logout-positive
Scenario: Verify if the logout works properly
	Given I navigate to the application login
	And I typed the <username> and <password>
	When I click the login button
	And I will logout

Examples: 
| username      | password     |
| standard_user | secret_sauce |