using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;
using System;
using System.Linq;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface IEnableTicketServiceRepository
    {
        Ticket GetTicketById(Guid id);
    }

    public class EnableTicketServicerepositoryInMemory : IEnableTicketServiceRepository
    {
        private readonly MemoryContext _context;

        public EnableTicketServicerepositoryInMemory(MemoryContext context)
        {
            this._context = context;
        }

        public Ticket GetTicketById(Guid id)
        {
            return this._context.Tickets.FirstOrDefault(t => t.Id == id);
        }
    }
}