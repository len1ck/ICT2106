using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICT2106.Models;

namespace ICT2106.Controllers
{
    public class RuleCreationController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public RuleCreationController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Rules()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Something()
        {
            return View();
        }
    }
}
