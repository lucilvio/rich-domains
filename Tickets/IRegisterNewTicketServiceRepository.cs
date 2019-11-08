using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface IRegisterNewTicketServiceRepository
    {
        void AddTicket(Ticket ticket);
    }

    public class RegisterNewTicketServiceRepositoryInMemory : IRegisterNewTicketServiceRepository
    {
        private readonly MemoryContext _context;

        public RegisterNewTicketServiceRepositoryInMemory(MemoryContext context)
        {
            this._context = context;
        }

        public void AddTicket(Ticket ticket)
        {
            this._context.Tickets.Add(ticket);
        }
    }
}