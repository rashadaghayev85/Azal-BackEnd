using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using Service.ViewModels.Passengers;
using Service.ViewModels.Planes;
using Service.ViewModels.Tickets;

namespace Azal.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PassengerController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly IPassengerService _passengerService;
        private readonly IMapper _mapper;

        public PassengerController(IPassengerService passengerService,
                              IWebHostEnvironment env,
                              IMapper mapper)
        {
            _passengerService = passengerService;
            _env = env;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var passengers = await _passengerService.GetAllAsync();
            return View(passengers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PassengerCreateVM request)
        {


            await _passengerService.CreateAsync(request);
            return RedirectToAction(nameof(Index));



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            await _passengerService.DeleteAsync((int)id);



            return RedirectToAction(nameof(Index));



        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var plane = await _passengerService.GetByIdAsync((int)id);
            if (plane == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<PassengerDetailVM>(plane);
            return View(data);



        }



        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var passenger = await _passengerService.GetByIdAsync((int)id);
            if (passenger == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<PassengerEditVM>(passenger);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, PassengerEditVM request)
        {
            var a = await _passengerService.GetByIdAsync((int)id);


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


            var passenger = await _passengerService.GetByIdAsync((int)id);

            if (passenger is null) return NotFound();

            //if (category.Name == request.Name)
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //category.Name = request.Name;














            if (request.Name is not null)
            {
                passenger.Name = request.Name;
            }
            if (request.Surname is not null)
            {
                passenger.Surname = request.Surname;
            }
           



            await _passengerService.EditSaveAsync();

            return RedirectToAction(nameof(Index));


        }
    }
}
