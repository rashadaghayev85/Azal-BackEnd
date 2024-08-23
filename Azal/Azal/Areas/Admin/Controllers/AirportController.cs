using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers.Extensions;
using Service.Services.Interfaces;
using Service.ViewModels.Airports;
using Service.ViewModels.Blogs;

namespace Azal.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class AirportController : Controller
    {
        private readonly IAirportService _airportService;
        private readonly ILanguageService _languageService;
        private readonly IWebHostEnvironment _env;
       
        private readonly IMapper _mapper;

        public AirportController(IAirportService airportService,
                              ILanguageService languageService,
                              IWebHostEnvironment env,
                              IMapper mapper)
        {
            _airportService = airportService;
            _languageService = languageService;
            _env = env;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var airports = await _airportService.GetAllAsync();
           // ViewBag.TranslateBlogTitle = await _blogTranslateService.GetAllAsync();
            return View(airports);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var airports = await _airportService.GetAllAsync();
            // ViewBag.TranslateBlogTitle = await _blogTranslateService.GetAllAsync();
            return Json(airports);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var airport = await _airportService.GetByIdAsync(id);
            if (airport == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<AirportDetailVM>(airport);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.languages = await _languageService.GetAllSelectedAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AirportCreateVM request)
        {
             ViewBag.languages = await _languageService.GetAllSelectedAsync();
            if (!ModelState.IsValid)
            {
                return View();
            }


            await _airportService.CreateAsync(request);
            return RedirectToAction(nameof(Index));



        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var airport = await _airportService.GetByIdAsync(id);
            if (airport == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<AirportEditVM>(airport);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, AirportEditVM request)
        {
            var a = await _airportService.GetByIdAsync((int)id);
          

            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
           

                if (id is null) return BadRequest();

                //if (await _blogService.ExistExceptByIdAsync((int)id, request.BlogTranslate.Name))
                //{
                //    ModelState.AddModelError("Name", "This blog already exist");
                //    return View();
                //}


                var airport = await _airportService.GetByIdAsync((int)id);

                if (airport is null) return NotFound();









            if (request.AirportCode is not null)
            {
                airport.AirportCode = request.AirportCode;
            }


            if (request.Location is not null)
                {
                    airport.AirportTranslates.FirstOrDefault().Location = request.Location;
                }

                await _airportService.EditSaveAsync();

                return RedirectToAction(nameof(Index));
            
           









                
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            await _airportService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
