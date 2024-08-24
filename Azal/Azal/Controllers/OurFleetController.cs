using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class OurFleetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
