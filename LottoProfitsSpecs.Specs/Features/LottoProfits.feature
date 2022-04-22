Feature: LottoProfits
! This program finds the profitability of a powerball lottery.

@mytag
Scenario: Creating a Ticket
	Given ticket
	When generating that ticket
	Then no two numbers should be the same
	Then all numbers should be between 1 and 69

Scenario: Creating the PowerBall Number
	Given ticket
	When generating that ticket
	Then the powerball should be between 1 and 26

Scenario: Selling 1000 Tickets
	Given we sell 1000 Tickets
	And when calculating revenue
	Then it should have 1000 Tickets
	Then the total revenue should be 2000

Scenario Outline: Checking Winning Tickets
	Given a ticket <ticket>
	And a winningTicket <winningTicket>
	And checking for winners
	When seeing how many balls matched up
	Then if the ticket has <balls> correct
	Then the ticket will win <winnerTier>
	Examples: 
	| ticket      | winningTicket | balls | winnerTier |
	| 1'2'3'4'5'6 | 1'2'3'4'5'6   | 15    | 0          |
	| 1'2'3'4'5'7 | 1'2'3'4'5'6   | 5     | 1          |
	| 1'2'3'4'6'7 | 1'2'3'4'5'6   | 14    | 2          |