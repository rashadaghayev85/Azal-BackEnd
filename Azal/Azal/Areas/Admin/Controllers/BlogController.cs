using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Helpers.Extensions;
using Service.Services.Interfaces;
using Service.ViewModels.Blogs;

namespace Azal.Areas.Admin.Controllers
{
    [Area("admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ILanguageService _languageService;
        private readonly IWebHostEnvironment _env;

        public BlogController(IBlogService blogService, 
                              ILanguageService languageService,
                              IWebHostEnvironment env)
        {
            _blogService = blogService;
            _languageService = languageService;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAllAsync();
            return View(blogs);
        }

        public async Task<IActionResult> Details(int id, string culture)
        {
            var blog = await _blogService.GetByIdAsync(id, culture);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.languages = await _languageService.GetAllSelectedAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogCreateVM request)
        {
            ViewBag.languages = await _languageService.GetAllSelectedAsync();

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

            await _blogService.CreateAsync(request);
            return RedirectToAction(nameof(Index));



        }

        public async Task<IActionResult> Edit(int id, string culture)
        {
            var blog = await _blogService.GetByIdAsync(id, culture);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, string name, string description, string culture)
        {
            await _blogService.EditAsync(id, name, description, culture);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _blogService.GetByIdAsync(id, "en-US");  // Default culture
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _blogService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
