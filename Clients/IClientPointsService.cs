using System;

namespace Lucilvio.TicketMe.AnemicModel.Clients
{
    public interface IClientPointsService
    {
        int GetPoints(Guid clientId);
    }

    public class ClientPointsService : IClientPointsService
    {
        private readonly IClientPointsServiceRepository _repository;

        public ClientPointsService(IClientPointsServiceRepository repository)
        {
            this._repository = repository;
        }

        public int GetPoints(Guid clientId)
        {
            var client = this._repository.GetClientById(clientId);
            return client != null ? client.Points : 0;
        }
    }
}