using System;
using Microsoft.AspNetCore.Mvc;
using ICT2106.Models.Listeners;
using ICT2106.Models.ConditionTableModule;
using System.Threading;

namespace ICT2106.Controllers{
    public class listenController : Controller {
        
        public IActionResult ListenDisplay()
        {
            StartAction act = new StartAction();
            BothThreadList dList = new BothThreadList();
            dList = act.getDisplay();
            ViewData["ForDisplay"] = dList;   
            return View("ListenDisplay");
        }

        public IActionResult TerminateThread(string tid)
        {
            StartAction act = new StartAction();
            act.AbortThread(Int32.Parse(tid));
            Thread.Sleep(300);
            BothThreadList dList = new BothThreadList();
            dList = act.getDisplay();
            ViewData["ForDisplay"] = dList;
            Console.WriteLine("Return View");

            return View("ListenDisplay");
        }
        public IActionResult GetActions()
        {
            StartAction act = new StartAction();
            Condition con = new Condition();
            con.Devcat = 2;
            con.ConditionID = 34;
            act.ActionChecker(con);
            Condition con2 = new Condition();
            con2.Devcat = 2;
            con2.ConditionID = 33;
            act.ActionChecker(con2);
            BothThreadList dList = new BothThreadList();
            dList = act.getDisplay();
            ViewData["ForDisplay"] = dList;

            return View("ListenDisplay");
        }

    }
}