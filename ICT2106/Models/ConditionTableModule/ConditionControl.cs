using System;

namespace ICT2106.Models.ConditionTableModule
{
    public class ConditionControl: ICondition
    {      
        private Condition condition = new Condition();

        public int ConditionID
        {
            get{ return condition.ConditionID; }
            set{ condition.ConditionID = value; }
        }

        public int RuleID
        {
            get{ return condition.RuleID; }
            set{ condition.RuleID = value; }
        }

        public int DeviceID
        {
            get{ return condition.DeviceID; }
            set{ condition.DeviceID = value; }
        }

        public int DetailID
        {
            get{ return condition.DetailID; }
            set{ condition.DetailID = value; }
        }

           public string CName
        {
            get{ return condition.CName; }
            set{ condition.CName = value; }
        }

             public string DName
        {
            get{ return condition.DName; }
            set{ condition.DName = value; }
        }
    }
}
