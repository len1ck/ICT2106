using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT2106.Interfaces;

namespace ICT2106.Models.Securities
{
    class SecurityGeneral : IGeneralValue
    {
        private int actionID;
        private string actionName;
        private string category;
        private int deviceID;
        private string deviceName;

        public SecurityGeneral(int actionID, string actionName, string category, int deviceID, string deviceName)
        {
            this.actionID = actionID;
            this.actionName = actionName;
            this.category = category;
            this.deviceID = deviceID;
            this.deviceName = deviceName;
        }

        public int getActionID()
        {
            return actionID;
        }

        public string getActionName()
        {
            return actionName;
        }

        public string getCategory()
        {
            return category;
        }

        public int getDeviceID()
        {
            return deviceID;
        }

        public string getDeviceName()
        {
            return deviceName;
        }
    }
}
