using System;

namespace ICT2106.Models.Rules
{
    public class RuleControl
    {      
        private Rule rule = new Rule();

        public String GetRuleName(){
            return rule.GetRuleName();
        }

        public int GetRuleID(){
            return rule.GetRuleID();
        }

        public void SetRuleName(string name){
            rule.SetRuleName(name);
        }

        public void SetRuleID(int id){
            rule.SetRuleID(id);
        }
    }
}
