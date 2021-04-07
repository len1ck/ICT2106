using System;
using System.Threading;

namespace ICT2106.Models.Listeners
{
    public class ThreadObj{
        private int threadID;
        private Thread threadOnly;

        public int ThreadID{
            get {return threadID;}
            set {threadID = value;}
        }

        public Thread thisThread{
            get {return threadOnly;}
            set {threadOnly = value;}
        }

        

    }
}