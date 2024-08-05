
using  Domain.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories.Interfaces;
using Service.Services;
using Service.Services.Interfaces;
using Service.ViewModels;
using System.Diagnostics;

namespace Azal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly ISpecialOffersService _specialOffersService;
        private readonly IPopularDirectionService _popularDirectionService;
        private readonly IBlogService _blogService;
        public HomeController(IBannerService bannerService,
                              ISpecialOffersService specialOffersService,
                              IPopularDirectionService popularDirectionService,
                              IBlogService blogService
                              )
        {
            _bannerService = bannerService;
            _specialOffersService = specialOffersService;
            _popularDirectionService = popularDirectionService;
            _blogService = blogService;
            
        }
        

        public async Task<IActionResult> Index()
        {
            var banner = await _bannerService.GetAllAsync();
            var specialOffer= await _specialOffersService.GetAllAsync();
            var popularDirection= await _popularDirectionService.GetAllAsync();
            var blogs=await _blogService.GetAllAsync();   
            HomeVM model = new()
            {
                Banners = banner.Where(m=>m.IsActive == true),
                SpecialOffers = specialOffer.Where(m=>m.IsActive==true),
                PopularDirections = popularDirection,
                Blogs = blogs,

            };



            return View(model);
        }
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            return Redirect(Request.Headers["Referer"].ToString());
        }

      

    }
}
