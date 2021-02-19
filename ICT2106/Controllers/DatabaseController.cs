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
using ICT2106.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using ICT2106.Controllers;


namespace ICT2106.Controllers
{
    public class DatabaseController : Controller
    {
        //get rules to display
        public void GetRules(){
            RuleGateway rg = new RuleGateway();
            List<IRule> data = rg.DBTest();

        }
        

    }
}
