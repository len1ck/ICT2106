using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICT2106.Models;
using ICT2106.Models.DevcatTableModule;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ICT2106.Controllers
{
    public class devcatGateway
    {
    private static string connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=rule;port=3306;password=qwerty123";
    private List<IDevcat> CatList = new List<IDevcat>();
    private MySqlConnection conn = new MySqlConnection(connStr);
    public List<IDevcat> GetAllCat(){
        try{
            conn.Open();
            string sql = "SELECT * FROM devcat";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                IDevcat cat = new DevcatControl();
                cat.CatID = Int32.Parse(rdr[0].ToString());
                cat.CatName = rdr[1].ToString();
                CatList.Add(cat);
            }
            rdr.Close();
            conn.Close();
            return CatList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
                return CatList;
            }
        }
    }
}