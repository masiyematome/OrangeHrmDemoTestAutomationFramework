Feature: Logout

Testing if a user gets logged out of the application upon clicking on the logout button

Scenario: Logout from application

	Given the user is logged in
	When the user logouts
	Then the user is redirected to the login page
