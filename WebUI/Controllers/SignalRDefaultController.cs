﻿using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class SignalRDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index1()
        {
            return View();
        }
    }
}
