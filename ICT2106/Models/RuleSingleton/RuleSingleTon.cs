using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ICT2106.Models.RuleTableModule;
using ICT2106.Models.ConditionTableModule;
using ICT2106.Models.DevcatTableModule;
using ICT2106.Models.DevcondTableModule;
using ICT2106.Models.MotionDetailsModule;
using ICT2106.Models.TimerDetailsModule;
using ICT2106.Models.RuleSingleton;
using ICT2106.Models;

namespace ICT2106.Models.RuleSingleton
{
    public class RuleSingleton
    {
        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private Singleton() { }

        // The Singleton's instance is stored in a static field. There there are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        private static Singleton _instance;

        //Lists
        private static IList<IRule> rulelist = new List<IRule>();
        private static IList<ICondition> conditionlist = new List<ICondition>();
        private static IList<IDevcat> catlist = new List<IDevcat>();
        private static IList<IDevcond> devlist = new List<IDevcond>();
        private static IList<IMotionDetails> mdlist = new List<IMotionDetails>();
        private static IList<ITimerDetails> tdlist = new List<ITimerDetails>();

        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        public static IList<IRule> Rulelist{
            get{return rulelist;}
            set{rulelist = value;}
        }

        public static IList<ICondition> Conditionlist{
            get{return conditionlist;}
            set{conditionlist = value;}
        }
        public static IList<IDevcat> Catlist{
            get{return catlist;}
            set{catlist = value;}
        }

        public static IList<IDevcond> Devlist{
            get{return devlist;}
            set{devlist = value;}
        }

        public static IList<IMotionDetails> Mdlist{
            get{return mdlist;}
            set{mdlist = value;}
        }

        public static IList<ITimerDetails> Tdlist{
            get{return tdlist;}
            set{tdlist = value;}
        }
    }
}