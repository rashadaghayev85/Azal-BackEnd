using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class UnwantedPassengersController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
