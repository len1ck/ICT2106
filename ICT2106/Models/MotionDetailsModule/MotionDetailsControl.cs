using System;

namespace ICT2106.Models.MotionDetailsModule
{
    public class MotionDetailsControl : IMotionDetails{
        
        private MotionDetails md = new MotionDetails();

        public String PetPresence{
            get{ return md.PetPresence; }
            set{ md.PetPresence = value; }
        }
        public String HumanPresence{
            get{ return md.HumanPresence; }
            set{ md.HumanPresence = value; }
        }
        public int MotionDetailID{
            get{ return md.MotionDetailID; }
            set{ md.MotionDetailID = value; }
        }
        public int DevCondID{
            get{ return md.DevCondID; }
            set{ md.DevCondID = value; }
        }
        public int CondID{
            get{ return md.CondID; }
            set{ md.CondID = value; }
        }
    }
}