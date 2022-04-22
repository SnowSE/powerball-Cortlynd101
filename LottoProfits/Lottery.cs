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
    }
}