using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Application.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public ActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime
        )
        {
            return Ok();
        }

        [HttpGet("cluster/from/{fromTime}/to/{toTime}")]
        public ActionResult GetMetricsFromAllCluster(
            [FromRoute] DateTime fromTime,
            [FromRoute] DateTime toTime
        )
        {
            return Ok();
        }
    }
}