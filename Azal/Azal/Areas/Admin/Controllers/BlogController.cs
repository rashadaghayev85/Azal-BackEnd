using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Helpers.Extensions;
using Service.Services;
using Service.Services.Interfaces;
using Service.ViewModels.Blogs;

namespace Azal.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "SuperAdmin,Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ILanguageService _languageService;
        private readonly IWebHostEnvironment _env;
        private readonly IBlogTranslateService _blogTranslateService;
        private readonly IMapper _mapper;

        public BlogController(IBlogService blogService, 
                              ILanguageService languageService,
                              IWebHostEnvironment env,
                              IBlogTranslateService blogTranslateService,
                              IMapper mapper)
        {
            _blogService = blogService;
            _languageService = languageService;
            _env = env;
            _blogTranslateService = blogTranslateService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAllAsync();
            ViewBag.TranslateBlogTitle = await _blogTranslateService.GetAllAsync();
            return View(blogs);
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
           var data= _mapper.Map<BlogDetailVM>(blog);
            return View(data);
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
           
           







            //string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;

            //// return Content(fileName);

            //string path = Path.Combine(_env.WebRootPath, "assets", "img", fileName);
            //await request.Image.SaveFileToLocalAsync(path);

            await _blogService.CreateAsync(request);
            return RedirectToAction(nameof(Index));



        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            var data=_mapper.Map<BlogEditVM>(blog);
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id,BlogEditVM  request)
        {
            var a = await _blogService.GetByIdAsync((int)id);
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


                var blog = await _blogService.GetByIdAsync((int)id);

                if (blog is null) return NotFound();

               


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





                    blog.Image = newfileName;



                }





                if (request.Name is not null)
                {
                    blog.BlogTranslates.FirstOrDefault().Name = request.Name;
                }
                if (request.Title is not null)
                {
                    blog.BlogTranslates.FirstOrDefault().Title = request.Title;
                }

                if (request.Description is not null)
                {
                    blog.BlogTranslates.FirstOrDefault().Description = request.Description;
                }

                await _blogService.EditSaveAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {







             

                var category = await _blogService.GetByIdAsync((int)id);

                if (category is null) return NotFound();









                if (request.Name is not null)
                {
                    category.BlogTranslates.FirstOrDefault().Name = request.Name;
                }
                if (request.Title is not null)
                {
                    category.BlogTranslates.FirstOrDefault().Title = request.Title;
                }
                if (request.Description is not null)
                {
                    category.BlogTranslates.FirstOrDefault().Description = request.Description;
                }
                await _blogService.EditSaveAsync();
                return RedirectToAction(nameof(Index));
            }
            //await _blogService.EditAsync(id, request);
            //return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
           
            await _blogService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsActive(int id)
        {

            var data = await _blogService.GetByIdAsync(id);
            if (data.IsActive == true)
            {
                data.IsActive = false;
                await _blogService.EditSaveAsync();
            }
            else
            {
                data.IsActive = true;
                await _blogService.EditSaveAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
