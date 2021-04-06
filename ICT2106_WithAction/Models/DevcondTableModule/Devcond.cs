using System;

namespace ICT2106.Models.DevcondTableModule
{
    public class Devcond
    {
        private int devconID;
        private int devID;
        private int catID;
        private string devType;
        private string devCondition;

        public string DevCondition
        {
            get{ return devCondition; }
            set{ devCondition = value; }
        }
        public string DevType
        {
            get{ return devType; }
            set{ devType = value; }
        }
        public int CatID
        {
            get{ return catID; }
            set{ catID = value; }
        }
        public int DevID
        {
            get{ return devID; }
            set{ devID = value; }
        }
        public int DevConID
        {
            get{ return devconID; }
            set{ devconID = value; }
        }
    }
}


