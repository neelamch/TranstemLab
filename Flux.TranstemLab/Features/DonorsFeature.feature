Feature: Donors Test Cases	
	
Scenario: Create Collection Event From Donar Page for Existing Recepient 
	Given I navigate to TranstemLab application 
	Then I should be navigated to TranstemLab home page
	Then I click on Donors Link 
	And I click on search button from the Donor Serach Page and I select a identifier 
	Then I click on Add collection Event link from the Donor Detail page and fill out the required fields 
	And I Click on Save button
	
Scenario Outline: Create Birth Event From Donar Page for Existing Recepient 
	Given I navigate to TranstemLab application 
	Then I should be navigated to TranstemLab home page
	Then I click on Donors Link 
	And I click on search button from the Donor Serach Page and I select a identifier
	Then I click on Add Birth Event link from the Donor Detail page and fill out the required fields <OtherPhysician> <Location> <OtherReferralType>
	And I Click on Save button on Add Birth Event page
	Examples: 
	| OtherPhysician | Location | OtherReferralType |
	|    Dr.Test  |    Texas     |     Dr.Jenny |
