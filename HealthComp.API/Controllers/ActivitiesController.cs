using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthComp.BusinessLogic.Interfaces;
using HealthComp.Common;
using HealthComp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthComp.API.Controllers
{
    [Route("api/workitem/{workItemId:int}/activity")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        //private readonly IActivityManager _workItemManager;
        public ActivityController()//(IActivityManager _workItemManager)
        {
            //to be added the manager for activities / omitted for brevity, similar to WorkItemManager
            //will show what it is different the configuration for hierarchical resources
        }

        [HttpGet]
        public ActionResult<IEnumerable<Activity>> GetActivities(int workItemId)
        {
           
            return Ok();
        }

        [HttpGet("{activityId:int}", Name = "GetActivity")]
        public ActionResult<Activity> GetActivity(int workItemId, int activityId)
        {
            
            //to avoid compiler error
            return Ok();
        }


        [HttpPost]
        public ActionResult<Activity> CreateActivity(int workItemId,
            [FromBody] Activity activity)
        {

            //return CreatedAtRoute(
            //    nameof(GetActivity),
            //    new { workItemId = workItemId, activityId = Activity.Id },
            //    activityCreated);

            //to avoid errors. to be deleted
            return Ok();
        }

        [HttpPut("{activityId:int}")]
        public ActionResult UpdateActivity(int workItemId, int activityId,
            [FromBody] Activity activity)
        {

            //etc
            return NoContent();
        }

        [HttpDelete("{activityId:int}")]
        public ActionResult DeleteActivity(int workItemId, int activityId,
                    [FromBody] Activity activity)
        {

            //etc
            return NoContent();
        }
    }
}
