using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using Service.ViewModels.Blogs;
using Service.ViewModels.SpecialOffers;

namespace Azal.Controllers
{
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
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<BlogDetailVM>(blog);
            return View(data);
        }
    }
}
