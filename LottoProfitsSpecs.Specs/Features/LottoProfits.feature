Feature: LottoProfits
! This program finds the profitability of a lottery.

@mytag
Scenario: Creating a Ticket
	Given a ticket is created
	When generating that ticket
	Then no two numbers should be the same
	Then all numbers should be between 1 and 69

Scenario: Creating the PowerBall Number
	Given a ticket is created
	When generating that ticket
	Then the powerball should be between 1 and 26

Scenario: Selling 1000 Tickets
	Given we sell 1000 Tickets
	And when calculating revenue
	Then it should have 1000 Tickets
	Then the total revenue should be 2000