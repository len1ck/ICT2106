using System;

namespace ICT2106.Models.ConditionTableModule
{
    public class Condition
    {
        private int conditionID;

        private int ruleID;

        private int deviceID;

        private string status;

        public int ConditionID
        {
            get{ return conditionID; }
            set{ conditionID = value; }
        }

        public int RuleID
        {
            get{ return ruleID; }
            set{ ruleID = value; }
        }

        public int DeviceID
        {
            get{ return deviceID; }
            set{ deviceID = value; }
        }

        public string Status
        {
            get{ return status; }
            set{ status = value; }
        }
    }
}
