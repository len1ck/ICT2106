using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ICT2106.Models.ActionTableModule
{
    public class ActionModel
    {
        private int a_ID;
        private String a_Name;
        private String a_Cat;
        private int d_ID;
        private String d_Name;
        private String d_Status;
        private ArrayList a_Properties;
        private ArrayList a_PropertiesValue;
        private static ArrayList Category = new ArrayList()
        {
            (String)"Air Treatment",
            (String)"Camera",
            (String)"Lock",
            (String)"Lighting",
            (String)"Smart Blind"
        };

        public String getCategoryItem(int i)
        {
            if(i >= 0 && i <5)
            {
                return (String)Category[i];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int AID
        {
            get { return a_ID; }
            set { a_ID = value; }
        }

        public ArrayList APropValue
        {
            get { return a_PropertiesValue; }
            set { a_PropertiesValue = value; }
        } 

        public String AName
        {
            get { return a_Name; }
            set { a_Name = value; }
        }

        public String ACat
        {
            get { return a_Cat; }
            set { a_Cat = value; }
        }

        public int DID
        {
            get { return d_ID; }
            set { d_ID = value; }
        }
        public String DName
        {
            get { return d_Name; }
            set { d_Name = value; }
        }
        public String DStatus
        {
            get { return d_Status; }
            set { d_Status = value; }
        }

        public ArrayList AProp
        {
            get { return a_Properties; }
            set { a_Properties = value; }
        }
    }
}
