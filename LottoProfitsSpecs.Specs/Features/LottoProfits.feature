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
	| ticket        | winningTicket | balls | winnerTier |
	| 1_2_3_4_5_6   | 1_2_3_4_5_6   | 15    | 0          |
	| 1_2_3_4_5_7   | 1_2_3_4_5_6   | 5     | 1          |
	| 1_2_3_4_6_6   | 1_2_3_4_5_6   | 14    | 2          |
	| 1_2_3_4_6_7   | 1_2_3_4_5_6   | 4     | 3          |
	| 1_2_3_6_7_6   | 1_2_3_4_5_6   | 13    | 4          |
	| 1_2_3_6_7_7   | 1_2_3_4_5_6   | 3     | 5          |
	| 1_2_6_7_8_6   | 1_2_3_4_5_6   | 12    | 6          |
	| 1_6_7_8_9_6   | 1_2_3_4_5_6   | 11    | 7          |
	| 6_7_8_9_10_6  | 1_2_3_4_5_6   | 10    | 8          |
	| 6_7_8_9_10_11 | 1_2_3_4_5_6   | 0     | 9          |


Scenario Outline: Checking Profit Amount
	Given a ticket <ticket>
	And a winningTicket <winningTicket>
	And checking for winners
	When seeing how many balls matched up
	Then if the ticket has <balls> correct
	When checking for profit
	Then the profit will be <profit>
	Examples: 
	| ticket        | winningTicket | balls | profit    |
	| 1_2_3_4_5_6   | 1_2_3_4_5_6   | 15    | -39999998 |
	| 1_2_3_4_5_7   | 1_2_3_4_5_6   | 5     | -999998   |
	| 1_2_3_4_6_6   | 1_2_3_4_5_6   | 14    | -49998    |
	| 1_2_3_4_6_7   | 1_2_3_4_5_6   | 4     | -98       |
	| 1_2_3_6_7_6   | 1_2_3_4_5_6   | 13    | -98       |
	| 1_2_3_6_7_7   | 1_2_3_4_5_6   | 3     | -5        |
	| 1_2_6_7_8_6   | 1_2_3_4_5_6   | 12    | -5        |
	| 1_6_7_8_9_6   | 1_2_3_4_5_6   | 11    | -2        |
	| 6_7_8_9_10_6  | 1_2_3_4_5_6   | 10    | -2        |
	| 6_7_8_9_10_11 | 1_2_3_4_5_6   | 0     | 2         |