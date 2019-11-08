using System;
using System.Collections.Generic;
using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface IBuyTicketService
    {
        void Buy(Guid clientId, Guid ticketId);
    }

    public class BuyTicketService : IBuyTicketService
    {
        private readonly IBuyTicketServiceRepository _repository;

        public BuyTicketService(IBuyTicketServiceRepository repository)
        {
            this._repository = repository;
        }

        public void Buy(Guid clientId, Guid ticketId)
        {
            var foundClient = this._repository.GetClientById(clientId);
            var foundTicket = this._repository.GetTicketById(ticketId);

            if (foundClient.Points < foundTicket.Price)
                throw new Exception("The client has no sufficient points to buy this ticket");

            foundClient.Points -= foundTicket.Price;
            foundTicket.State = TicketState.Sold;

            if (foundClient.Tickets == null)
                foundClient.Tickets = new List<Ticket>();

            foundClient.Tickets.Add(foundTicket);
        }
    }
}