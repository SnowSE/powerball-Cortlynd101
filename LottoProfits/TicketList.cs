using System;
using System.Collections.Generic;

namespace LottoProfits
{
    public class TicketList
    {
        public int totalRevenue;
        public List<Ticket> ticketList { get; set; }
        public TicketList()
        {
            ticketList = new List<Ticket>();
        }

        public TicketList createList(int p0)
        {
            throw new NotImplementedException();
        }

        public void calculateRevenue()
        {
            totalRevenue = ticketList.Count * 2;
        }
    }
}
