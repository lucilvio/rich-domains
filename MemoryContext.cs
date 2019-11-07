using System;
using System.Collections.Generic;
using Lucilvio.TicketMe.AnemicModel.Domain.User;
using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;

namespace Lucilvio.TicketMe
{
    public class MemoryContext
    {
        public MemoryContext()
        {
            this.Users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Points = 100,
                    Name = "Sample"
                }
            };

            this.Tickets = new List<Ticket>
            {
                new Ticket
                {
                    Title = "Sample Ticket 1",
                    Description = "This is a simple description of what is the Ticket",
                    ExpirationDate = DateTime.Now.AddDays(30),
                    State = TicketState.Available,
                    Price = 30,
                    Id = 1
                },

                new Ticket
                {
                    Title = "Sample Ticket 2",
                    Description = "This is a simple description of what is the Ticket",
                    ExpirationDate = DateTime.Now.AddDays(30),
                    State = TicketState.Available,
                    Price = 46,
                    Id = 2
                },

                new Ticket
                {
                    Title = "Sample Ticket 3",
                    Description = "This is a simple description of what is the Ticket",
                    ExpirationDate = DateTime.Now.AddDays(30),
                    State = TicketState.Available,
                    Price = 15,
                    Id = 3
                }
            };
        }

        public IList<User> Users { get; set; }
        public IList<Ticket> Tickets { get; set; }
    }
}