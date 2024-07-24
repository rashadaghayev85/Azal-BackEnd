
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

        public HomeController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }
        

        public async Task<IActionResult> Index()
        {
            var banner = await _bannerService.GetAllAsync();

            HomeVM model = new()
            {
                Banners = banner
               

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
