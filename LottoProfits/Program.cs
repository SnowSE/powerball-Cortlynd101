using System;

namespace LottoProfits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ticket ticket = new Ticket();
            ticket = ticket.createTicket(ticket);
            ticket.printOutTicket();

            Console.WriteLine("\n\nPress any key to exit");
            Console.ReadKey();

            TicketList ticketList = new TicketList();
            ticketList.createList(1000);

            Console.WriteLine("\n\nPress any key to exit");
            Console.ReadKey();
        }
    }
}
