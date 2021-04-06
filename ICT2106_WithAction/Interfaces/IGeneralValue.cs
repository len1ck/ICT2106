using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT2106.Interfaces
{
    public interface IGeneralValue
    {
        int getActionID();
        string getActionName();
        string getCategory();
        int getDeviceID();
        string getDeviceName();
    }
}
