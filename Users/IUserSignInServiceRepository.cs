using Lucilvio.TicketMe.AnemicModel.Domain.Client;
using System.Linq;

namespace Lucilvio.TicketMe.AnemicModel.Users
{
    public interface IUserSignInServiceRepository
    {
        Client GetClientByLogin(string login);
    }

    public class UserSignInServiceRepositoryInMemory : IUserSignInServiceRepository
    {
        private readonly MemoryContext context;

        public UserSignInServiceRepositoryInMemory(MemoryContext context)
        {
            this.context = context;
        }

        public Client GetClientByLogin(string login)
        {
            return this.context.Clients.FirstOrDefault(c => c.User.Login == login);
        }
    }
}