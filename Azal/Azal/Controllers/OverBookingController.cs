using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class OverBookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
