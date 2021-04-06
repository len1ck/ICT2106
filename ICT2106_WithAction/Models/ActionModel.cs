using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT2106.Interfaces;

namespace ICT2106.Models
{
    public class ActionModel : IAction, ICreateAction
    {
        private ActionGateway context;

        private int actionID;
        private string actionName;
        private string actionCategory;
        private List<string> actionPropertiesList;
        private List<string> actionPropertiesName;
        private int deviceID;
        private string deviceName;

        public int ACTIONID
        {
            get { return this.actionID; }
            set { this.actionID = value; }
        }

        public string ACTIONNAME
        {
            get { return this.actionName; }
            set { this.actionName = value; }
        }

        public string ACTIONCATEGORY
        {
            get { return this.actionCategory; }
            set { this.actionCategory = value; }
        }

        public List<string> ACTIONPROPERTYLIST
        {
            get { return this.actionPropertiesList; }
            set { this.actionPropertiesList = value; }
        }

        public List<string> ACTIONPROPERTYNAME
        {
            get { return this.actionPropertiesName; }
            set { this.actionPropertiesName = value; }
        }

        public int DEVICEID
        {
            get { return this.deviceID; }
            set { this.deviceID = value; }
        }

        public string DEVICENAME
        {
            get { return this.deviceName; }
            set { this.deviceName = value; }
        }

        // Creating the actionmodel (Pass value to an actionmodel and returning it)
        public void createAction(int actionID, string actionName, string category, List<string> actionPropertiesList, List<string> actionPropertiesName, int deviceID, string deviceName)
        {
            ACTIONID = actionID;
            ACTIONNAME = actionName;
            ACTIONCATEGORY = category;
            ACTIONPROPERTYLIST = actionPropertiesList;
            ACTIONPROPERTYNAME = actionPropertiesName;
            DEVICEID = deviceID;
            DEVICENAME = deviceName;
        }

        // Return an empty instance of ActionModel
        public ActionModel getActionInstance()
        {
            return new ActionModel();
        }
    }
}
