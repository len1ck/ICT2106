using System;

namespace ICT2106.Models.DevcondTableModule
{
    public interface IDevcond
    {
        String DevCondition {get; set;}
        String DevType {get; set;}
        int CatID{get; set;}
        int DevID{get; set;}
        int DevConID{get; set;}
    }
}