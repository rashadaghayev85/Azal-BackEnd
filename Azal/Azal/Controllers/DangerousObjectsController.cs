using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class DangerousObjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
