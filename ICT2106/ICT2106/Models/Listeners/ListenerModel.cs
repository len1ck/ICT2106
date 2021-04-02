using System;
using System.Threading;
using ICT2106.Models.ConditionTableModule;

namespace ICT2106.Models.Listeners
{
    class StartAction{
        //Start multithreading to track each condition
        static void ActionChecker(Condition condition){
            //creates new action tracker
            //StartAction startAction = new StartAction();

            //Switch to see what the action is
            int DevCat = condition.Devcat;

            switch(DevCat)
            {
                //case 1 is motion
                case 1:
                    //new Motion Thread
                    Thread m1 = new Thread(()=>MotionFunction());
                    break;
                //case 2 is Timer
                case 2:
                    //new Timer Thread
                    Thread t1 = new Thread(()=>TimerFunction(condition));
                    t1.Start();
                    break;
            }


            
        }

        public static void TimerFunction(Condition condition){
            //check what kind of timer funciton it is - TBC

            //get TimerDetails from DB
            int DevConID = condition.Devcon;
            /* <TODO>using DevConID to get Data from timerDetails(DB) using col "condID" */
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

            //Run Countdown until update
            CountdownTimer(SecDiff);
            /* <TODO> Run code to update database once time is up*/

        }

        public void AppleTests(){
            //check what kind of timer funciton it is - TBC

            //get TimerDetails from DB
            //int DevConID = condition.Devcon;
            /* <TODO>using DevConID to get Data from timerDetails(DB) using col "condID" */
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
            CountdownTimer(10);
            /* <TODO> Run code to update database once time is up*/

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
                System.Console.WriteLine("Time Left (seconds)..." + time);
                time--;
            }
        }


    }

    
}