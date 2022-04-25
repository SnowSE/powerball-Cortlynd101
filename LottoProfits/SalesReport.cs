using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LottoProfits
{
    public class SalesReport
    {
        public int profit;
        public int cost;
        public SalesReport()
        {
            profit = 0;
            cost = 0;
        }
        public SalesReport calculateProfit(Lottery lottery, TicketList ticketList, SalesReport salesReport)
        {
            int profit = ticketList.calculateRevenue();
            salesReport = calculateCost(lottery, salesReport);
            profit += salesReport.cost;

            salesReport.profit = profit;
            return salesReport;
        }

        private SalesReport calculateCost(Lottery lottery, SalesReport salesReport)
        {
            int cost = 0;
            if (lottery.grandPrizeWinners.ticketList.Count > 0)
            {
                cost += -40000000;
            }

            cost += lottery.firstPrizeWinners.ticketList.Count * -1000000;
            cost += lottery.secondPrizeWinners.ticketList.Count * -50000;
            cost += lottery.thirdPrizeWinners.ticketList.Count * -100;
            cost += lottery.fouthPrizeWinners.ticketList.Count * -100;
            cost += lottery.fifthPrizeWinners.ticketList.Count * -7;
            cost += lottery.sixthPrizeWinners.ticketList.Count * -7;
            cost += lottery.seventhPrizeWinners.ticketList.Count * -4;
            cost += lottery.eighthPrizeWinners.ticketList.Count * -4;

            salesReport.cost = cost;
            return salesReport;
        }

        public void clearReport()
        {
            string line = "";
            using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\cort.cox\Source\Repos\powerball-Cortlynd101\LottoProfits\TicketSalesReport.txt"))
            {
                streamWriter.WriteLine(line);
            }
        }

        public void writeToSalesReport(Lottery lottery, TicketList ticketList, SalesReport salesReport)
        {
            string line = "";
            using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\cort.cox\Source\Repos\powerball-Cortlynd101\LottoProfits\TicketSalesReport.txt"))
            {
                streamWriter.WriteLine($"Revenue: {ticketList.calculateRevenue()}");
                streamWriter.WriteLine($"Cost: {salesReport.cost}");
                streamWriter.WriteLine($"Profit: {salesReport.profit}\n");

                streamWriter.WriteLine($"Grand Prize Winners: {salesReport.printOutWinners(lottery.grandPrizeWinners.ticketList)}");
                streamWriter.WriteLine($"\nFirst Prize Winners: {salesReport.printOutWinners(lottery.firstPrizeWinners.ticketList)}");
                streamWriter.WriteLine($"\nSecond Prize Winners: {salesReport.printOutWinners(lottery.secondPrizeWinners.ticketList)}");
                streamWriter.WriteLine($"\nThird Prize Winners: {salesReport.printOutWinners(lottery.thirdPrizeWinners.ticketList)}");
                streamWriter.WriteLine($"\nFourth Prize Winners: {salesReport.printOutWinners(lottery.fouthPrizeWinners.ticketList)}");
                streamWriter.WriteLine($"\nFifth Prize Winners: {salesReport.printOutWinners(lottery.fifthPrizeWinners.ticketList)}");
                streamWriter.WriteLine($"\nSixth Prize Winners: {salesReport.printOutWinners(lottery.sixthPrizeWinners.ticketList)}");
                streamWriter.WriteLine($"\nSeventh Prize Winners: {salesReport.printOutWinners(lottery.seventhPrizeWinners.ticketList)}");
                streamWriter.WriteLine($"\nEighth Prize Winners: {salesReport.printOutWinners(lottery.eighthPrizeWinners.ticketList)}");
            }
        }

        private string printOutWinners(List<Ticket> ticketList)
        {
            string returnString = "";
            foreach (Ticket ticket in ticketList)
            {
                returnString += "\n Ticket: ";
                for (int i = 0; i < 6; i++)
                {
                    if (i == 0)
                    {
                        returnString += ticket.ticketNumbers[i];
                    }
                    else
                    {
                        returnString += $", {ticket.ticketNumbers[i]}";
                    }                   
                }
            }
            return returnString;
        }
    }
}
