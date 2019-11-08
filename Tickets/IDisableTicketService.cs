using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;
using System;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface IDisableTicketService
    {
        void Disable(Guid id);
    }

    public class DisableTicketService : IDisableTicketService
    {
        private readonly IDisableTicketServiceRepository _repository;

        public DisableTicketService(IDisableTicketServiceRepository repository)
        {
            this._repository = repository;
        }

        public void Disable(Guid id)
        {
            var foundTicket = this._repository.GetTicketById(id);

            if (foundTicket.State != TicketState.Available)
                throw new CantDisableUnavailableTickets();

            foundTicket.State = TicketState.Disabled;
        }
    }
}