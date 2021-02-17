using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        public RuleController(ILogger<RuleController> logger)
        {
            _logger = logger;
        }

        public IActionResult RuleCreation()
        {

            List<Rule> rulelist = new List<Rule>();
            Rule newrule = new Rule();
            newrule.SetRuleID(1);
            newrule.SetRuleName("Rule1");
            rulelist.Add(newrule);
            ViewData["RuleData"] = rulelist;  

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
