using System;

namespace ICT2106.Models.MotionDetailsModule
{
    public interface IMotionDetails{
        String PetPresence {get; set;}

        String HumanPresence {get; set;}

        int CondID {get; set;}

        int DevCondID {get; set;}

        int MotionDetailID {get; set;}
    }
}