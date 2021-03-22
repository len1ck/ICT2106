using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ICT2106.Models.ConditionTableModule
{
    public class Condition
    {
        //rule
        private int ruleID;

        //condition
        private String c_Cat;

        private String c_Name;

        private int conditionID;

        private string condStatus;

        //device
        private string deviceName;

        private int devID;

        //devcon
        private int devcon;

        private int devcat;

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

        public int RuleID
        {
            get{ return ruleID; }
            set{ ruleID = value; }
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

        public String CondStatus
        {
            get {return condStatus;}
            set {condStatus = value;}
        }
        

        public int DevID
        {
            get{ return devID; }
            set{ devID = value; }
        }

        public String DName
        {
            get { return deviceName; }
            set { deviceName = value; }
        }
        
        public int Devcon 
        {
            get {return devcon;}
            set {devcon = value;}
        }

           public int Devcat 
        {
            get {return devcat;}
            set {devcat = value;}
        }

    }
}
