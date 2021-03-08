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
using ICT2106.Models.DevcatTableModule;
using ICT2106.Models.DevcondTableModule;
using ICT2106.Models;

namespace ICT2106.Controllers
{
    public class CatController : Controller
    {
        private readonly ILogger<CatController> _logger;

        private IList<IDevcat> catlist = new List<IDevcat>();
        private IList<IDevcond> devlist = new List<IDevcond>();
        private devcatGateway dc = new devcatGateway();
        private devcondGateway d = new devcondGateway();
        public CatController(ILogger<CatController> logger)
        {
            _logger = logger;
        }

        public IActionResult Category()
        {
            catlist = dc.GetAllCat();
            ViewData["CatData"] = catlist;
            devlist = d.GetAllDev();
            ViewData["DeviceData"] = devlist;
            return View();
        }

    }
}