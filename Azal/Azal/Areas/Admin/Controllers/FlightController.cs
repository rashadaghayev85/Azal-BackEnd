using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Interfaces;
using Service.ViewModels.Airports;
using Service.ViewModels.Flights;

namespace Azal.Areas.Admin.Controllers
{
    [Area("admin")]
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly ILanguageService _languageService;
        private readonly IAirportService _airportService;
        private readonly IWebHostEnvironment _env;
        private readonly IPlaneService _planeService;
        private readonly IMapper _mapper;

        public FlightController(IFlightService flightService,
                              ILanguageService languageService,
                              IPlaneService planeService,
                              IAirportService airportService,
                              IWebHostEnvironment env,
                              IMapper mapper)
        {
            _flightService = flightService;
            _languageService = languageService;
            _planeService = planeService;
            _airportService = airportService;
            _env = env;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var flights = await _flightService.GetAllAsync();
            // ViewBag.TranslateBlogTitle = await _blogTranslateService.GetAllAsync();
            return View(flights);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.planes = await _planeService.GetAllSelectedAsync();
            ViewBag.airports = await _airportService.GetAllSelectedAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlightCreateVM request)
        {
            ViewBag.planes = await _planeService.GetAllSelectedAsync();
            ViewBag.airports = await _airportService.GetAllSelectedAsync();


            await _flightService.CreateAsync(request);
            return RedirectToAction(nameof(Index));



        }
    }
}
