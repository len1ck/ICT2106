using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT2106.Interfaces;

namespace ICT2106.Models.Speakers
{
    class SpeakerValue : IPropertyValue
    {
        private List<string> propertyList;
        private List<string> propertyName;

        public SpeakerValue(List<string> propertyList, List<string> propertyName)
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
