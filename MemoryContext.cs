using System;
using System.Collections.Generic;
using Lucilvio.TicketMe.AnemicModel.Domain.Client;
using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;
using Lucilvio.TicketMe.AnemicModel.Users;

namespace Lucilvio.TicketMe
{
    public class MemoryContext
    {
        public MemoryContext(IPasswordHiding passwordHiding)
        {
            this.Clients = new List<Client>
            {
                new Client
                {
                    Id = Guid.NewGuid(),
                    Points = 100,
                    Name = "Sample",

                    User = new User
                    {
                        Login = "sample@mail.com",
                        Password = passwordHiding.Hide("123456")
                    }
                }
            };

            this.Tickets = new List<Ticket>
            {
                //new Ticket
                //{
                //    Title = "Sample Ticket 1",
                //    Description = "This is a simple description of what is the Ticket",
                //    ExpirationDate = DateTime.Now.AddDays(30),
                //    State = TicketState.Available,
                //    Price = 30,
                //    Id = 1
                //},

                //new Ticket
                //{
                //    Title = "Sample Ticket 2",
                //    Description = "This is a simple description of what is the Ticket",
                //    ExpirationDate = DateTime.Now.AddDays(30),
                //    State = TicketState.Available,
                //    Price = 46,
                //    Id = 2
                //},

                //new Ticket
                //{
                //    Title = "Sample Ticket 3",
                //    Description = "This is a simple description of what is the Ticket",
                //    ExpirationDate = DateTime.Now.AddDays(30),
                //    State = TicketState.Available,
                //    Price = 15,
                //    Id = 3
                //},

                //new Ticket
                //{
                //    Title = "Sample Ticket 4",
                //    Description = "This is a simple description of what is the Ticket",
                //    ExpirationDate = DateTime.Now.AddDays(30),
                //    State = TicketState.Available,
                //    Price = 77,
                //    Id = 4
                //},

                //new Ticket
                //{
                //    Title = "Sample Ticket 5",
                //    Description = "This is a simple description of what is the Ticket",
                //    ExpirationDate = DateTime.Now.AddDays(30),
                //    State = TicketState.Available,
                //    Price = 32,
                //    Id = 5
                //}
            };
        }   

        public IList<Client> Clients { get; set; }
        public IList<Ticket> Tickets { get; set; }
    }
}