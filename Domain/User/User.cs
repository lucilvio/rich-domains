using System.Collections.Generic;

namespace Lucilvio.TicketMe.AnemicModel.Domain.User
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Points { get; set; }

        public IList<Ticket.Ticket> Tickets { get; set; }
    }
}