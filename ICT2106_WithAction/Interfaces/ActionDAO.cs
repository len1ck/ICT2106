using ICT2106.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICT2106.Interfaces
{
    public interface ActionDAO
    {
        int deleteActionFromDB(int ruleID);
        int saveActionToDB(ActionModel actionmodel, int ruleID);
        int updateAction(ActionModel actionmodel);
        int updateActionWithRule(ActionModel actionmodel, int ruleID);
        List<ActionModel> getAllActionFromDB();
        ActionModel getActionFromDB(int id);
        ActionModel getAllActionFromDBUsingRuleID(int ruleID);
        List<ActionModel> getActionCategoryFromDB(string category);
    }
}
