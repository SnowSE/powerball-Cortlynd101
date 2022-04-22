using System;

namespace LottoProfits
{
    public class WinningTicket
    {
        public Ticket winningTicket = new Ticket();
        public WinningTicket()
        {
            winningTicket = winningTicket.createTicket(winningTicket);
        }

        public WinningTicket createStaticWinningTicket(string s0)
        {
            throw new NotImplementedException();
        }
    }
}
