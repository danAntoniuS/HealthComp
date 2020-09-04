using HealthComp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthComp.Repository.Interfaces
{
    public interface IWorkItemRepository
    {
        WorkItem CreateWorkItem(WorkItem workItem);
        WorkItem GetWorkItem(int workItemId);
        WorkItem GetWorkItemAndActivities(int workItemId);
        bool UpdateWorkItem(WorkItem workItem);
        bool DeleteWorkItem(int workItemId);
    }
}
