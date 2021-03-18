using System;

namespace ICT2106.Models.DevcondTableModule
{
    public class DevcondControl: IDevcond
    {      
        private Devcond devcondz = new Devcond();

        public String DevCondition{
            get{ return devcondz.DevCondition; }
            set{ devcondz.DevCondition = value; }
        }
        public String DevType{
            get{ return devcondz.DevType; }
            set{ devcondz.DevType = value; }
        }
        public int CatID{
            get{ return devcondz.CatID; }
            set{ devcondz.CatID = value; }
        }
         public int DevID{
            get{ return devcondz.DevID; }
            set{ devcondz.DevID = value; }
        }
         public int DevConID{
            get{ return devcondz.DevConID; }
            set{ devcondz.DevConID = value; }
        }
    }
}
