using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;
using System;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface IEnableTicketService
    {
        void Enable(Guid id);
    }

    public class EnableTicketService : IEnableTicketService
    {
        private readonly IEnableTicketServiceRepository _repository;

        public EnableTicketService(IEnableTicketServiceRepository repository)
        {
            this._repository = repository;
        }

        public void Enable(Guid id)
        {
            var foundTicket = this._repository.GetTicketById(id);

            if (foundTicket.State != TicketState.Disabled)
                throw new CantEnableNonDisabledTickets();

            foundTicket.State = TicketState.Available;
        }
    }
}