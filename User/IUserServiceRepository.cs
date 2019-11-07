using System.Linq;

namespace Lucilvio.TicketMe.AnemicModel.User
{
    public interface IUserServiceRepository
    {
        Domain.User.User GetUserById(int userId);
    }

    public class UserServiceRepositoryInMemory : IUserServiceRepository
    {
        private readonly MemoryContext _context;

        public UserServiceRepositoryInMemory(MemoryContext context)
        {
            this._context = context;
        }

        public Domain.User.User GetUserById(int userId)
        {
            return this._context.Users.FirstOrDefault(u => u.Id == userId);
        }
    }
}