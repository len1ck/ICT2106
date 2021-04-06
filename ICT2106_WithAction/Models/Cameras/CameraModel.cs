using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT2106.Interfaces;

namespace ICT2106.Models.Cameras
{
    public class CameraModel: ICategoryPropertyType
    {
        private const string status = "Status";
        private const string angle = "Viewing Angle";
        private const string record = "Recording";
        private const string screenshot = "Take Screenshot";

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
                angle,
                record,
                screenshot
            };

            return properties;
        }
    }
}
