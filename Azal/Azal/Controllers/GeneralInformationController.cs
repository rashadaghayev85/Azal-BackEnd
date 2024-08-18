using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class GeneralInformationController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
