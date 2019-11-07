using System.Linq;

namespace Lucilvio.TicketMe.AnemicModel.User
{
    public interface IUseUserTicketService
    {
        void Use(int userId, int ticketId);
    }

    public class UseUserticketService : IUseUserTicketService
    {
        private readonly IUseUserTicketServiceRepository _repository;

        public UseUserticketService(IUseUserTicketServiceRepository repository)
        {
            this._repository = repository;
        }

        public void Use(int userId, int ticketId)
        {
            var foundUser = this._repository.GetUser(userId);
            var foundTicket = foundUser.Tickets.FirstOrDefault(t => t.Id == ticketId);

            foundTicket.State = Domain.Ticket.TicketState.Used;
        }
    }
}