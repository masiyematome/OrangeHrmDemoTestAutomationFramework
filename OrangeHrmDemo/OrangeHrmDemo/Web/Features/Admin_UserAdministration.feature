﻿Feature: Admin_UserAdministration

Verifying if the admin is able to add new users,search for and delete existing users

Background: Add,search and delete user
	
	Given the admin is on the Admin page
	
Scenario: Add a new user

	When the admin adds a new user

	| UserRole | EmployeeName | Status  | Username | Password      | ConfirmPassword |
	| ESS      | Laura Dan    | Enabled | Laura D  | Laura_Dan2023 | Laura_Dan2023   |

	And the admin logs out of the application
	And the user logs in with the newly created login credentials
	Then the user is redirected to the dashboard

Scenario: Search for an existing user

	When the admin searches for a user
	Then the admin is presented with the details of the searched user

Scenario: Delete an existing user

	When the admin deletes a user
	Then the admin is presented with no user details upon searching for the deleted user

	
