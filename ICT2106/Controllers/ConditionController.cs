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
using ICT2106.Models.RuleTableModule;
using ICT2106.Models.ConditionTableModule;
using ICT2106.Models.ActionTableModule;
using ICT2106.Models.DevcatTableModule;
using ICT2106.Models;
using ICT2106.Models.DevcondTableModule;

namespace ICT2106.Controllers
{
    public class ConditionController : Controller
    {
        private readonly ILogger<ConditionController> _logger;

        private IList<IRule> rulelist = new List<IRule>();
        private IList<ICondition> conditionlist = new List<ICondition>();
        private IList<ActionModel> actionlist = new List<ActionModel>();

        private IList<IDevcat> devcatlist = new List<IDevcat>();
        private ConditionGateway rg = new ConditionGateway();


        private IList<IDevcat> catlist = new List<IDevcat>();
        private IList<IDevcond> devlist = new List<IDevcond>();

        private devcatGateway dc = new devcatGateway();
        private devcondGateway d = new devcondGateway();
        // private AddConditionGateway ag = new ConditionGateway();

        private int CatID;
        public ConditionController(ILogger<ConditionController> logger)
        {
            _logger = logger;
        }


        private static Condition temp_cond = new Condition();

        private Condition c = new Condition{
            ConditionID = 1,
            // Status = "Dummy",
        };
        public static ArrayList selectCat(String cat)
        {
            if (cat == "Motion")
            {
                return getMotion();
            }
            else if (cat == "Timer")
            {
                return getTimer();
            }
            return null;
        }

        private static ArrayList getMotion()
        {
            ArrayList al = new ArrayList()
            {
                (String)"Detect",
                (String)"No Detect"
            };
            return al;
        }

        private static ArrayList getTimer()
        {
            ArrayList al = new ArrayList()
            {
                (String)"Timer Set",
                (String)"Timer Not Set"
            };
            return al;
        }
        private Condition createCond1(Condition cond, ArrayList options)
        {
            temp_cond.ConditionID = 1;
            temp_cond.CName = cond.CName;
            temp_cond.CCat = cond.CCat;
            temp_cond.DevID = 1;
            temp_cond.DName = cond.DName;
            //temp_cond.Status = (string)options[0];
            temp_cond.CPropValue = options;
            return temp_cond;
        }

        [HttpPost]
           public IActionResult createCond(String CName,String Catname)
        {
            if(Catname == "Motion")
            {
                CatID = 1;
            }
            else 
            {
                CatID = 2;
            }
            rg.createCond(CName,CatID);
            conditionlist = rg.GetAllCondition();
            ViewData["ConditionData"] = conditionlist;
            return RedirectToAction("Cond", "Condition");
        }
            public IActionResult getCondiiton()
        {
            conditionlist = rg.GetAllCondition();
            ViewData["Condition"] = conditionlist;
            return View();
        }
        [HttpGet]        
        public Condition getCond(Condition conds, ArrayList options)
        {
            Condition temp_cond = createCond1(conds, options);
            return temp_cond;
        }

        // public ConditionController(ILogger<ConditionController> logger)
        // {
        //     _logger = logger;
        // }

        [HttpPost]   
        public IActionResult EditCondition(string editCondition)
        {
            conditionlist = rg.GetSpecificCondition(editCondition);
            ViewData["Condition"] = conditionlist;
            catlist = dc.GetAllCat();
            ViewData["CatData"] = catlist;
            devlist = d.GetAllDev();
            ViewData["DeviceData"] = devlist;
            return View();
        }

         public IActionResult AllCondition()
        {
            conditionlist = rg.GetAllCondition();
            ViewData["Condition"] = conditionlist;
            return View();
        }

           public IActionResult DeleteCondition(string deleteCondition)
        {
            conditionlist = rg.DeleteCondition(deleteCondition);
            conditionlist = rg.GetAllCondition();
            ViewData["Condition"] = conditionlist;
            return View("AllCondition");
        }

        public IActionResult Cond()
        {
            return View(temp_cond);
        }

        [HttpPost]        
         public IActionResult Cond(Condition condPost, string conditionSubmit, string opt_0, string opt_1)
        {
            switch(conditionSubmit){
                case "Select Category":
                    ArrayList categoryProperties = ConditionController.selectCat(condPost.CCat);
                    temp_cond.CCat = condPost.CCat;
                    temp_cond.CProp = categoryProperties;
                    break;
                case "Create Condition":
                    ArrayList options = new ArrayList();
                    options.Add(opt_0);
                    options.Add(opt_1);

                    Condition createdCond = getCond(condPost, options);

                    // var Json_converted_cond_object = JsonConvert.SerializeObject(createdCond);
                    // HttpContext.Session.SetString("condObject",Json_converted_cond_object);

                    // RedirectToAction(Action, Controller)
                    return RedirectToAction("Cond", "Home");
            }
            return View(temp_cond);

        }
      
        // [HttpPost]        
        //  public IActionResult Cond2(Condition condPost)
        // {
        //     switch(conditionSubmit){
        //         case "Select Category":
        //             ArrayList categoryProperties = ConditionController.selectCat(condPost.CCat);
        //             temp_cond.CCat = condPost.CCat;
        //             break;
        //         case "Create Condition":
        //             ArrayList options = new ArrayList();
        //             options.Add(opt_0);
        //             options.Add(opt_1);

        //             Condition createdCond = getCond(condPost, options);

        //             // var Json_converted_cond_object = JsonConvert.SerializeObject(createdCond);
        //             // HttpContext.Session.SetString("condObject",Json_converted_cond_object);

        //             // RedirectToAction(Action, Controller)
        //             return RedirectToAction("Cond", "Home");
        //     }
        //     return View(temp_cond);

        // }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
