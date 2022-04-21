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
        }
    }
}
