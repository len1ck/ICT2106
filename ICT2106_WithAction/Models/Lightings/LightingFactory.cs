using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT2106.Interfaces;

namespace ICT2106.Models.Lightings
{
    public class LightingFactory : ICategoryFactory
    {
        public IGeneralValue setGeneralValue(int actionID, string actionName, string category, int deviceID, string deviceName)
        {
            return new LightingGeneral(actionID, actionName, category, deviceID, deviceName);
        }

        public IPropertyValue setPropertyValues(List<string> propertyList, List<string> propertyName)
        {
            return new LightingValue(propertyList, propertyName);
        }
    }
}
