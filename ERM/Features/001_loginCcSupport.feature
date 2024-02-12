Feature: 001_loginCcSupport

A short summary of the feature

@tag1  
Scenario: UI Part of Test.
	Given I am at home page.
	When I click on orders.
	And I click on Create New Button.
	And I enter "99999" at mrn input bar.
	And I enter "Awais " in first name input bar.
	And I enter "Imran" in last name inout bar.
	And I enter "00000" in accession number input bar.
	And I select Lumus organization.
	And I select Northern Beaches Hospital in site id drop down.
	And I select the MRI modality.
	And I enter the date "8/17/2023" and time "1245AM" from the calender.
	And I enter the submit button.
	And I deleted the record with "00000" Accession Number.

Scenario: API Part of the test.
	Given I send the Get request to get all the orders.
	Given I send the Get request to get all the patients.

