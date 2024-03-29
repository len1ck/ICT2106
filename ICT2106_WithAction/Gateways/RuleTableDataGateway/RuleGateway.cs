using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICT2106.Models;
using ICT2106.Models.RuleTableModule;
using ICT2106.Models.RuleSingleton;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ICT2106.Controllers
{
    public class RuleGateway
    {
        private RuleSingletonModel RS = RuleSingletonModel.getInstance();
        private static string connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=rule;port=3306;password=qwerty123";
        private MySqlConnection conn = new MySqlConnection(connStr);
        
        public void GetAllRules(){
            IList<IRule> RuleList = new List<IRule>();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM rule";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    IRule NewRule = new RuleControl();
                    NewRule.RuleID = Int32.Parse(rdr[0].ToString());
                    NewRule.RuleName = rdr[1].ToString();
                    RuleList.Add(NewRule);
                }
                rdr.Close();
                conn.Close();
                RS.Rulelist =  RuleList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
                RS.Rulelist = RuleList;
            }
        }   

        public void RuleDelete(String ruleID){
            try
            {
                conn.Open();
                string sql = "DELETE FROM rule WHERE RuleID = "+ruleID;
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

        
        public void RuleEdit(String ruleID, String ruleName){
            try
            {
                conn.Open();
                string sql = "UPDATE rule SET RuleName = '"+ruleName+"' WHERE RuleID = "+ruleID;
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

        public int RuleAdd(String ruleName){
            try
            {
                conn.Open();

                string sql = "INSERT INTO rule (RuleName) VALUES('"+(ruleName).ToString()+"')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();
                rdr.Close();

                sql = "SELECT MAX(RuleID) FROM rule.rule";
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                int rid = 0;
                while (rdr.Read())
                {
                    rid = Int32.Parse(rdr[0].ToString());
                }
                rdr.Close();

                conn.Close();
                return rid;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
                return 0;
            }
        }   
    }
}