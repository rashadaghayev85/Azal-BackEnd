using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class FinancialReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
