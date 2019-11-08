using System;
using Lucilvio.TicketMe.AnemicModel.Users;
using Lucilvio.TicketMe.AnemicModel.Domain.Client;

namespace Lucilvio.TicketMe.AnemicModel.Clients
{
    public interface IRegisterNewClientService
    {
        void Register(Client client);
    }

    public class RegisterNewClientService : IRegisterNewClientService
    {
        private readonly IPasswordHiding _passwordHiding;
        private readonly IRegisterNewClientServiceRepository _repository;

        public RegisterNewClientService(IRegisterNewClientServiceRepository repository, IPasswordHiding passwordHiding)
        {
            this._repository = repository;
            this._passwordHiding = passwordHiding;
        }

        public void Register(Client client)
        {
            var foundClientWithSameLogin = this._repository.GetClientByLogin(client.User.Login);

            if (foundClientWithSameLogin != null)
                throw new EmailAlreadyInUse();

            client.Id = Guid.NewGuid();
            client.Points = 100;
            client.User.Password = this._passwordHiding.Hide(client.User.Password);

            this._repository.AddClient(client);
        }
    }
}