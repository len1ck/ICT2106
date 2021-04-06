using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT2106.Interfaces;

namespace ICT2106.Models.Securities
{
    public class SecurityModel: ICategoryPropertyType
    {
        private const string status = "Status";

        /**
         * Functions implemented from ICategory
         * 
         * Used to return the specific properties value as a List that this model contain back to the caller
         */
        public List<string> getCategoryProperties()
        {
            List<string> properties = new List<string>
            {
                status
            };

            return properties;
        }
    }
}
