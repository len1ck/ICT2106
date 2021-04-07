using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICT2106.Models.RuleTableModule;
using ICT2106.Models.ConditionTableModule;
using ICT2106.Models.DevcatTableModule;
using ICT2106.Models.DevcondTableModule;
using ICT2106.Models.MotionDetailsModule;
using ICT2106.Models.TimerDetailsModule;

namespace ICT2106.Controllers
{
    public class RuleController : Controller
    {
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
        /*
        Still using a list of rules ADD ACTION STUFF IN RULES,RULEADD,RULEEDIT,RULEDELETE
        */
        public IActionResult Rules()
        {
            rulelist = rg.GetAllRules();
            conditionlist = cg.GetAllCondition();
            catlist = dcat.GetAllCat();
            devlist = dcon.GetAllDev();
            mdlist = md.GetAllMotion();
            tdlist = td.GetAllTimer();
            foreach(IRule rule in rulelist){
                foreach(ICondition condition in conditionlist){
                    if(rule.RuleID == condition.RuleID){
                        rule.Condition = condition;
                    }
                }
            }
            ViewData["CatData"] = catlist;
            ViewData["ConData"] = devlist;
            ViewData["RuleData"] = rulelist;
            ViewData["MotionData"] = mdlist;
            ViewData["TimerData"] = tdlist;
            return View();
        }
        /*
        Now just taking a string input then pass it to gateway
        */
        public IActionResult RuleAdd(String addRule,String MCName,String CID,String MDCID,String HP, String PP, String TCName,String TDCID,String tm)
        {
            int DevID = 0;
            int ruleID = rg.RuleAdd(addRule);
            if(CID == "1"){
                    if (MDCID == "1")
                    {
                        DevID = 2;
                    }
                    else if(MDCID =="2"){
                        DevID = 3;
                    }
                    cg.addNewCond(ruleID.ToString(),DevID.ToString(),MCName,CID,MDCID);
                    md.InsertMotionDetails(MDCID,HP,PP);
            }
            else if(CID == "2"){
                    if (TDCID =="3"){
                        DevID = 1;
                    }
                    else if(TDCID =="4"){
                        DevID = 2;
                    }
                    conditionlist= cg.addNewCond(ruleID.ToString(),DevID.ToString(),TCName,CID,TDCID);
                    tdlist= td.InsertTimerDetails(TDCID,tm);
            }
            rulelist = rg.GetAllRules();
            conditionlist = cg.GetAllCondition();
            catlist = dcat.GetAllCat();
            devlist = dcon.GetAllDev();
            mdlist = md.GetAllMotion();
            tdlist = td.GetAllTimer();
            foreach(IRule rule in rulelist){
                foreach(ICondition condition in conditionlist){
                    if(rule.RuleID == condition.RuleID){
                        rule.Condition = condition;
                    }
                }
            }
            ViewData["CatData"] = catlist;
            ViewData["ConData"] = devlist;
            ViewData["RuleData"] = rulelist;
            ViewData["MotionData"] = mdlist;
            ViewData["TimerData"] = tdlist;
            return View("Rules");
        }

         public IActionResult RuleEdit(String ruleIDEdit, String ruleNameEdit,String conIDEdit, String MCName,String CID,String MDCID,String HP, String PP, String TCName,String TDCID,String tm)
        {
            int DevID = 0;
            rg.RuleEdit(ruleIDEdit,ruleNameEdit);
            if(CID == "1"){
                    if (MDCID == "1")
                    {
                        DevID = 2;
                    }
                    else if(MDCID =="2"){
                        DevID = 3;
                    }
                    cg.EditCondition(conIDEdit,DevID.ToString(),MCName,CID,MDCID);
                    md.EditMotionDetails(conIDEdit,MDCID,HP,PP);
            }
            else if(CID == "2"){
                    if (TDCID =="3"){
                        DevID = 1;
                    }
                    else if(TDCID =="4"){
                        DevID = 2;
                    }
                    cg.EditCondition(conIDEdit,DevID.ToString(),TCName,CID,TDCID);
                    td.EditTimerDetails(conIDEdit,TDCID,tm);
            }
            rulelist = rg.GetAllRules();
            conditionlist = cg.GetAllCondition();
            catlist = dcat.GetAllCat();
            devlist = dcon.GetAllDev();
            mdlist = md.GetAllMotion();
            tdlist = td.GetAllTimer();
            foreach(IRule rule in rulelist){
                foreach(ICondition condition in conditionlist){
                    if(rule.RuleID == condition.RuleID){
                        rule.Condition = condition;
                    }
                }
            }
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
            rg.RuleDelete(delrid);
            if(delcatid == "1"){
                    cg.DeleteCondition(delcid);
                    md.DeleteMotion(delcid);
            }
            else if(delcatid == "2"){
                    cg.DeleteCondition(delcid);
                    td.DeleteTimer(delcid);
            }
            rulelist = rg.GetAllRules();
            conditionlist = cg.GetAllCondition();
            catlist = dcat.GetAllCat();
            devlist = dcon.GetAllDev();
            mdlist = md.GetAllMotion();
            tdlist = td.GetAllTimer();
            foreach(IRule rule in rulelist){
                foreach(ICondition condition in conditionlist){
                    if(rule.RuleID == condition.RuleID){
                        rule.Condition = condition;
                    }
                }
            }
            ViewData["CatData"] = catlist;
            ViewData["ConData"] = devlist;
            ViewData["RuleData"] = rulelist;
            ViewData["MotionData"] = mdlist;
            ViewData["TimerData"] = tdlist;
            return View("Rules");
        }
    }
}