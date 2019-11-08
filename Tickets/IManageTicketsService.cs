using System.Collections.Generic;
using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public interface IManageTicketsService
    {
        IEnumerable<Ticket> GetTicketsToManage();
    }

    public class ManageTicketsService : IManageTicketsService
    {
        private readonly IManageTicketsServiceRepository _repository;

        public ManageTicketsService(IManageTicketsServiceRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Ticket> GetTicketsToManage()
        {
            return this._repository.GetTickets();
        }
    }
}