using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Interfaces;
using Service.ViewModels.Airports;
using Service.ViewModels.Flights;
using Service.ViewModels.Planes;

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
        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var flight = await _flightService.GetByIdAsync((int)id);
            if (flight == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<FlightDetailVM>(flight);
            return View(data);



        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.planes = await _planeService.GetAllSelectedAsync();
            ViewBag.airports = await _airportService.GetAllSelectedAsync();
            var flight = await _flightService.GetByIdAsync((int)id);
            if (flight == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<FlightEditVM>(flight);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, FlightEditVM request)
        {
            ViewBag.planes = await _planeService.GetAllSelectedAsync();
            ViewBag.airports = await _airportService.GetAllSelectedAsync();
            var a = await _flightService.GetByIdAsync((int)id);


            if (!ModelState.IsValid)
            {
                return View();
            }


            if (id is null) return BadRequest();

            //if (await _categoryService.ExistExceptByIdAsync((int)id, request.Name))
            //{
            //    ModelState.AddModelError("Name", "This category already exist");
            //    return View();
            //}


            var flight = await _flightService.GetByIdAsync((int)id);

            if (flight is null) return NotFound();

            


            if (request.FlightNumber is not null)
            {
                flight.FlightNumber = request.FlightNumber;
            }
            if (request.DepartureTime !=flight.DepartureTime)
            {
                flight.DepartureTime = request.DepartureTime;
            }
            if (request.ArrivalTime != flight.ArrivalTime)
            {
                flight.ArrivalTime = request.ArrivalTime;
            }

            if (request.TicketCount != 0)
            {
                flight.TicketCount = request.TicketCount;
            }


            await _flightService.EditSaveAsync();

            return RedirectToAction(nameof(Index));


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            await _flightService.DeleteAsync((int)id);



            return RedirectToAction(nameof(Index));



        }
    }
}
