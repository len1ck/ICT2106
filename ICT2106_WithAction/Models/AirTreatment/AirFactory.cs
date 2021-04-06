using ICT2106.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT2106.Models.AirTreatment
{
    public class AirFactory : ICategoryFactory
    {
        public IGeneralValue setGeneralValue(int actionID, string actionName, string category, int deviceID, string deviceName)
        {
            return new AirGeneral(actionID, actionName, category, deviceID, deviceName);
        }

        public IPropertyValue setPropertyValues(List<string> propertyList, List<string> propertyName)
        {
            return new AirValue(propertyList, propertyName);
        }
    }
}
