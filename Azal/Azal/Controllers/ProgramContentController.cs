using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class ProgramContentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
