using Microsoft.AspNetCore.Mvc;

namespace Lucilvio.TicketMe.AnemicModel.Tickets
{
    public class TicketsController : Controller
    {
        private readonly ITicketsService _ticketsService;
        private readonly ITicketDetailService _ticketDetailService;
        private readonly IBuyTicketService _buyTicketService;

        public TicketsController(ITicketsService myTicketsService, ITicketDetailService ticketDetailService, IBuyTicketService buyTicketService)
        {
            this._ticketsService = myTicketsService;
            this._ticketDetailService = ticketDetailService;
            this._buyTicketService = buyTicketService;
        }

        [HttpGet]
        public IActionResult Tickets()
        {
            var model = new TicketsViewModel();
            model.TicketList = this._ticketsService.GetTickets();

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var ticket = this._ticketDetailService.GetTicketDetails(id);

            return View(ticket);
        }

        [HttpPost]
        public IActionResult Buy([FromForm]int id)
        {
            this._buyTicketService.Buy(1, id);

            return RedirectToAction(nameof(Tickets));
        }
    }
}
