using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Services;
using Service.Services.Interfaces;
using Service.ViewModels.Flights;
using Service.ViewModels.Planes;

namespace Azal.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PlaneController : Controller
    {
        
        private readonly IWebHostEnvironment _env;
        private readonly IPlaneService _planeService;
        private readonly IMapper _mapper;

        public PlaneController(IPlaneService planeService,
                              IWebHostEnvironment env,
                              IMapper mapper)
        {
            _planeService = planeService;
            _env = env;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var planes = await _planeService.GetAllAsync();
            return View(planes);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlaneCreateVM request)
        {
            

            await _planeService.CreateAsync(request);
            return RedirectToAction(nameof(Index));



        }
    }
}
