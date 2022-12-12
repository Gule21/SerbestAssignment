Feature: AddProducts
	Adding the products to the cart

@Regression
@cart
Scenario: Adding the products
	Given I am logged in the application with <username> and <password>
	When I am on the product page
	Then I am able to add the products to the cart
	Then I can see product in my cart
	And Logout

Examples: 
| username      | password     |
| standard_user | secret_sauce |