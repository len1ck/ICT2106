using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT2106.Interfaces;

namespace ICT2106.Models.Lightings
{
    public class LightingModel: ICategoryPropertyType
    {
        private const string status = "Status";
        private const string brightness = "Brightness";
        private const string color = "Color";

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
                brightness,
                color
            };

            return properties;
        }

        public void qwe()
        {
            Console.WriteLine("qwe");
        }
    }
}
