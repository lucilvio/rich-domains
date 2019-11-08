using System;

namespace Lucilvio.TicketMe.AnemicModel.Domain.Client
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}