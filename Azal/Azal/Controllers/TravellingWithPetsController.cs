﻿using Microsoft.AspNetCore.Mvc;

namespace Azal.Controllers
{
    public class TravellingWithPetsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
