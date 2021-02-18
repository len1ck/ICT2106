using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICT2106.Models;
using ICT2106.Models.RuleTableModule;

namespace ICT2106.Controllers
{
    public class RuleDataSource
    {
        private int[] RuleID;
        private string[] RuleName;
        public void createRule(int id, string name){
            //rule.RuleID.set(id);
            //rule.RuleName = name;

        }
        public int getRuleID(){
            return 1;
            //return rule.RuleID;
        }
    }
}