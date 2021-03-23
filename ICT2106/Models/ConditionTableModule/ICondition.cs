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

        public int DevID
        {
            // get{ return concontrol.DeviceID; }
            // set{ concontrol.DeviceID = value; }
              get;set;
        }


          public String CName
        {
              get;set;
        }
        public String DName
        {
          get;set;
        }
        public String CCat
        {
          get;set;
        }

        public int Devcon 
        {
          get;set;
        }

        public int Devcat
        {
          get; set;
        }

    }
}
