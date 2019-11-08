using System;
using System.Linq;

namespace Lucilvio.TicketMe.AnemicModel.Clients
{
    public interface IClientServiceRepository
    {
        Domain.Client.Client GetClientById(Guid clientId);
    }

    public class ClientServiceRepositoryInMemory : IClientServiceRepository
    {
        private readonly MemoryContext _context;

        public ClientServiceRepositoryInMemory(MemoryContext context)
        {
            this._context = context;
        }

        public Domain.Client.Client GetClientById(Guid clientId)
        {
            return this._context.Clients.FirstOrDefault(u => u.Id == clientId);
        }
    }
}