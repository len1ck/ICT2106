using System;

namespace ICT2106.Models.Rules
{
    public class Rule
    {
        private int RuleID;

        private string RuleName;

        public string GetRuleName()
        {
            return RuleName;
        }

        public int GetRuleID()
        {
            return RuleID;
        }

        public void SetRuleName(string value)
        {
            RuleName = value;
        }

        public void SetRuleID(int id){
            RuleID = id;
        }
    }
}
