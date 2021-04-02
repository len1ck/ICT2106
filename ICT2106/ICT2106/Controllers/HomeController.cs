using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICT2106.Models;

namespace ICT2106.Controllers
{
    public class HomeController : Controller
    {
        Device dev = new Device();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
                 // Creating and initializing threads 
        //Thread thr1 = new Thread(() => timer.Run(30,1)); 
        Thread thr2 = new Thread(() => setDev(30)); 
        Thread thr3 = new Thread(() => checkDev()); 
        //thr1.Start(); 
        thr2.Start(); 
        thr3.Start();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Something()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void checkDev(){
            while (true)
            {

                System.Threading.Thread.Sleep(1000);
                if(dev.getStatus() == "Started"){
                    System.Console.WriteLine("Device has started");
                }
            }
        }

         public void setDev(int numberOfTicks){
            while (numberOfTicks > 0)
            {

                System.Threading.Thread.Sleep(1000);
                dev.setStatus(System.Console.ReadLine().ToString());
                numberOfTicks--;
            }
        }
    }
}
