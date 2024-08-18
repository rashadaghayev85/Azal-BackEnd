using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class PricingPolicy : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
