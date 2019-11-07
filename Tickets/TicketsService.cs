using System.Collections.Generic;
using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface ITicketsService
    {
        IEnumerable<Ticket> GetTickets();
    }

    public class TicketsService : ITicketsService
    {
        private readonly ITicketsServiceRepository _repository;

        public TicketsService(ITicketsServiceRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return this._repository.GetAvailableTickets();
        }
    }
}