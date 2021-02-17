using System;

namespace ICT2106.Models.Rules
{
    public class Rule
    {
        private int ruleID;

        private string ruleName;

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
    }
}
