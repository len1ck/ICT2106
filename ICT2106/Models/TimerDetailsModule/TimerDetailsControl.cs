using System;

namespace ICT2106.Models.TimerDetailsModule
{
    public class TimerDetailsControl: ITimerDetails{

        private TimerDetails td = new TimerDetails();

        public String Time{
            get{return td.Time;}
            set{td.Time = value;}
        }

        public int TimerDetailID{
            get{ return td.TimerDetailID; }
            set{ td.TimerDetailID = value; }
        }
        public int DevCondID{
            get{ return td.DevCondID; }
            set{ td.DevCondID = value; }
        }

        public int CondID{
            get{ return td.CondID; }
            set{ td.CondID = value; }
        }
    }

}