using System;

namespace ICT2106.Models.Conditions
{
    public class Condition
    {
        private int ConditionID;

        private int RuleID;

        private int DeviceID;

        private string status;

        public int GetConditionID()
        {
            return ConditionID;
        }

        public int GetRuleID()
        {
            return RuleID;
        }

        public int GetDeviceID()
        {
            return DeviceID;
        }
        public string GetDeviceStatus()
        {
            return status;
        }

        public void SetConditionID(int id)
        {
           ConditionID = id;
        }

        public void SetRuleID(int id){
            RuleID = id;
        }

        public void SetDeviceID(int id){
            DeviceID = id;
        }
        public void SetDeviceStatus(string state)
        {
            status = state;
        }
    }
}
