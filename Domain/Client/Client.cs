using System;
using System.Collections.Generic;

namespace Lucilvio.TicketMe.AnemicModel.Domain.Client
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }

        public User User { get; set; }

        public IList<Ticket.Ticket> Tickets { get; set; }
    }
}