using System;

namespace ICT2106.Models.TimerDetailsModule
{
    public class TimerDetails
    {
        private int timerDetailID;

        private int devCondID;

        private string timing;
        
        private int conditionID;

        public int CondID    
        {
            get{ return conditionID; }
            set{ conditionID = value; }
        }

        public string Time
        {
            get{ return timing; }
            set{ timing = value; }
        }

        public int DevCondID
        {
            get{ return devCondID; }
            set{ devCondID = value; }
        }
        public int TimerDetailID
        {
            get{ return timerDetailID; }
            set{ timerDetailID = value; }
        }
    }
}