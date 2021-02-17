using System;

namespace ICT2106.Models.Conditions
{
    public class ICondition
    {
        private ConditionControl concontrol = new ConditionControl();

        public int GetContionID()
        {
            return concontrol.GetConditionID();
        }

        public int GetRuleID()
        {
            return concontrol.GetRuleID();
        }

        public int GetDeviceID()
        {
            return concontrol.GetDeviceID();
        }
        public string GetDeviceStatus()
        {
            return concontrol.GetDeviceStatus();
        }

        public void SetConditonID(int id)
        {
           concontrol.SetConditonID(id);
        }

        public void SetRuleID(int id){
            concontrol.SetRuleID(id);
        }

        public void SetDeviceID(int id){
            concontrol.SetDeviceID(id);
        }
        public void SetDeviceStatus(string state)
        {
            concontrol.SetDeviceStatus(state);
        }

    }
}
