using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agent.Application.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        [HttpGet("error-count/from/{fromTime}/to/{toTime}")]
        public ActionResult GetErrorCountMetrics([FromRoute] DateTime fromTime, [FromRoute] DateTime toTime)
        {
            return Ok();
        }
    }
}