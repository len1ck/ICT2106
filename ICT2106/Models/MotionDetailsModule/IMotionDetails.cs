using System;

namespace ICT2106.Models.MotionDetailsModule
{
    public interface IMotionDetails{
        String PetPresence {get; set;}

        String HumanPresence {get; set;}

        int DevCondIDz {get; set;}

        int MotionDetailID {get; set;}
    }
}