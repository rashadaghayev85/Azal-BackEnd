using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class FareRulesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
