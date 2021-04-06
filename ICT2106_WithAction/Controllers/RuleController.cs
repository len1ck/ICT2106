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
using ICT2106.Models.DevcatTableModule;
using ICT2106.Models.DevcondTableModule;
using ICT2106.Models.MotionDetailsModule;
using ICT2106.Models.TimerDetailsModule;
using ICT2106.Models;
using ICT2106.Interfaces;

namespace ICT2106.Controllers
{
    public class RuleController : Controller
    {
        private readonly ILogger<RuleController> _logger;
        private IAction _action = new ActionModel();
        private ActionDAO _dao;

        //lists ADD ACTION LIST HERE IF NEEDED
        private IList<IRule> rulelist = new List<IRule>();
        private IList<ICondition> conditionlist = new List<ICondition>();
        private IList<IDevcat> catlist = new List<IDevcat>();
        private IList<IDevcond> devlist = new List<IDevcond>();
        private IList<IMotionDetails> mdlist = new List<IMotionDetails>();
        private IList<ITimerDetails> tdlist = new List<ITimerDetails>();
        //gateways ADD ACTION GATEWAY HERE
        private RuleGateway rg = new RuleGateway();
        private ConditionGateway cg = new ConditionGateway();
        private devcatGateway dcat = new devcatGateway();
        private devcondGateway dcon = new devcondGateway();
        private motionDetailsGateway md = new motionDetailsGateway();
        private timerDetailsGateway td = new timerDetailsGateway();

        public RuleController(ILogger<RuleController> logger)
        {
            _logger = logger;
        }

        /*
        Still using a list of rules ADD ACTION STUFF IN RULES,RULEADD,RULEEDIT,RULEDELETE
        */
        public IActionResult Rules()
        {
            ActionModel create = _action.getActionInstance();
            TryUpdateModelAsync(create); // This is the asynchronous call to try to take data from the url into the ActionModel variable
            _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
            List<ActionModel> actionList = new List<ActionModel>();

            rulelist = rg.GetAllRules();
            conditionlist = cg.GetAllCondition();
            catlist = dcat.GetAllCat();
            devlist = dcon.GetAllDev();
            mdlist = md.GetAllMotion();
            tdlist = td.GetAllTimer();
            foreach (IRule rule in rulelist)
            {
                _action = _dao.getAllActionFromDBUsingRuleID(rule.RuleID);
                actionList.Add((ActionModel)_action);

                foreach (ICondition condition in conditionlist)
                {
                    if (rule.RuleID == condition.RuleID)
                    {
                        rule.Condition = condition;
                    }
                }
            }

            ViewData["ActionList"] = actionList;
            ViewData["CatData"] = catlist;
            ViewData["ConData"] = devlist;
            ViewData["RuleData"] = rulelist;
            ViewData["MotionData"] = mdlist;
            ViewData["TimerData"] = tdlist;
            ViewData["ActionData"] = create;
            return View();
        }
        /*
        Now just taking a string input then pass it to gateway
        */
        public IActionResult RuleAdd(String addRule, String MCName, String CID, String MDCID, String HP, String PP, String TCName, String TDCID, String tm, List<string> actionDetails, List<string> actionProperties, List<string> actionPropertiesName)
        {
            _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
            List<ActionModel> actionList = new List<ActionModel>();

            int DevID = 0;
            int ruleID = rg.RuleAdd(addRule);
            if (CID == "1")
            {
                if (MDCID == "1")
                {
                    DevID = 2;
                }
                else if (MDCID == "2")
                {
                    DevID = 3;
                }
                cg.addNewCond(ruleID.ToString(), DevID.ToString(), MCName, CID, MDCID);
                md.InsertMotionDetails(MDCID, HP, PP);
            }
            else if (CID == "2")
            {
                if (TDCID == "3")
                {
                    DevID = 1;
                }
                else if (TDCID == "4")
                {
                    DevID = 2;
                }
                conditionlist = cg.addNewCond(ruleID.ToString(), DevID.ToString(), TCName, CID, TDCID);
                tdlist = td.InsertTimerDetails(TDCID, tm);
            }

            ActionModel newAction = (ActionModel)_action;
            newAction.ACTIONNAME = actionDetails[0];
            newAction.ACTIONCATEGORY = actionDetails[2];
            newAction.DEVICEID = Int32.Parse(actionDetails[4]);
            newAction.ACTIONPROPERTYNAME = actionPropertiesName;
            newAction.ACTIONPROPERTYLIST = actionProperties;
            int no_of_affected_rows = _dao.saveActionToDB(newAction, ruleID);


            rulelist = rg.GetAllRules();
            conditionlist = cg.GetAllCondition();
            catlist = dcat.GetAllCat();
            devlist = dcon.GetAllDev();
            mdlist = md.GetAllMotion();
            tdlist = td.GetAllTimer();
            foreach (IRule rule in rulelist)
            {
                _action = _dao.getAllActionFromDBUsingRuleID(rule.RuleID);
                actionList.Add((ActionModel)_action);

                foreach (ICondition condition in conditionlist)
                {
                    if (rule.RuleID == condition.RuleID)
                    {
                        rule.Condition = condition;
                    }
                }
            }

            ViewData["ActionList"] = actionList;
            ViewData["CatData"] = catlist;
            ViewData["ConData"] = devlist;
            ViewData["RuleData"] = rulelist;
            ViewData["MotionData"] = mdlist;
            ViewData["TimerData"] = tdlist;
            return View("Rules");
        }

        public IActionResult RuleEdit(String ruleIDEdit, String ruleNameEdit, String conIDEdit, String MCName, String CID, String MDCID, String HP, String PP, String TCName, String TDCID, String tm, List<string> actionDetails, List<string> actionProperties, List<string> actionPropertiesName)
        {
            _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
            List<ActionModel> actionList = new List<ActionModel>();

            int DevID = 0;
            rg.RuleEdit(ruleIDEdit, ruleNameEdit);
            if (CID == "1")
            {
                if (MDCID == "1")
                {
                    DevID = 2;
                }
                else if (MDCID == "2")
                {
                    DevID = 3;
                }
                cg.EditCondition(conIDEdit, DevID.ToString(), MCName, CID, MDCID);
                md.EditMotionDetails(conIDEdit, MDCID, HP, PP);
            }
            else if (CID == "2")
            {
                if (TDCID == "3")
                {
                    DevID = 1;
                }
                else if (TDCID == "4")
                {
                    DevID = 2;
                }
                cg.EditCondition(conIDEdit, DevID.ToString(), TCName, CID, TDCID);
                td.EditTimerDetails(conIDEdit, TDCID, tm);
            }

            ActionModel newAction = (ActionModel)_action;
            newAction.ACTIONNAME = actionDetails[0];
            newAction.ACTIONCATEGORY = actionDetails[2];
            newAction.DEVICEID = Int32.Parse(actionDetails[4]);
            newAction.ACTIONPROPERTYNAME = actionPropertiesName;
            newAction.ACTIONPROPERTYLIST = actionProperties;
            int no_of_affected_rows = _dao.updateActionWithRule(newAction, int.Parse(ruleIDEdit));



            rulelist = rg.GetAllRules();
            conditionlist = cg.GetAllCondition();
            catlist = dcat.GetAllCat();
            devlist = dcon.GetAllDev();
            mdlist = md.GetAllMotion();
            tdlist = td.GetAllTimer();
            foreach (IRule rule in rulelist)
            {
                _action = _dao.getAllActionFromDBUsingRuleID(rule.RuleID);
                actionList.Add((ActionModel)_action);

                foreach (ICondition condition in conditionlist)
                {
                    if (rule.RuleID == condition.RuleID)
                    {
                        rule.Condition = condition;
                    }
                }
            }

            ViewData["ActionList"] = actionList;
            ViewData["CatData"] = catlist;
            ViewData["ConData"] = devlist;
            ViewData["RuleData"] = rulelist;
            ViewData["MotionData"] = mdlist;
            ViewData["TimerData"] = tdlist;
            return View("Rules");
        }
        /*
        Now just taking a string input then pass it to gateway
        */
        public IActionResult RuleDelete(String delcid, String delrid, String delcatid)
        {
            _dao = HttpContext.RequestServices.GetService(typeof(ActionGateway)) as ActionGateway;
            List<ActionModel> actionList = new List<ActionModel>();

            rg.RuleDelete(delrid);
            if (delcatid == "1")
            {
                cg.DeleteCondition(delcid);
                md.DeleteMotion(delcid);
            }
            else if (delcatid == "2")
            {
                cg.DeleteCondition(delcid);
                td.DeleteMotion(delcid);
            }

            int no_of_affected_rows = _dao.deleteActionFromDB(int.Parse(delrid));

            rulelist = rg.GetAllRules();
            conditionlist = cg.GetAllCondition();
            catlist = dcat.GetAllCat();
            devlist = dcon.GetAllDev();
            mdlist = md.GetAllMotion();
            tdlist = td.GetAllTimer();
            foreach (IRule rule in rulelist)
            {
                _action = _dao.getAllActionFromDBUsingRuleID(rule.RuleID);
                actionList.Add((ActionModel)_action);

                foreach (ICondition condition in conditionlist)
                {
                    if (rule.RuleID == condition.RuleID)
                    {
                        rule.Condition = condition;
                    }
                }
            }


            ViewData["ActionList"] = actionList;
            ViewData["CatData"] = catlist;
            ViewData["ConData"] = devlist;
            ViewData["RuleData"] = rulelist;
            ViewData["MotionData"] = mdlist;
            ViewData["TimerData"] = tdlist;
            return View("Rules");
        }
    }
}