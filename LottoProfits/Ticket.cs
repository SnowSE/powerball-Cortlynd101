using System;

namespace LottoProfits
{
    public class Ticket
    {
        public int[] ticketNumbers { get; set; }
        public Ticket()
        {
            ticketNumbers = new int[6];
        }

        public Ticket createTicket(Ticket ticket)
        {
            ticket = ticket.createNumbers(ticket);
            ticket = ticket.createPowerBall(ticket);
            return ticket;
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
            Random random = new Random();
            int randomNumber = createNewRandom();
            for (int i = 0; i < ticketNumbers.Length; i++)
            {
                if (numberInTicketNumbers(ticket, randomNumber) != true)
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

        private bool numberInTicketNumbers(Ticket ticket, int randomNumber)
        {
            bool numberIsInTicketNumbers = false;
            foreach (int number in ticketNumbers)
            {
                if (number == randomNumber)
                {
                    numberIsInTicketNumbers = true;
                }
            }

            return numberIsInTicketNumbers;
        }

        private int createNewRandom()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 69);
            return randomNumber;
        }

        private Ticket createPowerBall(Ticket ticket)
        {
            Random random = new Random();
            ticket.ticketNumbers[5] = random.Next(1, 26);
            return ticket;
        }

        public bool checkDuplicity()
        {
            throw new NotImplementedException();
        }

        public bool checkNumberIsInRange(int p0, int p1)
        {
            throw new NotImplementedException();
        }
    }
}
