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
        private IList<ICondition> conditionlist = new List<ICondition>();
        private IList<ActionModel> actionlist = new List<ActionModel>();
        private RuleGateway rg = new RuleGateway();
        private ConditionGateway cg = new ConditionGateway();

        public RuleController(ILogger<RuleController> logger)
        {
            _logger = logger;
        }
        /*
        Still using a list of rules
        */
        public IActionResult Rules()
        {
            rulelist = rg.GetAllRules();
            conditionlist = cg.GetAllCondition();
            foreach(IRule rule in rulelist){
                foreach(ICondition condition in conditionlist){
                    if(rule.RuleID == condition.RuleID){
                        rule.Condition = condition;
                    }
                }
            }
            ViewData["RuleData"] = rulelist;
            return View();
        }
        /*
        Now just taking a string input then pass it to gateway
        */
        public IActionResult RuleAdd(String addRule)
        {
            rg.RuleAdd(addRule);
            rulelist = rg.GetAllRules();
            ViewData["RuleData"] = rulelist;
            return View("Rules");
        }
        /*
        Now just taking a string input then pass it to gateway
        */
        public IActionResult RuleDelete(String deleteRule)
        {
            rg.DeleteRule(deleteRule);
            rulelist = rg.GetAllRules();
            ViewData["RuleData"] = rulelist;
            return View("Rules");
        }
    }
}

/*
Temp data, passes data from one controller to another 
public ActionResult Index()
        {
          TempData["data1"] = "I am from different action";
          return RedirectToAction("Read");
         
        }

        public string Read()
        {
            string str;
            str = TempData["data1"].ToString();
            return str;
        }
*/