using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT2106.Interfaces;

namespace ICT2106.Models.AirTreatment
{
    class AirValue : IPropertyValue
    {
        private List<string> propertyList;
        private List<string> propertyName;

        public AirValue(List<string> propertyList, List<string> propertyName)
        {
            this.propertyList = propertyList;
            this.propertyName = propertyName;
        }

        public List<string> getPropertyList()
        {
            return propertyList;
        }

        public List<string> getPropertyName()
        {
            return propertyName;
        }
    }
}
