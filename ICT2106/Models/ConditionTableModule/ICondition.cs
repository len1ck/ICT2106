using System;

namespace ICT2106.Models.ConditionTableModule
{
    public class ICondition
    {
        private ConditionControl concontrol = new ConditionControl();

         public int ConditionID
        {
            get{ return concontrol.ConditionID; }
            set{ concontrol.ConditionID = value; }
        }

        public int RuleID
        {
            get{ return concontrol.RuleID; }
            set{ concontrol.RuleID = value; }
        }

        public int DeviceID
        {
            get{ return concontrol.DeviceID; }
            set{ concontrol.DeviceID = value; }
        }

        public string Status
        {
            get{ return concontrol.Status; }
            set{ concontrol.Status = value; }
        }
    }
}
