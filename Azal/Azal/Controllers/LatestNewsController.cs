using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class LatestNewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
