using System;
using ICT2106.Models.ConditionTableModule;

namespace ICT2106.Models.RuleTableModule
{
    public class RuleControl: IRule
    {      
        private Rule rule = new Rule();

        public String RuleName{
            get{ return rule.RuleName; }
            set{ rule.RuleName = value; }
        }

        public int RuleID{
            get{ return rule.RuleID; }
            set{ rule.RuleID = value; }
        }

        public ICondition Condition
        {
            get{return rule.Condition;}
            set{rule.Condition = value;}
        }
        //Add action stuff here
    }
}
