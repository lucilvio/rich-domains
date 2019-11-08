using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;
using System;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public class TicketsController : Controller
    {
        private readonly ITicketsService _ticketsService;
        private readonly ITicketDetailService _ticketDetailService;
        private readonly IBuyTicketService _buyTicketService;
        private readonly IRegisterNewTicketService _registerNewTicketService;
        private readonly IManageTicketsService _manageTicketsService;
        private readonly IEditTicketService _editTicketService;
        private readonly IDisableTicketService _disableTicketService;
        private readonly IEnableTicketService _enableTicketService;

        public TicketsController(ITicketsService myTicketsService, ITicketDetailService ticketDetailService, 
            IBuyTicketService buyTicketService, IRegisterNewTicketService registerNewTicketService, IManageTicketsService manageTicketsService,
            IEditTicketService editTicketService, IDisableTicketService disableTicketService, IEnableTicketService enableTicketService)
        {
            this._ticketsService = myTicketsService;
            this._ticketDetailService = ticketDetailService;
            this._buyTicketService = buyTicketService;
            this._registerNewTicketService = registerNewTicketService;
            this._manageTicketsService = manageTicketsService;
            this._editTicketService = editTicketService;
            this._disableTicketService = disableTicketService;
            this._enableTicketService = enableTicketService;
        }

        [HttpGet]
        public IActionResult Tickets()
        {
            var model = new TicketsViewModel();
            model.TicketList = this._ticketsService.GetTickets();

            return View(model);
        }

        [HttpGet]
        public IActionResult ManageTickets()
        {
            var model = new TicketsViewModel();
            model.TicketList = this._manageTicketsService.GetTicketsToManage();

            return View(model);
        }

        [HttpGet]
        public IActionResult EditTicket(Guid id)
        {
            var foundTicket = this._ticketDetailService.GetTicketDetails(id);
            return View(foundTicket);
        }

        [HttpPost]
        public IActionResult EditTicket(Ticket ticket)
        {
            this._editTicketService.Edit(ticket);

            return RedirectToAction(nameof(ManageTickets));
        }

        [HttpGet]
        public IActionResult DisableTicket(Guid id)
        {
            this._disableTicketService.Disable(id);

            return RedirectToAction(nameof(ManageTickets));
        }

        [HttpGet]
        public IActionResult EnableTicket(Guid id)
        {
            this._enableTicketService.Enable(id);

            return RedirectToAction(nameof(ManageTickets));
        }

        [HttpGet]
        public IActionResult NewTicket()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterNewTicket(Ticket ticket)
        {
            this._registerNewTicketService.Register(ticket);

            return RedirectToAction(nameof(ManageTickets));
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var ticket = this._ticketDetailService.GetTicketDetails(id);

            return View(ticket);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Buy([FromForm]Guid id)
        {
            var clientId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            this._buyTicketService.Buy(clientId, id);

            return RedirectToAction(nameof(Tickets));
        }
    }
}
