using System;

namespace ICT2106.Models.Rules
{
    public class IRule
    {
        private RuleControl rulecontrol = new RuleControl();

        public String RuleName{
            get{ return rulecontrol.RuleName; }
            set{ rulecontrol.RuleName = value; }
        }

        public int RuleID{
            get{ return rulecontrol.RuleID; }
            set{ rulecontrol.RuleID = value; }
        }

    }
}
