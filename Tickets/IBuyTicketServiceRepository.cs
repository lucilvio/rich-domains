using System;
using System.Linq;
using Lucilvio.TicketMe.AnemicModel.Domain.Client;
using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface IBuyTicketServiceRepository
    {
        Client GetClientById(Guid clientId);
        Ticket GetTicketById(Guid ticketId);
    }

    public class BuyTicketServiceRepositoryInMemory : IBuyTicketServiceRepository
    {
        private readonly MemoryContext _context;

        public BuyTicketServiceRepositoryInMemory(MemoryContext context)
        {
            this._context = context;
        }

        public Ticket GetTicketById(Guid ticketId)
        {
            return this._context.Tickets.FirstOrDefault(t => t.Id == ticketId);
        }

        public Domain.Client.Client GetClientById(Guid clientId)
        {
            return this._context.Clients.FirstOrDefault(u => u.Id == clientId);
        }
    }
}