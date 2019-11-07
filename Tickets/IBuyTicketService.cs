using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;
using System;
using System.Collections.Generic;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface IBuyTicketService
    {
        void Buy(int userId, int ticketId);
    }

    public class BuyTicketService : IBuyTicketService
    {
        private readonly IBuyTicketServiceRepository _repository;

        public BuyTicketService(IBuyTicketServiceRepository repository)
        {
            this._repository = repository;
        }

        public void Buy(int userId, int ticketId)
        {
            var foundUser = this._repository.GetUserById(userId);
            var foundTicket = this._repository.GetTicketById(ticketId);

            if (foundUser.Points < foundTicket.Price)
                throw new Exception("User has no sufficient points to buy this ticket");

            foundUser.Points -= foundTicket.Price;
            foundTicket.State = Domain.Ticket.TicketState.Sold;

            if (foundUser.Tickets == null)
                foundUser.Tickets = new List<Ticket>();

            foundUser.Tickets.Add(foundTicket);
        }
    }
}