using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT2106.Interfaces
{
    public interface ICreateAction
    {
        void createAction(int actionID, string actionName, string category, List<string> actionPropertiesList, List<string> actionPropertiesName, int deviceID, string deviceName);
    }
}
