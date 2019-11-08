using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;
using System;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface ITicketDetailService
    {
        Ticket GetTicketDetails(Guid ticketId);
    }

    public class TicketDetailService : ITicketDetailService
    {
        private readonly ITicketDetailServiceRepository _ticketDetailServiceRepository;

        public TicketDetailService(ITicketDetailServiceRepository ticketDetailServiceRepository)
        {
            this._ticketDetailServiceRepository = ticketDetailServiceRepository;
        }

        public Ticket GetTicketDetails(Guid ticketId)
        {
            return this._ticketDetailServiceRepository.GetTicketById(ticketId);
        }
    }

}