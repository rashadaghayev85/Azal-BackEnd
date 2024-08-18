using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class BecomeAMember : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
