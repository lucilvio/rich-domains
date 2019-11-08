using System;
using System.Linq;

namespace Lucilvio.TicketMe.AnemicModel.Clients
{
    public interface IUseClientTicketService
    {
        void Use(Guid clientId, Guid ticketId);
    }

    public class UseClientTicketService : IUseClientTicketService
    {
        private readonly IUseClientTicketServiceRepository _repository;

        public UseClientTicketService(IUseClientTicketServiceRepository repository)
        {
            this._repository = repository;
        }

        public void Use(Guid clientId, Guid ticketId)
        {
            var foundClient = this._repository.GetClient(clientId);
            var foundTicket = foundClient.Tickets.FirstOrDefault(t => t.Id == ticketId);

            foundTicket.State = Domain.Ticket.TicketState.Used;
        }
    }
}