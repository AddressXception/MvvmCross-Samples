Feature: TipCalcScreen
	In order to calculate gratuity
	As a restaraunt patron
	I want to select a percentage of my bill's subtotal

@TipCalcChangeSubtotal
Scenario: TipCalc Change SubTotal
	Given I have selected the SubTotal field
	When I enter 50 into the SubTotal field
	Then the Tip Amount should be 5 on the screen
