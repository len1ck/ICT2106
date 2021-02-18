using System;

namespace ICT2106.Models.ConditionTableModule
{
    public class ConditionControl
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

        public string Status
        {
            get{ return condition.Status; }
            set{ condition.Status = value; }
        }
    }
}
