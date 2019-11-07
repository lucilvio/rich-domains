using System.Linq;
using Lucilvio.TicketMe.AnemicModel.Domain.User;
using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface IBuyTicketServiceRepository
    {
        Domain.User.User GetUserById(int userId);
        Ticket GetTicketById(int ticketId);
    }

    public class BuyTicketServiceRepositoryInMemory : IBuyTicketServiceRepository
    {
        private readonly MemoryContext _context;

        public BuyTicketServiceRepositoryInMemory(MemoryContext context)
        {
            this._context = context;
        }

        public Ticket GetTicketById(int ticketId)
        {
            return this._context.Tickets.FirstOrDefault(t => t.Id == ticketId);
        }

        public Domain.User.User GetUserById(int userId)
        {
            return this._context.Users.FirstOrDefault(u => u.Id == userId);
        }
    }
}