using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICT2106.Models;
using ICT2106.Models.MotionDetailsModule;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ICT2106.Controllers
{
    public class motionDetailsGateway
    {
        private static string connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=rule;port=3306;password=qwerty123";
        private List<IMotionDetails> motions = new List<IMotionDetails>();
        private MySqlConnection conn = new MySqlConnection(connStr);

         public List<IMotionDetails> InsertMotionDetails(String dev,String HP, String PP){
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
                string sql = $"INSERT INTO motionDetails (DevCondID, HumanPresence, PetPresence,CondID) VALUES({dev},'{HP}','{PP}',{condi})";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                
                while (rdr.Read())
                {
                    IMotionDetails motion = new MotionDetailsControl();
                    motion.MotionDetailID = Int32.Parse(rdr[0].ToString());
                    motion.DevCondID = Int32.Parse(rdr[1].ToString());
                    motion.HumanPresence = rdr[2].ToString();
                    motion.PetPresence = rdr[3].ToString();
                    motion.CondID = Int32.Parse(rdr[1].ToString());
                    motions.Add(motion);
                }
                rdr.Close();
                conn.Close();
                return motions;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
                return motions;
            }
        }   
    }
}