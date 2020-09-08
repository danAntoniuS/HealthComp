using HealthComp.Models;
using HealthComp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthComp.Repository
{
    /// <summary>
    /// Mock WorkItem repository for testing
    /// </summary>
    public class WorkItemRepository : IWorkItemRepository
    {
        private static List<WorkItem> workItems = new List<WorkItem>();
        public int maxWorkItemId = 1;

        /// <summary>
        /// //cn not use here illustration for how we configure and pass it through DI 
        /// in case of using Dapper
        /// </summary>
        /// <param name="workItemDBConnectionString"></param>
        public WorkItemRepository(string workItemDBConnectionString)
        {
            
        }
        public WorkItem CreateWorkItem(WorkItem workItem)
        {
            workItem.WorkItemId = maxWorkItemId++;
            workItems.Add(workItem);
            return workItem;
        }

        public bool DeleteWorkItem(int workItemId)
        {
            var item = Find(workItemId);
            if (item != null)
            {
                workItems.Remove(item);
                return true;
            }
            return false;
        }

        public WorkItem GetWorkItem(int workItemId)
        {
            return Find(workItemId);
        }

        public WorkItem GetWorkItemAndActivities(int workItemId)
        {
            var item = Find(workItemId);
            if(item != null)
            {
                //cheating a bit adding activities w/o another list for activities.
                item.Activities = new List<Activity>
                {
                    new Activity{ActivityId=1, ActivityName = "Design", TimeToCompleteInMinutes = 30},
                    new Activity{ActivityId=1, ActivityName = "Coding", TimeToCompleteInMinutes = 60},
                    new Activity{ActivityId=1, ActivityName = "UnitTesting", TimeToCompleteInMinutes = 30}
                };
            }
            return item;
        }

        public bool UpdateWorkItem(WorkItem workItem)
        {
            if (workItem != null)
            {
                int count = workItems.RemoveAll(w => w.WorkItemId == workItem.WorkItemId);
                workItems.Add(workItem);
                return count > 0;
            }
            return false;
        }

        public bool WorkItemExists(int workItem)
        {
            return Find(workItem) != null;
        }

        private WorkItem Find(int workItemId)
        {
            return workItems.Where(w => w.WorkItemId == workItemId).FirstOrDefault();
        }
    }
}
