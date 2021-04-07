using System.Collections.Generic;

namespace ICT2106.Models.Listeners
{
    public class BothThreadList{
            private List<ThreadObj> TimerAll = new List<ThreadObj>();
            private List<int> MotionAll = new List<int>();

            public List<ThreadObj> ATimer{
                get {return TimerAll;}
                set {TimerAll = value;}
            }
            public List<int> AMotion{
                get {return MotionAll;}
                set {MotionAll = value;}
            }
        }
}
        