using System;

namespace ICT2106.Models.ConditionTableModule
{
    public interface ICondition
    {
        // private ConditionControl concontrol = new ConditionControl();

         public int ConditionID
        {
            // get{ return concontrol.ConditionID; }
            // set{ concontrol.ConditionID = value; }
            get;set;
        }

        public int RuleID
        {
            // get{ return concontrol.RuleID; }
            // set{ concontrol.RuleID = value; }
              get;set;
        }

        public int DeviceID
        {
            // get{ return concontrol.DeviceID; }
            // set{ concontrol.DeviceID = value; }
              get;set;
        }

        public string Status
        {
            // get{ return concontrol.Status; }
            // set{ concontrol.Status = value; }
              get;set;
        }
    }
}
