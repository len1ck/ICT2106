using System;

namespace ICT2106.Models.DevcatTableModule
{
    public class DevcatControl: IDevcat
    {      
        private Devcat devcatz = new Devcat();

        public String CatName{
            get{ return devcatz.CatName; }
            set{ devcatz.CatName = value; }
        }

        public int CatID{
            get{ return devcatz.CatID; }
            set{ devcatz.CatID = value; }
        }
    }
}
