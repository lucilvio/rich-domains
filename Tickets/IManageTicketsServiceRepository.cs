using System.Collections.Generic;
using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface IManageTicketsServiceRepository
    {
        IEnumerable<Ticket> GetTickets();
    }

    public class ManageTicketsServiceRepositoryInMemory : IManageTicketsServiceRepository
    {
        private readonly MemoryContext _context;

        public ManageTicketsServiceRepositoryInMemory(MemoryContext context)
        {
            this._context = context;
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return this._context.Tickets;
        }
    }
}