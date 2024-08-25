using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Interfaces;
using Service.ViewModels.Planes;
using Service.ViewModels.Tickets;

namespace Azal.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class TicketController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ITicketService _ticketService;
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;

        public TicketController(ITicketService ticketService,
                              IWebHostEnvironment env,
                              IMapper mapper,
                              IFlightService flightService)
        {
            _ticketService = ticketService;
            _env = env;
            _mapper = mapper;
            _flightService = flightService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tickets = await _ticketService.GetAllAsync();
            return View(tickets);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.flights = await _flightService.GetAllSelectedAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TicketCreateVM request)
        {
            ViewBag.flights = await _flightService.GetAllSelectedAsync();

            if(request.Flight == 0)
            {
                ModelState.AddModelError("Flight", "Input can't be empty");
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _ticketService.CreateAsync(request,1);
          


            return RedirectToAction(nameof(Index));
        }
    }
}
