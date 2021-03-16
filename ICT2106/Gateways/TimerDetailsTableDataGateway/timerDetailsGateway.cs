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
        public List<ITimerDetails> TimeAdd(String tm){
            try
            {
                conn.Open();
                string sql = $"INSERT INTO timerDetails (DevCondID,Time) VALUES({1},'{tm}')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ITimerDetails times = new TimerDetailsControl();
                    times.TimerDetailID = Int32.Parse(rdr[0].ToString());
                    times.DevCondIDz = Int32.Parse(rdr[1].ToString());
                    times.Time = rdr[2].ToString();
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