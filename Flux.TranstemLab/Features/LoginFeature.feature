Feature: LoginFeature
	In order to test the login functionality with different users and different combinations,
	I want to develop a Login feature.

Scenario: Login TranstemLab application with valid credentials
	Given I navigate to TranstemLab login page
	When I enter username as 'neelamc'
	And I enter password as 'Testing!'
	And I click the Login button
	Then I should be navigated to TranstemLab home page

	Scenario: Login to TranstemLab application
	Given I navigate to TranstemLab application 
	Then I should be navigated to TranstemLab home page
