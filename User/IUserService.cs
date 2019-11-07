using System.Collections.Generic;
using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;

namespace Lucilvio.TicketMe.AnemicModel.User
{
    public interface IUserService
    {
        IEnumerable<Ticket> GetTickets(int userId);
    }

    public class UserService : IUserService
    {
        private readonly IUserServiceRepository _repository;

        public UserService(IUserServiceRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Ticket> GetTickets(int userId)
        {
            var foundUser = this._repository.GetUserById(userId);

            return foundUser.Tickets;
        }
    }
}