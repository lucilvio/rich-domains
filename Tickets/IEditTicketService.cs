using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface IEditTicketService
    {
        void Edit(Ticket ticket);
    }

    public class EditTicketService : IEditTicketService
    {
        private readonly IEditTicketServiceRepository _repository;

        public EditTicketService(IEditTicketServiceRepository repository)
        {
            this._repository = repository;
        }

        public void Edit(Ticket ticket)
        {
            if (ticket.State != TicketState.Available)
                throw new CantEditTicketsThereWereBoughtOrUsed();

            this._repository.EditTicket(ticket);
        }
    }
}