﻿using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class BaggageController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
