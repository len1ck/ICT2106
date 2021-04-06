using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT2106.Interfaces
{
    public interface ICategoryFactory
    {
        IGeneralValue setGeneralValue(int actionID, string actionName, string category, int deviceID, string deviceName);
        IPropertyValue setPropertyValues(List<string> propertyList, List<string> propertyName);
    }
}
