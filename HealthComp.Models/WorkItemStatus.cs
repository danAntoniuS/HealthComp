using HealthComp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthComp.Models
{
    public class WorkItemStatus
    {
        private readonly WorkItem _workItem;
        public WorkItemStatus(WorkItem workItem)
        {
            this._workItem = Validator.ThrowIfNull(workItem, nameof(workItem));
        }

        public int CalculateDelayOrAdvanceOnEstimateForWorItem()
        {
            int estimatedTimeInMinutes = _workItem.EstimatedTimeToCompletionInMinutes;
            int actualTimeInMinutes = ActualTimePerActivitiesInMinutes();
            return estimatedTimeInMinutes - actualTimeInMinutes;
        }

        public int ActualTimePerActivitiesInMinutes()
        {
            return _workItem.Activities.Sum(a => a.TimeToCompleteInMinutes);
        }
    }
}
