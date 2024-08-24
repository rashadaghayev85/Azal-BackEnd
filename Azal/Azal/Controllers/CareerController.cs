using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class CareerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
