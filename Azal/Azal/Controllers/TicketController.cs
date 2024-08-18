using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Service.Services.Interfaces;
using Service.ViewModels;
using Service.ViewModels.Flights;

namespace Azal.Controllers
{
    public class TicketController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IAirportService _airportService;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TicketController(
                              IFlightService flightService,
                              IAirportService airportService,
                              AppDbContext context,
                              IMapper mapper
                              )
        {
          
            _flightService = flightService;
            _airportService = airportService;
            _context = context;
            _mapper = mapper;

        }
      
        [HttpPost]       
        public async Task<IActionResult> Search([FromBody] SearchFlightVM data)
        {
            if (data == null)
            {
                return BadRequest("Invalid search data.");
            }

            var flights = await _context.Flights.Where(m => m.ArrivalAirport.AirportCode == data.ArrivalAirportCode).ToListAsync();

            var selectedflight = _mapper.Map<List<FlightDetailVM>>(flights);


            // Əgər heç bir uçuş tapılmadısa
            if (!flights.Any())
            {
                return RedirectToAction(nameof(Index));
            }

            // Uçuşları view-ə göndəririk
           return Ok(flights);

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
