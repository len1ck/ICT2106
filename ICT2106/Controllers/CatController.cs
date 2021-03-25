using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICT2106.Models.ConditionTableModule;
using ICT2106.Models.DevcatTableModule;
using ICT2106.Models.DevcondTableModule;
using ICT2106.Models.MotionDetailsModule;
using ICT2106.Models.TimerDetailsModule;
using ICT2106.Models;

namespace ICT2106.Controllers
{
    public class CatController : Controller
    {
        private readonly ILogger<CatController> _logger;

        private IList<IDevcat> catlist = new List<IDevcat>();
        private IList<IDevcond> devlist = new List<IDevcond>();
        private IList<ICondition> conditionlist = new List<ICondition>();
        private devcatGateway dc = new devcatGateway();
        private devcondGateway d = new devcondGateway();

        private IList<IMotionDetails> mdlist = new List<IMotionDetails>();
        private motionDetailsGateway md = new motionDetailsGateway();
        private IList<ITimerDetails> tdlist = new List<ITimerDetails>();
        private timerDetailsGateway td = new timerDetailsGateway();
        private ConditionGateway rg = new ConditionGateway();
        public CatController(ILogger<CatController> logger)
        {
            _logger = logger;
        }

        public IActionResult Category2()
        {
            catlist = dc.GetAllCat();
            ViewData["CatData"] = catlist;
            devlist = d.GetAllDev();
            ViewData["DeviceData"] = devlist;
            return View();
        }

        // public IActionResult Category()
        // {
        //     catlist = dc.GetAllCat();
        //     ViewData["CatData"] = catlist;
        //     devlist = d.GetAllDev();
        //     ViewData["DeviceData"] = devlist;
        //     return View();
        // }

        // public IActionResult SelDev(String catid){
        //     d.SelDev(catid);
        //     devlist = d.GetAllDev();
        //     ViewData["Device"] = devlist;
        //     return View("Category");
        // }
        private int CatID;
        public IActionResult SelDev(String category){
            catlist = dc.GetAllCat();
            ViewData["CatData"] = catlist;
            devlist = d.SelDev(category);
            ViewData["DeviceData"] = devlist;
            ViewData["CatID"] = category;
            return View("Category2");
        }

        // public IActionResult MotionAdd(String did, String dev, String HP, String PP){
        //     mdlist= md.MotionAdd(did,dev,HP,PP);
        //     return View("Category");
        // }

        

        // public IActionResult InsertTimerDetails(String dev,String tm,String did){
        //     tdlist= td.InsertTimerDetails(dev,tm,did);
        //     return View("Category");
        // }
        public IActionResult addNewCond(String did, String CName,String catz, String dev,String HP, String PP){
            conditionlist= rg.addNewCond(did,CName,catz, dev);
            conditionlist = rg.GetAllCondition();
            mdlist= md.MotionAdd(did,dev,HP,PP);
            ViewData["ConditionData"] = conditionlist;
            return View("Category");
        }
    }
}