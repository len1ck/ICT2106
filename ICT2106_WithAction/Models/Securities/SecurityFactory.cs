using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT2106.Interfaces;

namespace ICT2106.Models.Securities
{
    public class SecurityFactory : ICategoryFactory
    {
        public IGeneralValue setGeneralValue(int actionID, string actionName, string category, int deviceID, string deviceName)
        {
            return new SecurityGeneral(actionID, actionName, category, deviceID, deviceName);
        }

        public IPropertyValue setPropertyValues(List<string> propertyList, List<string> propertyName)
        {
            return new SecurityValue(propertyList, propertyName);
        }
    }
}
