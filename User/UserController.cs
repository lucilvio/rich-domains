using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;
using Lucilvio.TicketMe.AnemicModel.User.MyTickets;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucilvio.TicketMe.AnemicModel.User
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUseUserTicketService _useUserTicketService;

        public UserController(IUserService userService, IUseUserTicketService useUserTicketService)
        {
            this._userService = userService;
            this._useUserTicketService = useUserTicketService;
        }

        public IActionResult MyTickets()
        {
            var userTickets = this._userService.GetTickets(1);

            if (userTickets == null)
                userTickets = new List<Ticket>();

            return View(new MyTicketsViewModel
            {
                TicketsList = userTickets.ToList()
            });
        }

        [HttpPost]
        public IActionResult UseTicket([FromForm]int id)
        {
            this._useUserTicketService.Use(1, id);

            return RedirectToAction(nameof(MyTickets));
        }
    }
}
