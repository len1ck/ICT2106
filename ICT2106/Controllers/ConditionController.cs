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
using ICT2106.Models;

namespace ICT2106.Controllers
{
    public class ConditionController : Controller
    {
        private readonly ILogger<ConditionController> _logger;

        private Condition c = new Condition{
            ConditionID = 1,
            Status = "Dummy",
        };
        public ConditionController(ILogger<ConditionController> logger)
        {
            _logger = logger;
        }

        public IActionResult EditCondition()
        {
            ViewData["ConditionData"] = c;
            return View();
        }
        
      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
