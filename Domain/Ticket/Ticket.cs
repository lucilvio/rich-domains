using System;

namespace Lucilvio.TicketMe.AnemicModel.Domain.Ticket
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public TicketState State { get; set; }
        public int Price { get; set; }
    }
}