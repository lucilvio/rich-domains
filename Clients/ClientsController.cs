using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Lucilvio.TicketMe.AnemicModel.Domain.Ticket;
using Lucilvio.TicketMe.AnemicModel.Clients.MyTickets;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Lucilvio.TicketMe.AnemicModel.Domain.Client;
using System;

namespace Lucilvio.TicketMe.AnemicModel.Clients
{
    public class ClientsController : Controller
    {
        private readonly IClienteService _clientService;
        private readonly IClientPointsService _clientePointsService;
        private readonly IRegisterNewClientService _registerNewClientService;
        private readonly IUseClientTicketService _useClientTicketService;

        public ClientsController(IClienteService clientService, IUseClientTicketService useClientTicketService, 
            IClientPointsService clientPoinsService, IRegisterNewClientService registerNewClientService)
        {
            this._clientService = clientService;
            this._clientePointsService = clientPoinsService;
            this._registerNewClientService = registerNewClientService;
            this._useClientTicketService = useClientTicketService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult MyTickets()
        {
            var clientId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var clientTickets = this._clientService.GetTickets(clientId);

            if (clientTickets == null)
                clientTickets = new List<Ticket>();

            return View(new MyTicketsViewModel
            {
                TicketsList = clientTickets.ToList()
            });
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterNewClient([FromForm]Client client)
        {
            this._registerNewClientService.Register(client);
            return RedirectToAction("Tickets", "Tickets");
        }

        [HttpPost]
        [Authorize]
        public IActionResult UseTicket([FromForm]Guid ticketId)
        {
            var clientId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            this._useClientTicketService.Use(clientId, ticketId);

            return RedirectToAction(nameof(MyTickets));
        }

        [HttpGet]
        [Authorize]
        public JsonResult Points()
        {
            var clientId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var points = this._clientePointsService.GetPoints(clientId);

            return new JsonResult(new { points });
        }
    }
}
