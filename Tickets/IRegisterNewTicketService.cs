using System;
using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface IRegisterNewTicketService
    {
        void Register(Ticket ticket);
    }

    public class RegisterNewTicketService : IRegisterNewTicketService
    {
        private readonly IRegisterNewTicketServiceRepository _repository;

        public RegisterNewTicketService(IRegisterNewTicketServiceRepository repository)
        {
            this._repository = repository;
        }

        public void Register(Ticket ticket)
        {
            ticket.Id = Guid.NewGuid();

            this._repository.AddTicket(ticket);
        }
    }
}