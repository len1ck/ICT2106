using System;
namespace ICT2106.Models.TimerDetailsModule
{
    public interface ITimerDetails{
        String Time {get; set;}

        int DevCondID {get; set;}

        int TimerDetailID {get; set;}
    }
}