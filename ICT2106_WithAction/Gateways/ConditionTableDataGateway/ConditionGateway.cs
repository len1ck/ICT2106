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
using ICT2106.Models.RuleSingleton;

namespace ICT2106.Controllers
{
    public class ConditionGateway
    {
        //lists SINGLETON
        private RuleSingletonModel RS = RuleSingletonModel.getInstance();
        // SQL Server
        private static string connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=rule;port=3306;password=qwerty123";
        private MySqlConnection conn = new MySqlConnection(connStr);
        public void GetAllCondition(){
            IList<ICondition> ConditionList = new List<ICondition>();
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
                RS.Conditionlist = ConditionList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
                RS.Conditionlist = ConditionList;
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

        
       public void addNewCond(String RID, String DID, String CName,String CatID, String DcID){
           System.Console.WriteLine(RID.ToString()+" "+DID.ToString()+" "+CName+" "+CatID+" "+DcID);
            try
            {
                conn.Open();
                string sql = $"INSERT INTO rule.condition (RuleID,DevID,CondName,DevCondID,CatID) VALUES({RID},{DID},'{CName}',{DcID},{CatID});";
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
    }   
}