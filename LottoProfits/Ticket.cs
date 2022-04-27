using System;
using System.Collections.Generic;

namespace LottoProfits
{
    public class Ticket
    {
        public int[] ticketNumbers { get; set; }
        public int ballsCorrect;
        public Ticket()
        {
            ticketNumbers = new int[6];
            ballsCorrect = 0;
        }

        public Ticket createTicket(Ticket ticket)
        {
            ticket = ticket.createNumbers(ticket);
            ticket = ticket.createPowerBall(ticket);
            //ticket = ticket.sortTicket(ticket);
            //checkDuplicity();
            return ticket;
        }

        private Ticket sortTicket(Ticket ticket) //This might be useful later as the tickets numbers are now sorted smallest to largest (except the powerball, that is still last).
        {
            List<int> toBeSorted = addTicketNumbersToSort();
            toBeSorted.Sort();
            ticket = ticket.setTicketToSortedListNumbers(ticket, toBeSorted);
            return ticket;
        }

        private Ticket setTicketToSortedListNumbers(Ticket ticket, List<int> toBeSorted)
        {
            for (int i = 0; i < 5; i++)
            {
                ticket.ticketNumbers[i] = toBeSorted[i];
            }
            return ticket;
        }

        private List<int> addTicketNumbersToSort()
        {
            List<int> toBeSorted = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                toBeSorted.Add(ticketNumbers[i]);
            }
            return toBeSorted;
        }

        public void printOutTicket()
        {
            for(int i = 0; i < ticketNumbers.Length; i++)
            {
                if (i < 5)
                    Console.Write(ticketNumbers[i] + " --> ");
                else
                    Console.Write(ticketNumbers[i]);
            }
        }

        private Ticket createNumbers(Ticket ticket)
        {
            int randomNumber = createNewRandom();
            for (int i = 0; i < ticketNumbers.Length; i++)
            {
                if (numberInTicketNumbers(randomNumber, ticket.ticketNumbers) != true)
                {
                    ticket.ticketNumbers[i] = randomNumber;
                }
                else
                {
                    randomNumber = createNewRandom();
                    i--; //Repeat the loop if a number isn't added.
                }
            }
            return ticket;
        }

        private bool numberInTicketNumbers(int numberToCheck, int[] ticketNumbers)
        {
            foreach (int number in ticketNumbers)
            {
                if (number == numberToCheck)
                {
                    return true;
                }
            }
            return false;
        }

        public Ticket createStaticTicket(Ticket ticket, string s0)
        {
            string[] characters = s0.Split('_');
            for(int i = 0; i < ticket.ticketNumbers.Length; i++)
            {
                ticket.ticketNumbers[i] = Int32.Parse(characters[i]);
            }
            return ticket;
        }

        private int createNewRandom()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 70);
            return randomNumber;
        }

        private Ticket createPowerBall(Ticket ticket)
        {
            Random random = new Random();
            ticket.ticketNumbers[5] = random.Next(1, 27);
            return ticket;
        }

        public bool checkDuplicity()
        {
            foreach (int number in ticketNumbers)
            {
                for (int i = 0; i < ticketNumbers.Length; i++)
                    if (number == ticketNumbers[i])
                    {
                        return false;
                    }
            }
            return true;
        }

        public bool checkNumberIsInRange(int p0, int p1)
        {
            foreach (int number in ticketNumbers)
            {
                if (number > p0 && number < p1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
