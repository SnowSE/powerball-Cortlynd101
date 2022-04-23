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

        public WinningTicket createStaticWinningTicket(WinningTicket winningTicket, string staticNumbers)
        {
            string[] characters = staticNumbers.Split('_');
            for (int i = 0; i < winningTicket.winningTicket.ticketNumbers.Length; i++)
            {
                winningTicket.winningTicket.ticketNumbers[i] = Int32.Parse(characters[i]);
            }
            return winningTicket;
        }
    }
}
