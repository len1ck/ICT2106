using System;

namespace ICT2106.Models.DevcatTableModule
{
    public class Devcat
    {
        private int catID;

        private string catName;

        public string CatName
        {
            get{ return catName; }
            set{ catName = value; }
        }

        public int CatID
        {
            get{ return catID; }
            set{ catID = value; }
        }
    }
}
