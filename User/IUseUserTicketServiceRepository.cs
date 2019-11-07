using Lucilvio.TicketMe.AnemicModel.Domain.User;
using System.Linq;

namespace Lucilvio.TicketMe.AnemicModel.User
{
    public interface IUseUserTicketServiceRepository
    {
        Domain.User.User GetUser(int userId);
    }

    public class UseUserTicketServiceRepositoryInMemory : IUseUserTicketServiceRepository
    {
        private readonly MemoryContext _context;

        public UseUserTicketServiceRepositoryInMemory(MemoryContext context)
        {
            this._context = context;
        }

        public Domain.User.User GetUser(int userId)
        {
            return this._context.Users.FirstOrDefault(u => u.Id == userId);
        }
    }
}