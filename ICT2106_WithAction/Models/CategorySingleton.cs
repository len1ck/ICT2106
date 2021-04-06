using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT2106.Interfaces;

namespace ICT2106.Models
{
    public class CategorySingleton
    {
        // The instance of this class
        private static CategorySingleton instance = null;

        // Private constructor such that only this class can create it
        private CategorySingleton() { }

        // Get reference to the instance if it exist, else creating it
        public static CategorySingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new CategorySingleton();
            }
            return instance;
        }

        // Create the instance for CategoryFactory
        public ICategoryFactory GetFactory(string category)
        {
            switch (category)
            {
                case "Lighting":
                    return new Lightings.LightingFactory();

                case "Camera":
                    return new Cameras.CameraFactory();

                case "Speaker":
                    return new Speakers.SpeakerFactory();

                case "Security":
                    return new Securities.SecurityFactory();

                case "Air Treatment":
                    return new AirTreatment.AirFactory();

                default:
                    return null;
            }
        }
    }
}
