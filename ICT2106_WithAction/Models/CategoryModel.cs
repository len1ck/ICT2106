using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT2106.Models
{
    public class CategoryModel
    {
        /**
         * Readonly variable - cannot be changed or updated
         * 
         * Contain the list of action category for user to pick from
         */
        private readonly List<string> categoryType = new List<string>
        {
            "Lighting",
            "Camera",
            "Speaker",
            "Security",
            "Air Treatment"
        };

        /**
         * Function to return the whole category list
         *      - Used by to populate the dropdown list
         */
        public List<string> GetAllCategory()
        {
            return categoryType;
        }
    }
}
