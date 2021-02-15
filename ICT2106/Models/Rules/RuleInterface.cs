using System;

namespace ICT2106.Models.Rules
{
    public class RuleInterface
    {
        private RuleControl rulecontrol = new RuleControl();

        public String GetRuleName(){
            return rulecontrol.GetRuleName();
        }

        public int GetRuleID(){
            return rulecontrol.GetRuleID();
        }

        public void SetRuleName(string name){
            rulecontrol.SetRuleName(name);
        }

        public void SetRuleID(int id){
            rulecontrol.SetRuleID(id);
        }

    }
}
