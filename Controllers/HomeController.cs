using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using atividade02.Models;

namespace atividade02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            if(HttpContext.Session != null)
            {
             HttpContext.Session.Clear();
             return RedirectToAction("Index");
            }
            else
            {
                return View("Login", "Usuario");
            }
        }
    }
}
