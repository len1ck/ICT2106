using System;

namespace ICT2106.Models.TimerDetailsModule
{
    public class TimerDetails
    {
        private int timerDetailID;

        private int devCondID;

        private int conditionID;

        private string timing;

        public string Time
        {
            get{ return timing; }
            set{ timing = value; }
        }

        public int CondID    
        {
            get{ return conditionID; }
            set{ conditionID = value; }
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