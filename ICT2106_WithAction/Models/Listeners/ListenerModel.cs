using System;
using System.Threading;
using System.Collections.Generic;
using ICT2106.Models.ConditionTableModule;
using ICT2106.Controllers;
using ICT2106.Models.TimerDetailsModule;
using ICT2106.Models.MotionDetailsModule;


namespace ICT2106.Models.Listeners
{
    class ThreadObj{
        private int threadID;
        private Thread threadOnly;

        public Thread thisThread{
            get {return threadOnly;}
            set {threadOnly = value;}
        }

        public int ThreadID{
            get {return threadID;}
            set {threadID = value;}
        }

    }

    class BothThreadList{
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

    
    class StartAction{
        //Start multithreading to track each condition
        public static List<ThreadObj> AllTimer = new List<ThreadObj>();
        public static List<int> AllMotion = new List<int>();

        public BothThreadList getDisplay(){
            BothThreadList thisList = new BothThreadList();
            thisList.ATimer = AllTimer;
            thisList.AMotion = AllMotion;

            return thisList;
        }
        

        //public void ActionChecker(Condition condition){
        public void ActionChecker(Condition condition){
            //Switch to see what the action is
            int DevCat = condition.Devcat;
            int ConID = condition.ConditionID;
            //int ConID = 10;
            switch(DevCat)
            {
                //case 1 is motion
                case 1:
                    //new Motion Thread
                    AllMotion.Add(ConID);
                    break;
                //case 2 is Timer
                case 2:
                    //new Timer Thread
                    ThreadObj timer1 = new ThreadObj();
                    Console.WriteLine("Here1");
                    Thread t1 = new Thread(()=>TimerFunction(ConID));
                    timer1.ThreadID = ConID;
                    timer1.thisThread = t1;
                    AllTimer.Add(timer1);
                    t1.Start();
                    break;
            }


            
        }

        public static void AbortThread(int CondID){
            //appleThreadList ThreadList = new appleThreadList();
            foreach (var indiThread in AllTimer){
                if (indiThread.ThreadID == CondID){
                    indiThread.thisThread.Join();
                }
            }
        }

        //public static void TimerFunction(Condition condition){
        //take in condition ID from where we activate
        public static void TimerFunction(int conditionID){
            Console.WriteLine("Here2");
            //check what kind of timer funciton it is - TBC

            //get TimerDetails from DB
            //int DevConID = condition.Devcon;
            /* <TODO>using DevConID to get Data from timerDetails(DB) using col "condID" */
            timerDetailsGateway tdg= new timerDetailsGateway();
            var AllTimerList = tdg.GetAllTimer();
            String inpTime = "";
            foreach (var i in AllTimerList){
                Console.WriteLine(i.CondID + " == " + conditionID);
                if(i.CondID == conditionID){
                    inpTime = i.Time;
                }
            }
            Console.WriteLine(inpTime + "Hit");

            //Add error checking if unable to find
            // if (inpTime == ""){
            //     //Error
            // }

            //String inpTime = "9PM"; //temp testing

            //removing AM/PM
            inpTime = inpTime.ToUpper();
            string newTime = inpTime.Replace("AM", "");
            newTime = inpTime.Replace("PM", "");
            Console.WriteLine(newTime);

            //convert to int
            int rawtime = int.Parse(newTime);

            //checking AM/PM
            if (inpTime.Contains("PM")){
                rawtime = rawtime+12;
            }

            //convert rawtime to DateTime
            DateTime DT = DateTime.Now;
            DT = new DateTime(DT.Year, DT.Month, DT.Day, rawtime, 00, 00);

            //Compare with current time
            DateTime CurTime = DateTime.Now;
            Console.WriteLine(CurTime);
            int SecDiff = Convert.ToInt32((DT - CurTime).TotalSeconds);
            Console.WriteLine("Before:" + SecDiff);
            //If number is negative then it will activate on the next timing
            if (SecDiff < 0){
                DT = new DateTime(DT.Year, DT.Month, DT.Day+1, DT.Hour, DT.Minute, DT.Second);
                Console.WriteLine(DT);
                SecDiff = Convert.ToInt32((DT - CurTime).TotalHours); //Counting Hours, remember to change to Seconds below
                //SecDiff = Convert.ToInt32((DT - CurTime).TotalSeconds);
            }
            Console.WriteLine("After:" + SecDiff);
            //Run Countdown until update
            CountdownTimer(SecDiff);
            /* <TODO> Run code to update database once time is up*/

        }

        public List<ThreadObj> DisTimerCondition(){
            return AllTimer;
        }

        public void AppleTests(){
            //check what kind of timer funciton it is - TBC

            //Test Timing
            String inpTime = "9PM"; //temp testing

            //removing AM/PM
            string newTime = inpTime.Replace("AM", "");
            newTime = inpTime.Replace("PM", "");

            //convert to int
            int rawtime = Int16.Parse(newTime);

            //checking AM/PM
            if (inpTime.Contains("PM")){
                rawtime = rawtime+12;
            }

            //convert rawtime to DateTime
            DateTime DT = DateTime.Now;
            DT = new DateTime(DT.Year, DT.Month, DT.Day, rawtime, 00, 00);

            //Compare with current time
            DateTime CurTime = DateTime.Now;
            int SecDiff = Convert.ToInt16((DT - CurTime).TotalSeconds);

            //If number is negative then it will activate on the next timing
            if (SecDiff < 0){
                DT = new DateTime(DT.Year, DT.Month, DT.Day+1, DT.Hour, DT.Minute, DT.Second);
                SecDiff = Convert.ToInt16((DT - CurTime).TotalHours);
            }

            Console.WriteLine(SecDiff);
            //Run Countdown until update
            CountdownTimer2(5, SecDiff);
            /* <TODO> Run code to update database once time is up*/

        }

        
        private static void CountdownTimer2(int time, int DeffTime){
            while (time > 0)
            {
                System.Threading.Thread.Sleep(1000);
                System.Console.WriteLine("Time Left (seconds)..." + time);;
                time--;
            }
            System.Console.WriteLine(DeffTime + " Ended");
        }


        //Function for Motion
        private static void MotionFunction(){
            /* add codes to run Motion Update */
        }

        //Countdown Timer function
        private static void CountdownTimer(int time){
            while (time > 0)
            {
                System.Threading.Thread.Sleep(1000);
                //System.Console.WriteLine("Time Left (seconds)..." + time);
                System.Console.WriteLine("Time Left (Hours)..." + time); //Remember to remove
                time--;
            }
        }


    }

    
}