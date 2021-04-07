using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICT2106.Models;
using ICT2106.Models.TimerDetailsModule;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ICT2106.Controllers
{
    public class timerDetailsGateway
    {
        private static string connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=rule;port=3306;password=qwerty123";
        private List<ITimerDetails> timez = new List<ITimerDetails>();
        private MySqlConnection conn = new MySqlConnection(connStr);
       public List<ITimerDetails> InsertTimerDetails(String dev,String tm){
            try
            {
                conn.Open();
                string cond = "SELECT MAX(CondID) FROM rule.condition";
                MySqlCommand cmd = new MySqlCommand(cond, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                int condi = 0;
                while (rdr.Read())
                {
                    condi = Int32.Parse(rdr[0].ToString());
                }
                rdr.Close();
                System.Console.WriteLine(cond);
                string sql = $"INSERT INTO timerDetails (DevCondID,Time,CondID) VALUES({dev},'{tm}',{condi})";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ITimerDetails times = new TimerDetailsControl();
                    times.TimerDetailID = Int32.Parse(rdr[0].ToString());
                    times.DevCondID = Int32.Parse(rdr[1].ToString());
                    times.Time = rdr[2].ToString();
                    times.CondID = Int32.Parse(rdr[3].ToString());
                    timez.Add(times);
                }
                rdr.Close();
                conn.Close();
                return timez;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
                return timez;
            }
        } 

        public void EditTimerDetails(String CondID, String TDCID,String tm){
            try
            {
                conn.Open();
                string sql = "UPDATE timerDetails SET DevCondID = "+TDCID+" , Time = '"+tm+"' WHERE CondID = "+CondID;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                rdr.Close();
                conn.Close();
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
            }
        } 

        public void DeleteTimer(string conditionID){
            try
            {
                conn.Open();
                string sql = "DELETE FROM rule.timerDetails WHERE CondID = " + conditionID;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                rdr.Close();
                conn.Close();
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
            }
        } 

        public List<ITimerDetails> GetAllTimer(){
            try
            {
                conn.Open();
                string sql = $"SELECT * FROM timerDetails";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ITimerDetails times = new TimerDetailsControl();
                    times.TimerDetailID = Int32.Parse(rdr[0].ToString());
                    times.DevCondID = Int32.Parse(rdr[1].ToString());
                    times.Time = rdr[2].ToString();
                    times.CondID = Int32.Parse(rdr[3].ToString());
                    timez.Add(times);
                }
                rdr.Close();
                conn.Close();
                return timez;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
                return timez;
            }
        }
    }
}