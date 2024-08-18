using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class TermsAndConditions : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
