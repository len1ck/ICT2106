using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT2106.Interfaces;

namespace ICT2106.Models.Cameras
{
    public class CameraFactory : ICategoryFactory
    {
        public IGeneralValue setGeneralValue(int actionID, string actionName, string category, int deviceID, string deviceName)
        {
            return new CameraGeneral(actionID, actionName, category, deviceID, deviceName);
        }

        public IPropertyValue setPropertyValues(List<string> propertyList, List<string> propertyName)
        {
            return new CameraValue(propertyList, propertyName);
        }
    }
}
