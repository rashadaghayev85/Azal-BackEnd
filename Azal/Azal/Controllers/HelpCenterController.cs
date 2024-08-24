using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class HelpCenterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
