using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ICT2106.Models.ConditionTableModule
{
    public class Condition
    {
        private String c_Cat;

        private String c_Name;

        private int conditionID;

        private int ruleID;

        private int deviceID;

        private string deviceName;

        private int detailID;

        private int devID;

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

        public String CCat
        {
            get { return c_Cat; }
            set { c_Cat = value; }
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

         public String CName
        {
            get{ return c_Name; }
            set{ c_Name = value; }
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

        public String DName
        {
            get { return deviceName; }
            set { deviceName = value; }
        }
        
        public int DetailID
        {
            get{ return detailID; }
            set{ detailID = value; }
        }

    }
}
