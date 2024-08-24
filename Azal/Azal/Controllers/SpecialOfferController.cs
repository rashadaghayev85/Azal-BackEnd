using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;
using Service.ViewModels.Blogs;
using Service.ViewModels.SpecialOffers;

namespace Azal.Controllers
{
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
        public IActionResult Index()
        {
            return View();
        }
      
        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var specialOffer = await _specialOffersService.GetByIdAsync(id);
            if (specialOffer == null)
            {
                return NotFound();
            }
            var data = _mapper.Map<SpecialOfferDetailVM>(specialOffer);
            return View(data);
        }
    }
}
