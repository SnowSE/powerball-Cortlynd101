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
    }
}
