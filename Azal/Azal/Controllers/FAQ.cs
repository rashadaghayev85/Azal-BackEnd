using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class FAQ : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
