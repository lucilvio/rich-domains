using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;
using System;
using System.Linq;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface IDisableTicketServiceRepository
    {
        Ticket GetTicketById(Guid id);
    }

    public class DisableTicketServiceRepositoryInMemory : IDisableTicketServiceRepository
    {
        private readonly MemoryContext _context;

        public DisableTicketServiceRepositoryInMemory(MemoryContext context)
        {
            this._context = context;
        }
        public Ticket GetTicketById(Guid id)
        {
            return this._context.Tickets.FirstOrDefault(t => t.Id == id);
        }
    }
}