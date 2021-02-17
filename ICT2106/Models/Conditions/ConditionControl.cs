using System;

namespace ICT2106.Models.Conditions
{
    public class ConditionControl
    {      
        private Condition condition = new Condition();

        public int GetConditionID()
        {
            return condition.GetConditionID();
        }

        public int GetRuleID()
        {
            return condition.GetRuleID();
        }

        public int GetDeviceID()
        {
            return condition.GetDeviceID();
        }
        public string GetDeviceStatus()
        {
            return condition.GetDeviceStatus();
        }

        public void SetConditonID(int id)
        {
           condition.SetConditionID(id);
        }

        public void SetRuleID(int id){
            condition.SetRuleID(id);
        }

        public void SetDeviceID(int id){
            condition.SetDeviceID(id);
        }
        public void SetDeviceStatus(string state)
        {
            condition.SetDeviceStatus(state);
        }
    }
}
