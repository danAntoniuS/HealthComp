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
    [Route("api/workitem")]
    [ApiController]
    public class WorkItemController : ControllerBase
    {
        private readonly IWorkItemManager _workItemManager;
        public WorkItemController(IWorkItemManager workItemManager)
        {
            this._workItemManager = Validator.ThrowIfNull(workItemManager, nameof(workItemManager));
        }

        [HttpPost]
        public ActionResult<WorkItem> CreateWorkItem([FromBody] WorkItem workItem)
        {
            //validation could be done in many ways
            //with framework and/or custom attributes, with Fluent library, etc.
            //when ModelState is invalid it returns atomatically an error to the client
            //here is some custom in the controller validation for brevity, not the best 
            //as encapsulating it some other place is better just as an example
            if(workItem.ItemName == workItem.ItemDescription)
            {
                ModelState.AddModelError(
                    "ItemDescription",
                    "The provided description should be different from the item name.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workItemCreated = this._workItemManager.CreateWorkItem(workItem);

            return CreatedAtRoute(
                                nameof(GetWorkItem),
                                new { workItemId = workItemCreated.WorkItemId },
                                workItemCreated);
        }

        [HttpDelete("{workItemId:int}")]
        public ActionResult DeleteWorkItem(int workItemId)
        {
            bool found = this._workItemManager.DeleteWorkItem(workItemId);
            if (!found)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{workItemId:int}")]
        public ActionResult<WorkItem> GetWorkItem(int workItemId)
        {
            var workItem = this._workItemManager.GetWorkItem(workItemId);
            if(workItem == null)
            {
                return NotFound();
            }
            //real world application we may need to do mapping to a workItemDto
            return Ok(workItem);
        }

        [HttpPut("{workItemId:int}")]
        public ActionResult UpdateWorkItem(int workItemId, [FromBody] WorkItem workItem)
        {
            bool found = this._workItemManager.UpdateWorkItem(workItem);
            if (!found)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
