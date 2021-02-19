using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICT2106.Models.RuleTableModule;
using ICT2106.Models.ConditionTableModule;
using ICT2106.Models.ActionTableModule;
using ICT2106.Models;

namespace ICT2106.Controllers
{
    public class RuleController : Controller
    {
        private readonly ILogger<RuleController> _logger;

        private IList<IRule> rulelist = new List<IRule>();
        public RuleController(ILogger<RuleController> logger)
        {
            _logger = logger;
        }

        public IActionResult Rules()
        {
            ViewData["RuleData"] = rulelist;
            return View();
        }
        
        public IActionResult RuleAdd(IRule x)
        {
            rulelist.Add(x);
            ViewData["RuleData"] = rulelist;
            return View("Rules");
        }

        public IActionResult RuleDelete(IRule m)
        {
            rulelist.Remove(m);
            ViewData["RuleData"] = rulelist;
            return View("Rules");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
