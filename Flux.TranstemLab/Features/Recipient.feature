	Feature: RecipientCreation Test Cases

	Scenario Outline: Creating New Recipients 
	Given I navigate to TranstemLab application
	Then I click on Recipients Link 
	Then I click on Add Recipient button from the Recipient Search Page
	Then I have entered all the required details <Recipient ID> <First Name> <Last Name> <Medical Record> <CRID> <Registry ID> <Birth Date> Gender Ethnicity and Client Status from the page
	Then I click on Save button
	And I Click on Add a transplant event for this patient from RecipientDetail page
	Then I enter value for all the fields in Add Transplant Event page
	Then I click on Save button from Add Tranplant Event Page

	Examples: 
	| Recipient ID | First Name | Last Name | Medical Record | CRID | Registry ID | Birth Date |
	| Test852      | TestCheck2 |   T0123   |   AM123        |12ABC |   PO52      |    05/04/2012 |
	

	



