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
using ICT2106.Models.DevcatTableModule;
using ICT2106.Models.DevcondTableModule;
using ICT2106.Models.MotionDetailsModule;
using ICT2106.Models.TimerDetailsModule;
using ICT2106.Models;

namespace ICT2106.Controllers
{
    public class RuleController : Controller
    {
        private readonly ILogger<RuleController> _logger;

        //lists
        private IList<IRule> rulelist = new List<IRule>();
        private IList<ICondition> conditionlist = new List<ICondition>();
        private IList<ActionModel> actionlist = new List<ActionModel>();
        private IList<IDevcat> catlist = new List<IDevcat>();
        private IList<IDevcond> devlist = new List<IDevcond>();
        //gateways
        private RuleGateway rg = new RuleGateway();
        private ConditionGateway cg = new ConditionGateway();
        private devcatGateway dcat = new devcatGateway();
        private devcondGateway dcon = new devcondGateway();
        private IList<IMotionDetails> mdlist = new List<IMotionDetails>();
        private motionDetailsGateway md = new motionDetailsGateway();
        private IList<ITimerDetails> tdlist = new List<ITimerDetails>();
        private timerDetailsGateway td = new timerDetailsGateway();

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
            catlist = dcat.GetAllCat();
            devlist = dcon.GetAllDev();
            foreach(IRule rule in rulelist){
                foreach(ICondition condition in conditionlist){
                    if(rule.RuleID == condition.RuleID){
                        rule.Condition = condition;
                    }
                }
            }
            ViewData["CatData"] = catlist;
            ViewData["DeviceData"] = devlist;
            ViewData["RuleData"] = rulelist;
            return View();
        }
        /*
        Now just taking a string input then pass it to gateway
        */
        public IActionResult RuleAdd(String addRule,String MCName,String MCID,String MDCID,String HP, String PP)
        {
            int DevID = 0;
            int ruleID = rg.RuleAdd(addRule);
            if (MDCID == "1")
            {
                DevID = 2;
            }
            else if(MDCID =="2"){
                DevID = 3;
            }
            else if(MDCID =="3"){
                DevID = 1;
            }
            else if(MDCID =="4"){
                DevID = 2;
            }
            conditionlist= cg.addNewCond(ruleID,DevID,MCName,MCID,MDCID);
            mdlist= md.InsertMotionDetails(MDCID,HP,PP);

            rulelist = rg.GetAllRules();
            conditionlist = cg.GetAllCondition();
            catlist = dcat.GetAllCat();
            devlist = dcon.GetAllDev();
            foreach(IRule rule in rulelist){
                foreach(ICondition condition in conditionlist){
                    if(rule.RuleID == condition.RuleID){
                        rule.Condition = condition;
                    }
                }
            }
            ViewData["CatData"] = catlist;
            ViewData["DeviceData"] = devlist;
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