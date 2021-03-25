using System;
using ICT2106.Models.ConditionTableModule;
using ICT2106.Models.ActionTableModule;

namespace ICT2106.Models.RuleTableModule
{
    public interface IRule
    {
        String RuleName {get; set;}

        int RuleID{get; set;}

        ICondition Condition{get; set;}
    }
}
