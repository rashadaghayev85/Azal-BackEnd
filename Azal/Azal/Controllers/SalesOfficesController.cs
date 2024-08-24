using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class SalesOfficesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OfficeRepresentationOffices()
        {
            return View();
        }
    }
}
