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
                    NewCondition.DevID = Int32.Parse(rdr[2].ToString());
                    NewCondition.CName = rdr[3].ToString();
                    NewCondition.Devcon = Int32.Parse(rdr[4].ToString());
                    NewCondition.Devcat=Int32.Parse(rdr[5].ToString());
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

        public void DeleteCondition(string conditionID){
            try
            {
                conn.Open();
                string sql = "DELETE FROM rule.condition WHERE CondID = " + conditionID;
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

        public void EditCondition(string conID,string DevID,string MCName,string CID,string MDCID){
            try
            {
                conn.Open();
                string sql = "UPDATE rule.condition SET DevID = "+DevID+" , CondName = '"+MCName+"' , CatID = "+CID+" , DevCondID = "+MDCID+" WHERE CondID = "+conID;
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

        
       public List<ICondition> addNewCond(int RID, int DID, String CName,String CatID, String DcID ){
            try
            {
                System.Console.WriteLine(DID + " "+CName+" "+CatID+" "+DcID);
                conn.Open();
                string sql = $"INSERT INTO rule.condition (RuleID,DevID,CondName,DevCondID,CatID) VALUES({RID}, {DID},'{CName}',{DcID},{CatID});";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ICondition NewCondition = new ConditionControl();
                    NewCondition.ConditionID = Int32.Parse(rdr[0].ToString());
                    NewCondition.RuleID = Int32.Parse(rdr[1].ToString());
                    NewCondition.DevID = Int32.Parse(rdr[2].ToString());
                    NewCondition.CName = rdr[3].ToString();
                    NewCondition.DName = rdr[4].ToString();
                    NewCondition.CCat = rdr[5].ToString();
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
    }   
}