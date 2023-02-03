Feature: Login

Background: Login page

	Given the user is on the login page

Scenario: Successful login with valid credentials
	
	When the user logs in with a valid login credentials
	Then the user is redirected to the dashboard