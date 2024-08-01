
using  Domain.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using Service.ViewModels;
using System.Diagnostics;

namespace Azal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBannerService _bannerService;
        private readonly ISpecialOffersService _specialOffersService;
        public HomeController(IBannerService bannerService,
                              ISpecialOffersService specialOffersService)
        {
            _bannerService = bannerService;
            _specialOffersService = specialOffersService;
        }
        

        public async Task<IActionResult> Index()
        {
            var banner = await _bannerService.GetAllAsync();
            var specialOffer= await _specialOffersService.GetAllAsync();
            HomeVM model = new()
            {
                Banners = banner,
                SpecialOffers = specialOffer.Where(m=>m.IsActive==true),
              

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
