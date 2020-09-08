using HealthComp.BusinessLogic.Interfaces;
using HealthComp.Common;
using HealthComp.Models;
using HealthComp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthComp.BusinessLogic
{
    public class WorkItemManager : IWorkItemManager
    {
        private readonly IWorkItemRepository _workItemRepository;
        public WorkItemManager(IWorkItemRepository workItemRepository)
        {
            this._workItemRepository = Validator.ThrowIfNull(workItemRepository, nameof(workItemRepository));
        }

        public int CalculateWorkItemDelayOrAdvanceOnEstimateForWorItem(int workItemId)
        {
            WorkItem workItem = this._workItemRepository.GetWorkItem(workItemId);
            WorkItemStatus workItemStatus = new WorkItemStatus(workItem);
            return workItemStatus.CalculateDelayOrAdvanceOnEstimateForWorItem();
        }

        public WorkItem CreateWorkItem(WorkItem workItem)
        {
            //in real life sometimes we have diferent objects between 
            // ui (DTO) , business layer, database layer
            // and use a mapper to translate
            return this._workItemRepository.CreateWorkItem(workItem);
        }

        public bool DeleteWorkItem(int workItemId)
        {
            return this._workItemRepository.DeleteWorkItem(workItemId);
        }

        public WorkItem GetWorkItem(int workItemId)
        {
            return this._workItemRepository.GetWorkItem(workItemId);
        }

        public WorkItem GetWorkItemAndActivities(int workItemId)
        {
            return this._workItemRepository.GetWorkItemAndActivities(workItemId);
        }

        public bool UpdateWorkItem(WorkItem workItem)
        {
            return this._workItemRepository.UpdateWorkItem(workItem);
        }
    }
}
