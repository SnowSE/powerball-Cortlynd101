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
                Ticket newlyCreatedTicket = new Ticket();
                newlyCreatedTicket = newlyCreatedTicket.createTicket(newlyCreatedTicket);
                ticketList.Add(newlyCreatedTicket);
                //Console.WriteLine($"ticket {i} created");
            }
        }

        public int calculateRevenue()
        {
            return ticketList.Count * 2;
        }
    }
}
