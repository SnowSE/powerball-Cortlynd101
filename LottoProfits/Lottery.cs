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
            loserList = new TicketList();
        }

        public Lottery checkTicketListForWinners(TicketList ticketList)
        {
            Lottery lottery = new Lottery();
            WinningTicket winningTicket = new WinningTicket();
            foreach (Ticket ticket in ticketList.ticketList)
            {
                createWinnerLists(ticket, winningTicket, lottery);
            }
            return lottery;
        }

        public Lottery checkTicketListForWinners(TicketList ticketList, WinningTicket winningTicket)
        {
            Lottery lottery = new Lottery();
            foreach (Ticket ticket in ticketList.ticketList)
            {
                createWinnerLists(ticket, winningTicket, lottery);
            }
            return lottery;
        }

        public void createWinnerLists(Ticket ticket, WinningTicket winningTicket, Lottery lottery)
        {
            int numberOfWinningBalls = Lottery.checkTicketAgainstWinningTicket(ticket, winningTicket);
            numberOfWinningBalls += comparingPowerBall(ticket, winningTicket);
            ticket.ballsCorrect = numberOfWinningBalls;
            placeTicketInCorrectList(ticket, numberOfWinningBalls, lottery);
        }

        private void placeTicketInCorrectList(Ticket ticket, int numberOfWinningBalls, Lottery lottery)
        {
            switch(numberOfWinningBalls)
            {
                case 15:
                    lottery.grandPrizeWinners.ticketList.Add(ticket);
                    break;
                case 5:
                    lottery.firstPrizeWinners.ticketList.Add(ticket);
                    break;
                case 14:
                    lottery.secondPrizeWinners.ticketList.Add(ticket);
                    break;
                case 4:
                    lottery.thirdPrizeWinners.ticketList.Add(ticket);
                    break;
                case 13:
                    lottery.fouthPrizeWinners.ticketList.Add(ticket);
                    break;
                case 3:
                    lottery.fifthPrizeWinners.ticketList.Add(ticket);
                    break;
                case 12:
                    lottery.sixthPrizeWinners.ticketList.Add(ticket);
                    break;
                case 11:
                    lottery.seventhPrizeWinners.ticketList.Add(ticket);
                    break;
                case 10:
                    lottery.eighthPrizeWinners.ticketList.Add(ticket);
                    break;
                default:
                    lottery.loserList.ticketList.Add(ticket);
                    break;
            }
        }

        private static int checkTicketAgainstWinningTicket(Ticket ticket, WinningTicket winningTicket)
        {
            int numberOfCurrentBalls = 0;
            for (int i =0; i < 5; i++)
            {
                for (int j= 0; j < 5; j++)
                {
                    if (ticket.ticketNumbers[i] == winningTicket.winningTicket.ticketNumbers[j])
                    {
                        numberOfCurrentBalls++;
                    }
                }
            }
            return numberOfCurrentBalls;
        }

        public int comparingPowerBall(Ticket ticket, WinningTicket winningticket)
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