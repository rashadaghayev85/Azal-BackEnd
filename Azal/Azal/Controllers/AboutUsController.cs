using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
