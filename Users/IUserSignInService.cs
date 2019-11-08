using Lucilvio.TicketMe.AnemicModel.Domain.Client;

namespace Lucilvio.TicketMe.AnemicModel.Users
{
    public interface IUserSignInService
    {
        Client SignIn(string login, string password);
    }

    public class UserSignInService : IUserSignInService
    {
        private readonly IPasswordHiding _passwordHider;
        private readonly IUserSignInServiceRepository _repository;

        public UserSignInService(IUserSignInServiceRepository repository, IPasswordHiding passwordHasher)
        {
            this._repository = repository;
            this._passwordHider = passwordHasher;
        }

        public Client SignIn(string login, string password)
        {
            var client = this._repository.GetClientByLogin(login);

            if (client == null)
                throw new WrongUserOrPassword();

            var hiddenPassword = this._passwordHider.Hide(password);

            if(client.User.Password != hiddenPassword)
                throw new WrongUserOrPassword();

            return client;
        }
    }
}