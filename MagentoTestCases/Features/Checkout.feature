Feature: Checkout

Scenario: To verify the Submitted Orders
	Given the registered user logins
	When the user adds two Men jackets and one Men pant to the cart
	And proceeds to the checkout
	Then verify the product and price in the checkout page
	And the user provides valid address
	And select the delivery method
	And place the order
	When the user navigates to My Orders
	Then Verify the submitted order under My Orders