using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using ICT2106.Models;
using ICT2106.Models.Listeners;
using ICT2106.Models.ConditionTableModule;

namespace ICT2106.Controllers{
    public class listenController : Controller {
        
        public IActionResult ListenTest()
        {
            
            return View("ListenTest");
        }

        public IActionResult TestApple()
        {
            StartAction act = new StartAction();
            act.AppleTests();

            return View("ListenTest");
        }

        public IActionResult ForDisplay()
        {
            StartAction act = new StartAction();
            var AllDisplay = act.getDisplay();

            return View("ListenTest", AllDisplay);
        }

        public IActionResult TerminateThread()
        {
            StartAction act = new StartAction();
            act.AppleTests();

            return View("ListenTest");
        }
        public IActionResult GetActions()
        {
            StartAction act = new StartAction();
            Condition con = new Condition();
            con.Devcat = 2;
            con.ConditionID = 18;
            act.ActionChecker(con);

            return View("ListenTest");
        }

    }
}