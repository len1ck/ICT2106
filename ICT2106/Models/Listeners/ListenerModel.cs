using System;
using System.Threading;
using System.Collections.Generic;
using ICT2106.Models.ConditionTableModule;
using ICT2106.Controllers;


namespace ICT2106.Models.Listeners
{    
    public class StartAction{
        //Start multithreading to track each condition
        public static List<ThreadObj> AllTimer = new List<ThreadObj>();
        public static List<int> AllMotion = new List<int>();

        public BothThreadList getDisplay(){
            BothThreadList thisList = new BothThreadList();
            thisList.ATimer = AllTimer;
            thisList.AMotion = AllMotion;

            return thisList;
        }
        

        public void ActionChecker(Condition condition){
                //Switch to see what the action is
                int DevCat = condition.Devcat;
                int ConID = condition.ConditionID;
                switch(DevCat)
                {
                    //case 1 is motion
                    case 1:
                        //Add new Motion to List of Motions
                        AllMotion.Add(ConID);
                        break;
                    //case 2 is Timer
                    case 2:
                        //Add new Timer into List of Timers
                        ThreadObj timer1 = new ThreadObj();
                        //Thread t1 = new Thread(()=>TimerFunction(ConID));
                        Thread t1 = new Thread(()=>TimerFunction(condition));
                        timer1.ThreadID = ConID;
                        timer1.thisThread = t1;
                        AllTimer.Add(timer1);
                        t1.Start();
                        break;
                } 
        }

        public void AbortThread(int CondID){
            foreach (var indiThread in AllTimer){
                if (indiThread.ThreadID == CondID){
                    Console.WriteLine("interrupting Timer: " + CondID);
                    indiThread.thisThread.Interrupt();
                }
            }
        }

        public void TimerFunction(Condition condition){
            var conditionID = condition.ConditionID;
            try{
                //get all timer details from DB and find the details matching with ConditionID
                
                timerDetailsGateway tdg = new timerDetailsGateway();
                var AllTimerList = tdg.GetAllTimer();
                String inpTime = "";
                foreach (var i in AllTimerList){
                    //WriteLine(i.CondID + " == " + conditionID);
                    if(i.CondID == conditionID){
                        inpTime = i.Time;
                    }
                }

                /**<TODO>Add error checking if unable to find
                if (inpTime == ""){
                    //Error
                }**/

                //removing AM/PM from String (after setting them all to UpperCase)
                /**<TODO> Add Error checking for TimeDetails Issue**/
                inpTime = inpTime.ToUpper();
                string newTime = inpTime.Replace("AM", "");
                newTime = inpTime.Replace("PM", "");

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
                //int SecDiff = Convert.ToInt32((DT - CurTime).TotalSeconds);
                int SecDiff = Convert.ToInt32((DT - CurTime).TotalHours); //Need to remember to change back to Total Seconds
                Console.WriteLine("Before:" + SecDiff);
                //If number is negative then it will activate on the next timing
                if (SecDiff < 0){
                    DT = new DateTime(DT.Year, DT.Month, DT.Day+1, DT.Hour, DT.Minute, DT.Second);
                    Console.WriteLine(DT);
                    SecDiff = Convert.ToInt32((DT - CurTime).TotalHours); //Counting Hours for testing, remember to change to Seconds below
                    //SecDiff = Convert.ToInt32((DT - CurTime).TotalSeconds);
                }
                Console.WriteLine("Final:" + SecDiff);
                //Run Countdown until update
                CountdownTimer(SecDiff);
                /* <TODO> Run code to update database once time is up*/
                //Remove ID from list of AllTimer
                foreach(var objt in AllTimer){
                    if (objt.ThreadID == conditionID){
                        Console.WriteLine("removed: " + conditionID);
                        AllTimer.Remove(objt);
                        break;
                    }
                }
                //Repeat Timer
                ActionChecker(condition);
            }
            catch(ThreadInterruptedException exception) {
                /** <TODO> Remove from ObjList **/
                foreach(var objt in AllTimer){
                    if (objt.ThreadID == conditionID){
                        Console.WriteLine("removed: " + conditionID);
                        //Console.WriteLine(exception);
                        AllTimer.Remove(objt);
                        break;
                    }
                }
                Console.WriteLine("Thread End");
            }
            
        }


        //Function for Motion
        private static void MotionFunction(int CondID){
            /* <TODO> add codes to run Motion Update */
        }

        //Countdown Timer function
        private static void CountdownTimer(int time){
            while (time > 0)
            {
                System.Threading.Thread.Sleep(1000);
                //System.Console.WriteLine("Time Left (seconds)..." + time);
                System.Console.WriteLine("Time Left (Hours but run in Seconds)..." + time); //Remember to remove
                time--;
            }
        }


    }

    
}