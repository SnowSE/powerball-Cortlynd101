using System;

namespace LottoProfits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicketList ticketList = new TicketList();
            ticketList.createList(1000);

            WinningTicket staticWinningTicket = new WinningTicket();
            staticWinningTicket = staticWinningTicket.createStaticWinningTicket(staticWinningTicket, "1_2_3_4_5_6");

            Ticket staticTicket = new Ticket();
            staticTicket = staticTicket.createStaticTicket(staticTicket, "1_2_3_4_5_6");
            ticketList.ticketList.Add(staticTicket);

            Lottery lottery = new Lottery();
            //lottery = lottery.checkTicketListForWinners(ticketList, staticWinningTicket);
            lottery.checkTicketListForWinners(ticketList);

            SalesReport salesReport = new SalesReport();
            salesReport.clearReport();
            salesReport = salesReport.calculateProfit(lottery, ticketList, salesReport);
            salesReport.writeToSalesReport(lottery, ticketList, salesReport);

            //Console.WriteLine("\n\nPress any key to exit");
            //Console.ReadKey(true);
        }
    }
}
