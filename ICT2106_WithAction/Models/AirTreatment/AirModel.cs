using ICT2106.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT2106.Models.AirTreatment
{
    public class AirModel : ICategoryPropertyType
    {
        private const string status = "Status";
        private const string speed = "Fan Speed";
        private const string pan = "Auto Rotate";

        /**
         * Functions implemented from ICategory
         * 
         * Used to return the specific properties value as a List that this model contain back to the caller
         */
        public List<string> getCategoryProperties()
        {
            List<string> properties = new List<string>
            {
                status,
                speed,
                pan
            };

            return properties;
        }
    }
}
