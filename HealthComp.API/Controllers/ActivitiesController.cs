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
        public ActivityController()
        {
            //to be added the manager for activities / omitted for brevity, similar to WorkItemManager
            //will show what it is different the configuration for hierarchical resources
        }

        [HttpGet("{activityId:int}", Name = "GetActivity")]
        public IActionResult GetActivity(int workItemId, int activityId)
        {
            /*
            if (!_workItemRepository.Exists(workItemId))
            {
                return NotFound();
            }

            var activity = get acivities from repo

            if (activity == null)
            {
                return NotFound();
            }

            return Ok(activity);
            */
            //to avoid compiler error
            return Ok();
        }


        [HttpPost]
        public ActionResult<Activity> CreatePointOfInterest(int workItemId,
            [FromBody] Activity activity)
        {


            //ommited similar

            //return CreatedAtRoute(
            //    nameof(GetActivity),
            //    new { workItemId = workItemId, activityId = Activity.Id },
            //    activityCreated);

            //to avoid errors. to be deleted
            return Ok();
        }

        //etc

    }
}
