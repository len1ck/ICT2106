using System;
using System.Collections.Generic;
using ICT2106.Models.DevcatTableModule;
using ICT2106.Models.RuleSingleton;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace ICT2106.Controllers
{
    public class devcatGateway{
    private RuleSingletonModel RS = RuleSingletonModel.getInstance();
    private static string connStr = "server=t2-6.cthtaqebwmpy.us-east-1.rds.amazonaws.com;user=root;database=rule;port=3306;password=qwerty123";
    private MySqlConnection conn = new MySqlConnection(connStr);


    public void GetAllCat(){
        List<IDevcat> CatList = new List<IDevcat>();
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
            RS.Catlist = CatList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                conn.Close();
                RS.Catlist = CatList;
            }
        }
        public IList<IDevcat> SelCat(String cats){
        IList<IDevcat> CatList = new List<IDevcat>();
        try{
            conn.Open();
            string sql = "SELECT CatID FROM devcat WHERE CatID = "+cats;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                IDevcat cat = new DevcatControl();
                cat.CatID = Int32.Parse(rdr[0].ToString());
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