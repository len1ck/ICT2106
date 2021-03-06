using System;
using System.Collections;
using ICT2106.Models;
using ICT2106.Models.RuleTableModule;
using ICT2106.Models.ActionTableModule;
using ICT2106.Models.ConditionTableModule;

namespace ICT2106.Models.ACR
{
    public class ACR
    {
        public IRule rule = new RuleControl();
        public ICondition condition = new ConditionControl();
    }
}
