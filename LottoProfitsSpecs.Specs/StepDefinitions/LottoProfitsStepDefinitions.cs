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

        [Given(@"ticket")]
        public void GivenTicket()
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
            ticketList.createList(p0);
            context.Add("ticketList", ticketList);
        }

        [Given(@"when calculating revenue")]
        public void GivenWhenCalculatingRevenue()
        {
            TicketList ticketList = context.Get<TicketList>("ticketList");
            context.Add("revenue", ticketList.calculateRevenue());
        }

        [Then(@"it should have (.*) Tickets")]
        public void ThenItShouldHaveTickets(int p0)
        {
            TicketList ticketList = context.Get<TicketList>("ticketList");
            ticketList.ticketList.Count.Should().Be(p0);
        }

        [Then(@"the total revenue should be (.*)")]
        public void ThenTheTotalCostShouldBe(int p0)
        {
            TicketList ticketList = context.Get<TicketList>("ticketList");
            context.Get<int>("revenue").Should().Be(p0);
        }
        [Given(@"a ticket (.*)")]
        public void GivenATicket(string s0)
        {
            Ticket staticTicket = new Ticket();
            staticTicket = staticTicket.createStaticTicket(staticTicket, s0);
            context.Add("staticTicket", staticTicket);

            TicketList ticketList = new TicketList();
            ticketList.ticketList.Add(staticTicket);
            context.Add("ticketList", ticketList);
        }

        [Given(@"a winningTicket (.*)")]
        public void GivenAWinningTicket(string s0)
        {
            WinningTicket staticWinningTicket = new WinningTicket();
            staticWinningTicket = staticWinningTicket.createStaticWinningTicket(staticWinningTicket, s0);
            context.Add("staticWinningTicket", staticWinningTicket);
        }

        [Given(@"checking for winners")]
        public void GivenCheckingForWinners()
        {
            Lottery lottery = new Lottery();
            Ticket staticTicket = context.Get<Ticket>("staticTicket");
            lottery.createWinnerLists(staticTicket, context.Get<WinningTicket>("staticWinningTicket"), lottery);
            context.Add("lottery", lottery);
        }

        [When(@"seeing how many balls matched up")]
        public void WhenSeeingHowManyBallsMatchedUp()
        {
            context.Add("ballsCorrect", context.Get<Ticket>("staticTicket").ballsCorrect);
        }

        [Then(@"if the ticket has (.*) correct")]
        public void ThenIfTheTicketHasCorrect(int p0)
        {
            context.Get<int>("ballsCorrect").Should().Be(p0);
        }

        [Then(@"the ticket will win (.*)")]
        public void ThenTheTicketWillWin(int p0)
        {
            switch (p0)
            {
                case 0:
                    context.Get<Lottery>("lottery").grandPrizeWinners.ticketList.Count.Should().Be(1);
                    break;

                case 1:
                    context.Get<Lottery>("lottery").firstPrizeWinners.ticketList.Count.Should().Be(1);
                    break;

                case 2:
                    context.Get<Lottery>("lottery").secondPrizeWinners.ticketList.Count.Should().Be(1);
                    break;

                case 3:
                    context.Get<Lottery>("lottery").thirdPrizeWinners.ticketList.Count.Should().Be(1);
                    break;

                case 4:
                    context.Get<Lottery>("lottery").fouthPrizeWinners.ticketList.Count.Should().Be(1);
                    break;

                case 5:
                    context.Get<Lottery>("lottery").fifthPrizeWinners.ticketList.Count.Should().Be(1);
                    break;

                case 6:
                    context.Get<Lottery>("lottery").sixthPrizeWinners.ticketList.Count.Should().Be(1);
                    break;

                case 7:
                    context.Get<Lottery>("lottery").seventhPrizeWinners.ticketList.Count.Should().Be(1);
                    break;

                case 8:
                    context.Get<Lottery>("lottery").eighthPrizeWinners.ticketList.Count.Should().Be(1);
                    break;

                case 9:
                    context.Get<Lottery>("lottery").loserList.ticketList.Count.Should().Be(1);
                    break;
            }
        }

        [When(@"checking for profit")]
        public void WhenCheckingForProfit()
        {
            SalesReport salesReport = new SalesReport();
            salesReport = salesReport.calculateProfit(context.Get<Lottery>("lottery"), context.Get<TicketList>("ticketList"), salesReport);
            context.Add("salesReport", salesReport);
        }

        [Then(@"the profit will be (.*)")]
        public void ThenTheProfitWillBe(int p0)
        {
            context.Get<SalesReport>("salesReport").profit.Should().Be(p0);
        }
    }
}