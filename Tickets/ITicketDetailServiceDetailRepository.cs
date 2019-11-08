using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;
using System;
using System.Linq;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface ITicketDetailServiceRepository
    {
        Ticket GetTicketById(Guid ticketId);
    }

    public class TicketDetailServiceDetailRepositoryInMemory : ITicketDetailServiceRepository
    {
        private readonly MemoryContext _context;

        public TicketDetailServiceDetailRepositoryInMemory(MemoryContext context)
        {
            this._context = context;
        }

        public Ticket GetTicketById(Guid ticketId)
        {
            return this._context.Tickets.FirstOrDefault(t => t.Id == ticketId);
        }
    }
}