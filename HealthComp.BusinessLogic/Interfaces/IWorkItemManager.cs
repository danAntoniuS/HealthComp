using HealthComp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthComp.BusinessLogic.Interfaces
{
    public interface IWorkItemManager
    {
        WorkItem CreateWorkItem(WorkItem workItem);
        WorkItem GetWorkItem(int workItemId);
        WorkItem GetWorkItemAndActivities(int workItemId);
        bool UpdateWorkItem(WorkItem workItem);
        bool DeleteWorkItem(int workItemId);
    }
}
