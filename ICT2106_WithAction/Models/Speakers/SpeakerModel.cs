using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT2106.Interfaces;

namespace ICT2106.Models.Speakers
{
    public class SpeakerModel: ICategoryPropertyType
    {
        private const string status = "Status";
        private const string service = "Music Service";
        private const string playlist = "Play This Playlist";
        private const string song = "Play This Song";
        private const string state = "State";
        private const string volume = "Volume";

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
                service,
                playlist,
                song,
                state,
                volume
            };

            return properties;
        }
    }
}
