using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class ProgramUsingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
