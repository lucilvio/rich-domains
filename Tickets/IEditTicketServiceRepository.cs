using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;
using System.Linq;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface IEditTicketServiceRepository
    {
        void EditTicket(Ticket ticket);
    }

    public class EditTicketServiceRepositoryInMemory : IEditTicketServiceRepository
    {
        private MemoryContext _context;

        public EditTicketServiceRepositoryInMemory(MemoryContext context)
        {
            _context = context;
        }

        public void EditTicket(Ticket ticket)
        {
            var foundTicket = this._context.Tickets.FirstOrDefault(t => t.Id == ticket.Id);
            foundTicket.Title = ticket.Title;
            foundTicket.Description = ticket.Description;
            foundTicket.Price = ticket.Price;
        }
    }
}