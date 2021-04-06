using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ICT2106.Models;

namespace ICT2106.Interfaces
{
    public interface IAction
    {
        ActionModel getActionInstance();
    }
}
