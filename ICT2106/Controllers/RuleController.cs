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
using ICT2106.Models.Rules;
using ICT2106.Models;

namespace ICT2106.Controllers
{
    public class RuleController : Controller
    {
        private readonly ILogger<RuleController> _logger;

        private IList<IRule> rulelist = new List<IRule>(){
                new IRule{
                    RuleID = 1,
                    RuleName = "Rule1"
                },
                new IRule{
                    RuleID = 2,
                    RuleName = "Rule3"
                }

            };
        public RuleController(ILogger<RuleController> logger)
        {
            _logger = logger;
        }

        public IActionResult RuleCreation()
        {
            ViewData["RuleData"] = rulelist;
            return View();
        }
        
        public IActionResult RuleAdd(IRule x)
        {
            rulelist.Add(x);
             Console.WriteLine(x.RuleName);
            ViewData["RuleData"] = rulelist;
            return View("RuleCreation");
        }

        public IActionResult RuleDelete(IRule m)
        {
            //rulelist.Remove(m);
            Console.WriteLine(m.RuleName);
            ViewData["RuleData"] = rulelist;
            return View("RuleCreation");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
