using System;

namespace ICT2106.Models.MotionDetailsModule
{
    public class MotionDetails
    {
        private int motionDetailID;

        private int devCondID;

        private string humanPresence;

        private string petPresence;

        private int conditionID;

        public int CondID{
            get{ return conditionID; }
            set{ conditionID = value; }
        }

        public string PetPresence
        {
            get{ return petPresence; }
            set{ petPresence = value; }
        }
        public string HumanPresence
        {
            get{ return humanPresence; }
            set{ humanPresence = value; }
        }
        public int DevCondID
        {
            get{ return devCondID; }
            set{ devCondID = value; }
        }
        public int MotionDetailID
        {
            get{ return motionDetailID; }
            set{ motionDetailID = value; }
        }
    }
}
