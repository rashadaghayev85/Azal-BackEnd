using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using Service.ViewModels.Banners;
using Service.Helpers.Extensions;
using Domain.Models;
using Service.Services;

namespace Azal.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly IWebHostEnvironment _env;
        public BannerController(IBannerService bannerService,

                                   IWebHostEnvironment env)
        {
            _bannerService = bannerService;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _bannerService.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BannerCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!request.Image.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "Input can accept only image format");
                return View();
            }
            if (!request.Image.CheckFileSize(200))
            {
                ModelState.AddModelError("Image", "Image size must be max 200 KB ");
                return View();
            }
            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;

            // return Content(fileName);

            string path = Path.Combine(_env.WebRootPath, "assets", "img", fileName);

            await request.Image.SaveFileToLocalAsync(path);


          
           await _bannerService.CreateAsync(request);
                
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {

            Banner banner = await _bannerService.GetByIdAsync((int)id);
            var data = banner;
            return View(banner);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();
            var about = await _bannerService.GetByIdAsync((int)id);
            if (about == null) return NotFound();
            //return View();
            return View(new BannerEditVM { Image = about.Image });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, BannerEditVM request)
        {
            if (id == null) return BadRequest();
            var banner = await _bannerService.GetByIdAsync((int)id);
            if (banner == null) return NotFound();
            if (request.NewImage is null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!request.NewImage.CheckFileType("image/"))
            {
                ModelState.AddModelError("NewImage", "Input can accept only image format");
                request.Image = banner.Image;
                return View(request);

            }
            if (!request.NewImage.CheckFileSize(200))
            {
                ModelState.AddModelError("NewImage", "Image size must be max 200 KB ");
                request.Image = banner.Image;
                return View(request);
            }
            string oldPath = _env.GenerateFilePath("img", banner.Image);
            oldPath.DeleteFileFromLocal();
            string fileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;
            string newPath = _env.GenerateFilePath("img", fileName);

            await request.NewImage.SaveFileToLocalAsync(newPath);
           
            if (fileName is not null)
            {
                banner.Image = fileName;
            }

            await _bannerService.EditAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id,string filename)
        {
            var data=await _bannerService.GetByIdAsync(id);

            string path = filename;

            path.DeleteFileFromLocal();

           
            await _bannerService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
