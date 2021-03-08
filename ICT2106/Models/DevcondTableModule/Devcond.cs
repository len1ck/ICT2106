using System;

namespace ICT2106.Models.DevcondTableModule
{
    public class Devcond
    {
        private int devconID;
        private int devID;
        private int devcatID;
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
        public int DevCatID
        {
            get{ return devcatID; }
            set{ devcatID = value; }
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


