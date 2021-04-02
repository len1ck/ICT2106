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

    }
}