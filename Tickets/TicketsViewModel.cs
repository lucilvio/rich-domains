using System.Collections.Generic;
using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public class TicketsViewModel
    {
        public IEnumerable<Ticket> TicketList { get; set; }
    }
}
