using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using Service.ViewModels.Blogs;
using Service.ViewModels.SpecialOffers;

namespace Azal.Areas.Admin.Controllers
{
    [Area("admin")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOffersService _specialOffersService;
        private readonly ILanguageService _languageService;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public SpecialOfferController(ISpecialOffersService specialOffersService,
                              ILanguageService languageService,
                              IWebHostEnvironment env,
                              IBlogTranslateService blogTranslateService,
                              IMapper mapper)
        {
            _specialOffersService = specialOffersService;
            _languageService = languageService;
            _env = env;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var specialOffers = await _specialOffersService.GetAllAsync();
            //ViewBag.TranslateBlogTitle = await _blogTranslateService.GetAllAsync();
            return View(specialOffers);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.languages = await _languageService.GetAllSelectedAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpecialOfferCreateVM request)
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

            ViewBag.FileName = fileName;
            await _specialOffersService.CreateAsync(request);
            return RedirectToAction(nameof(Index));



        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var specialOffer = await _specialOffersService.GetByIdAsync(id);
            if (specialOffer == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<SpecialOfferEditVM>(specialOffer);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, SpecialOfferEditVM request)
        {
            var a = await _specialOffersService.GetByIdAsync((int)id);
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


                var specialOffer = await _specialOffersService.GetByIdAsync((int)id);

                if (specialOffer is null) return NotFound();




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





                    specialOffer.Image = newfileName;



                }





                if (request.Name is not null)
                {
                    specialOffer.SpecialOffersTransLates.FirstOrDefault().Name = request.Name;
                }
                if (request.Title is not null)
                {
                    specialOffer.SpecialOffersTransLates.FirstOrDefault().Title = request.Title;
                }
                if (request.Description is not null)
                {
                    specialOffer.SpecialOffersTransLates.FirstOrDefault().Description = request.Description;
                }

                await _specialOffersService.EditSaveAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {









                var specialOffer = await _specialOffersService.GetByIdAsync((int)id);

                if (specialOffer is null) return NotFound();









                if (request.Name is not null)
                {
                    specialOffer.SpecialOffersTransLates.FirstOrDefault().Name = request.Name;
                }
                if (request.Title is not null)
                {
                    specialOffer.SpecialOffersTransLates.FirstOrDefault().Title = request.Title;
                }
                if (request.Description is not null)
                {
                    specialOffer.SpecialOffersTransLates.FirstOrDefault().Description = request.Description;
                }
                await _specialOffersService.EditSaveAsync();
                return RedirectToAction(nameof(Index));
            }
            //await _blogService.EditAsync(id, request);
            //return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            await _specialOffersService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsActive(int id)
        {

            var data=await _specialOffersService.GetByIdAsync(id);
            if(data.IsActive==true)
            {
                data.IsActive = false;
                await _specialOffersService.EditSaveAsync();
            }
            else
            {
                data.IsActive = true;
               await _specialOffersService.EditSaveAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
