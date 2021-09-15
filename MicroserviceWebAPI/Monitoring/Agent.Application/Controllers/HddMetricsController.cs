using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agent.Application.Controllers
{
    [Route("api/metrics/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        [HttpGet("left/from/{fromTime}/to/{toTime}")]
        public ActionResult GetLeftMetrics([FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            return Ok();
        }
    }
}