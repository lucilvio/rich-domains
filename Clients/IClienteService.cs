using System;
using System.Collections.Generic;
using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;

namespace Lucilvio.TicketMe.AnemicModel.Clients
{
    public interface IClienteService
    {
        IEnumerable<Ticket> GetTickets(Guid clientId);
    }

    public class ClientService : IClienteService
    {
        private readonly IClientServiceRepository _repository;

        public ClientService(IClientServiceRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Ticket> GetTickets(Guid clientId)
        {
            var foundClient = this._repository.GetClientById(clientId);

            return foundClient != null ? foundClient.Tickets : new List<Ticket>();
        }
    }
}