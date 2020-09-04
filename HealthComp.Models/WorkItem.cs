using System;
using System.Collections.Generic;

namespace HealthComp.Models
{
    public class WorkItem
    {
        public int WorkItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int EstimatedTimeToCompletionInMinutes { get; set; }
        public List<Activity> Activities = new List<Activity>();
    }
}
