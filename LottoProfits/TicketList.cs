using System;
using System.Collections.Generic;

namespace LottoProfits
{
    public class TicketList
    {
        public List<Ticket> ticketList { get; set; }
        public TicketList()
        {
            ticketList = new List<Ticket>();
        }

        public void createList(int p0)
        {
            for (int i = 0; i < p0; i++)
            {
                Ticket t = new Ticket();
                Ticket newlyCreatedTicket = t.createTicket(t);
                ticketList.Add(newlyCreatedTicket);
            }
        }

        public int calculateRevenue()
        {
            return ticketList.Count * 2;
        }
    }
}
