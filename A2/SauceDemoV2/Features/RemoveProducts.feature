Feature: RemoveProducts
	Removing the products from the cart

@Regression
@removeCart
Scenario: Removing the products
	Given I am logging in with <username> and <password>
	When I am on the products page
	Then I am able to remove the products from the cart
	Then I can see no product in my cart
	And Log out

Examples: 
| username      | password     |
| standard_user | secret_sauce |