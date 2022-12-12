Feature: Checkout
	checking out of the cart

@Regression
@checkout
Scenario: Adding products and checking out
	Given I am logged in with <given_username> and <given_password>
	And I am adding the products in cart
	When my cart has items
	Then should be able to checkout
	And fill in my information
	And click on finish
	And Verify the message
	
Examples: 
| given_username	| given_password	|
| standard_user		| secret_sauce		|