using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ICT2106.Interfaces;
using MySql.Data.MySqlClient;

namespace ICT2106.Models
{
    public class ActionGateway : ActionDAO
    {
        public string ConnectionString { get; set; }
        private ICategoryPropertyType _propertyInterface;

        public ActionGateway(string connectionString) =>
            this.ConnectionString = connectionString;

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public int deleteActionFromDB(int id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand delete_cmd = new MySqlCommand("DELETE FROM actionv4 WHERE ruleId = '" + id.ToString() + "';", conn);
                return delete_cmd.ExecuteNonQuery();
            }
        }

        public ActionModel getActionFromDB(int id)
        {
            ActionModel newActionModelObj = new ActionModel();
            int rowCount = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand
                    ("SELECT * from actionv4 LEFT JOIN devices ON actionv4.deviceId = devices.id WHERE actionId = " + id, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (rowCount == 2) break;
                        int actionID = reader.GetInt32("actionId");
                        String actionName = reader.GetString("actionName");
                        String actionCategory = reader.GetString("actionCategory");
                        List<string> actionPropertiesList = reader.GetString("actionPropertiesList").Split(",").ToList();
                        List<string> actionPropertiesName = reader.GetString("actionPropertiesName").Split(",").ToList();
                        int deviceId = reader.GetInt32("id");
                        String deviceName = reader.GetString("name");
                        newActionModelObj.createAction(actionID, actionName, actionCategory, actionPropertiesList,
                            actionPropertiesName, deviceId, deviceName);
                    }
                }
            }

            return newActionModelObj;
        }

        public ActionModel getAllActionFromDBUsingRuleID(int ruleID)
        {
            ActionModel newActionModelObj = new ActionModel();
            int rowCount = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand
                    ("SELECT * from actionv4 LEFT JOIN devices ON actionv4.deviceId = devices.id WHERE ruleId = " + ruleID, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (rowCount == 2) break;
                        int actionID = reader.GetInt32("actionId");
                        String actionName = reader.GetString("actionName");
                        String actionCategory = reader.GetString("actionCategory");
                        List<string> actionPropertiesList = reader.GetString("actionPropertiesList").Split(",").ToList();
                        List<string> actionPropertiesName = reader.GetString("actionPropertiesName").Split(",").ToList();
                        int deviceId = reader.GetInt32("id");
                        String deviceName = reader.GetString("name");
                        newActionModelObj.createAction(actionID, actionName, actionCategory, actionPropertiesList,
                            actionPropertiesName, deviceId, deviceName);
                    }
                }
            }

            return newActionModelObj;
        }

        /*
         * use of left join where matches record from devices all records from actionv4
         */
        public List<ActionModel> getAllActionFromDB()
        {
            List<ActionModel> list = new List<ActionModel>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand
                    ("SELECT * from actionv4 LEFT JOIN devices ON actionv4.deviceId = devices.id", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ActionModel newActionModelObj = new ActionModel();
                        int actionID = reader.GetInt32("actionId");
                        String actionName = reader.GetString("actionName");
                        String actionCategory = reader.GetString("actionCategory");
                        List<string> actionPropertiesList = reader.GetString("actionPropertiesList").Split(",").ToList();
                        List<string> actionPropertiesName = reader.GetString("actionPropertiesName").Split(",").ToList();
                        int deviceId = reader.GetInt32("id");
                        String deviceName = reader.GetString("name");
                        newActionModelObj.createAction(actionID, actionName, actionCategory, actionPropertiesList,
                            actionPropertiesName, deviceId, deviceName);
                        list.Add(newActionModelObj);
                    }
                }
            }

            return list;
        }

        /*
         * return number of affected rows when creating action
         */
        public int saveActionToDB(ActionModel actionmodel, int ruleID)
        {
            String actionPropertiesList_ToString = "";
            foreach (String eachString in actionmodel.ACTIONPROPERTYLIST)
            {
                actionPropertiesList_ToString += eachString + ",";
            }
            actionPropertiesList_ToString = actionPropertiesList_ToString.Remove(actionPropertiesList_ToString.Length - 1, 1);
            actionPropertiesList_ToString = MySQLEscape(actionPropertiesList_ToString);

            String actionPropertiesName_ToString = "";
            foreach (String eachString in actionmodel.ACTIONPROPERTYNAME)
            {
                actionPropertiesName_ToString += eachString + ",";
            }
            actionPropertiesName_ToString = actionPropertiesName_ToString.Remove(actionPropertiesName_ToString.Length - 1, 1);

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand actionv4_cmd = new MySqlCommand("INSERT INTO actionv4" +
                    "(actionName, ruleId, actionCategory, actionPropertiesList, actionPropertiesName, deviceId) VALUES" +
                    " ('" + actionmodel.ACTIONNAME + "', " +
                    "'" + ruleID + "', " +
                    "'" + actionmodel.ACTIONCATEGORY + "', " +
                    "'" + actionPropertiesList_ToString + "', " +
                    "'" + actionPropertiesName_ToString + "', " +
                    "'" + actionmodel.DEVICEID + "'" +
                    ");", conn);
                int actionv4_NoOfAffectedRows = actionv4_cmd.ExecuteNonQuery();
                return actionv4_NoOfAffectedRows;
            }
        }

        /*
         * return number of affected of rows during updating action
         */
        public int updateAction(ActionModel actionmodel)
        {
            string actionPropertiesListToString = "";
            actionPropertiesListToString = actionmodel.ACTIONPROPERTYLIST.Aggregate((x, y) => x + "," + y);
            actionPropertiesListToString = MySQLEscape(actionPropertiesListToString);
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand actionv4_cmd = new MySqlCommand("UPDATE actionv4 SET actionName = '" + actionmodel.ACTIONNAME + "', actionPropertiesList = '" + actionPropertiesListToString + "' WHERE actionId = '" + actionmodel.ACTIONID + "';", conn);
                return actionv4_cmd.ExecuteNonQuery();
            }
        }

        public int updateActionWithRule(ActionModel actionmodel, int ruleID)
        {
            string actionPropertiesListToString = "";
            actionPropertiesListToString = actionmodel.ACTIONPROPERTYLIST.Aggregate((x, y) => x + "," + y);
            actionPropertiesListToString = MySQLEscape(actionPropertiesListToString);
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand actionv4_cmd = new MySqlCommand("UPDATE actionv4 SET actionName = '" + actionmodel.ACTIONNAME + "', actionPropertiesList = '" + actionPropertiesListToString + "' WHERE ruleId = '" + ruleID + "';", conn);
                return actionv4_cmd.ExecuteNonQuery();
            }
        }

        public List<ActionModel> getActionCategoryFromDB(string category)
        {
            if (category == "Lighting")
            {
                _propertyInterface = new Lightings.LightingModel();
            }
            else if (category == "Camera")
            {
                _propertyInterface = new Cameras.CameraModel();
            }
            else if (category == "Security")
            {
                _propertyInterface = new Securities.SecurityModel();
            }
            else if (category == "Speaker")
            {
                _propertyInterface = new Speakers.SpeakerModel();
            }
            else if (category == "Air Treatment")
            {
                _propertyInterface = new AirTreatment.AirModel();
            }
            else
            {
                return null;
            }

            List<string> propertiesName = _propertyInterface.getCategoryProperties();
            List<ActionModel> list = new List<ActionModel>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand
                    ("SELECT DISTINCT actionPropertiesList FROM action.actionv4 WHERE actionCategory = " + "'" + category + "'", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ActionModel newActionModelObj = new ActionModel();
                        List<string> actionPropertiesList = reader.GetString("actionPropertiesList").Split(",").ToList();
                        newActionModelObj.ACTIONPROPERTYLIST = actionPropertiesList;
                        newActionModelObj.ACTIONPROPERTYNAME = propertiesName;
                        newActionModelObj.ACTIONCATEGORY = category;
                        list.Add(newActionModelObj);
                    }
                }
            }
            return list;
        }

        public List<String> getAllDevice_Id_Name_FromDB(string category)
        {
            List<String> device_id_name = new List<String>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand
                    ("SELECT id, name from devices WHERE category = '" + category + "';", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        device_id_name.Add((reader.GetInt32("id")).ToString() + "," + reader.GetString("name"));
                    }
                }
            }

            return device_id_name;


        }

        public string getDeviceByID(int deviceID)
        {
            string deviceName = "";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand
                    ("SELECT name from devices WHERE id = '" + deviceID + "';", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        deviceName = reader.GetString("name");
                    }
                }
            }
            return deviceName;
        }

        private static string MySQLEscape(string str)
        {
            return Regex.Replace(str, @"[\x00'""\b\n\r\t\cZ\\%_]",
                delegate (Match match)
                {
                    string v = match.Value;
                    switch (v)
                    {
                        case "\x00":            // ASCII NUL (0x00) character
                            return "\\0";
                        case "\b":              // BACKSPACE character
                            return "\\b";
                        case "\n":              // NEWLINE (linefeed) character
                            return "\\n";
                        case "\r":              // CARRIAGE RETURN character
                            return "\\r";
                        case "\t":              // TAB
                            return "\\t";
                        case "\u001A":          // Ctrl-Z
                            return "\\Z";
                        default:
                            return "\\" + v;
                    }
                });
        }
    }
}
