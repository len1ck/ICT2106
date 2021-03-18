using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICT2106.Models;
using ICT2106.Models.DevcondTableModule;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ICT2106.Controllers
{
    public class devcondGateway
    {
    private static string connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=rule;port=3306;password=qwerty123";
    private List<IDevcond> devList = new List<IDevcond>();
    private MySqlConnection conn = new MySqlConnection(connStr);
    public List<IDevcond> GetAllDev(){
        try{
            conn.Open();
            string sql = "SELECT * FROM devcond";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                IDevcond cond = new DevcondControl();
                cond.DevConID = Int32.Parse(rdr[0].ToString());
                cond.DevID = Int32.Parse(rdr[1].ToString());
                cond.CatID = Int32.Parse(rdr[2].ToString());
                cond.DevCondition = rdr[3].ToString();
                cond.DevType = rdr[4].ToString();
                devList.Add(cond);
            }
            rdr.Close();
            conn.Close();
            return devList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
                return devList;
            }
        }
    }
}