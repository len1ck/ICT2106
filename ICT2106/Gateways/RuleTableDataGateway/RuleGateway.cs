using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICT2106.Models;
using ICT2106.Models.RuleTableModule;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ICT2106.Controllers
{
    public class RuleGateway
    {
        private RuleDataSource dataSource;

        //Test DB
        //https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials-sql-command.html
        public List<IRule> DBTest()
        {
            //string connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=rule;port=3306;password=qwerty123";
            string connStr = "server=localhost;user=root;database=ict2106;port=3306;password=";
            List<IRule> RuleList = new List<IRule>();
            List<ICT2106.Models.RuleTableModule.Rule> FromDB = new List<ICT2106.Models.RuleTableModule.Rule>();
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM rule";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Console.WriteLine(rdr[0]+" -- "+rdr[1]);
                    IRule NewRule = new IRule();
                    NewRule.RuleID = Int32.Parse(rdr[0].ToString());
                    NewRule.RuleName = rdr[1].ToString();
                    RuleList.Add(NewRule);
                }
                //rdr.Close();
                return RuleList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return RuleList;
            }

            conn.Close();
            Console.WriteLine("Done.");
            
        }


        
    }
    


}