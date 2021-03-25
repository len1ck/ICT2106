using System;
using ICT2106.Models.ConditionTableModule;
using ICT2106.Models.ActionTableModule;

namespace ICT2106.Models.RuleTableModule
{
    public class Rule
    {
        private int ruleID;

        private string ruleName;

        private ICondition condition = new ConditionControl(); 

        //Action here

        public string RuleName
        {
            get{ return ruleName; }
            set{ ruleName = value; }
        }

        public int RuleID
        {
            get{ return ruleID; }
            set{ ruleID = value; }
        }

        public ICondition Condition
        {
            get{return condition;}
            set{condition = value;}
        }
        //Add action stuff here
    }
}
