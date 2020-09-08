using HealthComp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HeathComp.UnitTests
{
    [TestClass]
    public class UnitTestWorkItems
    {
        [TestMethod]
        public void WorkItemShouldBeDelayedByTenMinutes()
        {
            //arrange
            WorkItem workItem = new WorkItem()
            {
                ItemName = "Activities for developing a work item",
                ItemDescription = "Related activities for an work item",
                EstimatedTimeToCompletionInMinutes = 90,
                WorkItemId = 1,
                Activities = new System.Collections.Generic.List<Activity>
                {
                    new Activity { ActivityId = 1, ActivityName = "Design", TimeToCompleteInMinutes = 20 },
                    new Activity { ActivityId = 1, ActivityName = "Coding", TimeToCompleteInMinutes = 60 },
                    new Activity { ActivityId = 1, ActivityName = "Testing", TimeToCompleteInMinutes = 20 }
                }
            };
            WorkItemStatus workItemStatus = new WorkItemStatus(workItem);

            //act
            int delayOrAdvance = workItemStatus.CalculateDelayOrAdvanceOnEstimateForWorItem();

            //assert, should be -10 that is 10 minutes delayed
            Assert.AreEqual(delayOrAdvance, -10);
        }
    }
}
