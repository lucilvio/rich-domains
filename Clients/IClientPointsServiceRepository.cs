using Lucilvio.TicketMe.AnemicModel.Domain.Client;
using System;
using System.Linq;

namespace Lucilvio.TicketMe.AnemicModel.Clients
{
    public interface IClientPointsServiceRepository
    {
        Client GetClientById(Guid clientId);
    }

    public class ClientPointsServiceRepositoryInMemory : IClientPointsServiceRepository
    {
        private readonly MemoryContext _context;

        public ClientPointsServiceRepositoryInMemory(MemoryContext context)
        {
            this._context = context;
        }

        public Client GetClientById(Guid clientId)
        {
            return this._context.Clients.FirstOrDefault(c => c.Id == clientId);
        }
    }
}