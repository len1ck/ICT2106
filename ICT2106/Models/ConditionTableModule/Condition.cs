using System;
using System.Collections;

namespace ICT2106.Models.ConditionTableModule
{
    public class Condition
    {
        private int conditionID;

        private int ruleID;

        private int deviceID;

        private string deviceName;

        private string status;

        private ArrayList c_Properties;

        private ArrayList c_PropertiesValue;

        private static ArrayList Category = new ArrayList()
        {
            (String)"Motion",
            (String)"Timer"
        };

        public String getCategoryItem(int i)
        {
            if(i >= 0 && i <2)
            {
                return (String)Category[i];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public ArrayList CPropValue
        {
            get { return c_PropertiesValue; }
            set { c_PropertiesValue = value; }
        } 

        public ArrayList CProp
        {
            get { return c_Properties; }
            set { c_Properties = value; }
        }

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
