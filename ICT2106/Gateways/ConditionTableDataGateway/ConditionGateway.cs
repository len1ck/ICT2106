using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICT2106.Models;
using ICT2106.Models.ConditionTableModule;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ICT2106.Controllers
{
    public class ConditionGateway
    {
        private static string connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=rule;port=3306;password=qwerty123";
        private List<ICondition> ConditionList = new List<ICondition>();
        private MySqlConnection conn = new MySqlConnection(connStr);
        public List<ICondition> GetAllCondition(){
            try
            {
                conn.Open();
                string sql = "SELECT * FROM rule.condition";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ICondition NewCondition = new ConditionControl();
                    NewCondition.ConditionID = Int32.Parse(rdr[0].ToString());
                    NewCondition.RuleID = Int32.Parse(rdr[1].ToString());
                    NewCondition.DeviceID = Int32.Parse(rdr[2].ToString());
                    NewCondition.DetailID = Int32.Parse(rdr[3].ToString());
                    NewCondition.CName = rdr[4].ToString();
                    ConditionList.Add(NewCondition);
                }
                rdr.Close();
                conn.Close();
                return ConditionList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
                return ConditionList;
            }
        }   

        // public List<ICondition> DeleteCondition(ICondition rule){
        //     try
        //     {
        //         conn.Open();
        //         string sql = "DELETE FROM rule.condition WHERE CondID = "+(rule.ConditionID).ToString();
        //         MySqlCommand cmd = new MySqlCommand(sql, conn);
        //         MySqlDataReader rdr = cmd.ExecuteReader();

        //         while (rdr.Read())
        //         {
        //             ICondition NewCondition = new ConditionControl();
        //             NewCondition.ConditionID = Int32.Parse(rdr[0].ToString());
        //             NewCondition.RuleID = Int32.Parse(rdr[0].ToString());
        //             NewCondition.DeviceID = Int32.Parse(rdr[0].ToString());
        //             NewCondition.Status = rdr[1].ToString();
        //             ConditionList.Add(NewCondition);
        //         }
        //         rdr.Close();
        //         conn.Close();
        //         return ConditionList;
        //     }
            
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine(ex.ToString());
        //         conn.Close();
        //         return ConditionList;
        //     }
        // } 

        // public List<ICondition> createCond(ICondition rule){
        //     try
        //     {
        //         conn.Open();
        //         string sql = "INSERT INTO rule.condition (Detail) VALUES('"+(rule.Status).ToString()+"')";
        //         MySqlCommand cmd = new MySqlCommand(sql, conn);
        //         MySqlDataReader rdr = cmd.ExecuteReader();

        //         while (rdr.Read())
        //         {
        //             ICondition NewCondition = new ConditionControl();
        //             NewCondition.ConditionID = Int32.Parse(rdr[0].ToString());
        //             NewCondition.RuleID = Int32.Parse(rdr[0].ToString());
        //             NewCondition.DeviceID = Int32.Parse(rdr[0].ToString());
        //             NewCondition.Status = rdr[1].ToString();
        //             ConditionList.Add(NewCondition);
        //         }
        //         rdr.Close();
        //         conn.Close();
        //         return ConditionList;
        //     }
        //     catch (Exception ex)
        //     {
        //         Console.WriteLine(ex.ToString());
        //         conn.Close();
        //         return ConditionList;
        //     }
        // }   
    }
}