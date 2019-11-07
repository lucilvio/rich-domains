using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;
using System.Linq;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface ITicketDetailServiceRepository
    {
        Ticket GetTicketById(int id);
    }

    public class TicketDetailServiceDetailRepositoryInMemory : ITicketDetailServiceRepository
    {
        private readonly MemoryContext _context;

        public TicketDetailServiceDetailRepositoryInMemory(MemoryContext context)
        {
            this._context = context;
        }

        public Ticket GetTicketById(int id)
        {
            return this._context.Tickets.FirstOrDefault(t => t.Id == id);
        }
    }
}