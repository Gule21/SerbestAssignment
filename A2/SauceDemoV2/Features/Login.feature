Feature: Login
	Testing the login of the application

@Regression
@loginTest-positive
Scenario: Verify if the login works properly
	Given I navigate to the application login
	And I typed the <username> and <password>
	When I click the login button
	Then I should see the Products page

Examples: 
| username      | password     |
| standard_user | secret_sauce |
| problem_user		|secret_sauce |
| performance_glitch_user  |secret_sauce |

@Regression
@loginTest-negative
Scenario: Verify if the login error works properly
	Given I navigate to the application login
	And I typed the <invalid_username> and <invalid_password>
	When I click the login button
	Then I should see the Error message

Examples: 
| invalid_username | invalid_password |
| locked_out_user  |secret_sauce |