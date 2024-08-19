using AutoMapper;
using Domain.Models;
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

            var flights = await _context.Flights
                .Include(m => m.ArrivalAirport)
                .ThenInclude(m => m.AirportTranslates
                    .Where(at => at.Location == data.ArrivalAirport))
                .Include(m => m.DepartureAirport)
                .ThenInclude(m => m.AirportTranslates
                    .Where(dt => dt.Location == data.DepartureAirport))
                .ToListAsync();

            var datas = flights.Where(m =>
                    m.DepartureTime.Year == data.DepatureDate.Year &&
                    m.DepartureTime.Month == data.DepatureDate.Month &&
                    m.DepartureTime.Day == data.DepatureDate.Day);
            if (!datas.Any())
            {
                return Ok(new List<int>());
            }

            var flightIds = datas.Select(m => m.Id).ToList();
            return Ok(flightIds);
          
        }






        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string ids)
        {
            var idList = ids?.Split(',').Select(int.Parse).ToList() ?? new List<int>();
            var flights = await _context.Flights
             .Include(m => m.ArrivalAirport)
             .Include(m => m.DepartureAirport)
            .Where(f => idList.Contains(f.Id))
             .ToListAsync();

            // Use the idList as needed
            // Example: Fetching related data based on idList

            return View(flights);
        }
    }
}
