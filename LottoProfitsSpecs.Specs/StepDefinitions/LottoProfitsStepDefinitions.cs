using LottoProfits;

namespace LottoProfitsSpecs.Specs.StepDefinitions
{
    [Binding]
    public sealed class LottoProfitsStepDefinitions
    {
        private readonly ScenarioContext context;
        public LottoProfitsStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }
        [Given(@"a ticket is created")]
        public void GivenATicketIsCreated()
        {
            Ticket ticket = new Ticket();
            context.Add("ticket", ticket);
        }

        [When(@"generating that ticket")]
        public void WhenGeneratingThatTicket()
        {
            Ticket ticket = context.Get<Ticket>("ticket");
            ticket = ticket.createTicket(ticket);
            context.Add("ticketCreated", ticket);
        }

        [Then(@"no two numbers should be the same")]
        public void ThenNoTwoNumbersShouldBeTheSame()
        {
            Ticket ticket = context.Get<Ticket>("ticketCreated");
            ticket.checkDuplicity().Should().Be(false);
        }

        [Then(@"all numbers should be between (.*) and (.*)")]
        public void ThenAllNumbersShouldBeBetweenAnd(int p0, int p1)
        {
            Ticket ticket = context.Get<Ticket>("ticketCreated");
            ticket.checkNumberIsInRange(p0, p1).Should().Be(true);
        }

        [Then(@"the powerball should be between (.*) and (.*)")]
        public void ThenThePowerballShouldBeBetweenAnd(int p0, int p1)
        {
            Ticket ticket = context.Get<Ticket>("ticketCreated");
            ticket.checkNumberIsInRange(p0, p1).Should().Be(true);
        }

        [Given(@"we sell (.*) Tickets")]
        public void GivenWeSellTickets(int p0)
        {
            TicketList ticketList = new TicketList();
            ticketList = ticketList.createList(p0);
            context.Add("ticketList", ticketList);
        }

        [Given(@"when calculating revenue")]
        public void GivenWhenCalculatingRevenue()
        {
            TicketList ticketList = context.Get<TicketList>("ticketList");
            ticketList.calculateRevenue();
        }

        [Then(@"it should have (.*) Tickets")]
        public void ThenItShouldHaveTickets(int p0)
        {
            TicketList ticketList = context.Get<TicketList>("ticketList");
            ticketList.ticketList.Capacity.Should().Be(p0);
        }

        [Then(@"the total revenue should be (.*)")]
        public void ThenTheTotalCostShouldBe(int p0)
        {
            TicketList ticketList = context.Get<TicketList>("ticketList");
            ticketList.totalRevenue.Should().Be(p0);
        }
    }
}