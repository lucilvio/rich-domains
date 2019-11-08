using Lucilvio.TicketMe.AnemicModel.Domain.Client;
using System.Linq;

namespace Lucilvio.TicketMe.AnemicModel.Clients
{
    public interface IRegisterNewClientServiceRepository
    {
        void AddClient(Client client);
        Client GetClientByLogin(string login);
    }

    public class RegisterNewClientServiceRepositoryInMemory : IRegisterNewClientServiceRepository
    {
        private readonly MemoryContext _context;

        public RegisterNewClientServiceRepositoryInMemory(MemoryContext context)
        {
            this._context = context;
        }

        public void AddClient(Client client)
        {
            this._context.Clients.Add(client);
        }

        public Client GetClientByLogin(string login)
        {
            return this._context.Clients.FirstOrDefault(c => c.User.Login == login);
        }
    }
}