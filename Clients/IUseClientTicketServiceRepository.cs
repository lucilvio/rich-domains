using System;
using System.Linq;

namespace Lucilvio.TicketMe.AnemicModel.Clients
{
    public interface IUseClientTicketServiceRepository
    {
        Domain.Client.Client GetClient(Guid clientId);
    }

    public class UseClientTicketServiceRepositoryInMemory : IUseClientTicketServiceRepository
    {
        private readonly MemoryContext _context;

        public UseClientTicketServiceRepositoryInMemory(MemoryContext context)
        {
            this._context = context;
        }

        public Domain.Client.Client GetClient(Guid clientId)
        {
            return this._context.Clients.FirstOrDefault(u => u.Id == clientId);
        }
    }
}