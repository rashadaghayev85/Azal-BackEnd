using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using Service.ViewModels.Airports;
using Service.ViewModels.Flights;
using Service.ViewModels.Planes;

namespace Azal.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
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
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _planeService.CreateAsync(request);
            return RedirectToAction(nameof(Index));



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();
           
            await _planeService.DeleteAsync((int)id);



            return RedirectToAction(nameof(Index));



        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var plane = await _planeService.GetByIdAsync((int)id);
            if (plane == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<PlaneDetailVM>(plane);
            return View(data);

           
           
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var plane = await _planeService.GetByIdAsync((int)id);
            if (plane == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<PlaneEditVM>(plane);
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, PlaneEditVM request)
        {
            var a = await _planeService.GetByIdAsync((int)id);
           

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


                var plane = await _planeService.GetByIdAsync((int)id);

                if (plane is null) return NotFound();

                //if (category.Name == request.Name)
                //{
                //    return RedirectToAction(nameof(Index));
                //}
                //category.Name = request.Name;



                

                   



              




                if (request.Model is not null)
                {
                    plane.Model = request.Model;
                }
            if (request.Capacity !=0)
            {
                plane.Capacity = request.Capacity;
            }



            await _planeService.EditSaveAsync();

                return RedirectToAction(nameof(Index));
          
            
        }
    }
}
