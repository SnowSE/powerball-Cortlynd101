using System;

namespace LottoProfits
{
    public class Lottery
    {
        public TicketList grandPrizeWinners;
        public TicketList firstPrizeWinners;
        public TicketList secondPrizeWinners;
        public TicketList thirdPrizeWinners;
        public TicketList fouthPrizeWinners;
        public TicketList fifthPrizeWinners;
        public TicketList sixthPrizeWinners;
        public TicketList seventhPrizeWinners;
        public TicketList eighthPrizeWinners;
        public TicketList loserList;
        public Lottery()
        {
            grandPrizeWinners = new TicketList();
            firstPrizeWinners = new TicketList();
            secondPrizeWinners = new TicketList();
            thirdPrizeWinners = new TicketList();
            fouthPrizeWinners = new TicketList();
            fifthPrizeWinners = new TicketList();
            sixthPrizeWinners = new TicketList();
            seventhPrizeWinners = new TicketList();
            eighthPrizeWinners = new TicketList();
        }
        public void checkTicketListForWinners(TicketList ticketList)
        {
            WinningTicket winningTicket = new WinningTicket();
            foreach (Ticket ticket in ticketList.ticketList)
            {
                createWinnerLists(ticket, winningTicket);
                ticketList.ticketList.Remove(ticket);
            }
        }
        public void createWinnerLists(Ticket ticket, WinningTicket winningTicket)
        {
            int numberOfWinningBalls = Lottery.CheckTicketAgainstWinningTicket(ticket, winningTicket);
            numberOfWinningBalls += ComparingPowerBall(ticket, winningTicket);
            placeTicketInCorrectList(ticket, numberOfWinningBalls);
        }

        private void placeTicketInCorrectList(Ticket ticket, int numberOfWinningBalls)
        {
            switch(numberOfWinningBalls)
            {
                case 15:
                    grandPrizeWinners.ticketList.Add(ticket);
                    break;
                case 5:
                    firstPrizeWinners.ticketList.Add(ticket);
                    break;
                case 14:
                    secondPrizeWinners.ticketList.Add(ticket);
                    break;
                case 4:
                    thirdPrizeWinners.ticketList.Add(ticket);
                    break;
                case 13:
                    fouthPrizeWinners.ticketList.Add(ticket);
                    break;
                case 3:
                    fifthPrizeWinners.ticketList.Add(ticket);
                    break;
                case 12:
                    sixthPrizeWinners.ticketList.Add(ticket);
                    break;
                case 11:
                    seventhPrizeWinners.ticketList.Add(ticket);
                    break;
                case 10:
                    eighthPrizeWinners.ticketList.Add(ticket);
                    break;
                default:
                    loserList.ticketList.Add(ticket);
                    break;
            }
        }

        private static int CheckTicketAgainstWinningTicket(Ticket ticket, WinningTicket winningTicket)
        {
            int numberOfCurrentBalls = 0;
            for (int i =0; i < 5; i++)
            {
                for (int j= 0; j < 5; j++)
                {
                    if (ticket.ticketNumbers[i]== winningTicket.winningTicket.ticketNumbers[j])
                    {
                        numberOfCurrentBalls++;
                    }
                }
            }
            return numberOfCurrentBalls;
        }
        public int ComparingPowerBall(Ticket ticket, WinningTicket winningticket)
        {
            if(ticket.ticketNumbers[5]==winningticket.winningTicket.ticketNumbers[5])
            {
                return 10;
            }
            else
            {
                return 0;
            }
        }
    }
}