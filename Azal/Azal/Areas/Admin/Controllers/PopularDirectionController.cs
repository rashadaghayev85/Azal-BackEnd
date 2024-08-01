using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using Service.ViewModels.PopularDirections;
using Service.ViewModels.SpecialOffers;

namespace Azal.Areas.Admin.Controllers
{
    [Area("admin")]
    public class PopularDirectionController : Controller
    {
        private readonly IPopularDirectionService _popularDirectionService;
        private readonly ILanguageService _languageService;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public PopularDirectionController(IPopularDirectionService popularDirectionService,
                              ILanguageService languageService,
                              IWebHostEnvironment env,
                              IBlogTranslateService blogTranslateService,
                              IMapper mapper)
        {
            _popularDirectionService = popularDirectionService;
            _languageService = languageService;
            _env = env;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var popularDirections = await _popularDirectionService.GetAllAsync();
            return View(popularDirections);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.languages = await _languageService.GetAllSelectedAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PopularDirectionCreateVM request)
        {
            ViewBag.languages = await _languageService.GetAllSelectedAsync();

            if (!request.Image.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "Input can accept only image format");
                return View();
            }
            if (!request.Image.CheckFileSize(500))
            {
                ModelState.AddModelError("Image", "Image size must be max 500 KB ");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;

            // return Content(fileName);

            string path = Path.Combine(_env.WebRootPath, "assets", "img", fileName);
            await request.Image.SaveFileToLocalAsync(path);

            await _popularDirectionService.CreateAsync(request);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var popularDirection = await _popularDirectionService.GetByIdAsync(id);
            if (popularDirection == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<PopularDirectionEditVM>(popularDirection);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, PopularDirectionEditVM request)
        {
            var a = await _popularDirectionService.GetByIdAsync((int)id);
            request.Image = a.Image;

            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            if (request.NewImage is not null)
            {

                if (id is null) return BadRequest();

                //if (await _blogService.ExistExceptByIdAsync((int)id, request.BlogTranslate.Name))
                //{
                //    ModelState.AddModelError("Name", "This blog already exist");
                //    return View();
                //}


                var popularDirection = await _popularDirectionService.GetByIdAsync((int)id);

                if (popularDirection is null) return NotFound();




                if (request.NewImage is not null)
                {


                    if (!request.NewImage.CheckFileType("image/"))
                    {
                        ModelState.AddModelError("NewImages", "Input can accept only image format");
                        return View(request);

                    }
                    if (!request.NewImage.CheckFileSize(500))
                    {
                        ModelState.AddModelError("NewImages", "Image size must be max 500 KB ");
                        return View(request);
                    }
                    string oldPath = _env.GenerateFilePath("assets/img", request.Image);
                    oldPath.DeleteFileFromLocal();
                    string newfileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;
                    string newPath = _env.GenerateFilePath("assets/img", newfileName);

                    await request.NewImage.SaveFileToLocalAsync(newPath);





                    popularDirection.Image = newfileName;



                }





                if (request.City is not null)
                {
                    popularDirection.PopularDirectionTranslates.FirstOrDefault().City = request.City;
                }
                if (request.Country is not null)
                {
                    popularDirection.PopularDirectionTranslates.FirstOrDefault().Country = request.Country;
                }
                if (request.Price_azn !=0)
                {
                    popularDirection.Price_azn = request.Price_azn;
                }
                if (request.Price_usd != 0)
                {
                    popularDirection.Price_usd = request.Price_usd;
                }
                await _popularDirectionService.EditSaveAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {









                var popularDirection = await _popularDirectionService.GetByIdAsync((int)id);

                if (popularDirection is null) return NotFound();









                if (request.Country is not null)
                {
                    popularDirection.PopularDirectionTranslates.FirstOrDefault().Country = request.Country;
                }
                if (request.City is not null)
                {
                    popularDirection.PopularDirectionTranslates.FirstOrDefault().City = request.City;
                }
                if (request.Price_azn != 0)
                {
                    popularDirection.Price_azn = request.Price_azn;
                }
                if (request.Price_usd != 0)
                {
                    popularDirection.Price_usd = request.Price_usd;
                }
                await _popularDirectionService.EditSaveAsync();
                return RedirectToAction(nameof(Index));
            }
            //await _blogService.EditAsync(id, request);
            //return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            await _popularDirectionService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
