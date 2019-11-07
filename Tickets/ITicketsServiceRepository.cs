using System.Collections.Generic;
using System.Linq;
using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface ITicketsServiceRepository
    {
        IEnumerable<Ticket> GetAvailableTickets();
    }

    public class TicketsServiceRepositoryInMemory : ITicketsServiceRepository
    {
        private readonly MemoryContext _memoryContext;

        public TicketsServiceRepositoryInMemory(MemoryContext memoryContext)
        {
            this._memoryContext = memoryContext;
        }

        public IEnumerable<Ticket> GetAvailableTickets()
        {
            return this._memoryContext.Tickets.Where(t => t.State == TicketState.Available);
        }
    }
}